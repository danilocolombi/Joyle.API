using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.GetCardashian
{
    public class GetCardashianQuery : QueryBase<CardashianDto>
    {
        public Guid CardashianId { get; }

        public GetCardashianQuery(Guid cardashianId)
        {
            CardashianId = cardashianId;
        }

    }
}
