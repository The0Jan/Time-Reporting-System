namespace NTR.Models.RestModels;

public class AcceptedActivity
{
    public int? ActivityId { get; set; }
    public DateTime Date { get; set; }
    public int Time { get; set; }
    public string Description { get; set; } 
    public bool Frozen { get; set; }
    public int? UserId { get; set; }
    public string ProjectCode { get; set; }
    public string? SubcodeName { get; set; }

}
