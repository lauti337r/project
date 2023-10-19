using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using project_be;

namespace project_be.Models
{
    [Table("Project")]
    public class ProjectModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string CountryId { get; set; }

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

            routes.MapPost("/api/Project", async (ProjectModel projectModel, ProjectDbContext db) =>
                {
                    //Check that country exists

                    var country = await db.Countries.FirstOrDefaultAsync(c => c.Id == projectModel.CountryId);
                    if (country == null)
                    {
                        return Results.BadRequest("Invalid country");
                    }

                    db.Projects.Add(projectModel);
                    await db.SaveChangesAsync();
                    return Results.Created($"/Projects/{projectModel.Id}", projectModel);
                })
                .WithName("CreateProject");
        }
    }
}
