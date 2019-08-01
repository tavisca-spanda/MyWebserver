using System;
using System.IO;
using System.Net;

namespace MyWebserver
{
    public class WebServer
    {

        public WebServer(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
            HttpListener Listener = new HttpListener();
            foreach (string s in prefixes)
            {
                Listener.Prefixes.Add(s);
            }
            Listener.Start();
            while (Listener.IsListening)
            {
                Console.WriteLine("Server is listening");
                HttpListenerContext context = Listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            
            Listener.Stop();

        }
    }
}
