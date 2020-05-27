using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTask.Entity.Models;

namespace WebApplicationTask.Api.Helpers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile() 
        {
            CreateMap<Base_User, Base_UserDTO>();
        }
}

    internal class Base_UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
    }
}
