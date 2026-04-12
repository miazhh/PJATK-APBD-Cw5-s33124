using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required] 
    public int RoomId { get; set; }
    
    [Required(ErrorMessage = "Dane organizatora wymagane")] 
    public string OrganizerName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Temat wymagany")]
    public string Topic { get; set; } = string.Empty;
    
    [Required]
    public DateOnly Date { get; set; }
    
    [Required]
    public TimeOnly StartTime { get; set; }
    [Required]
    public TimeOnly EndTime { get; set; }
    
    public string Status { get; set; } = "planned";
}
    