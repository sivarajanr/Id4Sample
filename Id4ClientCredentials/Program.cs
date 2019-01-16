using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Id4ClientCredentials
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
            /*var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError) throw new Exception(disco.Error);*/
            //var tokenClient = new TokenClient("http://localhost:5000/connect/token", "client", "secret");
            //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            var client = new HttpClient();
            var tokenResponse = await client.RequestTokenAsync(new TokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                GrantType =  OidcConstants.GrantTypes.ClientCredentials,

                ClientId = "client",
                ClientSecret = "secret",

                Parameters =
                {
                    { "scope", "api1" }
                }
            });
            

            

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);


            //var client = new HttpClient();
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
    }
}
