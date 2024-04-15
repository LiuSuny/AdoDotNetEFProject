

using System.Collections.ObjectModel;

namespace AdoDotNetEFProject.DAL.Test
{
    /// <summary>
    /// SqliteServiceTest use to test our SqliteService
    /// </summary>
    public class SqliteServiceTest
    {
        private const string TABLES = TableNames.TABLE_AIRPLANE;
     
      
        private SqlServiceProvider<Airplane> _service = new SqlServiceProvider<Airplane>();           

        [Fact]
        public void CreateSqliteServiceTestPositive()
        {
            ////checking that our _service is not null
            //if (_service is null) return;

            //else Assert.NotNull(_service);

            //checking that our _service is not null
            Assert.NotNull(_service);
        }

        [Fact]
        public void CreateSqliteServiceTestNegativetive()
        {
            Assert.Throws<ArgumentException>(testCode: ()=>
            {

                var _serviceNegative = new SqlServiceProvider<Airplane>(configPath: "Bad_Config.json");

            });
        }

        [Fact]
        public async void GetAllAsyncTest()
        {
           
            List<Airplane> expectedUsers = new List<Airplane>()
           {
            new Airplane()
            {
                airplaneId  = 1,
                PlaneNumbers = "SU100",
                Colors = "White",
                planeProductionYear = new DateTime(1875,01,02),
                NumberOfPassanges = 65

            },
             new Airplane()
            {
                airplaneId  = 2,
                PlaneNumbers = "Sjet200",
                Colors = "Black",
                planeProductionYear = new DateTime(1890,05,10),
                NumberOfPassanges = 100

            },
              new Airplane()
            {
                 airplaneId  = 3,
                PlaneNumbers = "Bx505",
                Colors = "orange",
                planeProductionYear = new DateTime(1899,10,10),
                NumberOfPassanges = 75

            }
           };
            var actualUsers = await _service.GetAllAsync(tableName: TABLES);

            Assert.Equal(expectedUsers, actualUsers);
        }

        [Fact]
        public async void FindByIdAsyncTest()
        {
            Airplane expected = new Airplane()
            {
                airplaneId = 1,
                PlaneNumbers = "SU100",
                Colors = "White",
                planeProductionYear = new DateTime(1875, 01, 02),
                NumberOfPassanges = 65
            };
            Airplane actual = await _service.FindByIdAsync(tableName: TABLES, TableAirplaneColumn.ID, key:1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task UpdateAndInsertTestAsync()
        {
           
          

            List<Airplane> expectedUsers = new List<Airplane>()
           {
            new Airplane()
            {
                airplaneId  = 1,
                PlaneNumbers = "SU100",
                Colors = "White",
                planeProductionYear = new DateTime(1875,01,02),
                NumberOfPassanges = 65

            },
             new Airplane()
            {
                airplaneId  = 2,
                PlaneNumbers = "Sjet200",
                Colors = "Black",
                planeProductionYear = new DateTime(1890,05,10),
                NumberOfPassanges = 100

            },
              new Airplane()
            {
                 airplaneId  = 3,
                PlaneNumbers = "Bx505",
                Colors = "orange",
                planeProductionYear = new DateTime(1899,10,10),
                NumberOfPassanges = 75

            }
            };
            expectedUsers.Add( new Airplane() 
                {
                   airplaneId = 6,
                PlaneNumbers = "Px6094",
                Colors = "Blue",
                planeProductionYear = new DateTime(1820, 04, 12),
                NumberOfPassanges = 98
            });
            var sql = $"INSERT INTO {TableNames.TABLE_AIRPLANE} ({TableAirplaneColumn.PLANENUMBERS}, {TableAirplaneColumn.PLANENUMBERS}, {TableAirplaneColumn.COLOR}, {TableAirplaneColumn.PRODUCTIONYEAR}, {TableAirplaneColumn.NUMBEROFPASSENGERS}) VALUES('Px6094', 'Blue', '1820.04.12', '98')";
            await _service.UpdateAndInsertAsync(sql);

            Airplane actual = await _service.FindByIdAsync(tableName: TABLES, TableAirplaneColumn.ID, key:4);
            var expected = expectedUsers[3];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Test()
        {
            var ticket = new TableTicket();
            await ticket.GetAllAsync();
        }

       
    }
}
