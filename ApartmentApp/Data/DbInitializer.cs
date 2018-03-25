using ApartmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApartmentContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var users = new User[] {
                    new User {
                        FirstName = "Rudi", LastName="Cuypers",
                        Email="rudi_cuypers@hotmail.com",
                        City = "Merksem",
                        Street = "Lambrechtshoekenlaan",
                        Zip = "2170",
                        EnrollmentDate = DateTime.Parse("01-01-1992")
                    },
                    new User {
                        FirstName = "Dominica", LastName="Vercammen",
                        Email="dominicavercammen@gmail.com",
                        City = "Merksem",
                        Street = "Lambrechtshoekenlaan",
                        Zip = "2170",
                        EnrollmentDate = DateTime.Parse("01-01-1992")
                    },
                    new User {
                        FirstName = "name", LastName="lastnae",
                        Email="test@gmail.com",
                        City = "Merksem",
                        Street = "Lambrechtshoekenlaan",
                        Zip = "2170",
                        EnrollmentDate = DateTime.Parse("01-01-2010")
                    }
            };
            foreach (User u in users) {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var Apartments = new Apartment[] {
                new Apartment { ApartmentID = 10 , Garage=true, Name="B3" },
                new Apartment { ApartmentID = 11 , Garage=false, Name="A1" }
            };
            foreach (Apartment a in Apartments)
            {
                context.Apartments.Add(a);
            }
            context.SaveChanges();

            var ApartmentUsers = new UserApartment[] {
                new UserApartment { ApartmentID = 10 , UserID = 1, Owner = true, Resident = true },
                new UserApartment { ApartmentID = 10 , UserID = 2, Owner = false, Resident = true  },
                new UserApartment { ApartmentID = 11 , UserID = 3, Owner = true, Resident = false  }
            };

            
            foreach (UserApartment a in ApartmentUsers)
            {
                context.UserApartments.Add(a);
            }
            context.SaveChanges();
        }
    }
}
