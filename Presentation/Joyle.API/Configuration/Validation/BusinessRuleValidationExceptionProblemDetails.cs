using Joyle.BuildingBlocks.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Joyle.API.Configuration.Validation
{
    public class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public IEnumerable<string> Errors { get; }

        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Error";
            Status = StatusCodes.Status400BadRequest;
            Errors = new List<string>() { exception.Message };
        }
    }
}
