using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PrintHold
{
    public class Listener
    {
        public const string EndOfData = "\u0017";

        public void StartListening() {
            int port = 3250;
            TcpListener server = new TcpListener(IPAddress.Any, port);

            try {
                // Start listening for client requests
                server.Start();
                Program.FormMain.printImpl.ShowMsg($"Server started on port {port}. Waiting for a connection...");

                // Enter the listening loop
                while (true) {
                    // Perform a blocking call to accept requests
                    // You could also use server.AcceptTcpClientAsync() for non-blocking
                    TcpClient client = server.AcceptTcpClient();
                    Program.FormMain.printImpl.ShowMsg("Connected!");


                    // Start a new thread for the connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            } catch (SocketException e) {
                Program.FormMain.printImpl.ShowMsg($"SocketException: {e}");
            } finally {
                // Stop listening for new clients
                server.Stop();
            }
        }

        static void HandleClient(object obj) {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = null;

            try {
                stream = client.GetStream();
                byte[] buffer = new byte[256]; // Buffer for reading data
                int numberOfBytesRead;

                string allData = "";
                // Loop to receive all the data sent by the client
                while ((numberOfBytesRead = stream.Read(buffer, 0, buffer.Length)) != 0) {
                    allData += Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                    int idx = allData.IndexOf(EndOfData);
                    string data;
                    if (idx >= 0) {
                        data = allData.Substring(0, idx);
                        Program.FormMain.printImpl.ShowMsg($"Received: {data}");
                        allData = allData.Substring(idx + 1);
                        string reply = Program.FormMain.printImpl.PrintFromJson(data);
                        reply += EndOfData;
                        // Enable this when the client is ready to read our reply.
                        if (false) {
                            byte[] msg = Encoding.UTF8.GetBytes(reply);
                            stream.Write(msg, 0, msg.Length);
                        }
                    }
                }
            } catch (Exception e) {
                Program.FormMain.printImpl.ShowMsg($"Exception: {e.Message}");
            } finally {
                // Shutdown and end connection
                stream?.Close();
                client?.Close();
            }
        }
    }
}
