using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineStudentScholarshipSystem.Web.ViewModels
{
    public class UserViewModel
    {
        private int id;

        private string firstName;

        private string secondName;

        
        
        
        private string email;

        
        private string password;

        
        



        private string nationality;

        private string identificationNumber;

        private DateTime birthDate;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

       

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public string IdentificationNumber
        {
            get { return identificationNumber; }
            set { identificationNumber = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
    }
}
