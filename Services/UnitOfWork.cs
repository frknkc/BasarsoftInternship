using BasarsoftInternship.Data;
using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IGenericService<Point> _pointService;
    private IGenericService<Wkt> _wktService;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IGenericService<Point> PointService => _pointService ??= new PointService(_context);

    public IGenericService<Wkt> WktService => _wktService ??= new WktService(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
