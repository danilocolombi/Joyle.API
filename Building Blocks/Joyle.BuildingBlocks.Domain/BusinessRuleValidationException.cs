using System;

namespace Joyle.BuildingBlocks.Domain
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {

        }
    }
}
