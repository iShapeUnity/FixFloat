using System;
using iShape.FixFloat;
using NUnit.Framework;

namespace Tests.Runtime.iShape.FixFloat {

	public class FixFloatTests {

		[Test]
		public void TestMul() {
			long a = 0;
			while (a < 10_000) {
				long b = 1;
				while (b < 10_000) {
					var m0 = a.Mul(b);
					var m1 = a.ToDouble() * b.ToDouble();
                
					Assert.AreEqual(m1.ToFix(), m0, 2);
					Assert.AreEqual(m1, m0.ToDouble(), 0.005);
					
					b += 17;
				}
				a += 23;
			}
		}
		
		[Test]
		public void TestDiv() {
			long a = 0;
			while (a < 10_000) {
				long b = 1;
				while (b < 10_000) {
					var m0 = a.Div(b);
					var m1 = a.ToDouble() / b.ToDouble();
                
					Assert.AreEqual(m1.ToFix(), m0, 2);
					Assert.AreEqual(m1, m0.ToDouble(), 0.005);
					
					b += 17;
				}

				a += 23;
			}
		}
		
		[Test]
		public void TestSqrt() {
			long a = 1;
			while (a < 30_000) {
				var m0 = a.Sqrt();
				var m1 = Math.Sqrt(a.ToDouble());
                
				Assert.AreEqual(m1.ToFix(), m0, 10);
				Assert.AreEqual(m1, m0.ToDouble(), 0.05);
				a += 1;
			}
		}
	}
}
