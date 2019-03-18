using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSnowflake
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sf = Snowflake.Instance();
            sf.Init(5, 20);
            var arr = new long[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sf.NextId();
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.IsTrue(arr[i] < arr[i + 1]);
            }
        }
    }
}
