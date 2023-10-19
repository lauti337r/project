using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                    //Check country is valid
                    var client = new HttpClient();
                    var response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries/states");
                    
                    ExternalApiResponse<ExternalApiCountry> externalApiResponse = JsonConvert.DeserializeObject<ExternalApiResponse<ExternalApiCountry>>(await response.Content.ReadAsStringAsync());

                    var country = externalApiResponse.Data.FirstOrDefault(c => c.iso2 == projectModel.CountryId);
                    if (country == null)
                    {
                        return Results.BadRequest("Invalid country");
                    }

                    //Check if country already exists in db
                    var countryExists = (await db.Countries.FirstOrDefaultAsync(c => c.Id == projectModel.CountryId)) != null;

                    if (!countryExists)
                    {
                        db.Countries.Add(new AddressModel()
                            { CountryName = country.Name, Id = projectModel.CountryId });
                    }

                    db.Projects.Add(projectModel);
                    await db.SaveChangesAsync();
                    return Results.Created($"/Projects/{projectModel.Id}", projectModel);
                })
                .WithName("CreateProject");
        }
    }
}
