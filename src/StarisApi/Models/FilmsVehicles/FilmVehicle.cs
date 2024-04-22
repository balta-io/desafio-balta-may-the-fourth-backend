using StarisApi.Models.Films;
using StarisApi.Models.Vehicles;

namespace StarisApi.Models.FilmsVehicle;

public class FilmVehicle()
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int VehicleId { get; set; }

    public Film Film { get; set; } = null!;
    public Vehicle Vehicle { get; set; } = null!;
}