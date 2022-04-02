using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Games.Domain.Cardashians
{
    public class CardashianCard : Entity
    {
        public string Description { get; private set; }
        public int Position { get; private set; }
        public Guid CardashianId { get; private set; }

        protected CardashianCard() { }

        internal CardashianCard(
            string description,
            int position,
            Guid cardashianId)
        {
            Id = Guid.NewGuid();
            Description = description;
            Position = position;
            CardashianId = cardashianId;
        }

        public void SetPosition(int newPosition)
        {
            this.Position = newPosition;
        }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }

    }
}
