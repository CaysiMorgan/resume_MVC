using resume_MVC;
using System.Linq;
using System.Web;

namespace ResumeMVC.Repository
{
    public interface IResumeRepository
    {
        bool AddPersonnalInformation(Person person, HttpPostedFileBase file);
        string AddOrUpdateEducation(Education education, int idPer);
        int GetIdPerson(string firstName, string lastName);
        string AddOrUpdateExperience(WorkExperience workExperience, int idPer);
        bool AddSkill(Skill skill, int idPer);
        bool AddCertification(Certification certification, int idPer);
        Person GetPersonnalInfo(int idPer);
        IQueryable<Education> GetEducationById(int idPer);
        IQueryable<WorkExperience> GetWorkExperienceById(int idPer);
        IQueryable<Skill> GetSkillsById(int idPer);
        IQueryable<Certification> GetCertificationsById(int idPer);
    }
}