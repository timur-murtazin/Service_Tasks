using AutoMapper;
using Service_Tasks.BLL.Models;
using Service_Tasks.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tasks.BLL.Services
{
    public class AppMappingService : Profile
    {
        public AppMappingService() 
        {
            CreateMap<TaskDTO, TaskEntity>().ReverseMap();
        }
    }
}
