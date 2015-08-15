using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Web.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IMessageHandler _handler;

        public MessageController(IMessageHandler messageHandler)
        {
            _handler = messageHandler;
        }

        [Route(@"api/message/freud")]
        public OkResult Post([FromBody]Update value)
        {
            Task.Run(() => _handler.Handle(value.Message));
            return Ok();
        }
    }
}
