﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel.AspNet.OAuth2Introspection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public class IdentityServerAuthenticationOptions : AuthenticationOptions
    {
        public IdentityServerAuthenticationOptions()
        {
            AuthenticationScheme = "Bearer";
        }

        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; } = true;

        public SupportedTokens SupportedTokens { get; set; } = SupportedTokens.Both;
        public Func<HttpRequest, string> TokenRetriever { get; set; } = TokenRetrieval.FromAuthorizationHeader();

        public string ScopeName { get; set; }
        public string ScopeSecret { get; set; }
        public IEnumerable<string> AdditionalScopes { get; set; } = Enumerable.Empty<string>();

        public string NameClaimType { get; set; } = "name";
        public string RoleClaimType { get; set; } = "role";

        public bool SaveTokens { get; set; } = false;

        public HttpMessageHandler JwtBackChannelHandler { get; set; }
        public HttpMessageHandler IntrospectionBackChannelHandler { get; set; }
        public HttpMessageHandler IntrospectionDiscoveryHandler { get; set; }
        public TimeSpan BackChannelTimeouts { get; set; } = TimeSpan.FromSeconds(60);
    }
}