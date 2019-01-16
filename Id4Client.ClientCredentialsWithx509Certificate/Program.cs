
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Id4Client.ClientCredentialsWithX509Certificate
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            var token = GenerateToken();



            /*var certPath = Path.Combine(@"C:\siva\samples\Id4Sample\Cert\CA.pfx");
            var cert = new X509Certificate2(certPath);
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);
            var client = new HttpClient(handler);
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "cc.client1",
                Parameters =
                {
                    {"scope", "api1"}
                }
            });

            




            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);


            client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:55423/api/values");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
            */



        }

        public static string GenerateToken()
        {
            X509Certificate2 signingCert = new X509Certificate2(@"C:\siva\samples\Id4Sample\Cert\CA.pfx");
            X509SecurityKey privateKey = new X509SecurityKey(signingCert);
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = now.AddMinutes(Convert.ToInt32(1)),
                SigningCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.Sha256)
            };
            JwtSecurityToken stoken = (JwtSecurityToken) tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(stoken);
            return token;

        }
    }
}