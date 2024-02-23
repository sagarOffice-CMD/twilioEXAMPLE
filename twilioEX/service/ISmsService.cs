namespace twilioEX.service
{
    public interface ISmsService
    {
        Task SendSmsAsync(string toPhoneNumber, string message);

        Task SendWhatAppMessage(string message,string phonenumber);
    }
        

    
}
