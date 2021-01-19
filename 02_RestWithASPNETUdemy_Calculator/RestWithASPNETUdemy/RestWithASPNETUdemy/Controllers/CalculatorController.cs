using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{op}/{firstNumber}/{secondNumber}")]

        public IActionResult Get(string op, string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (op == "sum")
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    op = sum.ToString();
                }
                else if(op == "sub")
                {
                    var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    op = sub.ToString();
                }
                else if (op == "div")
                {
                    if (ConvertToDecimal(secondNumber) != 0 || ConvertToDecimal(secondNumber) > 0)
                    {
                        var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                        op = div.ToString();
                    }
                    else
                    {
                        return BadRequest("Não se divide por ZERO");
                    }
                }
                else if (op == "multi")
                {
                        var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        op = multi.ToString();
                }
                else if (op == "media")
                {
                    var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                    op = media.ToString();
                }
                else if (op == "raiz")
                {
                    var raiz = Math.Sqrt((ConvertToDouble(firstNumber)));
                    op = raiz.ToString();
                }
                return Ok(op.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}
