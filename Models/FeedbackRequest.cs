using System.ComponentModel.DataAnnotations;

namespace FeedbackScan.Models;
public class FeedbackRequest
{
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ReviewText { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }
}
