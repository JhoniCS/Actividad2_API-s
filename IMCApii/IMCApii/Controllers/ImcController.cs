using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IMCApii.Entities;
using System.Text.Json;

namespace IMCApii.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImcController : ControllerBase
    {
        [HttpPost]
        public string POST(Persona dto)
        {
            double resul = Math.Round((dto.peso / (Math.Pow((dto.altura/100), 2))), 2);
            string msg = "";

            if(resul < 18.5)
            {
                msg = "Bajo Peso.";
            }

            if(resul >= 18.5 && resul <= 24.9)
            {
                msg = "Peso Saludable.";
            }

            if(resul > 24.9 && resul <= 29.9)
            {
                msg = "Sobre Peso.";
            }

            if(resul > 29.9)
            {
                msg = "Obesidad.";
            }

            IMC imc = new IMC()
            {
                imc = resul,
                corporal = msg

            };

            string json = JsonSerializer.Serialize(imc);

            return json;
        }

        
    }
}