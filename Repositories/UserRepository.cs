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
    
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemsDBContext _dbContext;
        public UserRepository(TasksSystemsDBContext tasksSystemsDBContext)
        {
            _dbContext = tasksSystemsDBContext;
        }
        public async Task<UserModel> SearchUserId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }        
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await SearchUserId(id);
            if(userById == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await SearchUserId(id);
            if(userById == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }        
        
    }
}