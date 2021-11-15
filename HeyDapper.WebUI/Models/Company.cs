using System.ComponentModel.DataAnnotations;

namespace HeyDapper.WebUI.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50)]
        public string State { get; set; }
        [Required, StringLength(255), Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}
