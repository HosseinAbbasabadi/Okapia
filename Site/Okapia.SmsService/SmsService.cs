﻿using RestSharp;
using RestSharp.Serialization.Json;

namespace Okapia.SmsService
{
    public class SmsService : ISmsService
    {
        private const string Sender = "3000133741";
        private const string ApiKey = "rPPqdw9bOPV8OGgOdg9KTJcfSBzFlpT3iPZV0xmQuTU";
        private readonly JsonSerializer _jsonSerializer;

        public SmsService()
        {
            _jsonSerializer = new JsonSerializer();
        }

        public string SendSms(string message, string reciever)
        {
            var client = new RestClient("http://api.smsapp.ir/v2/sms/send/simple");
            var request = new RestRequest(Method.POST);
            request.AddHeader("apikey", ApiKey);
            request.AddParameter("sender", Sender);
            request.AddParameter("receptor", reciever);
            request.AddParameter("message", message);
            var response = client.Execute(request);
            var result = _jsonSerializer.Deserialize<SmsServiceReponse>(response);
            if (result.Messageids > 1000)
                return "";
            return result.Result;
        }
    }
}