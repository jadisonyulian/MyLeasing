using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner
    {
        public int id { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name ="Fist Name")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }

        [Display(Name = "Full Name")]
        public string Fullname => $"{FirstName} {LastName}";

        public string FullnameWithDocument => $"{FirstName} {LastName} - {Document}";


        public ICollection<Property> properties { get; set; }


        public ICollection<Contract> contracts { get; set; }

    }
}
