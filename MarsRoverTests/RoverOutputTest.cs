using System;
using Xunit;
using MarsRover;

namespace MarsRoverTests
{
    public class RoverOutputTest
    {
        [Fact]
        public void executeInstruction()
        {
            //SAMPLE TEST CASE 1
            Rover rover = new Rover("1 2 N", "5 5");
            rover.executeInstruction("LMLMLMLMM");
            Assert.Equal("1 3 N", rover.x + " " + rover.y + " " + rover.direction);
            
            //SAMPLE TEST CASE 2
            rover = new Rover("3 3 E", "5 5");
            rover.executeInstruction("MMRMMRMRRM");
            Assert.Equal("5 1 E", rover.x + " " + rover.y + " " + rover.direction);
        }
    }
}
