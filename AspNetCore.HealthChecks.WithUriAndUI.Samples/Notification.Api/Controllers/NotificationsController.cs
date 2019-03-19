using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Notification.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NotificationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "the connection is open!" };
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            using (var stream = new MemoryStream())
            {
                HttpContext.Request.Body.CopyTo(stream);
                var ary = stream.ToArray();
                var str = Encoding.UTF8.GetString(ary);

                var notification = JsonConvert.DeserializeObject<HealthCheckNotification>(str);

                var email = new Email()
                {
                    Username = _configuration["EmailSettings:Username"],
                    Password = _configuration["EmailSettings:Password"],
                    SmtpServerAddress = _configuration["EmailSettings:SmtpServerAddress"],
                    SmtpPort = Convert.ToInt32(_configuration["EmailSettings:SmtpPort"]),
                    Subject = _configuration["EmailSettings:Subject"],
                    Body = notification.Title,
                    Recipients = _configuration["EmailSettings:Recipients"]
                };

                email.Send();
            }
        }
    }
}