using TwilioEX.Services;
using twilioEX.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Twilio

var twilioaccountsid = "AC60df8ececd98cfd4da2ec1f73d07c9bb";
var twilioauthtoken = "38dbbf4bb4efe0fb46367e4c5d116ca0";
var twuiliophonenumber = "+14158959071";

builder.Services.AddSingleton<ISmsService>(new TwilioSmsService(twilioaccountsid, twilioauthtoken, twuiliophonenumber));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
