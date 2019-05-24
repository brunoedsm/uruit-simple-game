using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Services;
using UruIT.GameOfDrones.Domain.Common;
using UruIT.GameOfDrones.Repository;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
using System.Linq;

namespace UruIT.GameOfDrones.Business.Services
{
    public class RoundService : IRoundService, IService<Round>
    {
        private readonly IRoundRepository _repository;

        public RoundService(IRoundRepository repositoryDI)
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
        public Task<RequestResult> Update(Round dbEntity, Round entity)
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
        public Task<RequestResult> Filter(Round round)
        {
            var result = new RequestResult(StatusResult.Success);

            try
            {
                result.Data = _repository.GetAll().Where(x =>
                    round.MatchId == 0 || x.MatchId == round.MatchId
                && round.PlayerId == 0 || x.PlayerId == round.PlayerId
                && round.HandSignalId == 0 || x.HandSignalId == round.HandSignalId
                && round.SecondPlayerId == 0 || x.SecondPlayerId == round.SecondPlayerId
                && round.SecondHandSignalId == 0 || x.SecondHandSignalId == round.SecondHandSignalId
                && round.WinnerId == 0 || x.WinnerId == round.WinnerId
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
