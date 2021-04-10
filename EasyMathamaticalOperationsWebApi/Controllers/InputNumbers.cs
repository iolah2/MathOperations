using MathOp.Data.Models;
using System;

namespace MathOperations.WebApi.Controllers
{
    public class InputNumbers
    {
        public InputNumbers(double aNum, double bNum)
        {
            ANum = aNum;
            BNum = bNum;
        }

        public double ANum { get; internal set; }
        public double BNum { get; internal set; }

        public double CalculateOperation(string operationName)
        {
            Operation op;
            try
            {
                op = (Operation)Enum.Parse(typeof(Operation), operationName);
            }
            catch
            {
                throw new Exception("Az őn által kért művelet nincs a válsztható műveletek között!");
            }

            double result;
            switch (op)
            {
                case Operation.összeadás:
                    result = ANum + BNum;
                    break;
                case Operation.kivonás:
                    result = ANum - BNum;
                    break;
                case Operation.szorzás:
                    result = ANum * BNum;
                    break;
                case Operation.osztás:
                    result = ANum / BNum;
                    break;
                case Operation.hatványozás:
                    result = Math.Pow(ANum, BNum);
                    break;
                ///If Operation get new item and here that case hasn't written yet.
                ///Now just needed because switch always need default case
                default: 
                    throw new Exception("A művelet nincs megvalósítva!");
            }
            return result;
        }
    }
}