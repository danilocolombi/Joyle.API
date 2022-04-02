using FluentAssertions;
using Joyle.BuildingBlocks.Domain;
using Joyle.BuildingBlocks.Domain.Extensions;
using Joyle.Games.Domain.Cardashians;
using System;
using System.Linq;
using Xunit;

namespace Joyle.Games.Domain.Tests.Cardashians
{
    [Collection(nameof(CardashiansTestsFixtureCollection))]
    public class CardashiansTests
    {
        private readonly CardashiansTestsFixture _testsFixture;

        public CardashiansTests(CardashiansTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Add Card, should add a new card to the list of cards")]
        [Trait("Category", "Add Card")]
        public void Cardashian_AddCard_ShouldAddCardToTheList()
        {
            var cardashian = _testsFixture.CreateFakeCardashian();
            var cardDescription = _testsFixture.CreateFakeCardDescription();
            var authorId = cardashian.AuthorId;

            cardashian.AddCard(authorId, cardDescription);

            cardashian.Cards.Should().HaveCount(1);
            cardashian.Cards.FirstOrDefault().Description.Should().Be(cardDescription);
        }

        [Fact(DisplayName = "Add Card to a cardashian passing the invalid authorId")]
        [Trait("Category", "Add Card")]
        public void Cardashian_AddCard_ShouldThrowAnException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateFakeCardashian();
            var cardDescription = _testsFixture.CreateFakeCardDescription();
            var authorId = Guid.NewGuid();

            Action action = () => cardashian.AddCard(authorId, cardDescription);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author of the Cardashian can add new cards");
        }

        [Fact(DisplayName = "Add Card to a cardashian with max number of cards, should throw an exception")]
        [Trait("Category", "Add Card")]
        public void Cardashian_AddCard_ShouldThrowAnException()
        {
            var cardashian = _testsFixture.CreateCardashianWithMaxCards();
            var cardDescription = _testsFixture.CreateFakeCardDescription();
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.AddCard(authorId, cardDescription);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage($"You can't have more than {Cardashian.MaxNumberOfCards} in a Cardashian");
        }

        [Fact(DisplayName = "Add Card using a description already used, should throw an exception")]
        [Trait("Category", "Add Card")]
        public void Cardashian_AddCard_ShouldThrowAnException_DescriptionAlreadyUserd()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var cardDescription = cardashian.Cards.FirstOrDefault().Description;
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.AddCard(authorId, cardDescription);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("There is already a card with this description");
        }

        [Fact(DisplayName = "Rename Cardashian,should update the title")]
        [Trait("Category", "Rename")]
        public void Cardashian_Rename_ShouldUpdateTitle()
        {
            var cardashian = _testsFixture.CreateFakeCardashian();
            var newTitle = _testsFixture.CreateFakeTitle();
            var authorId = cardashian.AuthorId;

            cardashian.Rename(authorId, newTitle);

            cardashian.Title.Should().Be(newTitle);
        }

        [Fact(DisplayName = "Rename Cardashian passing the invalid authorId, should throw exception")]
        [Trait("Category", "Rename")]
        public void Cardashian_Rename_ShouldUpdateTitle_ShouldThrowException()
        {
            var cardashian = _testsFixture.CreateFakeCardashian();
            var newTitle = _testsFixture.CreateFakeTitle();
            var authorId = Guid.NewGuid();

            Action action = () => cardashian.Rename(authorId, newTitle);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can rename the Cardashian");
        }

        [Fact(DisplayName = "Turn private, should update IsPublic to false")]
        [Trait("Category", "Turn Private")]
        public void Cardashian_TurnPrivate_ShouldUpdateIsPublicToFalse()
        {
            var cardashian = _testsFixture.CreateFakePublicCardashian();
            var authorId = cardashian.AuthorId;

            cardashian.TurnPrivate(authorId);

            cardashian.IsPublic.Should().BeFalse();
        }

        [Fact(DisplayName = "Turn a cardashian private passing the invalid authorId, should throw an exception")]
        [Trait("Category", "Turn Private")]
        public void Cardashian_TurnPrivate_ShouldThrowAnException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateFakePrivateCardashian();
            var authorId = Guid.NewGuid();

            Action action = () => cardashian.TurnPrivate(authorId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can turn the Cardashian private");
        }

        [Fact(DisplayName = "Turn a cardashian that is already private to private, should throw an exception")]
        [Trait("Category", "Turn Private")]
        public void Cardashian_TurnPrivate_ShouldThrowAnException()
        {
            var cardashian = _testsFixture.CreateFakePrivateCardashian();
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.TurnPrivate(authorId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("The Cardashian is already private");
        }

        [Fact(DisplayName = "Turn public, should update IsPublic to true")]
        [Trait("Category", "Turn Public")]
        public void Cardashian_TurnPublic_ShouldUpdateIsPublicToTrue()
        {
            var cardashian = _testsFixture.CreateFakePrivateCardashian();
            var authorId = cardashian.AuthorId;

            cardashian.TurnPublic(authorId);

            cardashian.IsPublic.Should().BeTrue();
        }

        [Fact(DisplayName = "Turn a cardashian public passing the invalid authorId should throw an exception")]
        [Trait("Category", "Turn Public")]
        public void Cardashian_TurnPublic_ShouldThrowAnException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateFakePublicCardashian();
            var authorId = Guid.NewGuid();

            Action action = () => cardashian.TurnPublic(authorId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can turn the Cardashian public");
        }

        [Fact(DisplayName = "Turn a cardashian that is already public to public, should throw an exception")]
        [Trait("Category", "Turn Public")]
        public void Cardashian_TurnPublic_ShouldThrowAnException()
        {
            var cardashian = _testsFixture.CreateFakePublicCardashian();
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.TurnPublic(authorId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("The Cardashian is already public");
        }

        [Fact(DisplayName = "Change card position to a lower postion, should update the card position")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldUpdateCardPosition_ToLower()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var randomCard = cardashian.Cards.FirstOrDefault(c => c.Position == 14);
            var newCardPosition = _testsFixture.GetRandomInt(1, randomCard.Position - 1);
            var authorId = cardashian.AuthorId;

            cardashian.ChangeCardPosition(authorId, randomCard.Id, newCardPosition);

            cardashian.Cards.Should().Contain(c => c.Position == newCardPosition && c.Id == randomCard.Id);
            cardashian.Cards.Should().OnlyContain(c => c.Position <= cardashian.Cards.Count);
            cardashian.Cards.Select(c => c.Position).Should().OnlyHaveUniqueItems();
        }

        [Fact(DisplayName = "Change card position to a higher postion, should update the card position")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldUpdateCardPosition_ToHigher()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var randomCard = cardashian.Cards.FirstOrDefault(c => c.Position == 5);
            var newCardPosition = _testsFixture.GetRandomInt(6, cardashian.Cards.Count());
            var authorId = cardashian.AuthorId;

            cardashian.ChangeCardPosition(authorId, randomCard.Id, newCardPosition);

            cardashian.Cards.Should().Contain(c => c.Position == newCardPosition && c.Id == randomCard.Id);
            cardashian.Cards.Should().OnlyContain(c => c.Position <= cardashian.Cards.Count);
            cardashian.Cards.Select(c => c.Position).Should().OnlyHaveUniqueItems();
        }

        [Fact(DisplayName = "Change card position passing the invalid authorId, should throw exception")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldThrowException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var randomCard = cardashian.Cards.FirstOrDefault(c => c.Position == 14);
            var newCardPosition = _testsFixture.GetRandomInt(1, randomCard.Position - 1);
            var authorId = Guid.NewGuid();

            Action action = () => cardashian.ChangeCardPosition(authorId, randomCard.Id, newCardPosition);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can change the card's position");
        }

        [Fact(DisplayName = "Change card position passing an invalid card id should throw an exception")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldThrowAnException_CardDoesntExist()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var invalidCardId = Guid.NewGuid();
            var newCardPosition = _testsFixture.GetRandomInt(1, cardashian.Cards.Count() + 1);
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.ChangeCardPosition(authorId, invalidCardId, newCardPosition);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("The card doesn't exist");
        }

        [Fact(DisplayName = "Change card position passing the same position that the card already has")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldThrowAnException_PositionIsTheSame()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var randomCard = cardashian.Cards.GetRandomElement();
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.ChangeCardPosition(authorId, randomCard.Id, randomCard.Position);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("The new position isn't different from the old one");
        }

        [Fact(DisplayName = "Change card position passing a position that is higher than the number of cards ")]
        [Trait("Category", "Change Card Position")]
        public void Cardashian_ChangeCardPosition_ShouldThrowAnException_PositionIsntValid()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var randomCard = cardashian.Cards.GetRandomElement();
            var newPosition = cardashian.Cards.Count + 1;
            var authorId = cardashian.AuthorId;

            Action action = () => cardashian.ChangeCardPosition(authorId, randomCard.Id, newPosition);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("The position is not valid");
        }

        [Fact(DisplayName = "Change card description, should update the card description")]
        [Trait("Category", "Change Card Description")]
        public void Cardashian_ChangeCardDescription_ShouldUpdateDescription()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = cardashian.AuthorId;
            var card = cardashian.Cards.GetRandomElement();
            var newCardDescription = _testsFixture.CreateFakeCardDescription();

            cardashian.ChangeCardDescription(authorId, card.Id, newCardDescription);

            cardashian.Cards.Should().Contain(c => c.Id == card.Id && c.Description == newCardDescription);
        }

        [Fact(DisplayName = "Change card description, passing the invalid authorId, should throw exception")]
        [Trait("Category", "Change Card Description")]
        public void Cardashian_ChangeCardDescription_ShouldThrowException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = Guid.NewGuid();
            var card = cardashian.Cards.GetRandomElement();
            var newCardDescription = _testsFixture.CreateFakeCardDescription();

            Action action = () => cardashian.ChangeCardDescription(authorId, card.Id, newCardDescription);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can change the card's description");
        }

        [Fact(DisplayName = "Change card description, passing invalid cardId")]
        [Trait("Category", "Change Card Description")]
        public void Cardashian_ChangeCardDescription_ShouldThrowException_CardNotFound()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = cardashian.AuthorId;
            var invalidCardId = Guid.NewGuid();
            var newCardDescription = _testsFixture.CreateFakeCardDescription();

            Action action = () => cardashian.ChangeCardDescription(authorId, invalidCardId, newCardDescription);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Card not found");
        }

        [Fact(DisplayName = "Remove card, should remove it from the list of Cards")]
        [Trait("Category", "Remove Card")]
        public void Cardashian_RemoveCard_ShouldRemoveCard()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = cardashian.AuthorId;
            var cardId = cardashian.Cards.GetRandomElement().Id;

            cardashian.RemoveCard(authorId, cardId);

            cardashian.Cards.Should().NotContain(c => c.Id == cardId);
        }

        [Fact(DisplayName = "Remove card, passing invalid authorId")]
        [Trait("Category", "Remove Card")]
        public void Cardashian_RemoveCard_ShouldThrowException_InvalidAuthor()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = Guid.NewGuid();
            var cardId = cardashian.Cards.GetRandomElement().Id;

            Action action = () => cardashian.RemoveCard(authorId, cardId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Only the author can delete a card");
        }

        [Fact(DisplayName = "Remove card, passing invalid cardId")]
        [Trait("Category", "Remove Card")]
        public void Cardashian_RemoveCard_ShouldThrowException_CardNotFound()
        {
            var cardashian = _testsFixture.CreateCardashianWithCards();
            var authorId = cardashian.AuthorId;
            var cardId = Guid.NewGuid();

            Action action = () => cardashian.RemoveCard(authorId, cardId);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Card not found");
        }
    }
}
