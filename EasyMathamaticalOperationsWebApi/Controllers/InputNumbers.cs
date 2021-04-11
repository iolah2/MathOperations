using MathOp.Data.Models;
using System;

namespace MathOperations.WebApi.Controllers
{
    /// <summary>
    /// We use this class for the input numbers store while operation calculate the result.
    /// </summary>
    public class InputNumbers
    {


        public InputNumbers(double aNum, double bNum)
        {
            ANum = aNum;
            BNum = bNum;
        }

        public double ANum { get; }
        public double BNum { get; }

        public double CalculateOperation(string operationName)
        {
            Operation op;
            try
            {
                op = (Operation)Enum.Parse(typeof(Operation), operationName);
            }
            catch
            {
                /// If we wrote HttpPost well, this will be called never.
                /// I set a prefilter there before call CalculateOperation function
                throw new Exception("Az őn által kért művelet nincs a válsztható műveletek között!");
            }
            // VS2019 message offered by message this "lambda" version            
            return op switch
            {
                Operation.összeadás => ANum + BNum,
                Operation.kivonás => ANum - BNum,
                Operation.szorzás => ANum * BNum,
                Operation.osztás => ANum / BNum,
                Operation.hatványozás => Math.Pow(ANum, BNum),
                _ => throw new Exception("A művelet nincs megvalósítva!"),
            };

            #region my fisrt switch version - just other format
            /*double result;
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
                default:
                    throw new Exception("A művelet nincs megvalósítva!");
            }
            return result;*/
            #endregion

        }
    }
}