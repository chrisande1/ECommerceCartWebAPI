using ECommerceCart.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCart.Infrastructure.Persistence.Repositories.Common;
public abstract class GenericRepository<TModel> where TModel : Entity
{
    protected readonly ApplicationDBContext _dBContext;

    protected GenericRepository(ApplicationDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async virtual Task<TModel> Add(TModel model)
    {
        await _dBContext.Set<TModel>().AddAsync(model);

        model.CreatedAt = DateTime.Now;
        await _dBContext.SaveChangesAsync();
        return model;
    }

    public async virtual Task<IEnumerable<TModel>> GetAll()
    {
        return await _dBContext.Set<TModel>()
            .Where(model => model.DeletedAt == null)
            .ToListAsync();
    }

    public async virtual Task<TModel?> GetById(Guid Id)
    {
        return await _dBContext.Set<TModel>()
            .Where(model => model.DeletedAt == null && model.Id == Id)
            .FirstOrDefaultAsync();
    }


    public async virtual Task<TModel?> DeleteById(Guid Id)
    {
        var targetModel = await GetById(Id);

        if (targetModel != null)
        {
            targetModel.DeletedAt = DateTime.Now;
        }

        await _dBContext.SaveChangesAsync();
        return targetModel;
    }
}   


