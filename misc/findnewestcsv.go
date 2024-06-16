package main

import (
	"fmt"
	"io/ioutil"
	"os"
	"path/filepath"
	"sort"
	"strings"
	"time"
)

type file struct {
	name    string
	modTime time.Time
}

func main() {
	// Get the home directory of the current user
	homeDir, err := os.UserHomeDir()
	if err != nil {
		fmt.Println(err)
		return
	}

	// Construct the path to the Downloads folder
	downloadsDir := filepath.Join(homeDir, "Downloads")

	// List the files in the Downloads folder
	files, err := ioutil.ReadDir(downloadsDir)
	if err != nil {
		fmt.Println(err)
		return
	}

	// Create a slice of file structs to store the file information
	var fileList []file

	// Iterate over the files and get their last access times
	for _, f := range files {
		filePath := filepath.Join(downloadsDir, f.Name())
		fi, err := os.Stat(filePath)
		if err != nil {
			fmt.Println(err)
			continue
		}

		modTime := fi.ModTime()
		fileList = append(fileList, file{name: f.Name(), modTime: modTime})
	}

	// Sort the files by last access time, most recent first
	sort.Slice(fileList, func(i, j int) bool {
		return fileList[i].modTime.After(fileList[j].modTime)
	})

	// Print newest file that matches the pattern Holds*.csv, which is
	// the format of the Holds file downloaded from Koha.
	var filename string
	for _, f := range fileList {
		if strings.HasPrefix(f.name, "Hold") && strings.HasSuffix(f.name, ".csv") {
			filename = f.name
			break
		}
	}
	fmt.Println(filename)
}
