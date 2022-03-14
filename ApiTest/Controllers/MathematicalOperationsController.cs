using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("add", Name = "Addition")]
        public IActionResult Add([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return Ok(mathematicalOperations.Add(firstValue, secondValue));
        }

        /// <summary>
        /// Subtraction of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting subtraction of both values</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("substract", Name = "Substraction")]
        public IActionResult Subtract([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return Ok(mathematicalOperations.Subtract(firstValue, secondValue));
        }

        /// <summary>
        /// Division of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting division of the first value by the second value</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("divide", Name = "Division")]
        public IActionResult Divide([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            if (secondValue == 0)
                return BadRequest("Cannot divide by zero.");

            return Ok(mathematicalOperations.Divide(firstValue, secondValue));
        }

        /// <summary>
        /// Multiplication of values
        /// </summary>
        /// <param name="firstValue">First value to be considered</param>
        /// <param name="secondValue">Second value to be considered</param>
        /// <returns>The resulting multiplication of both values</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("multiply", Name = "Multiplication")]
        public IActionResult Multiply([FromQuery] decimal firstValue, [FromQuery] decimal secondValue)
        {
            return Ok(mathematicalOperations.Multiply(firstValue, secondValue));
        }
    }
}