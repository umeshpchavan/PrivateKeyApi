using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrivateKeyApi.Constants;
using PrivateKeyApi.Models;

namespace PrivateKeyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnoucementController : ControllerBase
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        public AnnoucementController(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        [HttpGet] 
        public IActionResult AuthenticateViaBody([FromBody] RequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ApiKey))
                return BadRequest();
            string apiKey = model.ApiKey;
            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
            if (!isValid)
                return Unauthorized();
            return Ok();
        }

        [HttpPost("add-schedules")]
        public IActionResult AddSchedules()
        {
            string? apiKey = Request.Headers["X-API-Key"];
            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();
            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
            if (!isValid)
                return Unauthorized();

            return Ok();
        }

        [HttpGet("schedules")]
        public IActionResult GetSchedule()
        {
            string? apiKey = Request.Headers["X-API-Key"];
            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();
            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
            if (!isValid)
                return Unauthorized();
           
            return Ok(GetScheduleByCampus());
        }

        private TimeTable GetScheduleByCampus()
        {
            string jsonData = @"{
  ""College"": ""Example University"",
  ""Campus"": ""Main Campus"",
  ""FloorSelection"": [
    {
      ""Floor"": 12,
      ""Department"": ""Computer Science"",
      ""Course"": ""Introduction to Programming"",
      ""Lecture"": ""CS101"",
      ""ClassroomNo"": ""A101"",
      ""StartTime"": ""09:00"",
      ""EndTime"": ""10:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. John Doe"",
      ""EligibleStudents"": [
        ""Student1"",
        ""Student2"",
        ""Student3""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Mathematics"",
      ""Course"": ""Calculus I"",
      ""Lecture"": ""MATH101"",
      ""ClassroomNo"": ""B202"",
      ""StartTime"": ""11:00"",
      ""EndTime"": ""12:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Jane Smith"",
      ""EligibleStudents"": [
        ""Student4"",
        ""Student5"",
        ""Student6""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Physics"",
      ""Course"": ""Physics I"",
      ""Lecture"": ""PHYS101"",
      ""ClassroomNo"": ""C303"",
      ""StartTime"": ""13:00"",
      ""EndTime"": ""14:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Emily Clark"",
      ""EligibleStudents"": [
        ""Student7"",
        ""Student8"",
        ""Student9""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Biology"",
      ""Course"": ""General Biology"",
      ""Lecture"": ""BIO101"",
      ""ClassroomNo"": ""D404"",
      ""StartTime"": ""10:00"",
      ""EndTime"": ""11:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Alice Johnson"",
      ""EligibleStudents"": [
        ""Student10"",
        ""Student11"",
        ""Student12""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Chemistry"",
      ""Course"": ""Organic Chemistry"",
      ""Lecture"": ""CHEM101"",
      ""ClassroomNo"": ""E505"",
      ""StartTime"": ""12:00"",
      ""EndTime"": ""13:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Robert Brown"",
      ""EligibleStudents"": [
        ""Student13"",
        ""Student14"",
        ""Student15""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""English"",
      ""Course"": ""Literature 101"",
      ""Lecture"": ""ENG101"",
      ""ClassroomNo"": ""F606"",
      ""StartTime"": ""14:00"",
      ""EndTime"": ""15:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Linda Green"",
      ""EligibleStudents"": [
        ""Student16"",
        ""Student17"",
        ""Student18""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""History"",
      ""Course"": ""World History"",
      ""Lecture"": ""HIST101"",
      ""ClassroomNo"": ""G707"",
      ""StartTime"": ""15:00"",
      ""EndTime"": ""16:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Michael Davis"",
      ""EligibleStudents"": [
        ""Student19"",
        ""Student20"",
        ""Student21""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Economics"",
      ""Course"": ""Microeconomics"",
      ""Lecture"": ""ECON101"",
      ""ClassroomNo"": ""H808"",
      ""StartTime"": ""16:00"",
      ""EndTime"": ""17:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Rachel Wilson"",
      ""EligibleStudents"": [
        ""Student22"",
        ""Student23"",
        ""Student24""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Philosophy"",
      ""Course"": ""Introduction to Philosophy"",
      ""Lecture"": ""PHIL101"",
      ""ClassroomNo"": ""I909"",
      ""StartTime"": ""17:00"",
      ""EndTime"": ""18:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. James Lee"",
      ""EligibleStudents"": [
        ""Student25"",
        ""Student26"",
        ""Student27""
      ]
    },
    {
      ""Floor"": 12,
      ""Department"": ""Art"",
      ""Course"": ""Art History"",
      ""Lecture"": ""ART101"",
      ""ClassroomNo"": ""J010"",
      ""StartTime"": ""18:00"",
      ""EndTime"": ""19:30"",
      ""Status"": ""Scheduled"",
      ""FacultyName"": ""Dr. Patricia Martinez"",
      ""EligibleStudents"": [
        ""Student28"",
        ""Student29"",
        ""Student30""
      ]
    }
  ]
}
";

            var data = JsonConvert.DeserializeObject<TimeTable>(jsonData);
            return data;
        }
    }
}
