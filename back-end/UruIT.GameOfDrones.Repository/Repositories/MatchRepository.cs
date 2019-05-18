using System.Collections.Generic;
using System.Linq;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
 
namespace UruIT.GameOfDrones.Repository
{
    public class MatchRepository : IMatchRepository, IRepository<Match>
    {
        readonly AssessmentContext _matchContext;
 
        public MatchRepository(AssessmentContext context)
        {
            _matchContext = context;
        }
 
        public IEnumerable<Match> GetAll()
        {
            return _matchContext.Matches.ToList();
        }
 
        public Match Get(long id)
        {
            return _matchContext.Matches
                  .FirstOrDefault(e => e.Id == id);
        }
 
        public void Add(Match entity)
        {
            _matchContext.Matches.Add(entity);
            _matchContext.SaveChanges();
        }
 
        public void Update(Match match, Match entity)
        {
            match.CurrentRound = entity.CurrentRound;
            _matchContext.SaveChanges();
        }
 
        public void Delete(Match match)
        {
            _matchContext.Matches.Remove(match);
            _matchContext.SaveChanges();
        }
    }
}