using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service_Tasks.BLL.Models;
using Service_Tasks.DAL.Context;
using Service_Tasks.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;



namespace Service_Tasks.BLL.Services
{
    public class TasksService
    {
        //public object TestTask { get; set; }

        /*private readonly DbContext _dbContext;

        public TasksService (DbContext dbContext)
        {
            _dbContext = dbContext;
        }*/

        private readonly IMapper _mapper;
        private readonly WebApiDbContext _context;

        public TasksService(IMapper mapper, WebApiDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<TaskDTO> GetAllTaskDTOs ()
        {
            var taskEntitiesList = DbContext.Tasks;
            List<TaskDTO> taskDtosList = new List<TaskDTO> ();
            foreach (TaskEntity taskEntity in taskEntitiesList)
            {
                TaskDTO taskDTO = new TaskDTO ();
                taskDTO.Id = taskEntity.Id;
                taskDTO.Title = taskEntity.Title;
                taskDTO.Description = taskEntity.Description;
                taskDTO.Status = taskEntity.Status;
                taskDTO.CreatedDate = taskEntity.CreatedDate;
                taskDtosList.Add (taskDTO);
            }
            return taskDtosList;
        }

        public TaskDTO GetByIdTaskDTOs(int id)
        {
            var finded = DbContext.Tasks.Find(el => el.Id.Equals(id));
            if (finded is null)
            {
                throw new Exception();
            }

            TaskDTO taskDTO = new TaskDTO()
            {
                Id = finded.Id,
                Title = finded.Title,
                Description = finded.Description,
                Status = finded.Status,
                CreatedDate = finded.CreatedDate,
            };
            return taskDTO;
        }

        public TaskDTO AddNewTaskDTO (TaskDTO taskDTO)
        {
            TaskEntity taskEntity = new TaskEntity ();

            /*taskEntity.Id = taskDTO.Id;
            taskEntity.Title = taskDTO.Title;
            taskEntity.Description = taskDTO.Description;
            taskEntity.Status = taskDTO.Status;
            taskEntity.CreatedDate = taskDTO.CreatedDate;*/
            var task = _mapper.Map<TaskDTO>(taskEntity);
            DbContext.Tasks.Add (taskEntity);

            return taskDTO;
        }

        public TaskDTO RenameTaskDTO (TaskDTO taskDTO)
        {
            var finded = DbContext.Tasks.Find(el => el.Id == taskDTO.Id);
            finded.Title = taskDTO.Title;

            return taskDTO;
        }


        public bool DeleteTaskDTO(int id)
        {
            bool result = false;
            var finded = DbContext.Tasks.Find (el => el.Id == id);

            result = DbContext.Tasks.Remove (finded);

            return result;
        }
    }
}
