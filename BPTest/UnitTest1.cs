using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void TestMethod1()
        {
            BloodPressure bp = new BloodPressure();
            bp.Systolic = 80;
            bp.Diastolic = 50;
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BloodPressure bp = new BloodPressure();
            bp.Systolic = 110;
            bp.Diastolic = 70;
            Assert.AreEqual(BPCategory.Normal, bp.Category);

        }
        [TestMethod]
        public void TestMethod4()
        {
            BloodPressure bp = new BloodPressure();
            bp.Systolic = 130;
            bp.Diastolic = 85;
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }
        [TestMethod]
        public void TestMethod3()
        {
            BloodPressure bp = new BloodPressure();
            bp.Systolic = 170;
            bp.Diastolic = 100;
            Assert.AreEqual(BPCategory.High, bp.Category);
        }
    }
}
