using System;
using System.Threading.Tasks;
using EveroneAPI.ContextDB;
using JWT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EveroneAPI.Controllers
{
    [EnableCors("any")]//跨域
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignaLRController : ControllerBase
    {
        private readonly IHubContext<MyHUB> ContHub;
        private readonly ContextDBs db;
        public SignaLRController(IHubContext<MyHUB> _ContHub, ContextDBs _db)
        {
            ContHub = _ContHub;
            db = _db;
        }
        // HttpGet api/signalr
        [HttpGet]
        public async Task<int> Post()
        {

            await ContHub.Clients.All.SendAsync("ReceiveMessage", "系统通知", $"你他妈的是真的帅");
            return 0;
        }

     



    }
}