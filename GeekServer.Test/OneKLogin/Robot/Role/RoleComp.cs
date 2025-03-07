﻿using NLog;
using System.Threading.Tasks;

namespace Geek.Server.Test
{
    public class RoleComp : NoHotfixComponent { }

    public class RoleCompAgent : FuncComponentAgent<RoleComp>
    {
        static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public override async Task Active()
        {
            await base.Active();
        }

        public async Task Start()
        {
            //连接服务器
            await ConnectServer();
            await Task.Delay(500);

            //登陆
            var login = await GetCompAgent<LoginCompAgent>();
            await login.ReqLogin();

            //获取背包数据
            var bag = await GetCompAgent<BagCompAgent>();
            await bag.ReqBagInfo();
        }

        public async Task ConnectServer()
        {
            var net = await GetCompAgent<NetCompAgent>();
            await net.Start();
        }

    }
}
