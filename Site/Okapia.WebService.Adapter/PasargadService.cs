using System.Collections.Generic;
using System.Linq;
using System.Net;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Models;
using Okapia.WebService.Adapter.Contracts;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Okapia.WebService.Adapter
{
    public class PasargadService : IPasargadService
    {
        private readonly RestClient _client;
        private readonly JsonSerializer _jsonSerializer;
        private const string Appsecret = "139B1A50-2812-4152-8F3D-EE180B3C2714";
        private const string Appkey = "E3B3F817-BE8D-474C-81D7-9C88D694B641";

        public PasargadService()
        {
            _jsonSerializer = new JsonSerializer();
            _client = new RestClient("https://212.80.25.71/api/api/GeneralApi");
        }

        public bool TryRegister(CreateUser user, List<UserCard> userCards)
        {
            var cards = userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber));
            const string seperator = ",";
            var cardString = $"{user.Card1},";
            if (!string.IsNullOrEmpty(user.Card2))
                cardString += string.Join(seperator, cards);

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var request = RequestBuilder("Register", Method.POST).AddParameter("FirstNameFa", user.Name)
                .AddParameter("LastNameFa", user.Family).AddParameter("FirstNameEn", user.NameEn)
                .AddParameter("LastNameEn", user.FamilyEn).AddParameter("NationalCode", user.NationalCardNumber)
                .AddParameter("CellNumber", user.PhoneNumber).AddParameter("MappedCards", cardString)
                .AddParameter("CardGroupId", "253").AddParameter("CustomerGroupId", "1234010910");
            var response = _client.Execute(request);
            var result = _jsonSerializer.Deserialize<WebServiceResponse>(response);
            return result.Status == -1 && result.ErrorMessage == "";
        }

        public bool IsAlreadyApiMember(string nationalCode)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var request = RequestBuilder("EnquireMemebership", Method.POST).AddParameter("NationalCode", nationalCode);
            var response = _client.Execute(request);
            var result = _jsonSerializer.Deserialize<WebServiceResponse>(response);
            return result.Status == -105;
        }

        public bool IsCardAleadyExists(List<string> cards)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var request = RequestBuilder("CardMembership", Method.GET).AddParameter("CardNumber", cards);
            var response = _client.Execute(request);
            var result = _jsonSerializer.Deserialize<WebServiceResponse>(response);
            return result.Status == -105;
        }

        public bool MapCards(string nationalCode, string concatedCards)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var request = RequestBuilder("CardMembership", Method.GET).AddParameter("NationalCode", nationalCode).AddParameter("MappedCards", concatedCards);
            var response = _client.Execute(request);
            var result = _jsonSerializer.Deserialize<WebServiceResponse>(response);
            return result.Status == 0;
        }

        private static RestRequest RequestBuilder(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("AppKey", Appkey).AddParameter("AppSecret", Appsecret);
            return request;
        }
    }
}