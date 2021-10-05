using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromosApp.Entities;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PalindromosApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalindromosController : ControllerBase
    {
        [HttpPost]
        public string POST(Frases dto)
        {
            string Frases = dto.frases.Replace(" ", String.Empty).ToLower();
            string caracter;
            string inverso = "";
            string msg;

            int i = Frases.Length;
            MatchCollection wordColl = Regex.Matches(dto.frases, @"[\W]+");

            for(int x = (i - 1); x >= 0; x--)
            {
                caracter = Frases.Substring(x, 1);
                inverso = inverso + caracter;
            }

            if (Frases == inverso)
            {
                msg = "Es Palindromio";
            }
            else
            {
                msg = "No es Palindromo";
            }
            
            Palindromos Palindromos = new Palindromos()
            {
                Frases = dto.frases,
                status = msg,
                Numero_Palabras = (wordColl.Count + 1)
            };

            string json = JsonSerializer.Serialize(Palindromos);

            return json;
        }
    }
}

