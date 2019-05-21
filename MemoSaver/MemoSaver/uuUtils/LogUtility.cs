using System;
using System.IO;
using Xamarin.Forms;

namespace uuUtils
{
    public static class LogUtility
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        private static string _savePath = null;
        public static IDependDevice DependSerivce = DependencyService.Get<IDependDevice>();

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="err">エラー内容</param>
        public static void OutPutError(string err)
        {
            //保存パスを形成する
            //保存パス＝ドキュメントパス＆アプリ名_yyyyMMdd.log
            if (String.IsNullOrEmpty(_savePath))
            {
                _savePath = DependSerivce.GetDocumentPath();
                if (!_savePath.EndsWith("/"))
                {
                    _savePath += "/";
                }
                _savePath += DependSerivce.GetPackageName() + "_";
            }
            //ログ内容の成形
            string msg = "---------------------------------------------------------------------------------------------" + System.Environment.NewLine +
                         DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " Error " + System.Environment.NewLine +
                         err;

            //Visual Studio 上でのログを出力する
            System.Diagnostics.Debug.WriteLine(msg);

            //ファイルログを出力する
            DependSerivce.OutPutLog(_savePath + DateTime.Now.ToString("yyyyMMdd") + ".log", msg);
        }
    }
}