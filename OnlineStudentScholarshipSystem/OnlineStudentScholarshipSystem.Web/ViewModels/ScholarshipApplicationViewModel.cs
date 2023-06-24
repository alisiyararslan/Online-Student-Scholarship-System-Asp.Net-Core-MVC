namespace OnlineStudentScholarshipSystem.Web.ViewModels
{
    public class ScholarshipApplicationViewModel
    {



        private int id;

        private int studentId;

        private int scholarshipId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public int ScholarshipId
        {
            get { return scholarshipId; }
            set { scholarshipId = value; }
        }
    }
}
