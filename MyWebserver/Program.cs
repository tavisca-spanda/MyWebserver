using System;

namespace MyWebserver
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] prefixes = new String[] { "http://localhost:8080/test/" };
            WebServer webserver = new WebServer(prefixes);
            Console.WriteLine("Server is listening");
            Console.ReadKey();


        }
    }
}
