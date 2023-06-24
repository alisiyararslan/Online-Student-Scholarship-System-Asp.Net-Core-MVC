using AutoMapper;
using OnlineStudentScholarshipSystem.Web.Models;
using OnlineStudentScholarshipSystem.Web.ViewModels;

namespace OnlineStudentScholarshipSystem.Web.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Scholarship,ScholarshipViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Officer, OfficerViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<ScholarshipApplication, ScholarshipApplicationViewModel>().ReverseMap();
        }
    }
}
