using MathOp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MathOperations.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly ILogger<MathController> _logger;
        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
        }
        // GET: api/<MathController>/history
        [HttpGet("history")]
        public IEnumerable<Calculation> Get()
        {
            using (var context = new MathDbContext())
            {
                return context.Calculations.ToArray();
            }
        }

        // DELETE api/<MathController>/history
        [HttpDelete("history")]
        public void Delete()
        {
            using (var context = new MathDbContext())
            {
                context.Calculations.RemoveRange(context.Calculations.ToList());
                context.SaveChanges();
            }
        }

        // POSTí https://stackoverflow.com/questions/35937118/build-json-response-in-web-api-controller - kell még a json file!!!
        // https://gist.github.com/rheone/11092375
        // POST api/<MathController>/<operationName>
        [HttpPost("{operationName}")]
        public CalcApi Post(string operationName, [FromBody] InputNumbers numbers)
        {
            Operation op;
            switch (operationName)
            {
                case "osszeadas":
                    op = Operation.összeadás;
                    break;
                case "kivonas":
                    op = Operation.kivonás;
                    break;
                case "szorzas":
                    op = Operation.szorzás;
                    break;
                case "osztas":
                    op = Operation.osztás;
                    if (numbers.BNum == 0)
                        throw new DivideByZeroException("Nullával való osztás nem értelmezhető! A számítás nem került rögzítésre.");
                    break;
                case "hatvanyozas":
                    op = Operation.hatványozás;
                    break;
                default:
                    throw new Exception("Nem definiált művelet! Csak osszeadas, kivonas, szorzas, osztas illetve hatvanyozas műveleti kulcsszó használata elfogadott!"+
                        " api/math/<művelet>");

            }
            CalcApi calcApi;
            using (var context = new MathDbContext())
            {
                calcApi = new CalcApi
                (
                    anum : numbers.ANum,
                    bnum : numbers.BNum,
                    muvelet : op.ToString(),
                    eredmeny : numbers.CalculateOperation(op.ToString())
                );
                //try
                //{
                Calculation calculation = new Calculation
                {
                    Created = DateTime.Now,
                    Anum = calcApi.ANum,
                    Bnum = calcApi.BNum,
                    Muvelet = calcApi.Muvelet,
                    Eredmeny = calcApi.Eredmeny
                };
                context.Calculations.Add(calculation);
                context.SaveChanges();
                
                //}
                //catch (Exception ex)
                //{
                //    ;
                //}                
            }
            return calcApi;
        }
    }
}
