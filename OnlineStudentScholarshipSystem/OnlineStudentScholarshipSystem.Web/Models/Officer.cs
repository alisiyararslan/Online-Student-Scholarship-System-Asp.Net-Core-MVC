namespace OnlineStudentScholarshipSystem.Web.Models
{
    public class Officer:User
    {
        private string companyName;

        public string CompanyName { get => companyName; set => companyName = value; }
    }
}
