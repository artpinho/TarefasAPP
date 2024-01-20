using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TarefasApp.Data;
using TarefasApp.Models;
using TarefasApp.Repositories.Interfaces;

namespace TarefasApp.Repositories
{
    
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksSystemsDBContext _dbContext;
        public TaskRepository(TasksSystemsDBContext tasksSystemsDBContext)
        {
            _dbContext = tasksSystemsDBContext;
        }
        public async Task<TaskModel> SearchTaskId(int id)
        {
            return await _dbContext.Tasks
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<TaskModel>> SearchAllTasks()
        {
            return await _dbContext.Tasks
            .Include(x => x.User)
            .ToListAsync();
        }        
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }
        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await SearchTaskId(id);
            if(taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await SearchTaskId(id);
            if(taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }        
        
    }
}