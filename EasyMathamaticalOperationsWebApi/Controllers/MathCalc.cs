using MathOp.Data.Models;
using System;

namespace MathOperations.WebApi.Controllers
{
    internal class MathCalc
    {
        /// <summary>
        /// If Operation is osztás and bNum 0 -> ZeroDivideException...
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="aNum"></param>
        /// <param name="bNum"></param>
        /// <returns></returns>
        //internal static double CalculateOperation(string operationName, InputNumbers numbers)
        //{
        //    Operation op = (Operation) Enum.Parse(typeof(Operation), operationName);
        //    double aNum, double bNum;
        //    (aNum, bNum) = (numbers.ANum, numbers.BNum);
        //    double result;
        //    switch (op)
        //    {
        //        case Operation.összeadás:
        //            result = aNum + bNum;
        //            break;
        //        case Operation.kivonás:
        //            result = aNum - bNum;
        //            break;
        //        case Operation.szorzás:                    
        //            result = aNum * bNum;
        //            break;
        //        case Operation.osztás:                   
        //            result = aNum / bNum;
        //            break;
        //        case Operation.hatványozás:
        //            result = Math.Pow(aNum, bNum);
        //            break;
        //        default:
        //            throw new Exception("Nem definált funkció!");                                    
        //    }
        //    return result;
        //}
    }
}