using Calculator.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICommandExecutionService _commandExecutionService;

        public CalculatorController(ICommandExecutionService commandExecutionService)
        {
            _commandExecutionService = commandExecutionService;
        }

        //RestApi should not have verb as their name
        //for example GetEmployee is not correct rather the route should be api/employees/{employeeId}
        //which is why I decide to have one route to pass api/calculator/{operator}/{firstOperand}/{secondOperand}
        //e.g api/calculator/addition/1/2 
        //as opposed to api/calculator/add/{firstOperand}/{secondOperand}
        [HttpGet]
        [Route("{operator}/{firstOperand}/{secondOperand}")]
        public IActionResult Calculate(string @operator, decimal firstOperand, decimal secondOperand)
        {
            return SafeExecute(() =>
                _commandExecutionService.Run(@operator, firstOperand, secondOperand)
            );
        }

        private IActionResult SafeExecute<T>(Func<T> action)
        {
            try
            {
                return new OkObjectResult(action());
            }
            catch (Exception exception)
            {
                //log full exception stack in real situations before returning
                //_logService.Error(exception);
                return new BadRequestObjectResult(exception.Message);
            }
        }
    }
}
