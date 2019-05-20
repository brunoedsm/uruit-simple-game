using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Services;
using UruIT.GameOfDrones.Domain.Common;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
using UruIT.GameOfDrones.Repository;
using System.Linq;

namespace UruIT.GameOfDrones.Business.Services
{
    public class HandSignalService : IHandSignalService, IService<HandSignal>
    {
        private readonly IHandSignalRepository _repository;

        public HandSignalService(IHandSignalRepository repositoryDI)
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
        public Task<RequestResult> Add(HandSignal entity)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                entity.DataRegister = DateTime.Now;
                _repository.Add(entity);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
        public Task<RequestResult> Update(HandSignal dbEntity, HandSignal entity)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                _repository.Update(dbEntity, entity);
            }
            catch (Exception ex)
            {
                result.Status = StatusResult.Danger;
                result.Messages.Add(new Message(ex.Message));
            }

            return Task.FromResult(result);
        }
        public Task<RequestResult> Delete(HandSignal entity)
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

        public Task<RequestResult> Filter(HandSignal signal)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                result.Data = _repository.GetAll().Where(x =>
                    string.IsNullOrEmpty(signal.Description) || x.Description == signal.Description
                );
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
