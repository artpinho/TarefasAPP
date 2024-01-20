using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TarefasApp.Integration;
using TarefasApp.Integration.Interfaces;
using TarefasApp.Integration.Response;

namespace TarefasApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListDataAdress(string cep)
        {
            var responseData = await _viaCepIntegration.GetDataViaCep(cep);

            if(responseData == null)
            {
                return BadRequest("CEP não encontrado!");
            }

            return Ok(responseData);
        }
    }
}