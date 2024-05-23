using ApplicationCore.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApplicationCore.Entities
{
    public class Patient
    {
        public Patient()
        {
           
            SelectedNCDList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public int DiseaseId { get; set; }
        [Required]
        public int EpilepsyType { get; set; }

        [NotMapped]
        public string SelectedNCDs { get; set; }

        [NotMapped]
        public string SelectedAllergies { get; set; }

        [NotMapped]
        public List<SelectListItem>? NCDs { get; set; }
        [NotMapped]
        public List<SelectListItem>? SelectedNCDList { get; set; }
        
        [NotMapped]
        public List<SelectListItem>? Allergies { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Diseases { get; set; }


    }

}

