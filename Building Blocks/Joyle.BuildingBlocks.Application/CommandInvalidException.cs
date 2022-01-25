using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joyle.BuildingBlocks.Application
{
    public class CommandInvalidException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public CommandInvalidException(IEnumerable<string> erros)
        {
            this.Errors = erros;
        }

        public CommandInvalidException(string error)
        {
            this.Errors = new List<string>() { error };
        }

        public CommandInvalidException(ValidationResult validationResults)
        {
            if (validationResults == null)
                throw new Exception();

            this.Errors = validationResults.Errors.Select(e => e.ErrorMessage);
        }
    }
}
