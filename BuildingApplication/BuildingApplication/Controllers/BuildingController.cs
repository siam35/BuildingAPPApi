using BuildingApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuildingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService service;

        public BuildingController(IBuildingService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/get/all/buildings")]
        public async Task<ActionResult> getAllBuildings()
        {
            try
            {
                var data = await service.getAllBuildings();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        [Route("~/api/get/all/datafield")]
        public async Task<ActionResult> getAllDataField()
        
        {
            try
            {
                var data = await service.getallDataField();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpGet]
        [Route("~/api/filtered/reading/{fromdate}/{todate}/{buildingid}/{datafieldid}/{objectid}")]
        public async Task<ActionResult> getFilteredReading(DateTime FromDate, DateTime ToDate, int BuildingID, int DataFieldID, int ObjectID)
        {
            try
            {
                var data = await service.getFilteredReading(FromDate, ToDate, BuildingID, DataFieldID, ObjectID);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        [Route("~/api/get/all/objects")]
        public async Task<ActionResult> getAllObjects()
        {
            try
            {
                var data = await service.getallObjects();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}
