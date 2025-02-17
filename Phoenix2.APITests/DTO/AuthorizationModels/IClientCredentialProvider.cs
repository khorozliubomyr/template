using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AuthorizationModels
{
    public interface IClientCredentialProvider
    {
        Task<string?> GetClientCredentialsTokenAsync();
    }
}
