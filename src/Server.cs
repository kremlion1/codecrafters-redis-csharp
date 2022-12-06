using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
var server = new TcpListener(IPAddress.Any, 6379);
server.Start();
const string response = "+PONG\r\n";
var responseBytes = Encoding.ASCII.GetBytes(response);


var client = server.AcceptTcpClient(); // wait for client
var stream = client.GetStream();

var buffer = new byte[256];
while (stream.Read(buffer, 0, buffer.Length) != 0)
{
    stream.Write(responseBytes);
}

client.Close();