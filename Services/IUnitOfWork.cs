using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;

public interface IUnitOfWork : IDisposable
{
    IGenericService<Point> PointService { get; }
    IGenericService<Wkt> WktService { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
