﻿/*
 小米系统解锁器
 @zsh2401
 2017/9/8
 */
using AutumnBox.Basic.AdbEnc;
using AutumnBox.Basic.Functions.Event;
using AutumnBox.Basic.Util;
using System.Threading;

namespace AutumnBox.Basic.Functions
{
    /// <summary>
    /// 小米系统解锁器(非BL锁解锁器),操作完成后可以获得完整root权限,前提是,必须是开发版并且已经开启开发版的root权限
    /// </summary>
    public sealed class XiaomiSystemUnlocker : FunctionModule
    {
        private static new FunctionRequiredDeviceStatus RequiredDeviceStatus = FunctionRequiredDeviceStatus.Running;
        public XiaomiSystemUnlocker() : base(RequiredDeviceStatus){}
        protected override void MainMethod()
        {
            adb.Execute(DeviceID, "root");
            Thread.Sleep(300);
            OutputData o = adb.Execute(DeviceID, "disable-verity");
            OnFinish(this, new FinishEventArgs() { OutputData = o });
            adb.Execute(DeviceID, "reboot");
        }
    }
}