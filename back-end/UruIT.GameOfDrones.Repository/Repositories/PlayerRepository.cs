using System.Collections.Generic;
using System.Linq;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
 
namespace UruIT.GameOfDrones.Repository
{
    public class PlayerRepository : IPlayerRepository,IRepository<Player>
    {
        readonly AssessmentContext _playerContext;
 
        public PlayerRepository(AssessmentContext context)
        {
            _playerContext = context;
        }
 
        public IEnumerable<Player> GetAll()
        {
            return _playerContext.Players.ToList();
        }
 
        public Player Get(long id)
        {
            return _playerContext.Players
                  .FirstOrDefault(e => e.Id == id);
        }
 
        public void Add(Player entity)
        {
            _playerContext.Players.Add(entity);
            _playerContext.SaveChanges();
        }
 
        public void Update(Player player, Player entity)
        {
            player.Name = entity.Name;
            _playerContext.SaveChanges();
        }
 
        public void Delete(Player player)
        {
            _playerContext.Players.Remove(player);
            _playerContext.SaveChanges();
        }
    }
}