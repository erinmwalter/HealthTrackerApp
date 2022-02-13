using HealthTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        MeasurementDAL mDB = new MeasurementDAL();

        //localhost/api/measurement/create
        [HttpPost("create")]
        public void CreateMeasurement(Measurement m)
        {
            mDB.CreateMeasurement(m);
        }

        //localhost/api/measurement/update
        [HttpPut("update")]
        public void UpdateMeasurement(Measurement m)
        {
            mDB.UpdateMeasurement(m);
        }

        //localhost/api/measurement/delete/{measId}
        [HttpDelete("delete/{measId}")]
        public void DeleteMeasurement(int measId) 
        {
            mDB.DeleteMeasurement(measId);
        }

        //localhost/api/measurement/get/{userId}
        [HttpGet("get/{userId}")]
        public List<Measurement> GetMeasurements(int userId) 
        {
            return mDB.GetMeasurementsByUserId(userId);
        }
    }
}
