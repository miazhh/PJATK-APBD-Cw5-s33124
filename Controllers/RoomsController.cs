using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly)
    {
        var rooms = ApplicationData.Rooms.AsQueryable();

        if (minCapacity.HasValue)
        {
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);
        }

        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);
        }

        if (activeOnly.HasValue && activeOnly.Value)
        {
            rooms = rooms.Where(r => r.IsActive);
        }
        return Ok(rooms);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var room = ApplicationData.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return NotFound($"Sala o id {id} nie istnieje");
        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuilding(string buildingCode)
    {
        var rooms = ApplicationData.Rooms.Where(r =>
            r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase));
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Room room)
    {
        room.Id = ApplicationData.Rooms.Any() ? ApplicationData.Rooms.Max(r=>r.Id) + 1 : 1;
        ApplicationData.Rooms.Add(room);
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Room updatedRoom)
    {
        var room = ApplicationData.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return NotFound();
        
        room.Name = updatedRoom.Name;
        room.BuildingCode = updatedRoom.BuildingCode;
        room.Capacity = updatedRoom.Capacity;
        room.HasProjector = updatedRoom.HasProjector;
        room.IsActive = updatedRoom.IsActive;
        room.Floor = updatedRoom.Floor;
        return Ok(room);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var room = ApplicationData.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return NotFound();

        if (ApplicationData.Reservations.Any(reservation => reservation.RoomId == id))
        {
            return Conflict("Istnieją rezerwacje dla usuwanej sali");
        }
        ApplicationData.Rooms.Remove(room);
        return NoContent();
    }
}