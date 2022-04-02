using Bogus;
using Joyle.Games.Domain.Cardashians;
using System;
using Xunit;

namespace Joyle.Games.Domain.Tests.Cardashians
{
    [CollectionDefinition(nameof(CardashiansTestsFixtureCollection))]
    public class CardashiansTestsFixtureCollection : ICollectionFixture<CardashiansTestsFixture>
    {

    }

    public class CardashiansTestsFixture
    {
        public Cardashian CreateFakeCardashian()
        {
            return new Faker<Cardashian>("pt_BR")
                 .CustomInstantiator(f => Cardashian.NewCardashian(CreateFakeTitle(), f.Random.Bool(), Guid.NewGuid()));
        }

        public Cardashian CreateFakePublicCardashian()
        {
            return new Faker<Cardashian>("pt_BR")
                 .CustomInstantiator(f => Cardashian.NewCardashian(CreateFakeTitle(), true, Guid.NewGuid()));
        }

        public Cardashian CreateFakePrivateCardashian()
        {
            return new Faker<Cardashian>("pt_BR")
                 .CustomInstantiator(f => Cardashian.NewCardashian(CreateFakeTitle(), false, Guid.NewGuid()));
        }

        public string CreateFakeTitle()
           => new Faker().Lorem.Sentence();

        public string CreateFakeCardDescription()
            => new Faker().Lorem.Sentence();

        public Cardashian CreateCardashianWithMaxCards()
        {
            return CreateCardashianWithCards(Cardashian.MaxNumberOfCards);
        }

        public Cardashian CreateCardashianWithCards(int numberOfCards = 20)
        {
            var cardashian = CreateFakeCardashian();
            var faker = new Faker();

            for (int i = 0; i < numberOfCards; i++)
                cardashian.AddCard(cardashian.AuthorId, faker.Lorem.Sentence());

            return cardashian;
        }

        public int GetRandomInt(int min, int max)
        {
            return new Faker().Random.Int(min, max);
        }
    }
}
