using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using TarefasApp.Integration.Response;

namespace TarefasApp.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}