using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium_Zadanie2.DTOs
{
    public class PetRequest
    {
        public string BreedName { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
