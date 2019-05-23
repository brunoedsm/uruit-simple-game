using System.Collections.Generic;
using System.Linq;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;

namespace UruIT.GameOfDrones.Repository
{
    public class RoundRepository : IRoundRepository, IRepository<Round>
    {
        readonly AssessmentContext _roundContext;

        public RoundRepository(AssessmentContext context)
        {
            _roundContext = context;
        }

        public IEnumerable<Round> GetAll()
        {
            return _roundContext.Rounds.ToList();
        }

        public Round Get(long id)
        {
            return _roundContext.Rounds
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Round entity)
        {
            _roundContext.Rounds.Add(entity);
            _roundContext.SaveChanges();
        }

        public void Update(Round round, Round entity)
        {
            round.MatchId = entity.MatchId;
            round.PlayerId = entity.PlayerId;
            round.HandSignalId = entity.HandSignalId;
            round.SecondPlayerId = entity.SecondPlayerId;
            round.SecondHandSignalId = entity.SecondHandSignalId;
            round.WinnerId = entity.WinnerId; 
            _roundContext.SaveChanges();
        }

        public void Delete(Round round)
        {
            _roundContext.Rounds.Remove(round);
            _roundContext.SaveChanges();
        }
    }
}