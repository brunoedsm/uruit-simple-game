using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Services;
using UruIT.GameOfDrones.Domain.Common;
using UruIT.GameOfDrones.Repository;

namespace UruIT.GameOfDrones.Business
{
    public class RoundService : IRoundService, IService<Round>
    {
        private readonly RoundRepository _repository;

        public RoundService(RoundRepository repositoryDI)
        {
            _repository = repositoryDI;
        }

        public Task<RequestResult> GetAll()
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                result.Data = _repository.GetAll();
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
        public Task<RequestResult> Get(long id)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                result.Data = _repository.Get(id);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
        public Task<RequestResult> Add(Round entity)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                _repository.Add(entity);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }    

            return Task.FromResult(result);
        }
        public Task<RequestResult> Update(Round dbEntity, Round entity)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                _repository.Update(dbEntity,entity);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
        public Task<RequestResult> Delete(Round entity)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
    }
}
