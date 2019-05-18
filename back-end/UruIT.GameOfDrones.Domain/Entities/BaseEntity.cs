using System;
using System.ComponentModel.DataAnnotations; 
    
namespace  UruIT.GameOfDrones.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id{get;set;}
        public DateTime DataRegister{get;set;}
    }
}