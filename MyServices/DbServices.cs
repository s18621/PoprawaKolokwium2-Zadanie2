using PoprawaKolokwium_Zadanie2.DTOs;
using PoprawaKolokwium_Zadanie2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium_Zadanie2.MyServices
{
    public interface DbServices
    {
        public Pet AddPet(PetRequest petRequest);
    }
}
