using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp.DataBaseCreate.Models
{
    public static class DbInitializer    
    {
        public static void Initialize(MathContext context)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0
            //Write into Api host builder
            context.Database.EnsureCreated();

            if (context.Calculations.Any()) 
                return;

            var calculations = new Calculation[]
            {
                new Calculation{CalculationId=1, ANum=2,BNum=3.2,Result=2+3.2,Operation=Operation.összeadás, Created=DateTime.Now.AddDays(1.5)},
                new Calculation{CalculationId=2, ANum=2,BNum=3,Result=-1,Operation=Operation.kivonás, Created=DateTime.Now.AddDays(-.5)},
                new Calculation{CalculationId=3, ANum=5,BNum=3,Result=5/3,Operation=Operation.osztás, Created=DateTime.Now.AddHours(.7)},
                new Calculation{CalculationId=4, ANum=7,BNum=3.5,Result=7*3.5,Operation=Operation.szorzás, Created=DateTime.Now.AddSeconds(1500)},
                new Calculation{CalculationId=5, ANum=4,BNum=0.5,Result=Math.Pow(4,0.5),Operation=Operation.hatványozás, Created=DateTime.UtcNow.AddMinutes(1.5)},
            };

            calculations.AsParallel().ForAll(s => context.Calculations.Add(s));///Ids?
            context.SaveChangesAsync();///Vs simple SaveChanges
        }
    }
}
