using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using project_be;

namespace project_be.Models
{
    [Table("Project")]
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")] 
        public AddressModel Country { get; set; }
    }


    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Project", async (ProjectDbContext db) =>
            {
                return await db.Projects.Include(p => p.Country).ToListAsync();
            })
            .WithName("GetAllProjects");
        }
    }
}
