using System.Runtime.InteropServices;

namespace AdoDotNetEFProject.DAL.Test
{
    public class DataBaseConfigTest
    {
       private const string Expected = "Data Source = Store_Demo.db";

        [Fact] //this annotation means our down below method is Test and the fact should always return true
        public void DbConfigToStringTest()
        {
            
            var config = new  DataBaseConfig()
            {
               DataSource = "Store_Demo.db"
            };

            var actual = config.ToString();

            //Assert is basic statics class from xunit  test
            //that verified that the condition are met during the process of testing
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GetFromConfigAsyncPostiveTest()
        {
            var config =  DataBaseConfig.GetFromDataBaseConfig();

            var actual = config!.ToString();

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GetFromConfigAsyncNegativeiveTest()
        {
            var config =   DataBaseConfig.GetFromDataBaseConfig(path:"Bad_Config.json");

            //This tells us that when we assert to null meaning our test negative is successful since we don't such file Data Source with space
            Assert.Null(config?.DataSource);
        }
    }
}