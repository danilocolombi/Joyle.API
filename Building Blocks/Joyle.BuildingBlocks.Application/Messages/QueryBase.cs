﻿using System;

namespace Joyle.BuildingBlocks.Application.Messages
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public Guid Id { get; }

        protected QueryBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected QueryBase(Guid id)
        {
            this.Id = id;
        }
    }
}
