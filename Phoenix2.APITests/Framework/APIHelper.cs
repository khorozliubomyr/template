using Microsoft.IdentityModel.Tokens;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Diagnostics;
using System.Net.Http.Headers;
using Phoenix2.APITests.DTO.UserServiceDTO;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Task = System.Threading.Tasks.Task;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Phoenix2.APITests.DTO;
using Phoenix2.APITests.DTO.AuthorizationModels;

namespace Phoenix2.APITests
{
    public class APIHelper<T>
    {

        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://qa-api-v2.ilendingdirect.com/";
        public string baseUrldev = "https://dev-api-v2.ilendingdirect.com/";




        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);

            return restClient;
        }

        public RestClient SetUrlDev(string endpoint)
        {
            var url = Path.Combine(baseUrldev, endpoint);
            var restClient = new RestClient(url);

            return restClient;
        }

        public RestRequest UploadFile(string path)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddFile("file", path);
            return restRequest;
        }
        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreatePostRequest(string payload, string acessToken)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(payload);
           
            return restRequest;
        }
        public RestRequest CreatePostRequestWithoutBody()
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public RestRequest CreatePostRequestWithoutBody(string acessToken)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken);
            return restRequest;
        }
        public RestRequest CreatePatchRequestWithoutBody()
        {
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public RestRequest CreatePatchRequestWithoutBody(string acessToken)
        {
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + acessToken);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreatePutRequest(string payload, string acessToken)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(payload);
            return restRequest;
        }

        public RestRequest CreatePutRequestWithoutBody()
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public RestRequest CreatePutRequestWithoutBody(string acessToken)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + acessToken);
            return restRequest;
        }
        public RestRequest CreatePatchRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreatePatchRequest(string payload, string acessToken)
        {
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(payload);
            return restRequest;
        }
        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreateGetRequest(string acessToken)
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Authorization", "Bearer " + acessToken)
                .AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreateGetRequestWithBody(string payload)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public RestRequest CreateDeleteRequest(string acessToken)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + acessToken);
            return restRequest;
        }
        public RestRequest CreateDeleteRequestWithBody(string payload)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreateDeleteRequestWithBody(string payload, string acessToken)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(payload);
            return restRequest;
        }
        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

        public IEnumerable<DTO> GetArrayContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            IEnumerable<DTO> result = JsonConvert.DeserializeObject<IEnumerable<DTO>>(content);
            return result;
        }

        public string Serialize(dynamic content)
        {
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
            return serializeObject;
        }

        public string GenerateDocName(int length)
        {
            string result = string.Empty;
            Random random = new Random((int)DateTime.Now.Ticks);
            List<string> characters = new List<string>() { };
            for (int i = 48; i < 58; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (int i = 65; i < 91; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (int i = 97; i < 123; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (int i = 0; i < length; i++)
            {
                result += characters[random.Next(0, characters.Count)];
                Thread.Sleep(1);
            }
            return result;
        }
        public int randomNumber()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            return num;
        }
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public string authorizationToken()
        {
            var secret = "FLkedhqiuerhwqkfds78r3y60824y32!CO~@Y021c0";
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var issuer = "CLM_WEB";
            var audience = "Phoenix2";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
new Claim(ClaimTypes.NameIdentifier,"Lb"),
            }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public void PhoenixUIService(ITokenAcquisition tokenAcquisition, HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _tokenAcquisition = tokenAcquisition;
            _PhoenixAPIScope = configuration["PhoenixAPI:PhoenixAPIScope"];
            _PhoenixAPIBaseAddress = configuration["PhoenixAPI:PhoenixAPIBaseAddress"];
        }
        public async Task<IEnumerable<UserRole>> GetAsync()
        {
            await PrepareAuthenticatedClient();
            var response = await _httpClient.GetAsync($"{_PhoenixAPIBaseAddress}/users");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                IEnumerable<UserRole> useRolesList = JsonConvert.DeserializeObject<IEnumerable<UserRole>>(content);



                return useRolesList;
            }
            else
            {
                var temp = new Exception(response.Content.ToString());
            }



            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        }
        public async Task PrepareAuthenticatedClient()
        {
            var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "api://d9a29073-026e-40a2-ac35-13f176b4a798/access_as_user" });
            Debug.WriteLine($"access token-{accessToken}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private HttpClient _httpClient;
        private ITokenAcquisition _tokenAcquisition;
        private string _PhoenixAPIScope;
        private string _PhoenixAPIBaseAddress;
    }
}

