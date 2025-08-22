using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace learun.webapi
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：即使通信服务(可供客户端调用的方法开头用小写)
    /// </summary>
    public class ChatsHub : Hub
    {
        #region 重载Hub方法
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //await AddOnline();
            await base.OnConnectedAsync();
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="exception">异常信息</param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await RemoveOnline();
            await base.OnDisconnectedAsync(exception);
        }
        #endregion

        private static readonly ConcurrentDictionary<string, string> clientIdMap =
            new ConcurrentDictionary<string, string>();

        #region 客户端操作
        ///// <summary>
        ///// 添加在线用户
        ///// </summary>
        //public async Task AddOnline()
        //{
        //}
        /// <summary>
        /// 移除在线用户
        /// </summary>
        public async Task RemoveOnline()
        {
            string clientId = Context.ConnectionId;
            clientIdMap.TryRemove(clientId, out string userId);
            if (!string.IsNullOrEmpty(userId)) {
                await Groups.RemoveFromGroupAsync(clientId, userId);
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="myUserId">我的UserId</param>
        /// <param name="toUserId">对方UserId</param>
        /// <param name="msg">消息</param>
        /// <param name="id">消息</param>
        /// <param name="isSystem">是否系统消息0不是1是</param>
        public async Task SendMsg(string myUserId, string toUserId, string msg,string id, int isSystem)
        {
            if (string.IsNullOrEmpty(toUserId))
            {
                return;
            }

            await Clients.Group(toUserId).SendAsync("RevMsg",myUserId, msg, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id, isSystem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task SendInfo(string userId)
        {
            string clientId = Context.ConnectionId;
            
            clientIdMap.TryRemove(clientId,out string _userId);
            if (!string.IsNullOrEmpty(_userId))
            {
                await Groups.RemoveFromGroupAsync(clientId, _userId);
            }

            clientIdMap.GetOrAdd(clientId, userId);
            
            await Groups.AddToGroupAsync(clientId, userId);
        }

        #endregion
    }
}
