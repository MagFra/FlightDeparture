using FlightDeparture.Data;
using FlightDeparture.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace FlightDeparture.Components
{
    public partial class Departures
    {
        protected List<Departure>? departures = null;

        [Inject]
        public required ApplicationDbContext Db { get; set; }
        protected override async Task OnInitializedAsync()
        {
            departures = await Db.Departures.Where(d => d.DepartureWhen >= DateTime.Now).ToListAsync();
        }
    }
}