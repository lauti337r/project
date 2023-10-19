using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace project_be.Models
{
    [Table("Address")]
    public class AddressModel
    {
        public string Id { get; set; }
        public string CountryName { get; set; }
    }
    public static class CountryEndpoints
    {
        public static void MapCountryEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Country", async (ProjectDbContext db) =>
                {
                    return await db.Countries.ToListAsync();
                })
                .WithName("GetAllCountries");
        }
    }
}
