using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service_Tasks.BLL.Models;
using Service_Tasks.DAL.Context;
using Service_Tasks.DAL.Entities;



namespace Service_Tasks.BLL.Services
{
    public class TasksService
    {
        private readonly DBContext _context;

        public TasksService (DBContext context)
        {
            _context = context;
        }

        public List<TaskDTO> GetAllTaskDTOs ()
        {
            var taskEntitiesList = DBContext.Tasks;
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

        public TaskDTO AddNewTaskDTO (TaskDTO taskDTO)
        {
            TaskEntity taskEntity = new TaskEntity ();

            taskEntity.Id = taskDTO.Id;
            taskEntity.Title = taskDTO.Title;
            taskEntity.Description = taskDTO.Description;
            taskEntity.Status = taskDTO.Status;
            taskEntity.CreatedDate = taskDTO.CreatedDate;
            DBContext.Tasks.Add (taskEntity);

            return taskDTO;
        }

    }
}
