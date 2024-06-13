// senditemskoha.go - Send the CSV-formatted hold items to our holds website.
// It's presumed that we've downloaded the holds file from Koha and
// it's in the user's Downloads directory with a filename like Holds*.csv.
//
// Conceptually similar to senditems.py from 2023-07-07, but written in Go
// for ease of deployment.
// Mark Riordan  2024-06-12

package main

import (
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
	"net/url"
	"os"
	"path/filepath"
	"regexp"
	"sort"
	"strconv"
	"strings"
	"time"
)

type file struct {
	name    string
	modTime time.Time
}

// Post the items to the website.
// password: The password to access the website.
// items:    The items to post to the website, in CSV format.
// Return the response from the website.
func postToWebsite(urlStr string, password string, items string) string {
	//escapedItems := url.QueryEscape(items)
	formData := url.Values{
		"password": {password},
		"items":    {items},
	}
	resp, err := http.PostForm(urlStr, formData)
	if err != nil {
		log.Fatalln(err)
	}
	defer resp.Body.Close()

	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		log.Fatalln(err)
	}

	responseBody := string(body)
	return responseBody
}

// Return the newest file in the Downloads folder that matches the pattern Holds*.csv.
func findNewestCSV() string {
	filename := ""
	for {
		// Get the home directory of the current user
		homeDir, err := os.UserHomeDir()
		if err != nil {
			fmt.Println(err)
			break
		}

		// Construct the path to the Downloads folder
		downloadsDir := filepath.Join(homeDir, "Downloads")

		// List the files in the Downloads folder
		files, err := ioutil.ReadDir(downloadsDir)
		if err != nil {
			fmt.Println(err)
			break
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

		// Select the newest file that matches the pattern Holds*.csv, which is
		// the format of the Holds file downloaded from Koha.
		for _, f := range fileList {
			if strings.HasPrefix(f.name, "Hold") && strings.HasSuffix(f.name, ".csv") {
				filename = filepath.Join(downloadsDir, f.name)
				break
			}
		}
		break
	}
	return filename
}

// Return the contents of a file as a string, else "" if the file cannot be read.
// It's assumed that the file won't be empty.
func readFile(filename string) string {
	contents := ""
	data, err := ioutil.ReadFile(filename)
	if err != nil {
		log.Fatalln(err)
	} else {
		contents = string(data)
	}
	return contents
}

// Parse the response from the website to get the number of items loaded.
func parseLoadedItemsCount(responseBody string) int {
	re := regexp.MustCompile(`Loaded (\d+) items`)
	matches := re.FindStringSubmatch(responseBody)

	if len(matches) < 2 {
		log.Fatalln("Could not find 'Loaded X items' message in response")
	}

	loadedItems, err := strconv.Atoi(matches[1])
	if err != nil {
		log.Fatalln(err)
	}

	return loadedItems
}

// Report the messages from the response body.
func reportMessagesFromResponse(responseBody string) {
	re := regexp.MustCompile(`(?s)<pre>(.*?)</pre>`)
	matches := re.FindAllStringSubmatch(responseBody, -1)

	for _, match := range matches {
		if len(match) > 1 {
			fmt.Println(match[1])
		}
	}
}

func main() {
	filename := findNewestCSV()
	for {
		if filename == "" {
			fmt.Println("No Holds CSV file found")
			break
		}
		fmt.Println("Found file:", filename)
		contents := readFile(filename)
		if contents == "" {
			fmt.Println("Cannot read file")
			break
		}
		url := "http://scopehustler.net/sedlibkoha/loaditems.php"
		//url := "http://localhost/~mrr/sedlibkoha/loaditems.php"
		response := postToWebsite(url, "se", contents)
		//fmt.Println(response)
		reportMessagesFromResponse(response)
		// loadedItems := parseLoadedItemsCount(response)
		// fmt.Println("Loaded", loadedItems, "items")
		break
	}
}
