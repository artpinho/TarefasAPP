using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Models;

namespace TarefasApp.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> SearchAllTasks();
        Task<TaskModel> SearchTaskId(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}