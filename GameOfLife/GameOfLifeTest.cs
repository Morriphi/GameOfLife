using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class GameOfLifeTest
    {
        private bool O;
        private bool X = true;

        [Test]
        public void ShouldReturnGamesCurrentState()
        {
            var state = new[,]{ {X,X,X},
                                {O,O,O},
                                {O,O,O},
                                {X,O,X}};

            var gameOfLife = new GameOfLife(state);

            Assert.That(gameOfLife.CurrentState(), Is.EquivalentTo(state));
        }

        [Test]
        public void Block()
        {
            var state = new[,]{ {O,O,O,O},
                                {O,X,X,O},
                                {O,X,X,O},
                                {O,O,O,O}};

            var gameOfLife = new GameOfLife(state);

            Assert.That(gameOfLife.Tick().CurrentState(), Is.EquivalentTo(state));
        }

        [Test]
        public void Loaf()
        {
            var state = new[,]{ {O,O,O,O,O,O},
                                {O,O,X,X,O,O},
                                {O,X,O,O,X,O},
                                {O,X,O,X,O,O},
                                {O,O,X,O,O,O},
                                {O,O,O,O,O,O}};

            var gameOfLife = new GameOfLife(state);

            Assert.That(gameOfLife.Tick().CurrentState(), Is.EquivalentTo(state));
        }

        [Test]
        public void Beehive()
        {
            var state = new[,]{ {O,O,O,O,O},
                                {O,O,X,O,O},
                                {O,X,O,X,O},
                                {O,X,O,X,O},
                                {O,O,X,O,O},
                                {O,O,O,O,O}};

            var gameOfLife = new GameOfLife(state);

            Assert.That(gameOfLife.Tick().CurrentState(), Is.EquivalentTo(state));
        }

        [Test]
        public void Boat()
        {
            var state = new[,]{ {O,O,O,O,O},
                                {O,O,X,X,O},
                                {O,X,O,X,O},
                                {O,O,X,O,O},
                                {O,O,O,O,O}};

            var gameOfLife = new GameOfLife(state);

            Assert.That(gameOfLife.Tick().CurrentState(), Is.EquivalentTo(state));
        }

        [Test]
        public void Blinker()
        {
            var state = new[,]{ {O,O,O,O,O},
                                {O,O,O,O,O},
                                {O,X,X,X,O},
                                {O,O,O,O,O},
                                {O,O,O,O,O}};

            var gameOfLife = new GameOfLife(state);

            gameOfLife = gameOfLife.Tick();

            Assert.That(gameOfLife.CurrentState(), Is.EquivalentTo(new[,]{ {O,O,O,O,O},
                                                                           {O,O,X,O,O},
                                                                           {O,O,X,O,O},
                                                                           {O,O,X,O,O},
                                                                           {O,O,O,O,O}}));

            gameOfLife = gameOfLife.Tick();

            Assert.That(gameOfLife.CurrentState(), Is.EquivalentTo(state));
        }
    }
}