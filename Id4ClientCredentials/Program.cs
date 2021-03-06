﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Id4Client.ResourceOwner
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
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "ro.client",
                ClientSecret = "secret",
                Parameters =
                {
                    { "scope", "api1" }
                },
                UserName = "alice",
                Password = "password"
            });
            
            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
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
