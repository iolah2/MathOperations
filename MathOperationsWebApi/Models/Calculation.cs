using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MathOp.Data.Models
{    
    public enum Operation
    {
        összeadás, kivonás, szorzás, osztás, hatványozás
    }    
    
    /// <summary>
    /// SQLite table class
    /// </summary>
    public class Calculation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double Anum { get; set; }
        public double Bnum { get; set; }        
        public string Muvelet { get; set; }
        public double Eredmeny { get; set; }
    }

    /// <summary>
    /// This will send data to create json file    
    /// </summary>
    public class CalcApiResult
    {
        public CalcApiResult(double anum, double bnum, string muvelet, double eredmeny)
        {
            ANum = anum;
            BNum = bnum;
            Muvelet = muvelet;
            Eredmeny = eredmeny;
        }

        public double ANum { get; }
        public double BNum { get; }
        public string Muvelet { get; }
        public double Eredmeny { get; }
    }
}
