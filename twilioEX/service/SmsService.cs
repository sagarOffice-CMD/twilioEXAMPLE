using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using twilioEX.service;

namespace TwilioEX.Services
{
    public class TwilioSmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _phoneNumber;

        public TwilioSmsService(string accountSid, string authToken, string phoneNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _phoneNumber = phoneNumber;
        }

        public async Task SendSmsAsync(string toPhoneNumber, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(_phoneNumber),
                Body = $"Sagar bhai OTP hai kya {message}"
            };

            var response = await MessageResource.CreateAsync(messageOptions);
            Console.WriteLine(response.Sid);
        }

        public async Task SendWhatAppMessage(string message,string phonenumber)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{phonenumber}"))
            {
                From = new PhoneNumber("whatsapp:+14155238886"),
                Body = message

            };

            var response = await MessageResource.CreateAsync(messageOptions);
            Console.WriteLine(response.Body);
        }

      
   
    }
}
