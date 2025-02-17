using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Phoenix2.APITests.DTO.AuthorizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.Framework
{
    public class ClientCredentialProvider : IClientCredentialProvider
    {
        private readonly AzureAdOptions _adOptions;
        private readonly ClientAdOptions _clientAdOptions;

        public ClientCredentialProvider()
        {
            ClientAdOptions clientadoptions = new ClientAdOptions();
            AzureAdOptions azureadoptions = new AzureAdOptions();
            _adOptions = azureadoptions;
            _clientAdOptions = clientadoptions;
        }
        public async Task<string?> GetClientCredentialsTokenAsync()
        {
            var app = ConfidentialClientApplicationBuilder.Create(_clientAdOptions.ClientId)
                .WithClientSecret(_clientAdOptions.ClientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{_adOptions.TenantId}"))
                .Build();
 
            AuthenticationResult result = null;
            try
            {
                result = await app.AcquireTokenForClient(new List<string> { _clientAdOptions.Scope })
                    .ExecuteAsync();


                Console.WriteLine("Token acquired");
            }
            catch (MsalServiceException ex) when (ex.Message.Contains("AADSTS70011"))
            {
                Console.WriteLine("Scope provider is not supported");
            }
            return result?.AccessToken;

        }


    }
}
