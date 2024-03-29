﻿using Duende.IdentityServer.Models;

namespace UdemyIdentityServer4.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1")
                {
                    Scopes = { "api1.read", "api1.write" , "api1.update" },
                    ApiSecrets = new[]{new Secret("secretapi1".Sha256())}
                },
                new ApiResource("resource_api2")
                {
                    Scopes = { "api2.read", "api2.write" , "api2.update" },
                    ApiSecrets = new[]{new Secret("secretapi2".Sha256())}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","Api 1 için okuma izni"),
                new ApiScope("api1.write","Api 1 için yazma izni"),
                new ApiScope("api1.update","Api 1 için güncelleme izni"),
                new ApiScope("api2.read","Api 2 için okuma izni"),
                new ApiScope("api2.write","Api 2 için yazma izni"),
                new ApiScope("api2.update","Api 2 için güncelleme izni")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId = "Client1",
                    ClientName = "Client1 app uygulaması",
                    ClientSecrets = new  []{new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new []{ "api1.read"}
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client2 app uygulaması",
                    ClientSecrets = new  []{new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new []{ "api1.read", "api1.update", "api2.write","api2.update"}
                }
            };
        }
    }
}
