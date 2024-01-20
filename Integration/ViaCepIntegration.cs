using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Integration.Interfaces;
using TarefasApp.Integration.Refit;
using TarefasApp.Integration.Response;

namespace TarefasApp.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var respondeData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if(respondeData != null && respondeData.IsSuccessStatusCode)
            {
                return respondeData.Content;
            }

            return null;
        }
    }
}