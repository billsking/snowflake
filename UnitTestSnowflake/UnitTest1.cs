using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var tasks = new Task[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                var jj = i;
               tasks[i]=(Task.Run(() => { arr[jj] = sf.NextId(); }));
            }

            Task.WaitAll(tasks);
            var aaa = arr.GroupBy(a => a).Count();
            Assert.IsTrue(aaa == arr.Length);
        }
    }
}
