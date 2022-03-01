using BuildingApplication.DTO;
using BuildingApplication.Models.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingApplication.Interfaces
{
    public interface IBuildingService
    {
        Task<List<Building>> getAllBuildings();
        Task<List<DataField>> getallDataField();
        Task<List<BuildingApplication.Models.Building.Object>> getallObjects();
        Task<List<BuildingDTO>> getFilteredReading(DateTime FromDate, DateTime ToDate, int BuildingID, int DataFieldID, int ObjectID);
    }
}
