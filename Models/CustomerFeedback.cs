using System.ComponentModel.DataAnnotations;

namespace FeedbackScan.Models;
public class CustomerFeedback
{
    [Key]
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ReviewText { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }
    public string Sentiment{ get; set; }
    public string MainReason { get; set; }
    public DateTime CreatedDate { get; set; }
}