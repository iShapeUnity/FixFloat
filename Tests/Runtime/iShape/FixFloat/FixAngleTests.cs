using iShape.FixFloat;
using NUnit.Framework;
using Unity.Mathematics;

namespace Tests.Runtime.iShape.FixFloat {

    public class FixAngleTests {

        [Test]
        public void TestMul() {
            Assert.AreEqual(0d.ToFixAngle(), 0);
            Assert.AreEqual((0.125 * math.PI).ToFixAngle(), 64);
            Assert.AreEqual((0.25 * math.PI).ToFixAngle(), 128);
            Assert.AreEqual((0.375 * math.PI).ToFixAngle(), 192);
            Assert.AreEqual((0.5 * math.PI).ToFixAngle(), 256);
            Assert.AreEqual((0.625 * math.PI).ToFixAngle(), 320);
            Assert.AreEqual((0.75 * math.PI).ToFixAngle(), 384);
            Assert.AreEqual((0.875 * math.PI).ToFixAngle(), 448);
            Assert.AreEqual((1.0 * math.PI).ToFixAngle(), 512);
            Assert.AreEqual((1.125 * math.PI).ToFixAngle(), 576);
            Assert.AreEqual((1.25 * math.PI).ToFixAngle(), 640);
            Assert.AreEqual((1.375 * math.PI).ToFixAngle(), 704);
            Assert.AreEqual((1.5 * math.PI).ToFixAngle(), 768);
            Assert.AreEqual((1.625 * math.PI).ToFixAngle(), 832);
            Assert.AreEqual((1.75 * math.PI).ToFixAngle(), 896);
            Assert.AreEqual((1.875 * math.PI).ToFixAngle(), 960);
            Assert.AreEqual((2.0 * math.PI).ToFixAngle(), 1024);

            Assert.AreEqual(0.ToFix().AngleToFixAngle(), 0);
            Assert.AreEqual(45.ToFix().AngleToFixAngle(), 128);
            Assert.AreEqual(90.ToFix().AngleToFixAngle(), 256);
            Assert.AreEqual(135.ToFix().AngleToFixAngle(), 384);
            Assert.AreEqual(180.ToFix().AngleToFixAngle(), 512);
            Assert.AreEqual(225.ToFix().AngleToFixAngle(), 640);
            Assert.AreEqual(270.ToFix().AngleToFixAngle(), 768);
            Assert.AreEqual(315.ToFix().AngleToFixAngle(), 896);
            Assert.AreEqual(360.ToFix().AngleToFixAngle(), 1024);


            Assert.AreEqual(0d.ToFix().RadToFixAngle(), 0);
            Assert.AreEqual(0d.ToFix(), 0);

            Assert.AreEqual((0.5 * math.PI).ToFix().RadToFixAngle(), 256, 1);
            Assert.AreEqual((0.5 * math.PI).ToFix(), 1608);

            Assert.AreEqual((1.0 * math.PI).ToFix().RadToFixAngle(), 512, 1);
            Assert.AreEqual((1.0 * math.PI).ToFix(), 3216);

            Assert.AreEqual((1.5 * math.PI).ToFix().RadToFixAngle(), 768, 1);
            Assert.AreEqual((1.5 * math.PI).ToFix(), 4825);

            Assert.AreEqual((2.0 * math.PI).ToFix().RadToFixAngle(), 1024, 1);
            Assert.AreEqual((2.0 * math.PI).ToFix(), 6433);
        }
		
        [Test]
        public void TestCos() {
            var rad = -100d;

            while (rad < 100) {
                var angle = 180 * rad / math.PI;
                var fixAngle0 = rad.ToFix().RadToFixAngle();

                var fixFloat = angle.ToFix();
                var fixAngle1 = fixFloat.AngleToFixAngle();

                Assert.AreEqual(fixAngle0, fixAngle1, 1);

                var cs = math.cos(rad).ToFix();
                var cs0 = fixAngle0.Cos();
                var cs1 = fixAngle1.Cos();

                Assert.AreEqual(cs, cs0, 8);
                Assert.AreEqual(cs, cs1, 8);

                rad += 0.001;
            }
        }
        
        [Test]
        public void TestSin() {
            var rad = -100d;

            while (rad < 100) {
                var angle = 180 * rad / math.PI;
                var fixAngle0 = rad.ToFix().RadToFixAngle();

                var fixFloat = angle.ToFix();
                var fixAngle1 = fixFloat.AngleToFixAngle();

                Assert.AreEqual(fixAngle0, fixAngle1, 1);

                var sn = math.sin(rad).ToFix();
                var sn0 = fixAngle0.Sin();
                var sn1 = fixAngle1.Sin();

                Assert.AreEqual(sn, sn0, 8);
                Assert.AreEqual(sn, sn1, 8);

                rad += 0.001;
            }
        }

    }
}