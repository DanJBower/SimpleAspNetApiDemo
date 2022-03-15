using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using System.Collections.Generic;
using SimpleAspNetApiDemo.DataAccess.Entities;

namespace SimpleAspNetApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly SchoolContext _context;

        public TeacherController(ILogger<TeacherController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TeacherEntity> Get()
        {
            return _context.Teachers;
        }
    }
}
