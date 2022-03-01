using BuildingApplication.DTO;
using BuildingApplication.Interfaces;
using BuildingApplication.Models.Building;
using BuildingApplication.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingApplication.Services
{
    public class BuildingService: IBuildingService
    {
        private readonly BuildingRepository repo = null;
        private readonly DbContext context;
        public BuildingService(IConfiguration Config)
        {
            this.context = new BuildingMasterContext(Config);
            this.repo = new BuildingRepository(this.context);

        }

        public async Task<List<Building>> getAllBuildings()
        {
            return await repo.getallBuildings();
        }

        public async Task<List<DataField>> getallDataField()
        {
            return await repo.getallDataField();
        }

        public async Task<List<BuildingApplication.Models.Building.Object>> getallObjects()
        {
            return await repo.getallObjects();
        }
        public async Task<List<BuildingDTO>> getFilteredReading(DateTime FromDate, DateTime ToDate, int BuildingID, int DataFieldID, int ObjectID)
        {
                return await repo.getFilteredReading(FromDate, ToDate, BuildingID, DataFieldID, ObjectID);
        }

    }
}
