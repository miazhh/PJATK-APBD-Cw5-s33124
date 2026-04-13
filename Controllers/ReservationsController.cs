using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] DateOnly? date, [FromQuery] string? status, [FromQuery] int? roomId)
    {
        var query = ApplicationData.Reservations.AsQueryable();
        
        if(date.HasValue) query = query.Where(r=>r.Date == date.Value);
        if (roomId.HasValue) query = query.Where(r => r.RoomId == roomId.Value);
        if(!string.IsNullOrEmpty(status)) query = query.Where(r => r.Status == status);
        return Ok(query.ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var reservation = ApplicationData.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null) return NotFound();
        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Reservation newReservation)
    {
        if (newReservation.EndTime <= newReservation.StartTime)
        {
            return BadRequest("Błędne godziny");
        }

        var room = ApplicationData.Rooms.FirstOrDefault(r => r.Id == newReservation.RoomId);
        if (room == null)
        {
            return NotFound("Sala o podanym id nie istnieje");
        }

        if (!room.IsActive)
        {
            return BadRequest("Nie można rezerwować nieaktywnej sali");
        }

        bool roomReservation = ApplicationData.Reservations.Any(r => r.RoomId == newReservation.RoomId &&
                                                                     r.Date == newReservation.Date &&
                                                                     r.Status != "odwołane" &&
                                                                     newReservation.StartTime < r.EndTime &&
                                                                     newReservation.EndTime > r.StartTime);

        if (roomReservation)
        {
            return Conflict("Sala zajęta");
        }

        newReservation.Id = ApplicationData.Reservations.Any() ? ApplicationData.Reservations.Max(r => r.Id) + 1 : 1;
        ApplicationData.Reservations.Add(newReservation);
        
        return CreatedAtAction(nameof(GetById), new { id = newReservation.Id }, newReservation);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Reservation updatedReservation)
    {
        var reservation = ApplicationData.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null) return NotFound("Brak rezerwacji o takim id");
        
        reservation.OrganizerName = updatedReservation.OrganizerName;
        reservation.Topic = updatedReservation.Topic;
        reservation.Date = updatedReservation.Date;
        reservation.StartTime = updatedReservation.StartTime;
        reservation.EndTime = updatedReservation.EndTime;
        reservation.Status = updatedReservation.Status;
        
        return Ok(reservation);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var reservation = ApplicationData.Reservations.FirstOrDefault(r=>r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        ApplicationData.Reservations.Remove(reservation);
        return NoContent();
    }
}