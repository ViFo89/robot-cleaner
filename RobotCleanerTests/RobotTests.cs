using RobotCleaner;
using Xunit;

namespace RobotCleanerTests
{
    public class RobotTests
    {
        private MovementProviderTestHelper _directionProviderTestHelper;
        private Robot _sut;

        public RobotTests()
        {
            _directionProviderTestHelper = new MovementProviderTestHelper();
            _sut = new Robot(_directionProviderTestHelper);
        }

        [Fact]
        public void When_Robot_is_started_without_any_commands_Expect_startingposition_should_be_cleaned()
        {
            var result = _sut.Start(0, 0, 0);

            Assert.Equal(1, result);
        }

        [Fact]
        public void When_MovingNorth_Expect_Cleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.N, 1);
            var result = _sut.Start(1, 0, 0);

            Assert.Equal(2, result);
        }

        [Fact]
        public void When_MovingWest_Expect_Cleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.W, 3);
            var result = _sut.Start(1, 0, 0);

            Assert.Equal(4, result);
        }

        [Fact]
        public void When_MovingEast_Expect_Cleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.E, 4);
            var result = _sut.Start(1, 0, 0);

            Assert.Equal(5, result);
        }

        [Fact]
        public void When_MovingSouth_Expect_Cleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.S, 1);
            var result = _sut.Start(1, 0, 0);

            Assert.Equal(2, result);
        }

        [Fact]
        public void When_Receiving2Commands_Expect_CleaingInBothDirections()
        {
            _directionProviderTestHelper.AddDirection(Direction.N, 4);
            _directionProviderTestHelper.AddDirection(Direction.E, 2);
            var result = _sut.Start(2, 0, 0);

            Assert.Equal(7, result);
        }

        [Fact]
        public void When_RobotCleansSameSpotTwice_Expect_SpaceToBeCountedOnce()
        {
            _directionProviderTestHelper.AddDirection(Direction.N, 4);
            _directionProviderTestHelper.AddDirection(Direction.S, 6);
            
            var result = _sut.Start(2, 0, 0);

            Assert.Equal(7, result);
        }

        [Fact]
        public void When_StartingInADifferentPosition_Expect_RegularCleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.N, 4);
            _directionProviderTestHelper.AddDirection(Direction.W, 4);

            var result = _sut.Start(2, 100, 200);

            Assert.Equal(9, result);
        }

        [Fact]
        public void When_StartingInANegativePosition_Expect_RegularCleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.S, 2);
            _directionProviderTestHelper.AddDirection(Direction.W, 3);

            var result = _sut.Start(2, -300, 122);

            Assert.Equal(6, result);
        }

        [Fact]
        public void When_MovingInAllDirections_Expect_RegularCleaning()
        {
            _directionProviderTestHelper.AddDirection(Direction.N, 4);
            _directionProviderTestHelper.AddDirection(Direction.E, 2);
            _directionProviderTestHelper.AddDirection(Direction.S, 2);
            _directionProviderTestHelper.AddDirection(Direction.W, 4);

            var result = _sut.Start(4, -10, 10);

            Assert.Equal(12, result);
        }

    }
}
