using System.Xml.Linq;

namespace OnlineStudentScholarshipSystem.Web.Models
{
    public class Scholarship
    {
        private int id;

        private string name;

        private int amount;

        private string applicationCriteria;

        private string? foundation;

        private string description;

        private string educationLevel;

        private DateTime publishDate; 
        
        private DateTime deadline;

        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string ApplicationCriteria
        {
            get { return applicationCriteria; }
            set { applicationCriteria = value; }
        }

        public string? Foundation
        {
            get { return foundation; }
            set { foundation = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string EducationLevel
        {
            get { return educationLevel; }
            set { educationLevel = value; }
        }

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        public DateTime Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }
    }
}
