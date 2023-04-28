using iShape.FixFloat;
using NUnit.Framework;
using Unity.Mathematics;

namespace Tests.Runtime.iShape.FixFloat {

    public class FixVecTests {

        [Test]
        public void TestMath() {
            var v0 = new FixVec(-1000, 1000) + new FixVec(1000, -1000);
            Assert.AreEqual(v0, new FixVec(0, 0));

            var v1 = new FixVec(-1000, 0) - new FixVec(-1000, -1000);
            Assert.AreEqual(v1, new FixVec(0, 1000));

            var a0 = new FixVec(-512, 0).SqrDistance(new FixVec(512, 0));
            Assert.AreEqual(a0, FixNumber.Unit);
        }
        
        [Test]
        public void TestSQRLengthDebug_0() {
            var v0 = new FixVec(70034108, 654178);
            var v1 = v0.ToFloat2();
            
            var s0 = v0.SqrLength.ToFloat();
            var s1 = v1.SqrLength();
            
            Assert.AreEqual(s0, s1, 0.001f * s1);
        }
        
        [Test]
        public void TestSQRLengthDebug_1() {
            var v0 = new FixVec(12, 1);
            var v1 = v0.ToFloat2();
            
            var s0 = v0.SqrLength.ToFloat();
            var s1 = v1.SqrLength();
            
            Assert.AreEqual(s0, s1, 0.01 * (s1 + s0 + 1));
        }
        
        [Test]
        public void TestLengthDebug() {
            var v0 = new FixVec(1024 * 1024, 0);
            var v1 = v0.ToFloat2();
            
            var s0 = v0.Length.ToFloat();
            var s1 = v1.Length();
            
            Assert.AreEqual(s0, s1, 0.01 * (s1 + s0 + 1));
        }
        
        [Test]
        public void TestNormalizeDebug() {
            var v0 = new FixVec(12, 1);
            var v1 = v0.ToFloat2();
            
            var s0 = v0.Normalize.ToFloat2();
            var s1 = v1.Normalize();
            
            Assert.AreEqual(s0.x, s1.x, 0.05);
            Assert.AreEqual(s0.y, s1.y, 0.05);
        }
        
        [Test]
        public void TestSQRLength() {
            long x = 12;
            while (x < 25_000) {
                long y = 1;
                while (y < 10_000) {
                    var v0 = new FixVec(x, y);
                    var v1 = v0.ToFloat2();
            
                    var s0 = v0.SqrLength.ToFloat();
                    var s1 = v1.SqrLength();
                
                    Assert.AreEqual(s0, s1, 0.05 * (s1 + s0 + 1));
					
                    y += 17;
                }
                x += 13;
            }
        }
        
        [Test]
        public void TestLength() {
            long x = 12;
            while (x < 10_000) {
                long y = 1;
                while (y < 100_000) {
                    var v0 = new FixVec(x, y);
                    var v1 = v0.ToFloat2();
            
                    var s0 = v0.Length.ToFloat();
                    var s1 = v1.Length();
                
                    Assert.AreEqual(s0, s1, 0.05 * (s1 + s0 + 1));
					
                    y += 131;
                }
                x += 109;
            }
        }
        
        [Test]
        public void TestNormalize() {
            long x = 12;
            while (x < 10_000) {
                long y = 1;
                while (y < 100_000) {
                    var v0 = new FixVec(x, y);
                    var v1 = v0.ToFloat2();
            
                    var s0 = v0.Normalize.ToFloat2();
                    var s1 = v1.Normalize();

                    var message = "(" + x + ", " + y + ")"; 
                    
                    Assert.AreEqual(s0.x, s1.x, 0.05, message);
                    Assert.AreEqual(s0.y, s1.y, 0.05, message);
					
                    y += 131;
                }
                x += 109;
            }
        }
        
        [Test]
        public void TestOrtho() {
            AssertOrtho(new float2(0, 1), new float2(1, 0));
            AssertOrtho(new float2(0, 10), new float2(1, 0));
            AssertOrtho(new float2(0, 100), new float2(1, 0));

            AssertOrtho(new float2(0.1f, 0.9f), new float2(0.9f, -0.1f).Normalize());
            AssertOrtho(new float2(1, 9), new float2(0.9f, -0.1f).Normalize());
            AssertOrtho(new float2(10, 90), new float2(0.9f, -0.1f).Normalize());

            AssertOrtho(new float2(1, 0), new float2(0, -1));
            AssertOrtho(new float2(10, 0), new float2(0, -1));
            AssertOrtho(new float2(100, 0), new float2(0, -1));

            AssertOrtho(new float2(0, -1), new float2(-1, 0));
            AssertOrtho(new float2(0, -10), new float2(-1, 0));
            AssertOrtho(new float2(0, -100), new float2(-1, 0));

            AssertOrtho(new float2(-1, 0), new float2(0, 1));
            AssertOrtho(new float2(-10, 0), new float2(0, 1));
            AssertOrtho(new float2(-100, 0), new float2(0, 1));

            var r = 0.01f;
            var hp = 0.5f * math.PI;
            while (r < 2000) {
                var a = -0.001f;
                while (a < 2 * math.PI) {
                    var v = r * new float2(math.cos(a), math.sin(a));
                    var n = new float2(math.cos(a - hp), math.sin(a - hp));

                    AssertOrtho(v, n);
                    a += 0.1f;
                }

                r *= 5;
            }
        }
        
        private void AssertOrtho(float2 v, float2 m) {
            var f = v.ToFixVec();
            var n = m.ToFixVec();

            AssertVec(f.Ortho(clockwise: true), n);
            AssertVec(f.Ortho(clockwise: false), n.Reverse);
        }

    
        private void AssertVec(FixVec a, FixVec b) {
            Assert.AreEqual(a.x, b.x, 130);
            Assert.AreEqual(a.y, b.y, 130);
        }
    }
}