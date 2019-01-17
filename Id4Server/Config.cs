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
                            Value = "MIIDGDCCAgCgAwIBAgIQkfdY4CvfHaJKR5EtFelrRDANBgkqhkiG9w0BAQ0FADAYMRYwFAYDVQQDEw1NeUNlcnRpZmljYXRlMB4XDTE5MDExNjIyMjQ1MFoXDTM5MTIzMTIzNTk1OVowGDEWMBQGA1UEAxMNTXlDZXJ0aWZpY2F0ZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKvqKdDxcfMRXLgDrYPMjO/hr5gOiRwdrQ0PYzu26mHVZr5N2LraeQbm5w9ARAhndu9A5M2oL22CugXkI+up3PY1VVs5MlHOzLebu4hYC3qVyKhLZIAxeZz+wa1y6e/tS5y8la48as/IiYSR6GVEM9MERbkpza8GgJdDhz2DpG1uMklXjZAZ7uXeOESQndC8kxrBuV5lSm/PUzqRZTzSTBZI5TXCE9UqqDS28t0MRHW22jODWc8ksGZOS9pxWJUtdR0dlVj2dyDnSmBjhtbHGxNXXzSg/ZQqS+qba1apw6oRxjjEqd3st8+Kn5axD2Fz0RiY3OLFHK4ggEeEzRYcM50CAwEAAaNeMFwwDwYDVR0TAQH/BAUwAwEB/zBJBgNVHQEEQjBAgBA9FOROXMIuTKzyx9Q/nbecoRowGDEWMBQGA1UEAxMNTXlDZXJ0aWZpY2F0ZYIQkfdY4CvfHaJKR5EtFelrRDANBgkqhkiG9w0BAQ0FAAOCAQEAnpDdk/OhGh9r6xYJq0ch37UKU0R6DH8usNqZU5n/vnvkxvHyXp/k9WRExFul+fSydGzU+3Jva40NAi/w06iwvMrY1X2hNprvbqtyZILr9pvIBmHNAlDdX+4JEsrcV3BJmsPMJ8Uw3Y+ZaljTi0d01wHQk7q23ja0g7Xnq5w/j7MPe1agcSNBpmWPS2wFHRxvbw55BFlRBZWjiHQ7y3yKjjvWy5igdRmfzkUMqzJW4kC2tJUW2M8uCI+FLSic/U0KySlxopq2EhA2I9MXdYXtelVVBG2LsOU7kse/U9q/GtKKyN6APYB2XBebjjeXpGngMxBet36iJ8mVnJJQ8rquaw=="
                        }
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" },
                    //AllowOfflineAccess =  true
                    
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
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
