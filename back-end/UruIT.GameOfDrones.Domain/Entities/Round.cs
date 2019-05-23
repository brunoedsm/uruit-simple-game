using System;

namespace UruIT.GameOfDrones.Domain.Entities
{
    public class Round : BaseEntity
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int HandSignalId { get; set; }
        public int SecondPlayerId { get; set; }
        public int SecondHandSignalId { get; set; }
        public int WinnerId { get; set; }
    }
}