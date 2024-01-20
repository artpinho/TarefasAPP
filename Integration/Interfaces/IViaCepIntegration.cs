using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Integration.Response;

namespace TarefasApp.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDataViaCep(string cep);
    }
}