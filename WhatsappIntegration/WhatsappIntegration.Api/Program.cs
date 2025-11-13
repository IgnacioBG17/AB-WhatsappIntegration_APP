using Microsoft.OpenApi;
using WhatsappIntegration.Api;
using WhatsappIntegration.Application;
using WhatsappIntegration.Application.Contracts.WhatsappCloud.SendMessage;
using WhatsappIntegration.Common;
using WhatsappIntegration.External;
using WhatsappIntegration.External.WhatsappCloud.SendMessage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IWhatsappCloudSendMessage, WhatsappCloudSendMessage>();

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
