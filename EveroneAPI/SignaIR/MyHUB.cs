using EveroneAPI.ContextDB;
using EveroneAPI.ContextDB.Models;
using EveroneAPI.Models;
using EveroneAPI.Models.File;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWT
{

    public class MyHUB : Hub
    {
        public static ConcurrentDictionary<string, UserInfo> UserInfos { get; }
        public const string ChatName = "找工作-.-";
        private readonly ContextDBs db;
        public MyHUB(ContextDBs _db)
        {
            db = _db;
        }

        static MyHUB()
        {
            UserInfos = new ConcurrentDictionary<string, UserInfo>();
        }

        private static readonly object SyncObj = new object();
        public class SignalrRedisHelper
        {
            public static IEnumerable<shoping> ShopingList(ContextDBs db)
            {
                var sa = db.shoping.ToList();
                return sa;
            }
        }
        public override async Task OnConnectedAsync()
        {
            var http = Context.GetHttpContext();
            var client = new UserInfo()
            {
                UserName = http.Request.Query["UserName"],
                Avatar = http.Request.Query["avatar"]
            };
            lock (SyncObj)
            {
                UserInfos[Context.ConnectionId] = client;
            }

            await base.OnConnectedAsync();
            await Groups.AddToGroupAsync(Context.ConnectionId, ChatName);
            await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("system", $"用户{client.UserName}加入了群聊");
            await Clients.Client(Context.ConnectionId).SendAsync("system", $"成功加入{ChatName}");

        }
        //同样在用户断开连接时做离线处理
        public override async Task OnDisconnectedAsync(Exception exception)
        {

            await base.OnDisconnectedAsync(exception);

            bool isRemoved;
            UserInfo client;
            lock (SyncObj)
            {
                isRemoved = UserInfos.TryRemove(Context.ConnectionId, out client);


            }
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, ChatName);

            if (isRemoved)
            {
                await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("system", $"用户{client.UserName}加入了群聊");
            }

        }
        //一个简单的发送消息方法
        public async Task SendMessage(string msg)
        {
            var client = UserInfos.Where(x => x.Key == Context.ConnectionId).Select(x => x.Value).FirstOrDefault();
            if (client == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("system", "您已不在聊天室,请重新加入");
            }
            else
            {
                await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("receive", new { msg, nickName = client.UserName, avatar = client.Avatar });
            }
        }


        //public Task SendMessage(string msg)
        //{
        //    return Clients.All.SendAsync("ReceiveMessage", msg);
        //}
        //如果有新的连接建立了, 这个方法就会被执行.
        #region OnConnectedAsync注释
        // 在Hub类里, 我们可以访问到Context属性.从Context属性那, 我们可以获得一个常用的属性叫做ConnectionId.这个ConnectionId就是连接到Hub的这个客户端的唯一标识.
        //使用ConnectionId, 我们就可以取得这个客户端, 并调用其方法, 如图中的Clients.Client(connectionId).xxx.
        //Hub的Clients属性表示客户端, 它有若干个方法可以选择客户端, 刚才的Client(connectionId)就是使用connectionId找到这一个客户端.而AllExcept(connectionId) 就是除了这个connectionId的客户端之外的所有客户端.更多方法请查看文档.
        //SignalR还有Group分组的概念, 而且操作简单, 这里用到的是Hub的Groups属性.向一个Group名添加第一个connectionId的时候, 分组就被建立.移除分组内最后一个客户端的时候, 分组就被删除了.使用Clients.Group("组名")可以调用组内客户端的方法.
        #endregion

        //public override async Task OnConnectedAsync()
        //{
        //    var connectionId = Context.ConnectionId;
        //    await Clients.Client(connectionId).SendAsync("someFunc");
        //    await Clients.AllExcept(connectionId).SendAsync("someFunc");
        //    //将同一个人的连接ID绑定到同一个分组，推送时就推送给这个分组
        //    await Groups.AddToGroupAsync(connectionId, "MyGroup");
        //    await Groups.RemoveFromGroupAsync(connectionId, "MyGroup");
        //    await Clients.Groups("MyGroup").SendAsync("someFunc");
        //}

        ////发送消息--发送给指定用户
        //public Task SendPrivateMessage(string userId, string message)
        //{
        //    return Clients.User(userId).SendAsync("ReceiveMessages", message);
        //}





    }
}
