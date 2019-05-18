using System.Collections.Generic;
using System.Linq;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
 
namespace UruIT.GameOfDrones.Repository
{
    public class HandSignalRepository : IHandSignalRepository, IRepository<HandSignal>
    {
        readonly AssessmentContext _handSignalContext;
 
        public HandSignalRepository(AssessmentContext context)
        {
            _handSignalContext = context;
        }
 
        public IEnumerable<HandSignal> GetAll()
        {
            return _handSignalContext.HandSignals.ToList();
        }
 
        public HandSignal Get(long id)
        {
            return _handSignalContext.HandSignals
                  .FirstOrDefault(e => e.Id == id);
        }
 
        public void Add(HandSignal entity)
        {
            _handSignalContext.HandSignals.Add(entity);
            _handSignalContext.SaveChanges();
        }
 
        public void Update(HandSignal handSignal, HandSignal entity)
        {
            handSignal.Description = entity.Description;
            _handSignalContext.SaveChanges();
        }
 
        public void Delete(HandSignal handSignal)
        {
            _handSignalContext.HandSignals.Remove(handSignal);
            _handSignalContext.SaveChanges();
        }
    }
}