using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Test;

namespace Id4Server
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "cc.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "cc.client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //RequireClientSecret = false,
                    ClientSecrets =
                    {
                        new Secret
                        {
                            Type = IdentityServerConstants.SecretTypes.X509CertificateBase64,
                            Value = "MIIDGDCCAgCgAwIBAgIQy3SHsm/3iIlBA3fWt289dTANBgkqhkiG9w0BAQ0FADAYMRYwFAYDVQQD\r\nEw1NeUNlcnRpZmljYXRlMB4XDTE5MDExODA3MTY0OVoXDTM5MTIzMTIzNTk1OVowGDEWMBQGA1UE\r\nAxMNTXlDZXJ0aWZpY2F0ZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANhy6pFyapki\r\nWc96UfpSL6pqoLE2cQW7nW8wi3B+YTCO+neBmWWXvZEbvhUM6goTuQOta1vHcGBb/61ByGbpmFkA\r\noTiLyPBBjMbk1jixXVuf/LNZlLznC9EmCSOVtFKDq4xqNz23T4eRI/S+hIwyJEkLHyvwydda7Jgg\r\nZOPe+gYIY9VLxCWWjY1lnt0/jbHBVazumRI0Pwmd5p9ZloyTOV+RQuHVThFVpbppIu9LGU/MeIe0\r\n6DbSQddSdVyor+T6aXI9axHfCEI/N6U0EUrTaRGYTXXhxaWQsnQu6Qq6ZAzjAEzla9jSdHQyxRrw\r\nf3OgYOv+Doh8jjGXula+Y1X8FEUCAwEAAaNeMFwwDwYDVR0TAQH/BAUwAwEB/zBJBgNVHQEEQjBA\r\ngBAYhaOEzWCKUa8RIJIdwedSoRowGDEWMBQGA1UEAxMNTXlDZXJ0aWZpY2F0ZYIQy3SHsm/3iIlB\r\nA3fWt289dTANBgkqhkiG9w0BAQ0FAAOCAQEALsEvhO9l7bo7pasYfCWi7VDGsaxp189z/wkEmRT2\r\nBI7B9ibQwRar2g28npDZBnKIrTS8Q1HlIg1o8O2WJQxdnGYIgWhVSqri9mLUsGN1cIZ2KP9jjfuF\r\nbFRt9h6j38VpJovNwiRlLgEHioM2aCathjJJ/5obJB8a3d2iha076raCZGiGc6fbEgF8wJeJFBLj\r\nUecPpK7Wxtp7bj1oDXaAJ2YXPnobFk0y7r25uruXE7MhRGq8UfkI9ST4lGqsyd5Qs/17NuK8hK4e\r\nN06O52edwNTeBGMvDkY9kILTmpO+xxc8T+3vyNI4ESxmbRnYRmThT12y0JgWGEzySquUWKGj6Q==" // Make Cert Base64
                        }
                    },
                    
                    // scopes that client has access to
                    AllowedScopes = { "api1" },
                    //AllowOfflineAccess =  true
                    
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
