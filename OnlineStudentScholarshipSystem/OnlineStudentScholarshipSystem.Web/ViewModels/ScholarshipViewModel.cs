using System.ComponentModel.DataAnnotations;

namespace OnlineStudentScholarshipSystem.Web.ViewModels
{
    public class ScholarshipViewModel
    {
        private int id;

        [Required]
        private string name;

        [Required]
        private int amount;

        [Required]
        private string applicationCriteria;

        
        private string? foundation;

        [Required]
        private string description;

        [Required]
        private string educationLevel;

        [Required]
        private DateTime publishDate;

        [Required]
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
