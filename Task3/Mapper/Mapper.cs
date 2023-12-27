using AutoMapper;
using Task3.Models;
using Task3.Models.DTOs;

namespace Task3.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, Employee>();
            //CreateMap<Employee, EmployeeDTO>();
            //CreateMap<EmployeeDTO, Employee>();
        }
    }
}
