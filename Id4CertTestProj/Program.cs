using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Id4CertTestProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var certPath = Path.Combine(@"C:\Users\Manoj TS\Desktop\Certificates\makecert\CA.pfx");
            //var certPath = Path.Combine(@"C:\siva\samples\Id4Sample\Cert\CA.pfx");
            var cert = new X509Certificate2(certPath);

            var handler = new WebRequestHandler();
            handler.ClientCertificates.Add(cert);
            
            var client = new HttpClient(handler);

            var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "cc.client1",
                Scope = "api1"
            }).GetAwaiter().GetResult();

            
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }
    }
}
