using BuildingApplication.DTO;
using BuildingApplication.Models.Building;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingApplication.Repository
{
    public class BuildingRepository
    {
        private DbContext context = null;
        public BuildingRepository(DbContext context)
        {
            this.context = context;
            this.context.Database.SetCommandTimeout(240);

        }

        public async Task<List<BuildingDTO>> getFilteredReading(DateTime FromDate, DateTime ToDate, int BuildingID, int DataFieldID, int ObjectID)
        {
            this.context.Database.SetCommandTimeout(600);
            var data = await this.context.Set<BuildingDTO>().FromSqlRaw("getFilteredReading @FromDate, @ToDate, @BuildingID, @DataFieldID, @ObjectID",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@BuildingID", BuildingID), new SqlParameter("@DataFieldID", DataFieldID), new SqlParameter("@ObjectID", ObjectID)).ToListAsync();
            return data;
        }


        public async Task<List<Building>> getallBuildings()
        {
            var res =await this.context.Set<Building>().ToListAsync();
            return res;
        }
        public async Task<List<BuildingApplication.Models.Building.Object>> getallObjects()
        {


            var res = await this.context.Set<BuildingApplication.Models.Building.Object>().ToListAsync();
            return res;
        }
        public async Task<List<DataField>> getallDataField()
        {
            var res = await this.context.Set<DataField>().ToListAsync();
            return res;
        }
    }
}
