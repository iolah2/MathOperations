using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp.Data.Models
{
    public static class DbInitializer
    {
        public static void Initialize(MathDbContext context)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0
            //Write into Api host builder
            context.Database.EnsureCreated();

#if DEBUG           
            
            if (context.Calculations.Any()) 
              return;
            var calculations = new Calculation[]
            {
                new Calculation{Id=1, Anum=2,Bnum=3.2,Eredmeny=2+3.2,Muvelet= "összeadás", Created=DateTime.Now.AddDays(1.5)},
                new Calculation{Id=2, Anum=2,Bnum=3,Eredmeny=-1,Muvelet= "kivonás", Created=DateTime.Now.AddDays(-.5)},
                new Calculation{Id=3, Anum=5,Bnum=3,Eredmeny=5/3,Muvelet= "osztás", Created=DateTime.Now.AddHours(.7)},
                new Calculation{Id=4, Anum=7,Bnum=3.5,Eredmeny=7*3.5,Muvelet= "szorzás", Created=DateTime.Now.AddSeconds(1500)},
                new Calculation{Id=5, Anum=4,Bnum=0.5,Eredmeny=Math.Pow(4,0.5),Muvelet="hatványozás", Created=DateTime.UtcNow.AddMinutes(1.5)},
                //new Calculation{CalculationId=4, ANum=7,BNum=3.5,Result=7*3.5,Operation=Operation.szorzás, Created=DateTime.Now.AddSeconds(1500)},
                //new Calculation{CalculationId=5, ANum=4,BNum=0.5,Result=Math.Pow(4,0.5),Operation=Operation.hatványozás, Created=DateTime.UtcNow.AddMinutes(1.5)},
            };
            foreach (var calc in calculations)
            {
                context.Calculations.Add(calc);
            }
            context.SaveChanges();
            #endif
        }
    }
}
