using System.Diagnostics.CodeAnalysis;

namespace OnlineStudentScholarshipSystem.Web.ViewModels
{
    public class StudentViewModel: UserViewModel
    {
        private string educationLevel;

        private bool isDisabled;

        private bool gender;

        private bool isDisciplined;

        private bool haveVehicleLicense;

        private string address;

        private double gradeAverage;

        
        private string? motherName;

        private bool isMotherAlive;

        
        private string? fatherName;

        private bool isFatherAlive;

        private int siblingsCount;

        private int totalFamilyIncome;


        public string EducationLevel
        {
            get { return educationLevel; }
            set { educationLevel = value; }
        }

        public bool IsDisabled { get => isDisabled; set => isDisabled = value; }
        public bool Gender { get => gender; set => gender = value; }
        public bool IsDisciplined { get => isDisciplined; set => isDisciplined = value; }
        public bool HaveVehicleLicense { get => haveVehicleLicense; set => haveVehicleLicense = value; }
        public string Address { get => address; set => address = value; }
        public double GradeAverage { get => gradeAverage; set => gradeAverage = value; }
        public string? MotherName { get => motherName; set => motherName = value; }
        public bool IsMotherAlive { get => isMotherAlive; set => isMotherAlive = value; }
        public string? FatherName { get => fatherName; set => fatherName = value; }
        public bool IsFatherAlive { get => isFatherAlive; set => isFatherAlive = value; }
        public int SiblingsCount { get => siblingsCount; set => siblingsCount = value; }
        public int TotalFamilyIncome { get => totalFamilyIncome; set => totalFamilyIncome = value; }
    }
}
