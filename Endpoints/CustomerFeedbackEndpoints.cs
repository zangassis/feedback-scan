using Microsoft.EntityFrameworkCore;
using FeedbackScan.Data;
using FeedbackScan.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using OpenAI.Chat;
using System.Text.Json;
namespace FeedbackScan.Endpoints;

public static class CustomerFeedbackEndpoints
{
    public static void MapCustomerFeedbackEndpoints(this IEndpointRouteBuilder routes, ChatClient chatService)
    {
        var group = routes.MapGroup("/api/CustomerFeedback").WithTags(nameof(CustomerFeedback));

        group.MapGet("/", async (FeedbackScanContext db) =>
        {
            return await db.CustomerFeedback.ToListAsync();
        })
        .WithName("GetAllCustomerFeedbacks")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CustomerFeedback>, NotFound>> (string id, FeedbackScanContext db) =>
        {
            return await db.CustomerFeedback.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is CustomerFeedback model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCustomerFeedbackById")
        .WithOpenApi();

        group.MapPost("/feedback-submission", async (FeedbackRequest request, FeedbackScanContext db) =>
        {
            string feedbackAnalysisPrompt = $@"Analyze the following customer feedback and return the sentiment (positive, negative, or neutral) 
            and the main reason (with a maximum of 5 words) for that sentiment in the following JSON format:
            {{
              ""sentiment"": ""positive|negative|neutral"",
              ""mainReason"": ""reason for the sentiment""
            }}
            Feedback Text: {request.ReviewText}";

            var result = await chatService.CompleteChatAsync(feedbackAnalysisPrompt);

            var resultContent = result.Value.Content.FirstOrDefault().Text;

            var feedbackAnalysisResult = JsonSerializer.Deserialize<FeedbackResponse>(resultContent);

            var customerFeedback = new CustomerFeedback
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ReviewText = request.ReviewText,
                Rating = request.Rating,
                Sentiment = feedbackAnalysisResult.Sentiment,
                MainReason = feedbackAnalysisResult.MainReason,
                CreatedDate = DateTime.Now
            };

            db.CustomerFeedback.Add(customerFeedback);
            await db.SaveChangesAsync();
            return TypedResults.Ok();
        })
        .WithName("FeedbackSubmission")
        .WithOpenApi();
    }
}