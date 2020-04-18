using System;
using System.Runtime.InteropServices;

namespace wxcPLSQLPlugin
{
    //声明引入回调方法

    //序号1，获得PL/SQL Developer版本信息
    delegate int SysVersion();
    //序号20，创建窗口
    delegate void IdeCreateWindow(int windowType, string text, [MarshalAs(UnmanagedType.Bool)] bool execute);
    //序号30，获得窗口中的值
    delegate string IdeGetText();
    //序号31，获得窗口中选中的值
    delegate string IdeGetSelectedText();
    //序号34，设置窗口中的值
    [return: MarshalAs(UnmanagedType.Bool)] delegate bool IdeSetText(string text);
    //序号90，新建登录界面（会自动替换原有并加上进度条)
    delegate void IdeSplashCreate(int progressMax);
    //序号93，改变登录界面文字
    delegate void IdeSplashWrite(string s);
    //序号93，改变登录界面文字+换行
    delegate void IdeSplashWriteLn(string s);
  


    public class wxcPLSQLPlugin
    {
        //插件信息
        private const string PLUGIN_NAME = "wxcPLSQLPlugin";
        private static wxcPLSQLPlugin thisPlugin;
        private int thispluginId;

        private const int PLUGIN_MENU_INDEX = 3;

        //回调方法定义                             命名规范:驼峰函数名+Callback
        //同时，每个回调方法都有PL/SQL约定好的index。  命名规范:CONST_CB_函数名
        private static SysVersion sysVersionCallback;
        private const int CONST_CB_SYS_VERSION = 1;

        private static IdeCreateWindow ideCreateWindowCallback;
        private const int CONST_CB_IDE_CREATEWINDOW = 20;

        private static IdeGetText ideGetTextCallback;
        private const int CONST_CB_IDE_GETTEXT = 30;

        private static IdeGetSelectedText ideGetSelectedTextCallback;
        private const int CONST_CB_IDE_GETSELECTEDTEXT = 31;

        private static IdeSetText ideSetTextCallback;
        private const int CONST_CB_IDE_SETTEXT = 34;

        private static IdeSplashCreate ideSplashCreateCallback;
        private const int CONST_CB_IDE_SPLASHCREATE = 90;

        private static IdeSplashWrite ideSplashWriteCallback;
        private const int CONST_CB_IDE_SPLASHWRITE = 92;

        private static IdeSplashWriteLn ideSplashWriteLnCallback;
        private const int CONST_CB_IDE_SPLASHWRITELN = 93;

        //插件名
        public string Name
        {
            get
            {
                return PLUGIN_NAME;
            }

        }
        //构造方法
        private wxcPLSQLPlugin(int id)
        {
            thispluginId = id;
        }

        //DllExport区域开始标识，标识DllExport的即为最后会导出到DLL动态链接库的方法。需导出三个必需方法、回调函数注册方法和需要使用的事件方法。
        #region DLL exported API

        //必需方法。PL/SQL会传入一个插件ID，使用传入的ID构造一个wxcPLSQLPlugin对象，存入thisPlugin，最后返回插件名。
        [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (thisPlugin == null)
            {
                thisPlugin = new wxcPLSQLPlugin(id);
            }
            return PLUGIN_NAME;
        }

        //必需方法。PL/SQL会调用这个函数99次，分别传入index=1-99，对于每个index可以创建一次菜单项，PL/SQL会将这个index和菜单项绑定起来，供OnMenuClick使用。
        //PL/SQL12改为Ribbon界面后写法与之前不兼容，具体见官方文档
        [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            //PL/SQL12及以上
            if (sysVersionCallback()>=1200)
            {
                switch (index)
                {
                    case 1:
                        return "TAB=wxcPQPlugin";

                    case 2:
                        return "GROUP=Crt window";

                    case PLUGIN_MENU_INDEX:
                        return "ITEM=Hello World";

                    default:
                        return "";
                }
            }
            //PL/SQL12以下
            else
            {
                switch (index)
                {
                    case 1:
                        return "wxcPQPlugin / -";

                    //case 2:
                    //    return "wxcPQPlugin / Crt Window";

                    case PLUGIN_MENU_INDEX:
                        return "wxcPQPlugin / Hello World";

                    default:
                        return "";
                }
            }
        }

        //必需方法。当用户点击插件创建的菜单项时，PL/SQL调用此函数，传入菜单项所对应的index。
        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                thisPlugin.CreateSqlWindow();
            }
        }

        //回调函数注册方法。用于注册插件需要使用到的PL/SQL回调函数，对每个回调方法，将其指针传入定义好的函数变量，完成初始化
        [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            switch (index)
            {
                case CONST_CB_SYS_VERSION:
                    sysVersionCallback = (SysVersion)Marshal.GetDelegateForFunctionPointer(function, typeof(SysVersion));
                    break;
                case CONST_CB_IDE_CREATEWINDOW:
                    ideCreateWindowCallback = (IdeCreateWindow)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCreateWindow));
                    break;
                case CONST_CB_IDE_GETTEXT:
                    ideGetTextCallback = (IdeGetText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetText));
                    break;
                case CONST_CB_IDE_GETSELECTEDTEXT:
                    ideGetSelectedTextCallback = (IdeGetSelectedText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetSelectedText));
                    break;
                case CONST_CB_IDE_SETTEXT:
                    ideSetTextCallback = (IdeSetText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSetText));
                    break;
                case CONST_CB_IDE_SPLASHCREATE:
                    ideSplashCreateCallback = (IdeSplashCreate)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSplashCreate));
                    break;
                case CONST_CB_IDE_SPLASHWRITELN:
                    ideSplashWriteLnCallback = (IdeSplashWriteLn)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSplashWriteLn));
                    break;
                case CONST_CB_IDE_SPLASHWRITE:
                    ideSplashWriteCallback = (IdeSplashWrite)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSplashWrite));
                    break;
            }
        }

        //OnActivate事件方法。
        [DllExport("OnActivate", CallingConvention = CallingConvention.Cdecl)]
        public static void OnActivate()
        {
            ideSplashCreateCallback(100);
            ideSplashWriteLnCallback("");
            ideSplashWriteCallback("Loading wxcPQPlugin： ");
            ideSplashWriteCallback("PL/SQL版本： " + sysVersionCallback().ToString());
        }

        //About事件方法。设置PL/SQL插件设置窗口里关于的返回值。
        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return "This Oryacle (A PL/SQL Developer Plugin) is Written by WangXuChen(YaCHEN) Providing Some Useful Function to PL/SQL Developer.";
        }

        //DllExport区域结束标识
        #endregion

        public void CreateSqlWindow()
        {
            ideCreateWindowCallback(1, "", false);
            ideSetTextCallback("select 'Hello world!' from dual");
        }

    }
}
