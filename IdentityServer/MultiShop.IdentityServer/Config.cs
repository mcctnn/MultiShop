// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
            {
                new ApiResource("ResourceCatalog")
                {
                    Scopes = { "CatalogFullPermission","CatalogReadPermission"}
                },
                new ApiResource("ResourceDiscount")
                {
                    Scopes = { "DiscountFullPermission"}
                },
                new ApiResource("ResourceOrder")
                {
                    Scopes = { "OrderFullPermission"}
                },
                new ApiResource("ResourceCargo")
                {
                    Scopes={"CargoFullPermission","CargoReadPermission" }
                },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission", "Full permission to catalog API"),
                new ApiScope("CatalogReadPermission", "Read permission to catalog API"),
                new ApiScope("DiscountFullPermission", "Full permission to discount API"),
                new ApiScope("OrderFullPermission", "Full permission to order API"),
                new ApiScope("CargoFullPermission", "Full permission to cargo API"),
                new ApiScope("CargoReadPermission", "Read permission to cargo API"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>


            new Client[]
            {
                //visitor
                new Client
                {
                    ClientId="MultiShopVisitorId",
                    ClientName="MultiShop Visitor Name",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("multishopsecret".Sha256())},
                    AllowedScopes = { "CatalogReadPermission","CargoReadPermission"}
                },

                //manager
                new Client
                {
                    ClientId="MultiShopManagerId",
                    ClientName="MultiShop Manager Name",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("multishopsecret".Sha256())},
                    AllowedScopes = {"CatalogFullPermission","CargoFullPermission" }
                },

                //admin
                new Client
                {
                    ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission","DiscountFullPermission","CargoFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
                }
            };

    }
}