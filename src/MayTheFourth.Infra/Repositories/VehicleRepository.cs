using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class VehicleRepository: IVehicleRepository
{
    private readonly AppDbContext _appDbContext;

    public VehicleRepository(AppDbContext appDbContext)
        => _appDbContext = appDbContext;
    
    public async Task<bool> AnyAsync(string name, string model)
        => await _appDbContext.Vehicles.AnyAsync(x => x.Name == name && x.Model == model);

    public async Task<(List<Vehicle>? vehicles, int totalRecords)> GetAllAsync(int pageNumber, int pageSize)
    {
        var totalRecords = await _appDbContext.Vehicles.CountAsync();

        var vehicles = await _appDbContext.Vehicles.Skip((pageNumber - 1) * pageSize).AsNoTracking().ToListAsync();

        return (vehicles, totalRecords);
    } 
    
    public async Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Vehicles
            .Include(x => x.Films)
            .Include(x => x.Pilots)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Vehicle?> GetBySlugAsync(string slug, CancellationToken cancellationToken)  
        => await _appDbContext.Vehicles
            .Include(x => x.Films)
            .Include(x => x.Pilots)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == slug, cancellationToken);

    public async Task SaveAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await _appDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteVehicleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var vehicle = await _appDbContext.Vehicles.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        if (vehicle is null) return false;
        _appDbContext.Vehicles.Remove(vehicle);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return true;

    }
}