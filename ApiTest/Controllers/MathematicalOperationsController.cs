using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    /// <summary>
    /// Mathematical Operations
    /// </summary>
    [ApiController]
    [Route("math")]
    public class MathematicalOperationsController : ControllerBase
    {
        private readonly IMathematicalOperations mathematicalOperations;

        public MathematicalOperationsController(IMathematicalOperations mathematicalOperations)
        {
            this.mathematicalOperations = mathematicalOperations;
        }

        /// <summary>
        /// Addition of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting addition operation of both values</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [HttpGet("add", Name = "Addition")]
        public decimal Add([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return mathematicalOperations.Add(firstValue, secondValue);
        }

        /// <summary>
        /// Subtraction of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting subtraction of both values</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [HttpGet("substract", Name = "Substraction")]
        public decimal Substract([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return mathematicalOperations.Substract(firstValue, secondValue);
        }

        /// <summary>
        /// Division of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting division of the first value by the second value</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [HttpGet("divide", Name = "Division")]
        public decimal Divide([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return mathematicalOperations.Divide(firstValue, secondValue);
        }

        /// <summary>
        /// Multiplication of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting multiplication of both values</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [HttpGet("multiply", Name = "Multiplication")]
        public decimal Multiply([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return mathematicalOperations.Multiply(firstValue, secondValue);
        }
    }
}