using WebApplication.Models;

namespace WebApplication.Data;

public class ApplicationData
{
    public static List<Room> Rooms = new()
    {
        new Room
        {
            Id = 1, Name = "Sala A359", BuildingCode = "A", Floor = 3, Capacity = 16, HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 2, Name = "Sala A260", BuildingCode = "A", Floor = 2, Capacity = 16, HasProjector = true,
            IsActive = false
        },
        new Room
        {
            Id = 3, Name = "Aula Główna B1", BuildingCode = "B", Floor = 0, Capacity = 250, HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 4, Name = "Aula A1", BuildingCode = "A", Floor = 0, Capacity = 250, HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 5, Name = "B228", BuildingCode = "B", Floor = 2, Capacity = 16, HasProjector = false, IsActive = true
        },
        new Room
        {
            Id = 6, Name = "B117", BuildingCode = "B", Floor = 1, Capacity = 16, HasProjector = true, IsActive = false
        },
        new Room
        {
            Id = 7, Name = "A235", BuildingCode = "A", Floor = 2, Capacity = 16, HasProjector = true, IsActive = true
        },

    };

    public static List<Reservation> Reservations = new()
    {
        new Reservation(){Id = 1, RoomId = 3, OrganizerName = "Samorząd", Topic = "Wykład wprowadzający dla nowych studentów", Date = new DateOnly(2026, 3,20), StartTime = new TimeOnly(17,30), EndTime = new TimeOnly(19,00),Status = "potwierdzone"},
        new Reservation(){Id = 2, RoomId = 1, OrganizerName = "mgr. inż. Jan Kowalski", Topic = "PPJ", Date = new DateOnly(2026,5,10), StartTime = new TimeOnly(10,15), EndTime = new TimeOnly(11,45),Status = "potwierdzone"},
        new Reservation(){Id = 3, RoomId = 1, OrganizerName = "mgr. inż. Adam Lewandowski", Topic = "APBD", Date = new DateOnly(2026,5,10), StartTime = new TimeOnly(12,15), EndTime = new TimeOnly(13,45),Status = "zaplanowane"},
        new Reservation(){Id = 4, RoomId = 1, OrganizerName = "Prof. dr hab. Aleksander Wysocki", Topic = "UTP", Date = new DateOnly(2026,5,11), StartTime = new TimeOnly(12,15), EndTime = new TimeOnly(13,45),Status = "potwierdzone"},
        new Reservation(){Id = 5, RoomId = 5, OrganizerName = "Administracja", Topic = "Spotkanie organizacyjne", Date = new DateOnly(2026,5,12), StartTime = new TimeOnly(10,15), EndTime = new TimeOnly(11,45),Status = "zaplanowane"},
        new Reservation(){Id = 6, RoomId = 7, OrganizerName = "Prof. Piotr Nowak", Topic = "Kolokwium poprawkowe MAD", Date = new DateOnly(2026,5,10), StartTime = new TimeOnly(15,45), EndTime = new TimeOnly(17,15),Status = "odwołane"}
        
    };
}