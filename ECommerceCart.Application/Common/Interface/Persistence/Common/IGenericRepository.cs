﻿namespace ECommerceCart.Application.Common.Interface.Persistence.Common;
public interface IGenericRepository<TModel> where TModel : class
{
    public Task<TModel> Add(TModel model);
    public Task<IEnumerable<TModel>> GetAll();
    public Task<TModel?> GetById(Guid Id);
    public Task<TModel?> DeleteById(Guid Id);
}

