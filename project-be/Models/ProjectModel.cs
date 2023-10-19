using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace project_be.Models
{
    [Table("Project")]
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CountryId { get; set; }
        public AddressModel Country { get; set; }
    }
}
