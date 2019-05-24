using System;

namespace UruIT.GameOfDrones.Domain.Entities
{
    public class Match : BaseEntity
    {
        public string HashId { get; set; }
        public int CurrentRound { get; set; }
    }
}