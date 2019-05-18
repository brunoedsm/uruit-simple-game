using System;

namespace UruIT.GameOfDrones.Domain.Entities
{
    public class Round : BaseEntity
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int HandSignalId { get; set; }
    }
}