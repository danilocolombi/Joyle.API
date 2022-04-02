using Joyle.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joyle.Games.Domain.Cardashians
{
    public class Cardashian : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public bool IsPublic { get; private set; }
        public Guid AuthorId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<CardashianCard> Cards { get; private set; }

        public const int MaxNumberOfCards = 100;

        protected Cardashian() { }

        public static Cardashian NewCardashian(
           string title,
           bool isPublic,
           Guid authorId)
        {
            return new Cardashian(title, isPublic, authorId);
        }

        private Cardashian(
            string title,
            bool isPublic,
            Guid authorId)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.IsPublic = isPublic;
            this.AuthorId = authorId;
            this.CreationDate = DateTime.Now;
            this.Cards = new List<CardashianCard>();
        }

        public void AddCard(Guid authorId, string description)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author of the Cardashian can add new cards");

            if (!CanAddMoreCards())
                throw new BusinessRuleValidationException($"You can't have more than {MaxNumberOfCards} in a Cardashian");

            if (CardDescriptonAlreadyUsed(description))
                throw new BusinessRuleValidationException("There is already a card with this description");

            if (!AreThereAnyCards())
                Cards = new List<CardashianCard>();

            Cards.Add(new CardashianCard(description, GetNextCardOrder(), this.Id));
        }

        private bool CardDescriptonAlreadyUsed(string description)
        {
            if (!AreThereAnyCards())
                return false;

            return Cards.Any(c => c.Description.ToUpper() == description.ToUpper());
        }

        private int GetNextCardOrder()
        {
            if (!AreThereAnyCards())
                return 1;

            return Cards.Count() + 1;
        }

        private bool CanAddMoreCards()
        {
            if (!AreThereAnyCards())
                return true;

            return Cards.Count < MaxNumberOfCards;
        }

        private bool AreThereAnyCards()
        {
            return Cards != null && Cards.Any();
        }

        public void Rename(Guid authorId, string newTitle)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can rename the Cardashian");

            this.Title = newTitle;
        }

        public void TurnPrivate(Guid authorId)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can turn the Cardashian private");

            if (!IsPublic)
                throw new BusinessRuleValidationException("The Cardashian is already private");

            this.IsPublic = false;
        }

        public void TurnPublic(Guid authorId)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can turn the Cardashian public");

            if (IsPublic)
                throw new BusinessRuleValidationException("The Cardashian is already public");

            this.IsPublic = true;
        }

        public void ChangeCardPosition(Guid authorId, Guid cardId, int newPosition)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can change the card's position");

            var cardWithNewPosition = Cards?.FirstOrDefault(c => c.Id == cardId);

            if (cardWithNewPosition == null)
                throw new BusinessRuleValidationException("The card doesn't exist");

            if (cardWithNewPosition.Position == newPosition)
                throw new BusinessRuleValidationException("The new position isn't different from the old one");

            if (!IsPositionValid(newPosition))
                throw new BusinessRuleValidationException("The position is not valid");

            ReorderCards(cardWithNewPosition, newPosition);
        }

        private bool IsPositionValid(int newPosition)
            => newPosition <= this.Cards.Count;

        private void ReorderCards(CardashianCard cardWithNewPosition, int newPosition)
        {
            var oldPosition = cardWithNewPosition.Position;
            var newPositionIsLowerThanOld = newPosition < oldPosition;

            foreach (var card in Cards)
            {
                if (newPositionIsLowerThanOld)
                {
                    if (card.Position >= newPosition && card.Position < oldPosition)
                        card.SetPosition(card.Position + 1);
                }
                else
                {
                    if (card.Position > oldPosition && card.Position <= newPosition)
                        card.SetPosition(card.Position - 1);
                }
            }

            cardWithNewPosition.SetPosition(newPosition);
        }

        public void ChangeCardDescription(Guid authorId, Guid cardId, string cardDescription)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can change the card's description");

            var card = Cards?.FirstOrDefault(c => c.Id == cardId);

            if (card == null)
                throw new BusinessRuleValidationException("Card not found");

            card.ChangeDescription(cardDescription);
        }

        public void RemoveCard(Guid authorId, Guid cardId)
        {
            if (!IsAuthor(authorId))
                throw new BusinessRuleValidationException("Only the author can delete a card");

            var card = Cards?.FirstOrDefault(c => c.Id == cardId);

            if (card == null)
                throw new BusinessRuleValidationException("Card not found");

            Cards.Remove(card);
        }

        public bool IsAuthor(Guid authorId)
            => this.AuthorId == authorId;
    }
}
