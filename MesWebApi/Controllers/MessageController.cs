using MesWebApi.Models;
using MesWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesWebApi.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly EmailSender _sender;

        public MessageController(ILogger<MessageController> logger, EmailSender es)
        {
            _logger = logger;
            _sender = es;
        }

        [HttpPost]
        [Route("api/send")]
        public IActionResult Send(Message message)
        {
            _logger.LogInformation($"Incoming message for: {message.Email}");
            try
            {
                _sender.Send(message);
                _logger.LogInformation($"sent!");
                return new OkResult();
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
                return new BadRequestResult();
            }
            

        }
    }
}
