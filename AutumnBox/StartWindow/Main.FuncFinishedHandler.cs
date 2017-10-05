﻿namespace AutumnBox
{
    using AutumnBox.UI;
    using System;
    using System.Windows;
    using AutumnBox.Util;
    using AutumnBox.Basic.Functions.Event;
    using AutumnBox.Basic.Functions;
    using AutumnBox.Helper;

    /// <summary>
    /// 各种界面事件
    /// </summary>
    public partial class StartWindow
    {
        string mweTag = "MainWindowEvent";
        #region 功能事件
        /// <summary>
        /// 通用事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FuncFinish(object sender, FinishEventArgs e)
        {
            UIHelper.CloseRateBox();
            if (sender is FileSender)
            {
                PushFinish(sender, e);
            }
            else if (sender is BreventServiceActivator)
            {
                ActivatedBrvent(sender, e);
            }
            else if (sender is ActivityLauncher)
            {
                //TODO
            }
            else if (sender is CustomRecoveryFlasher)
            {
                FlashCustomRecFinish(sender, e);
                //TODO
            }
            else if (sender is RebootOperator)
            {
                //TODO
            }
            else if (sender is XiaomiSystemUnlocker)
            {
                UnlockMiSystemFinish(sender, e);
            }
            else if (sender is XiaomiBootloaderRelocker)
            {
                RelockMiFinish(sender, e);
            }
        }

        /// <summary>
        /// 黑域启动完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivatedBrvent(object sender, FinishEventArgs e)
        {
            Logger.D(TAG, e.OutputData.Error.ToString());
            Logger.D(TAG, e.OutputData.Out.ToString());
            this.Dispatcher.Invoke(new Action(() =>
            {
                UIHelper.CloseRateBox();
            }));
            if (!e.Result.IsSuccessful) {
                MMessageBox.ShowDialog(this,"Fail",e.Result.OutputData.ToString());
            }
        }

        /// <summary>
        /// 解锁小米系统完成时的事件
        /// </summary>
        /// <param name="o"></param>
        private void UnlockMiSystemFinish(object sender, FinishEventArgs e)
        {
            Logger.D(mweTag, "UnlockMiSystemFinish Event ");
            this.Dispatcher.Invoke(new Action(() =>
            {
                UIHelper.CloseRateBox();
            }));
        }

        /// <summary>
        /// 重新给小米手机上锁完成时的事件
        /// </summary>
        /// <param name="o"></param>
        private void RelockMiFinish(object sender, FinishEventArgs e)
        {
            Logger.D(mweTag, "Relock Mi Finish");
            this.Dispatcher.Invoke(new Action(() =>
            {
                //this.core.Reboot(nowDev, Basic.Arg.RebootOptions.System);
            }));
            this.Dispatcher.Invoke(new Action(() =>
            {
                UIHelper.CloseRateBox();
            }));
        }

        /// <summary>
        /// 推送文件到SDCARD完成的事件
        /// </summary>
        /// <param name="outputData">操作时的输出数据</param>
        private void PushFinish(object sender, FinishEventArgs e)
        {
            Logger.D(mweTag, "Push finish");
            if (e.Result.IsSuccessful)
            {
                MMessageBox.ShowDialog(this, Application.Current.Resources["Notice"].ToString(), Application.Current.FindResource("msgPushOK").ToString());
            }
            else {
                MMessageBox.ShowDialog(this, Application.Current.Resources["Notice"].ToString(), "Push_Failed 0x123123121232");
            }
        }

        /// <summary>
        /// 刷入自定义Recovery完成时发生的事件
        /// </summary>
        /// <param name="outputData">操作时的数据数据</param>
        private void FlashCustomRecFinish(object sender, FinishEventArgs e)
        {
            Logger.D(mweTag, "Flash Custom Recovery Finish");
            this.Dispatcher.Invoke(new Action(() =>
            {
                UIHelper.CloseRateBox();
            }));
            MMessageBox.ShowDialog(this, Application.Current.FindResource("Notice").ToString(), Application.Current.FindResource("msgFlashOK").ToString());
        }
        #endregion
    }
}