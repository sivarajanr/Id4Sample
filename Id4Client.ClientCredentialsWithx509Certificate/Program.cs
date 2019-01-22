
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
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                GrantType = OidcConstants.GrantTypes.ClientCredentials,
                ClientId = "cc.client1",
                Scope = "api1",

                ClientAssertion = new ClientAssertion
                {
                    Type = OidcConstants.ClientAssertionTypes.JwtBearer,
                    Value = CreateClientAuthJwt()
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
        }
        

        private static string CreateClientAuthJwt()
        {
            // set exp to 5 minutes
            var tokenHandler = new JwtSecurityTokenHandler { TokenLifetimeInMinutes = 5 };
            var certPath = @"..\..\..\cert\CA.pfx";
            var securityToken = tokenHandler.CreateJwtSecurityToken(
                // iss must be the client_id of our application
                issuer: "cc.client1",
                // aud must be the identity provider (token endpoint)
                audience: "http://localhost:5000/connect/token",
                // sub must be the client_id of our application
                subject: new ClaimsIdentity(
                    new List<Claim> { new Claim("sub", "cc.client1") }),
                // sign with the private key (using RS256 for IdentityServer)
                signingCredentials: new SigningCredentials(
                    new X509SecurityKey(new X509Certificate2(certPath)), "RS256")
            );

            return tokenHandler.WriteToken(securityToken);
        }
    }
}