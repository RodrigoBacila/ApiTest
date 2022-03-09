using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("math")]
    public class MathematicalOperationsController : ControllerBase
    {
        private readonly IMathematicalOperations mathematicalOperations;

        public MathematicalOperationsController(IMathematicalOperations mathematicalOperations)
        {
            this.mathematicalOperations = mathematicalOperations;
        }

        [HttpGet("add")]
        public int Add([FromQuery] int firstValue, [FromQuery] int secondValue)
        {
            return mathematicalOperations.Add(firstValue, secondValue);
        }

        [HttpGet("substract")]
        public int Substract([FromQuery] int firstValue, [FromQuery] int secondValue)
        {
            return mathematicalOperations.Substract(firstValue, secondValue);
        }

        [HttpGet("divide")]
        public int Divide([FromQuery] int firstValue, [FromQuery] int secondValue)
        {
            return mathematicalOperations.Divide(firstValue, secondValue);
        }

        [HttpGet("multiply")]
        public int Multiply([FromQuery] int firstValue, [FromQuery] int secondValue)
        {
            return mathematicalOperations.Multiply(firstValue, secondValue);
        }
    }
}