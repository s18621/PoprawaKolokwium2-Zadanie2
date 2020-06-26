using System;
using System.Collections.Generic;

namespace PoprawaKolokwium_Zadanie2.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAdopted { get; set; }
        public ICollection<Volunteer_Pet> Volunteer_pets { get; set; }
        public BreedType BreedType { get; set; }

    }
}