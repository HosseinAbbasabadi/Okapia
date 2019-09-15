using System;
using System.Net.Http;
using IdentityModel.Client;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("");
            Console.WriteLine("Hello World!");
        }
    }
}
