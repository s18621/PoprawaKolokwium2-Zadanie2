using PoprawaKolokwium_Zadanie2.DTOs;
using PoprawaKolokwium_Zadanie2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium_Zadanie2.MyServices
{
    public class SQLServices : DbServices
    {
        private readonly s18621Context _context;

        public SQLServices(s18621Context context)
        {
            _context = context;
        }

        public Pet AddPet(PetRequest petRequest)
        {
            var breedTyp = _context.BreedTypes.Where(m => m.Name == petRequest.BreedName).FirstOrDefault();
            int max = _context.BreedTypes.DefaultIfEmpty().Max(m => m == null ? 0 : m.IdBreedType);
            int maxP = _context.Pets.DefaultIfEmpty().Max(m => m == null ? 0 : m.IdPet);
            int idBreed = _context.BreedTypes.Where(m => m.Name == petRequest.BreedName).Select(m => m.IdBreedType).FirstOrDefault();
            var pet = new Pet();

            if (breedTyp == null)
            {
                var newBreed = new BreedType
                {
                    IdBreedType = max + 1,
                    Name = petRequest.BreedName
                };

                _context.Attach(newBreed);
                _context.Add(newBreed);


                pet = new Pet

                {
                    IdPet = maxP + 1,
                    IdBreedType = max + 1,
                    Name = petRequest.Name,
                    IsMale = petRequest.IsMale,
                    DateRegistered = petRequest.DateRegistered,
                    DateOfBirth = petRequest.DateOfBirth
                };

                _context.Attach(pet);
                _context.Add(pet);
                _context.SaveChanges();
            } else
            {
                pet = new Pet

                {
                    IdPet = maxP + 1,
                    IdBreedType = idBreed,
                    Name = petRequest.Name,
                    IsMale = petRequest.IsMale,
                    DateRegistered = petRequest.DateRegistered,
                    DateOfBirth = petRequest.DateOfBirth
                };
                _context.Attach(pet);
                _context.Add(pet);
                _context.SaveChanges();
            }
            return pet;

        }
    }
}
