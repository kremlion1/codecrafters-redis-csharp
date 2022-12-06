using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
var server = new TcpListener(IPAddress.Any, 6379);
server.Start();
while (true)
{
    var socket = server.AcceptSocket(); // wait for client
    const string response = "+PONG\r\n";
    var bytes = Encoding.ASCII.GetBytes(response);
    socket.Send(bytes);
    socket.Close();
}
