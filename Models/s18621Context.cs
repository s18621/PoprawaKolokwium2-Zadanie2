using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium_Zadanie2.Models
{
    public class s18621Context : DbContext
    {
        public s18621Context()
        {

        }

        public s18621Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BreedType> BreedTypes {get;set;}
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Volunteer_Pet> Volunteer_Pets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BreedType>(opt =>
            {
                opt.HasKey(k => k.IdBreedType);
                opt.Property(k => k.IdBreedType).ValueGeneratedOnAdd();
                opt.Property(k => k.Name).HasMaxLength(50).IsRequired();
                opt.Property(k => k.Description).HasMaxLength(500);

            });

            modelBuilder.Entity<Volunteer>(opt =>
            {
                opt.HasKey(k => k.IdVolunteer);
                opt.Property(k => k.IdVolunteer).ValueGeneratedOnAdd();
                opt.Property(k => k.Name).HasMaxLength(80).IsRequired();
                opt.Property(k => k.Surname).HasMaxLength(80).IsRequired();
                opt.Property(k => k.Phone).HasMaxLength(30).IsRequired();
                opt.Property(k => k.Address).HasMaxLength(100).IsRequired();
                opt.Property(k => k.Email).HasMaxLength(80).IsRequired();
                opt.Property(k => k.StartingDate).IsRequired();

                
            });

            modelBuilder.Entity<Pet>(opt =>
            {
                opt.HasKey(k => k.IdPet);
                opt.Property(k => k.IdPet).ValueGeneratedOnAdd();
                opt.Property(k => k.Name).HasMaxLength(80).IsRequired();
                opt.Property(k => k.IsMale).IsRequired();
                opt.Property(k => k.DateRegistered).IsRequired();
                opt.Property(k => k.DateOfBirth).IsRequired();
                opt.Property(k => k.DateAdopted);

                opt.HasOne(k => k.BreedType).WithMany(m => m.Pets).HasForeignKey(k => k.IdBreedType);

            });

            modelBuilder.Entity<Volunteer_Pet>(opt =>
            {
                opt.HasKey(k => k.IdVolunteer);
                opt.HasKey(k => k.IdPet);
                opt.Property(k => k.DateAccepted).IsRequired();

                opt.HasOne(k => k.Pet).WithMany(m => m.Volunteer_pets).HasForeignKey(k => k.IdPet);
                opt.HasOne(k => k.Volunteer).WithMany(m => m.Volunteer_Pets).HasForeignKey(k => k.IdVolunteer);

            });

        }



    }
}
