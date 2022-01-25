using System;

namespace Joyle.BuildingBlocks.Application.Messages
{
    public class CommandBase : ICommand
    {
        public Guid Id { get; }
        public DateTime OcurredOn { get; }

        protected CommandBase()
        {
            this.OcurredOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid();
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }
        public DateTime OcurredOn { get; }

        protected CommandBase()
        {
            this.OcurredOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid();
        }
    }
}
