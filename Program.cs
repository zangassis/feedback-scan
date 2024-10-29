using Microsoft.EntityFrameworkCore;
using FeedbackScan.Data;
using OpenAI;
using System.ClientModel;
using FeedbackScan.Endpoints;

var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

var apiKey = configuration["AI:OpenAI:ApiKey"];
OpenAIClient openAIClient = new OpenAIClient(new ApiKeyCredential(apiKey));
const string apiClient = "gpt-4o-mini";

var chatService = openAIClient.GetChatClient(apiClient);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FeedbackScanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeedbackScanContext") ?? 
    throw new InvalidOperationException("Connection string 'FeedbackScanContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCustomerFeedbackEndpoints(chatService);

app.Run();