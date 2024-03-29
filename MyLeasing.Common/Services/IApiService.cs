﻿using System.Threading.Tasks;
using MyLeasing.Common.Models;

namespace MyLeasing.Common.Services
{
    public interface IApiService
    {
        Task<Response<OwnerResponse>> GetOwnerByEmailAsync(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            string tokenType, 
            string accessToken, 
            string email);


        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            TokenRequest request);

        Task<bool> CheckConnectionAsync(string url);

        Task<Response<object>> RegisterUserAsync(
                string urlBase,
                string servicePrefix,
                string controller,
                UserRequest userRequest);

        Task<Response<object>> RecoverPasswordAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            EmailRequest emailRequest);



    }
}