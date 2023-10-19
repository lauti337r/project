using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace project_be.Models
{
    [Table("Address")]
    public class AddressModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
