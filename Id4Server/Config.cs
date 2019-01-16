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
                            Value = "MIIC8DCCAdigAwIBAgIJAJMatQ7PceALMA0GCSqGSIb3DQEBDQUAMA0xCzAJBgNV\r\nBAYTAlVTMB4XDTE4MDgxNzA2MTE1NloXDTIxMDUxMzA2MTE1NlowDTELMAkGA1UE\r\nBhMCVVMwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCdcXZjVEHIDfQL\r\nZbYQUjV3/FrmjS7jx6kjRicGvK0edpEzIToEsAkJ1gEuoHBK4ccrTFokbrVW+Ss4\r\n3TZcqP6fCUigzLQ//8DvopaBQdK0LuCosn6XgLQoUUz+l8hzhvS9xsJfsk+Sjb4g\r\nw8BfKMMySU0VlZmLWiUL+i0jBu+MGZkjSkb4TpaH/fkfoj/EiY7NIoD0ZBhTkF4E\r\nD8eqKmhgKH9z3qgk+nIitaDEib1sZU4HfKEHMjsIameZWzWiQLKDFYMzp11SA4rF\r\nWTVfZzndunTsTQZLn8nQbU0uFW3Ap7TBsfhGucAxe2108l64Cu7mirYv8WXsrdDn\r\nA4LYhiy9AgMBAAGjUzBRMB0GA1UdDgQWBBRPgrkaQ4Wr/dvu2CFrpyETal9eVjAf\r\nBgNVHSMEGDAWgBRPgrkaQ4Wr/dvu2CFrpyETal9eVjAPBgNVHRMBAf8EBTADAQH/\r\nMA0GCSqGSIb3DQEBDQUAA4IBAQCbkDpQyM6C5K9Chz5OVo14eY1MoU673B9gtHNt\r\nPoklUVoRtWcv4yXRDpnNY1u+mppP9wk72AegCDdGZ54BpAsghZxSAAPEj6njIcV6\r\np33ys5OvtbJRAD++a2wNM5l3gDNsiW40T/szUgYjZPWElvhoZs6cNdsuPlT2ZevY\r\nBy9t7yRNKUXdbVacw1CHp9FHOUppuk82ce2rao9bJEBgXY85MPWGo3Tnk3eAP68S\r\nWnxqOCqgLTqcGKVhUtxHQkr4XB2wyjMR2fWc8tmRhEKXXTHQDTDTfCn9XouWqa7Q\r\nash5smDLGxA5fzSBK4cuCsXmx0d9pXcI8ySG7hcwKa909OwY"
                        }
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" },
                    AllowOfflineAccess =  true
                    
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
