using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace resume_MVC.ViewModel
{
   
        public class CertificationVM
        {
            [Required(ErrorMessage = "Please Your Certification name")]
            public string CertificationName { get; set; }

           [Required(ErrorMessage = "Please select Certification Level")]
            public string LevelCertification { get; set; }

            [Required(ErrorMessage = "Please select achievement date")]
            public Nullable<System.DateTime> FromYear { get; set; }

            public List<SelectListItem> ListOfLevel { get; set; }
        }
    }
