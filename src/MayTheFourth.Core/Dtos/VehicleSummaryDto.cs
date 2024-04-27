using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class VehicleSummaryDto
{
    public VehicleSummaryDto(){}
    public VehicleSummaryDto(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Name = vehicle.Name;
        Slug = vehicle.Slug;
        Model = vehicle.Model;
        Manufacturer = vehicle.Manufacturer;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}
