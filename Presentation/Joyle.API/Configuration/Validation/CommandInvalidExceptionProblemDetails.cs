using Joyle.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Joyle.API.Configuration.Validation
{
    public class CommandInvalidExceptionProblemDetails : ProblemDetails
    {
        public IEnumerable<string> Errors { get; }

        public CommandInvalidExceptionProblemDetails(CommandInvalidException exception)
        {
            Title = "Error";
            Status = StatusCodes.Status400BadRequest;
            Errors = exception.Errors;
            Detail = "Error processing command";
        }
    }
}
