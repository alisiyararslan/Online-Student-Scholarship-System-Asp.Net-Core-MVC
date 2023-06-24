using Microsoft.EntityFrameworkCore;

namespace OnlineStudentScholarshipSystem.Web.Models
{
    public class Company
    {
        
        private int id;

        string name;

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
    }
}
