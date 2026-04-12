using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models;

public class Room
{
    public int Id{get;set;}
    
    [Required(ErrorMessage = "Wprowadz nazwe sali")]
    public string Name{get;set;} = string.Empty;
    
    [Required(ErrorMessage = "Wprowadz kod budynku")]
    public string BuildingCode{get;set;} = string.Empty;
    
    public int Floor{get;set;}
    
    [Range(1, 250, ErrorMessage = "Bledna pojemnosc sali")]
    public int Capacity{get;set;}
    
    public bool HasProjector {get;set;}
    
    public bool IsActive{get;set;}
    
}