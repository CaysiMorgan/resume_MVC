using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.Entity;
using resume_MVC;

namespace ResumeMVC.Repository
{
    public class ResumeRepository : IResumeRepository  
    {  
        //Db Context  
        private readonly ResumeEntities _dbContext = new ResumeEntities();  
  
        public bool AddCertification(Certification certification, int idPer)  
        {  
            try  
            {  
                int countRecords = 0;  
                Person personEntity = _dbContext.People.Find(idPer);  
  
                if (personEntity != null && certification != null)  
                {  
                    personEntity.Certifications.Add(certification);  
                    countRecords = _dbContext.SaveChanges();  
                }  
  
                return countRecords > 0 ? true : false;  
            }  
            catch (DbEntityValidationException)
            {  
  
                throw;  
            }  
             
        }  
  
        public string AddOrUpdateEducation(Education education, int idPer)  
        {  
            string msg = string.Empty;  
  
            Person personEntity = _dbContext.People.Find(idPer);  
  
            if(personEntity != null)  
            {  
                if (education.IDEdu > 0)  
                {  
                    //we will update education entity  
                    _dbContext.Entry(education).State = EntityState.Modified;  
                    _dbContext.SaveChanges();  
  
                    msg = "Education entity has been updated successfully";  
                }  
                else  
                {  
                    // we will add new education entity  
                    personEntity.Educations.Add(education);  
                    _dbContext.SaveChanges();  
  
                    msg = "Education entity has been Added successfully";  
                }  
            }  
  
            return msg;  
        }

        internal static bool AddPersonnalInformation(Person personEntity)
        {
            throw new NotImplementedException();
        }

        internal static object GetIDPers(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string AddOrUpdateExperience(WorkExperience workExperience, int idPer)  
        {  
            string msg = string.Empty;  
  
            Person personEntity = _dbContext.People.Find(idPer);  
  
            if (personEntity != null)  
            {  
                if (workExperience.IDExp > 0)  
                {  
                    //we will update work experience entity  
                    _dbContext.Entry(workExperience).State = EntityState.Modified;  
                    _dbContext.SaveChanges();  
  
                    msg = "Work Experience entity has been updated successfully";  
                }  
                else  
                {  
                    // we will add new work experience entity  
                    personEntity.WorkExperiences.Add(workExperience);  
                    _dbContext.SaveChanges();  
  
                    msg = "Work Experience entity has been Added successfully";  
                }  
            }  
  
            return msg;  
        }

        internal static string AddOrUpdateEducations(Education educationEntity, int idPer)
        {
            throw new NotImplementedException();
        }

        public bool AddPersonnalInformation(Person person, HttpPostedFileBase file)  
        {  
            try  
            {  
                int nbRecords = 0;  
  
                if (person != null)  
                {  
                    
                    _dbContext.People.Add(person);  
                    nbRecords = _dbContext.SaveChanges();  
                }  
  
                return nbRecords > 0 ? true : false;  
            }  
            catch (DbEntityValidationException dbEx)  
            {  
  
                Exception raise = dbEx;  
                foreach (var validationErrors in dbEx.EntityValidationErrors)  
                {  
                    foreach (var validationError in validationErrors.ValidationErrors)  
                    {  
                        string message = string.Format("{0}:{1}",  
                            validationErrors.Entry.Entity.ToString(),  
                            validationError.ErrorMessage);  
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);  
                    }  
                }  
                throw raise;  
            }  
              
        }

        internal static string AddOrUpdateWorkExperience(WorkExperience workExperienceEntity, int idPer)
        {
            throw new NotImplementedException();
        }

        public bool AddSkill(Skill skill, int idPer)  
        {  
            int countRecords = 0;  
            Person personEntity = _dbContext.People.Find(idPer);  
  
            if(personEntity != null && skill != null)  
            {  
                personEntity.Skills.Add(skill);  
                countRecords = _dbContext.SaveChanges();  
            }  
  
            return countRecords > 0 ? true : false;  
  
        }

        internal static bool AddSkills(Skill skillEntity, int idPer)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Certification> GetCertificationsById(int idPer)  
        {  
            var certificationList = _dbContext.Certifications.Where(w => w.IDPers == idPer);  
            return certificationList;  
        }  
  
        public IQueryable<Education> GetEducationById(int idPer)  
        {  
            var educationList = _dbContext.Educations.Where(e => e.IDPers == idPer);  
            return educationList;  
        }  
  
        public int GetIdPerson(string firstName, string lastName)  
        {  
            int idSelected = _dbContext.People.Where(p => p.FirstName.ToLower().Equals(firstName.ToLower()))  
                                              .Where(p => p.LastName.ToLower().Equals(lastName.ToLower()))  
                                              .Select(p => p.IDPers).FirstOrDefault();  
  
            return idSelected;  
        }  
  
        public Person GetPersonnalInfo(int idPer)  
        {  
            return _dbContext.People.Find(idPer);  
        }  
  
        public IQueryable<Skill> GetSkillsById(int idPer)  
        {  
            var skillsList = _dbContext.Skills.Where(w => w.IDPers == idPer);  
            return skillsList;  
        }  
  
        public IQueryable<WorkExperience> GetWorkExperienceById(int idPer)  
        {  
            var workExperienceList = _dbContext.WorkExperiences.Where(w => w.IDPers == idPer);  
            return workExperienceList;  
        }  
  
        private byte[] ConvertToBytes(HttpPostedFileBase image)  
        {  
            byte[] imageBytes = null;  
            BinaryReader reader = new BinaryReader(image.InputStream);  
            imageBytes = reader.ReadBytes((int)image.ContentLength);  
            return imageBytes;  
        }  
  
    }  
}  