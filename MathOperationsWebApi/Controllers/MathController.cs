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
        /*private readonly ILogger<MathController> _logger;
        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
        }*/
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
        public IEnumerable<Calculation> Delete()//return empty IEnumerable 
        {
            using (var context = new MathDbContext())
            {
                context.Calculations.RemoveRange(context.Calculations.ToList());
                context.SaveChanges();
                return context.Calculations.ToArray();
            }
        }
        
        // POST api/<MathController>/<operationName>
        [HttpPost("{operationName}")]
        public CalcApiResult Post(string operationName, [FromBody] InputNumbers numbers)
        {
            Operation op;
            
            switch (operationName.ToLower())
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
                    throw new Exception("Nem definiált művelet! Csak az osszeadas, kivonas, szorzas, osztas illetve hatvanyozas műveleti kulcsszó használata elfogadott(ékezett nélkül)!"+
                        " api/math/<művelet>");

            }
            
            CalcApiResult calcApi;
            /// Calculate and save result into database
            using (var context = new MathDbContext())
            {
                calcApi = new CalcApiResult
                (
                    anum : numbers.ANum,
                    bnum : numbers.BNum,
                    muvelet : op.ToString(),
                    eredmeny : numbers.CalculateOperation(op.ToString())
                );
                
                Calculation calculation = new ()
                {
                    Created = DateTime.Now,
                    Anum = calcApi.ANum,
                    Bnum = calcApi.BNum,
                    Muvelet = calcApi.Muvelet,
                    Eredmeny = calcApi.Eredmeny
                };
                context.Calculations.Add(calculation);
                context.SaveChanges();
            }
            return calcApi;
        }
    }
}
