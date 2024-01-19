using Microsoft.AspNetCore.Identity;
using FlightDeparture.Models.Entities;

namespace FlightDeparture.Data
{
    public class SeedData
    {
        public static ApplicationDbContext db = default!;

        public static async Task InitAsync(ApplicationDbContext context)
        {
            //##-< Setup >-####################################################################
            db = context;
            //#################################################################################


            //##-< Seed Departures >-##########################################################
            //                   (DepaWhen, FlName, Gat, Aircra, Destin)
            var departures = new (DateTime, string, int, string, string)[]
            {
                (DateTime.Now.AddMinutes(15), "AZ-135", 12, "Boing 747", "Amsterdam")
            };
            await SeedDeparturesAsync(departures);
            //#################################################################################


        }
        //#####################################################################################


        //##-< Seed Departures Method >-#######################################################
        private static async Task SeedDeparturesAsync((DateTime, string, int, string, string)[] departures)
        {
            DateTime departWhen; string name, aircraft, destination; int gate;
            foreach (var departure in departures)
            {
                (departWhen, name, gate, aircraft, destination) = departure;
                await db.Departures.AddAsync(new Departure
                {
                    DepartureWhen = departWhen,
                    Name = name,
                    Gate = gate,
                    Aircraft = aircraft,
                    Destination = destination
                });
            }
            await db.SaveChangesAsync();
        }
        //#################################################################################



    }
}
