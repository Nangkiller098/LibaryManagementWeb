using AutoMapper;
using LibaryManagementWeb.Data;
using LibaryManagementWeb.Models;

namespace LibaryManagementWeb.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
