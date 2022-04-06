namespace Robots.Tests

{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        private Robot testrobot;
        private RobotManager testrobotmanager;
        [SetUp]
        public void SetUp()
        {
            testrobot = new Robot("Stoqnegei", 69);
            testrobotmanager = new RobotManager(15);
        }

        [Test]

        public void RobotConstructor()
        {
            Assert.AreEqual("Stoqnegei", testrobot.Name);
            Assert.AreEqual(69, testrobot.MaximumBattery);
        }

        [Test]

        public void RobotManagerConstructor()
        {
            Assert.AreEqual(15, testrobotmanager.Capacity);
            testrobotmanager.Add(testrobot);
            Assert.That(testrobotmanager.Count > 0);
        }
        [Test]
        public void COUNTRTTEREWERWE()
        {
            RobotManager robotManager = new RobotManager(1);
            Assert.IsNotNull(robotManager.Count);
        }
        [Test]
        public void TestAddDupe()
        {
            var robota = new Robot("GEI",56);
             testrobotmanager.Add(robota);

            Assert.Throws<InvalidOperationException>(() => testrobotmanager.Add(robota));
            
        }

        [Test]

        public void TestAdd()
        {
            var robota = new Robot("ROBERTBOY",78);

            
        }

        
       
    }
}
