using System;
using System.ComponentModel.DataAnnotations; 
    
namespace  UruIT.GameOfDrones.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id{get;set;}
        public DateTime DataRegister{get;set;}
    }
}