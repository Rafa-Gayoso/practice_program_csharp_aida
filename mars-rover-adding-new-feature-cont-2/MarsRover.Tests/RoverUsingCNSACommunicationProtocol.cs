using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests
{
    public class RoverUsingCNSACommunicationProtocol
    {
        [Test]
        public void Forward_Commands()
        {
            var rover = ACNSARover().WithCoordinates(0, 0).Facing("N").Build();

            rover.Receive("bx");

            Assert.That(rover, Is.EqualTo(ACNSARover().WithCoordinates(0, 1).Facing("N").Build()));
        }

        [Test]
        public void Backward_Commands()
        {
            var rover = ACNSARover().WithCoordinates(3, 3).Facing("E").Build();

            rover.Receive("tf");

            Assert.That(rover, Is.EqualTo(ACNSARover().WithCoordinates(2, 3).Facing("E").Build()));
        }

        [Test]
        public void Rotate_Left_Commands()
        {
            var rover = ACNSARover().Facing("E").Build();

            rover.Receive("ah");

            Assert.That(rover, Is.EqualTo(ACNSARover().Facing("N").Build()));
        }

        [Test]
        public void Rotate_Right_Commands()
        {
            var rover = ACNSARover().Facing("W").Build();

            rover.Receive("pl");

            Assert.That(rover, Is.EqualTo(ACNSARover().Facing("N").Build()));
        }

        [Test]
        public void No_Commands()
        {
            var rover = ACNSARover().Build();

            rover.Receive("");

            Assert.That(rover, Is.EqualTo(ACNSARover().Build()));
        }

        [Test]
        public void Two_Commands()
        {
            var rover = ACNSARover().WithCoordinates(3,4).Facing("W").Build();

            rover.Receive("ahbx");

            Assert.That(rover, Is.EqualTo(ACNSARover().WithCoordinates(3, 3).Facing("S").Build()));
        }
    }
}
