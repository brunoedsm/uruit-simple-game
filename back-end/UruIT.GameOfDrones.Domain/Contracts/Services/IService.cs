using System.Collections.Generic;
using UruIT.GameOfDrones.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UruIT.GameOfDrones.Domain.Common;

namespace UruIT.GameOfDrones.Domain.Contracts.Services
{
    public interface IService<TEntity>
      where TEntity : BaseEntity
    {
        Task<RequestResult> GetAll();
        Task<RequestResult> Get(long id);
        Task<RequestResult> Add(TEntity entity);
        Task<RequestResult> Update(TEntity dbEntity, TEntity entity);
        Task<RequestResult> Delete(TEntity entity);
        Task<RequestResult> Filter(TEntity entity);
    }
}