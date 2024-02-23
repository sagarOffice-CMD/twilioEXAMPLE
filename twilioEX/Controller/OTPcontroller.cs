using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Http;
using Twilio.Types;
using twilioEX.service;
using TwilioEX.Models;
using TwilioEX.Services;
using static System.Net.WebRequestMethods;

namespace TwilioEX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public OTPController(ISmsService smsService)
        {
            _smsService = smsService;
        }




        [HttpPost("sendotp")]
        public async Task<IActionResult> SendOTP([FromBody] OTPRequest request)
        {
            try
            {

                var otp = OtpGenerator.GenerateOtp();
                await _smsService.SendSmsAsync(request.PhoneNumber, $"Your OTP is {otp}");
                return Ok("OTP sent successfully.");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("SendWhatsappMessage")]

        public async Task<IActionResult> SendMessage([FromBody] Whatsmessage mess)
        {
            try
            {
                await _smsService.SendWhatAppMessage(mess.message, mess.Phonenumber);
                return Ok("Message send on Whatsapp succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
  
    }

    public class OTPRequest
    {
        public string PhoneNumber { get; set; }
    }

    public class Whatsmessage
    {
        public string Phonenumber { get; set; }
        public string message { get; set;}
    }
}
