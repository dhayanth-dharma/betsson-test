

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library.Components;
using Game.Library.Components.Enums;
namespace Game.UnitTests
{
    [TestClass]
    public class TurtleGameTest
    {
        [TestMethod]
        public void Test_Grid_Point()
        {
            //Arrange
            GridPoint point = new GridPoint(1, 1);

            //Assert
            Assert.AreEqual(1, point.Y);
        }


        [TestMethod]
        public void Turtle_Grid_Creation()
        {
            //Arrange
            var grid = new GridComponent(2, 2);
  
            //Assert
            Assert.AreEqual(2, grid.height);
        }

       

        [TestMethod]
        public void Turtle_Move_To_South_Direction_Test()
        {
            //Arrange
            var grid = new GridComponent(4, 4);
            var turtle_position = new GridPoint(3, 1);
            var turtle = TurtleComponent.GetInstance(turtle_position);
            turtle.direction = Direction.S;
            grid[turtle_position] = turtle;

            //Act
            turtle.MoveTurlte();

            //Assert
            Assert.AreEqual(4, turtle.Position.X);
        }


        [TestMethod]
        public void Mine_Hit_Test()
        {
            //Arrange
            var grid = new GridComponent(4, 4);
            var turtle_position = new GridPoint(2, 1);
            var turtle = TurtleComponent.GetInstance(turtle_position);
            turtle.direction = Direction.S;
            grid[turtle.Position] = turtle;
            var mine_position = new GridPoint(3, 1);
            grid[mine_position] = new MineComponent() { Position = mine_position };
            var status_indicator = new StatusIndicator(grid);
            //Act
            turtle.MoveTurlte();
            var status = status_indicator.GetCurrentStatus(turtle.Position);
            //Assert
            Assert.AreEqual(TurtleStatus.MineHit, status);
        }

        [TestMethod]
        public void Status_Indigator_Test()
        {
            //Arrange
            var status_indicator = new StatusIndicator(new GridComponent(2, 2));

            //Act
            var status = status_indicator.GetCurrentStatus(new GridPoint(1, 1));

            //Assert
            Assert.AreEqual(TurtleStatus.StillInDanger, status);
        }



    }
}
