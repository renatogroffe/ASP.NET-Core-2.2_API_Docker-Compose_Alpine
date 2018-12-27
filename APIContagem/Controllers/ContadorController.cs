using System;
using Microsoft.AspNetCore.Mvc;

namespace APIContagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorController : ControllerBase
    {
        private static Contador _CONTADOR = new Contador();

        [HttpGet]
        public object Get()
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();

                return new
                {
                    _CONTADOR.ValorAtual,
                    Environment.MachineName,
                    Sistema = Environment.OSVersion.VersionString
                };
            }
        }
    }
}