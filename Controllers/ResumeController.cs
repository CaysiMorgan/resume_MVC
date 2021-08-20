using AutoMapper;
using resume_MVC.ViewModel;
using ResumeMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;

namespace resume_MVC.Controllers
{
    public class ResumeController : Controller
    {
        
        [HttpGet]  
    public ActionResult PersonnalInformtion(PersonVM person)  
        {  
     return View();  
} 
        
       [HttpGet]
        public ActionResult Education(EducationVM education)
        {
            return View();
        }

        [HttpGet]
        public ActionResult WorkExperience(WorkExperienceVM workExperience)
        {
            return View();
        }
    
        [HttpGet]
        public ActionResult Skills(SkillsVM skills)
        {
            return View();
        }
        
        public ActionResult Certification(CertificationVM certification) 
        {
            return View();
        }
     
         
    }
}