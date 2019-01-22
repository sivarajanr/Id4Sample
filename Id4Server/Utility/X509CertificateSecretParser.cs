using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.Extensions.Logging;

namespace Id4Server.Utility
{
    public class X509CertificateSecretParser : ISecretParser
    {
        private readonly ILogger _Logger;
        private readonly IdentityServerOptions _Options;

        public X509CertificateSecretParser(IdentityServerOptions options, ILogger<X509CertificateSecretParser> logger)
        {
            _Options = options;
            _Logger = logger;
        }

        #region Implementation of ISecretParser

        public string AuthenticationMethod => "ClientCertificate";

        public Task<ParsedSecret> ParseAsync(HttpContext context)
        {
            _Logger.LogDebug("Start parsing for X.509 certificate");

            var certificate = context.Connection.ClientCertificate;

            if (certificate == null)
            {
                _Logger.LogDebug("Client certificate is null");
                return Task.FromResult<ParsedSecret>(null);
            }

            if (!context.Request.HasFormContentType)
            {
                _Logger.LogDebug("Content type is not a form");
                return Task.FromResult<ParsedSecret>(null);
            }

            var body = context.Request.Form;

            if (body == null)
            {
                _Logger.LogDebug("No form found");
                return Task.FromResult<ParsedSecret>(null);
            }

            var id = body["client_id"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(id))
            {
                _Logger.LogDebug("No client id found");
                return Task.FromResult<ParsedSecret>(null);
            }

            if (id.Length > _Options.InputLengthRestrictions.ClientId)
            {
                _Logger.LogError("Client ID exceeds maximum lenght.");
                return Task.FromResult<ParsedSecret>(null);
            }

            return Task.FromResult(new ParsedSecret
            {
                Id = id,
                Type = IdentityServerConstants.ParsedSecretTypes.X509Certificate,
                Credential = certificate
            });
        }

        #endregion
    }
}
