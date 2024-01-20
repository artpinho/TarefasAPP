using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Models;

namespace TarefasApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchUserId(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}