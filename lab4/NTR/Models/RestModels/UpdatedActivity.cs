namespace NTR.Models.RestModels;

public class UpdatedActivity
{
    public int ActivityId { get; set; }
    public int Time { get; set; }
    public string Description { get; set; } 
    public string? SubcodeName { get; set; }

}
