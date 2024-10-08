using System.Dynamic;
using System.Text.Json;
using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;

namespace ecommerce_music_back.Rest
{
    public class BrasilApiRest : IBrasilApiRepository
    {


        // public async Task<GenericResponse<Bank>> findBankByCode(string code)
        // {
            
        // }

        public async Task<GenericResponse<Address>> findAddressByCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new GenericResponse<Address>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync(); 
                var objResponse = JsonSerializer.Deserialize<Address>(contentResponse);

                if (responseBrasilApi.IsSuccessStatusCode) 
                {
                    response.httpStatusCode = responseBrasilApi.StatusCode;
                    response.returnData = objResponse;
                }

                else
                {
                    response.httpStatusCode = responseBrasilApi.StatusCode;
                    response.returnError = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }

               
            }
             return response;
        }

        // public async Task<GenericResponse<List<Bank>>> findAllBanks() 
        // {
            
        // }
    }
}