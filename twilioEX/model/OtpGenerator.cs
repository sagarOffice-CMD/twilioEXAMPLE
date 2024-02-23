﻿using System;

namespace TwilioEX.Models
{
    public class OtpGenerator
    {
        public static string GenerateOtp(int length = 6)
        {
            Random random = new Random();
            string otp = "";
            for (int i = 0; i < length; i++)
            {
                otp += random.Next(0, 9).ToString();
            }
            return otp;
        }
    }
}
