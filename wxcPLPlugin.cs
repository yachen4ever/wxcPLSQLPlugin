using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace wxcPLSQLPlugin
{
    public class wxcPLSQLPlugin
    {
        //插件信息
        private const string PLUGIN_NAME = "wxcPLSQLPlugin";
        public static string pluginVersion = "Alpha0.6 Builddate20200505";

        //INIParser
        public static IniData settings;

        public string GetPluginVersion()
        {
            return pluginVersion;
        }
        public static string pluginRoot;
        public static string pluginSettingFile;
        public string GetPluginSettingFile()
        {
            return pluginSettingFile;
        }
        private static wxcPLSQLPlugin thisPlugin;
        private int thispluginId;

        #region 菜单项定义
        const int MENU_INDEX_START = 1;
        const int MENU_INDEX_GROUP_FUNCTION = 2;
        const int MENU_INDEX_HELLOWORLD = 3;
        const int MENU_INDEX_WHEREIN = 4;
        const int MENU_INDEX_ESCAPE = 5;
        const int MENU_INDEX_UNESCAPE = 6;
        const int MENU_INDEX_COMMENT = 7;
        const int MENU_INDEX_GROUP_MOST_USED_SQL = 70;
        const int MENU_INDEX_SQL_LOCKEDTABLE = 71;
        const int MENU_INDEX_SQL_PROCRUNNING = 72;
        const int MENU_INDEX_SQL_STOPJOB = 73;
        const int MENU_INDEX_SQL_WHICHJOB = 74;
        const int MENU_INDEX_SQL_TABLEINWHICHPROC = 75;
        const int MENU_INDEX_GROUP_ABOUT = 90;
        const int MENU_INDEX_SETTINGSFORM = 98;
        const int MENU_INDEX_ABOUTFORM = 99;
        #endregion 菜单项定义

        #region 回调方法定义
        //命名规范:驼峰函数名+Callback
        //同时，每个回调方法都有PL/SQL约定好的index。  命名规范:CONST_CB_函数名
        private static SysVersion sysVersionCallback;
        private const int CONST_CB_SYS_VERSION = 1;

        private static SysRootDir sysRootDirCallback;
        private const int CONST_CB_SYS_ROOTDIR = 3;

        private static IdeGetWindowHandle ideGetWindowHandleCallback;
        private const int CONST_CB_IDE_GETWINDOWHANDLE = 16;

        private static IdeGetChildHandle ideGetChildHandleCallback;
        private const int CONST_CB_IDE_GETCHILDHANDLE = 18;

        private static IdeCreateWindow ideCreateWindowCallback;
        private const int CONST_CB_IDE_CREATEWINDOW = 20;

        private static IdeGetText ideGetTextCallback;
        private const int CONST_CB_IDE_GETTEXT = 30;

        private static IdeGetSelectedText ideGetSelectedTextCallback;
        private const int CONST_CB_IDE_GETSELECTEDTEXT = 31;

        private static IdeGetCursorWord ideGetCursorWordCallback;
        private const int CONST_CB_IDE_GETCURSORWORD = 32;

        private static IdeGetEditorHandle ideGetEditorHandleCallback;
        private const int CONST_CB_IDE_GETEDITORHANDLE = 33;

        private static IdeSetText ideSetTextCallback;
        private const int CONST_CB_IDE_SETTEXT = 34;

        private static IdeGetCursorWordPosition ideGetCursorWordPositionCallback;
        private const int CONST_CB_IDE_GETCURSORWORDPOSITION = 38;

        private static IdePerform idePerformCallback;
        private const int CONST_CB_IDE_PERFORM = 39;

        private static SqlExecute sqlExecuteCallback;
        private const int CONST_CB_SQL_EXECUTE = 40;

        private static IdeSplashCreate ideSplashCreateCallback;
        private const int CONST_CB_IDE_SPLASHCREATE = 90;

        private static IdeSplashWrite ideSplashWriteCallback;
        private const int CONST_CB_IDE_SPLASHWRITE = 92;

        private static IdeSplashWriteLn ideSplashWriteLnCallback;
        private const int CONST_CB_IDE_SPLASHWRITELN = 93;

        private static HookProc autoReplaceHookProc = new HookProc(AutoReplaceHookProcCallback);

        #endregion 回调方法定义

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
                    case MENU_INDEX_START:
                        return "TAB=wxcPQPlugin";

                    case MENU_INDEX_GROUP_FUNCTION:
                        return "GROUP=功能";

                    case MENU_INDEX_HELLOWORLD:
                        return "ITEM=Hello World";

                    case MENU_INDEX_WHEREIN:
                        return "ITEM=WHERE IN (X)";

                    case MENU_INDEX_ESCAPE:
                        return "ITEM=将语句写入Execute Immediate";

                    case MENU_INDEX_UNESCAPE:
                        return "ITEM=将语句从Execute Immediate提出";

                    case MENU_INDEX_COMMENT:
                        return "ITEM=注释或去注释语句";

                    case MENU_INDEX_GROUP_MOST_USED_SQL:
                        return "GROUP=常用查询";

                    case MENU_INDEX_SQL_LOCKEDTABLE:
                        return "ITEM=锁表情况";

                    case MENU_INDEX_SQL_PROCRUNNING:
                        return "ITEM=正在运行的存储过程";

                    case MENU_INDEX_SQL_STOPJOB:
                        return "ITEM=终止JOB运行";

                    case MENU_INDEX_SQL_WHICHJOB:
                        return "ITEM=存储过程写在哪个JOB";

                    case MENU_INDEX_SQL_TABLEINWHICHPROC:
                        return "ITEM=表在哪个存储过程创建";

                    case MENU_INDEX_GROUP_ABOUT:
                        return "GROUP=关于";

                    case MENU_INDEX_SETTINGSFORM:
                        return "ITEM=插件设置";

                    case MENU_INDEX_ABOUTFORM:
                        return "ITEM=关于此插件";

                    default:
                        return "";
                }
            }
            //PL/SQL12以下
            else
            {
                switch (index)
                {
                    case MENU_INDEX_START:
                        return "wxcPQPlugin / -";

                    case MENU_INDEX_GROUP_FUNCTION:
                        return "wxcPQPlugin / -";

                    case MENU_INDEX_HELLOWORLD:
                        return "wxcPQPlugin / Hello World";

                    case MENU_INDEX_WHEREIN:
                        return "wxcPQPlugin / WHERE IN (X)";

                    case MENU_INDEX_ESCAPE:
                        return "wxcPQPlugin / 将语句写入Execute Immediate";

                    case MENU_INDEX_UNESCAPE:
                        return "wxcPQPlugin / 将语句从Execute Immediate提出";

                    case MENU_INDEX_COMMENT:
                        return "wxcPQPlugin / 注释或去注释语句";

                    case MENU_INDEX_GROUP_MOST_USED_SQL:
                        return "wxcPQPlugin / 常用查询 / -";

                    case MENU_INDEX_SQL_LOCKEDTABLE:
                        return "wxcPQPlugin / 常用查询 / 锁表情况";

                    case MENU_INDEX_SQL_PROCRUNNING:
                        return "wxcPQPlugin / 常用查询 / 正在运行的存储过程";

                    case MENU_INDEX_SQL_STOPJOB:
                        return "wxcPQPlugin / 常用查询 / 终止JOB运行";

                    case MENU_INDEX_SQL_WHICHJOB:
                        return "wxcPQPlugin / 常用查询 / 存储过程写在哪个JOB";

                    case MENU_INDEX_SQL_TABLEINWHICHPROC:
                        return "wxcPQPlugin / 常用查询 / 表在哪个存储过程创建";

                    case MENU_INDEX_GROUP_ABOUT:
                        return "wxcPQPlugin / -";
                    
                    case MENU_INDEX_SETTINGSFORM:
                        return "wxcPQPlugin / 插件设置";
                    
                    case MENU_INDEX_ABOUTFORM:
                        return "wxcPQPlugin / 关于此插件";

                    default:
                        return "";
                }
            }
        }

        //必需方法。当用户点击插件创建的菜单项时，PL/SQL调用此函数，传入菜单项所对应的index。
        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            switch (index)
            {
                case MENU_INDEX_HELLOWORLD:
                    thisPlugin.OutputEditorHandle();
                    break;
                case MENU_INDEX_WHEREIN:
                    thisPlugin.HandleWhereInX();
                    break;
                case MENU_INDEX_ESCAPE:
                    thisPlugin.HandleEscape();
                    break;
                case MENU_INDEX_UNESCAPE:
                    thisPlugin.HandleUnEscape();
                    break;
                case MENU_INDEX_COMMENT:
                    thisPlugin.HandleComment();
                    break;
                case MENU_INDEX_SQL_LOCKEDTABLE:
                    thisPlugin.MostUsedSql_LockedTable();
                    break;
                case MENU_INDEX_SQL_PROCRUNNING:
                    thisPlugin.MostUsedSql_ProcRunning();
                    break;
                case MENU_INDEX_SQL_STOPJOB:
                    thisPlugin.MostUsedSql_StopJob();
                    break;
                case MENU_INDEX_SQL_WHICHJOB:
                    thisPlugin.MostUsedSql_WhichJob();
                    break;
                case MENU_INDEX_SQL_TABLEINWHICHPROC:
                    thisPlugin.MostUsedSql_TableInWhichProc();
                    break;
                case MENU_INDEX_SETTINGSFORM:
                    thisPlugin.ShowSettingsForm();
                    break;
                case MENU_INDEX_ABOUTFORM:
                    thisPlugin.ShowAboutForm();
                    break;
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
                case CONST_CB_SYS_ROOTDIR:
                    sysRootDirCallback = (SysRootDir)Marshal.GetDelegateForFunctionPointer(function, typeof(SysRootDir));
                    break;
                case CONST_CB_IDE_GETWINDOWHANDLE:
                    ideGetWindowHandleCallback = (IdeGetWindowHandle)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetWindowHandle));
                    break;
                case CONST_CB_IDE_GETCHILDHANDLE:
                    ideGetChildHandleCallback = (IdeGetChildHandle)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetChildHandle));
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
                case CONST_CB_IDE_GETCURSORWORD:
                    ideGetCursorWordCallback = (IdeGetCursorWord)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetCursorWord));
                    break;
                case CONST_CB_IDE_GETEDITORHANDLE:
                    ideGetEditorHandleCallback = (IdeGetEditorHandle)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetEditorHandle));
                    break;
                case CONST_CB_IDE_SETTEXT:
                    ideSetTextCallback = (IdeSetText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSetText));
                    break;
                case CONST_CB_IDE_GETCURSORWORDPOSITION:
                    ideGetCursorWordPositionCallback = (IdeGetCursorWordPosition)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetCursorWordPosition));
                    break;
                case CONST_CB_IDE_PERFORM:
                    idePerformCallback = (IdePerform)Marshal.GetDelegateForFunctionPointer(function, typeof(IdePerform));
                    break; 
                case CONST_CB_SQL_EXECUTE:
                    sqlExecuteCallback = (SqlExecute)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlExecute));
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
            ideSplashWriteLnCallback("加载wxcPQPlugin插件中, 插件版本：" + thisPlugin.GetPluginVersion());
            ideSplashWriteLnCallback("PL/SQL版本： " + sysVersionCallback().ToString());
            pluginRoot = sysRootDirCallback() + @"\Plugins\";
            pluginSettingFile = pluginRoot + "wxcPQPlugin.ini";
            
            if (System.IO.File.Exists(pluginSettingFile))
            {
                ideSplashWriteCallback("找到配置文件，读取中...");
                var iniDataParser = new FileIniDataParser();
                settings = iniDataParser.ReadFile(pluginSettingFile);
            }
            else
            {
                ideSplashWriteCallback("配置文件不存在，生成默认设置...");
                File.WriteAllText(pluginSettingFile, Properties.Resources.DefaultConfig);
                var settingsParser = new FileIniDataParser();
                settings = settingsParser.ReadFile(pluginSettingFile);
            }
            ideSplashWriteCallback("完成");

        }

        [DllExport("OnWindowCreated", CallingConvention = CallingConvention.Cdecl)]
        public static void OnWindowCreated(int WindowType)
        {
            //最大化子窗口
            if (!string.IsNullOrEmpty(settings["Startup"]["MaximizeChildWindow"]) && settings["Startup"]["MaximizeChildWindow"] =="1")
            {
                //获取当前子窗口句柄
                IntPtr windowHandle = ideGetChildHandleCallback();
                Win32API.ShowWindow(windowHandle, ShowWindowCommands.Maximize);
                IntPtr intCurrentEditorHandle = ideGetEditorHandleCallback();
                var threadId = Win32API.GetWindowThreadProcessId(intCurrentEditorHandle, IntPtr.Zero);
                Win32API.SetWindowsHookEx(HookType.WH_KEYBOARD, autoReplaceHookProc, IntPtr.Zero, threadId);
            }

        }

        [DllExport("AfterExecuteWindow", CallingConvention = CallingConvention.Cdecl)]
        public static void AfterExecuteWindow(int WindowType, int Result)
        {
            if (WindowType == 1 && Result > 0)
            {
                //先拉文本
                string strExecuted = ideGetSelectedTextCallback();
                string strAll = ideGetTextCallback();
                //如果根本就没有文本直接退出
                if (string.IsNullOrWhiteSpace(strAll))
                {
                    return;
                }
                //标识是否为选中的文本
                bool flagIsSelected = true;
                //如果没有选中文本，则为否
                if (string.IsNullOrWhiteSpace(strExecuted))
                {
                    flagIsSelected = false;
                }


                //如果没有选中文本则处理全部文本
                if (!flagIsSelected)
                {
                    strExecuted = strAll;
                }

                strExecuted = strExecuted.ToLower();

                //如果有DML语句
                if (!string.IsNullOrEmpty(settings["Function"]["AutoCommit"]) && (strExecuted.Contains("insert") || strExecuted.Contains("delete") || strExecuted.Contains("update") || strExecuted.Contains("merge")))
                {
                    if (settings["Function"]["AutoCommit"] == "1")
                    {

                        //通过IDE_PERFORM执行commit（会提示）
                        bool a = idePerformCallback(4);
                    }
                    else if (settings["Function"]["AutoCommit"] == "2")
                    {
                        //通过SQL_EXECUTE执行commit（不提示）
                        bool a = sqlExecuteCallback("commit;");
                    }
                }
            }
        }

        //关闭窗口事件方法。设置关闭时不要提示保存
        [DllExport("OnWindowClose", CallingConvention = CallingConvention.Cdecl)]
        public static int OnWindowClose(int WindowType, [MarshalAs(UnmanagedType.Bool)] bool Changed)
        {
            if (!string.IsNullOrEmpty(settings["Other"]["AskOnClosing"])) {
                return int.Parse(settings["Other"]["AskOnClosing"]);
            }
            else return 0;
        }

        //About事件方法。设置PL/SQL插件设置窗口里关于的返回值。
        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return " 这是一个为PL/SQL Developer开发的插件，\r\n 用于提供一些PL/SQL缺失的实用功能。\r\n\r\n 开发者信息：\r\n 蚌埠电信分公司 智慧营销中心/IT支撑中心 王旭晨\r\n 联系方式: 18955296958\r\n QQ: 360039166\r\n 项目信息：https://github.com/yachen4ever/wxcPLSQLPlugin \r\n 当前版本：" + pluginVersion;
        }

        //Configure事件方法。设置PL/SQL插件设置窗口里设置按钮的事件。
        [DllExport("Configure", CallingConvention = CallingConvention.Cdecl)]
        public static void Configure()
        {
            SettingsUI frm = new SettingsUI();
            frm.Show(thisPlugin);
        }

        //AfterStart事件方法。触发于PL/SQL加载完所有自身内容和插件后。
        //创建一个空白窗口
        [DllExport("AfterStart", CallingConvention = CallingConvention.Cdecl)]
        public static void AfterStart()
        {
            //默认打开的窗口
            if (!string.IsNullOrEmpty(settings["Startup"]["OpenWindowType"]))
            {
                int intWindowType = int.Parse(settings["Startup"]["OpenWindowType"]);
                if (intWindowType > 0)
                {
                    ideCreateWindowCallback(intWindowType, "", false);
                }
            }

            //最大化PL/SQL窗口
            if (!string.IsNullOrEmpty(settings["Startup"]["MaximizeWindow"]) && settings["Startup"]["MaximizeWindow"] == "1")
            {
                //获取当前子窗口句柄
                IntPtr windowHandle = ideGetWindowHandleCallback();
                Win32API.ShowWindow(windowHandle, ShowWindowCommands.Maximize);
            }
        }

        //DllExport区域结束标识
        #endregion

        public void CreateSqlWindow(string s)
        {
            ideCreateWindowCallback(1, "", false);
            ideSetTextCallback(s);
        }

        //处理WhereInX功能的方法
        public void HandleWhereInX()
        {
            //先拉文本
            //选中的文本
            string strSelected = ideGetSelectedTextCallback();
            //文本框全部文本
            string strAll = ideGetTextCallback();
            //剪切板的文本
            string strClip = "";
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                strClip = (string)iData.GetData(DataFormats.Text);
            }

            //要处理的文本
            string strToBeHandled = "";
            int flagWho = 0;
            //处理优先级:选中的>剪切板>全部
            if (!string.IsNullOrWhiteSpace(strSelected))
            {
                strToBeHandled = strSelected;
                flagWho = 1;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(strClip))
                {
                    strToBeHandled = strClip;
                    flagWho = 2;
                }
                else
                {
                    strToBeHandled = strAll;
                    flagWho = 3;
                }
            }

            //定义处理后的文本
            string strAfterHandle = "(";
            //标识一下需不需要逗号
            bool flagNeedComma = false;

            //处理文本
            //定义一下分隔符
            char[] delimiterChars = {' ', ',', '，', '\t','\r','\n'};
            string[] words = strToBeHandled.Split(delimiterChars);
     
            foreach (var word in words)
            {
                //只要不是空的就格式化下塞进strAfterHandled
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (!flagNeedComma) 
                    {
                        strAfterHandle = strAfterHandle + "'" + word + "'";
                        flagNeedComma = true;
                    }
                    else
                    {
                        strAfterHandle = strAfterHandle + ",'" + word + "'";
                    }
                }
            }
            strAfterHandle += ")";
            //如果没有选中文本直接输出全部文本
            switch(flagWho)
            {
                case 1:
                    ideSetTextCallback(strAll.Replace(strToBeHandled, strAfterHandle));
                    break;
                case 2:
                    ideSetTextCallback(strAll + strAfterHandle);
                    break;
                case 3:
                    ideSetTextCallback(strAfterHandle);
                    break;
                default:
                    break;
            }
        }

        //Escape一句SQL
        public static string EscapeSentence(string strToBeHandled)
        {
            //处理文本
            string strAfterHandle = strToBeHandled.Trim();

            //剔除最后的换行或;
            while (strAfterHandle.EndsWith(";") || strAfterHandle.EndsWith("\r") || strAfterHandle.EndsWith("\n"))
            {
                strAfterHandle = strAfterHandle.Remove(strAfterHandle.Length - 1);
            }
            //转义引号
            strAfterHandle = strAfterHandle.Replace("'", "''");

            //末尾为变量标识
            bool flagVariableAtEnd = false;

            //寻找&
            int intPosOfAmpersand;
            while (true)
            {
                intPosOfAmpersand = strAfterHandle.IndexOf("&");
                //如果没找到或者&在末尾直接结束
                if (intPosOfAmpersand < 0 || intPosOfAmpersand == strAfterHandle.Length - 1)
                {
                    break;
                }
                //变量名从&后一位开始
                int intPosOfVariableStart = intPosOfAmpersand + 1;
                //初始变量长度为1
                int intVariableLength = 1;
                while (true)
                {
                    //如果搜到结尾了就跳出
                    if (intPosOfVariableStart + intVariableLength == strAfterHandle.Length)
                    {
                        break;
                    }
                    //如果这一位还是合法变量名，长度+1
                    if (isLegalVariableChar(strAfterHandle[intPosOfVariableStart + intVariableLength]))
                    {
                        intVariableLength++;
                    }
                    //不合法了跳出
                    else
                    {
                        break;
                    }

                }
                //拉出变量名
                string strVariableName = strAfterHandle.Substring(intPosOfVariableStart, intVariableLength);
                string strAmpersandVariable = "&" + strVariableName;
                string strConnectedVariableInBetween = "'||" + strVariableName + "||'";
                string strConnectedVariableAtEnd = "'||" + strVariableName;
                //如果变量在末尾用尾部不带||的去拼
                if (intPosOfVariableStart + intVariableLength == strAfterHandle.Length)
                {
                    strAfterHandle = strAfterHandle.Replace(strAmpersandVariable, strConnectedVariableAtEnd);
                    flagVariableAtEnd = true;
                }
                //反之用尾部带||的去拼
                else
                {
                    strAfterHandle = strAfterHandle.Replace(strAmpersandVariable, strConnectedVariableInBetween);
                }
            }
            //如果末尾有变量就不需要结尾的单引号了
            if (flagVariableAtEnd)
            {
                strAfterHandle = "Execute Immediate '" + strAfterHandle + ";";
            }
            else
            {
                strAfterHandle = "Execute Immediate '" + strAfterHandle + "';";
            }
            return strAfterHandle;
        }

        //判断是否为合法变量字符
        private static bool isLegalVariableChar(char v)
        {
            if (char.IsLetterOrDigit(v) || v == '_')
            {
                return true;
            }
            return false;
        }

        //UnEscape一句SQL
        public static string UnEscapeSentence(string strToBeHandled)
        {
            //处理文本
            string strAfterHandle = strToBeHandled.Trim();

            //剔除最后的换行或;
            while (strAfterHandle.EndsWith(";") || strAfterHandle.EndsWith("\r") || strAfterHandle.EndsWith("\n"))
            {
                strAfterHandle = strAfterHandle.Remove(strAfterHandle.Length - 1);
            }

            strAfterHandle = strAfterHandle.Replace("''", "'");
            //踢掉execute和immediate
            strAfterHandle = Regex.Replace(strAfterHandle, "execute", "", RegexOptions.IgnoreCase);
            strAfterHandle = Regex.Replace(strAfterHandle, "immediate", "", RegexOptions.IgnoreCase);
            strAfterHandle = strAfterHandle.Trim();
            //剔除开头的引号
            if (strAfterHandle.StartsWith("'"))
            {
                strAfterHandle = strAfterHandle.Remove(0, 1);
            }
            //剔除结尾的引号
            if (strAfterHandle.EndsWith("'"))
            {
                strAfterHandle = strAfterHandle.Remove(strAfterHandle.Length - 1);
            }

            int intPosOfJoint;

            //bug：如果拼接的不是变量而是用到了Oracle函数怎么办，里面可能还会有单引号，括号
            //把用||拼接的变量替换成&变量名
            while (true)
            {
                //找到第一个||
                intPosOfJoint = strAfterHandle.IndexOf("||");
                if (intPosOfJoint <= 0)
                {
                    break;
                }
                //往前找前一串字符串的结尾引号
                int intPosOfPrevEndQuote = intPosOfJoint - 1;
                while (strAfterHandle[intPosOfPrevEndQuote] != '\'')
                {
                    intPosOfPrevEndQuote--;
                }
                //往后找变量名
                int intPosOfVariableStart = intPosOfJoint + 2;
                while (!isLegalVariableChar(strAfterHandle[intPosOfVariableStart]))
                {
                    if (intPosOfVariableStart == strAfterHandle.Length - 1)
                    {
                        break;
                    }
                    intPosOfVariableStart++;
                }
                int intPosOfVariableLength = 1;
                while (isLegalVariableChar(strAfterHandle[intPosOfVariableStart + intPosOfVariableLength]))
                {
                    if (intPosOfVariableStart + intPosOfVariableLength == strAfterHandle.Length - 1)
                    {
                        break;
                    }
                    intPosOfVariableLength++;
                }
                //获得变量名
                string strVariableName = strAfterHandle.Substring(intPosOfVariableStart, intPosOfVariableLength);
                //再往后找下一个||，找不到说明在结尾
                int intPosOfNextStartQuote = intPosOfVariableStart + intPosOfVariableLength;
                while (strAfterHandle[intPosOfNextStartQuote] != '\'')
                {
                    if (intPosOfNextStartQuote == strAfterHandle.Length - 1)
                    {
                        break;
                    }
                    intPosOfNextStartQuote++;
                }
                //替换下
                string strShouldBeReplaced = strAfterHandle.Substring(intPosOfPrevEndQuote, intPosOfNextStartQuote - intPosOfPrevEndQuote + 1);
                strAfterHandle = strAfterHandle.Replace(strShouldBeReplaced, "&" + strVariableName);
            }
            //如果本来语句结尾没分号就补一个
            if (!strAfterHandle.EndsWith(";"))
            {
                strAfterHandle += ";";
            }

            return strAfterHandle;
        }

        //处理Escape功能的方法
        public void HandleEscape()
        {
            //先拉文本
            string strToBeHandled = ideGetSelectedTextCallback();
            string strAll = ideGetTextCallback();
            //如果根本就没有文本直接退出
            if (string.IsNullOrWhiteSpace(strAll))
            {
                return;
            }
            //标识是否为选中的文本
            bool flagIsSelected = true;
            //如果没有选中文本，则为否
            if (string.IsNullOrWhiteSpace(strToBeHandled))
            {
                flagIsSelected = false;
            }


            //如果没有选中文本则处理全部文本
            if (!flagIsSelected)
            {
                strToBeHandled = strAll;
            }

            //处理文本
            string strAfterHandle = EscapeSentence(strToBeHandled);

            //如果没有选中文本直接输出全部文本
            if (!flagIsSelected)
            {
                ideSetTextCallback(strAfterHandle);
            }
            //否则在strAll里替换一下输出回去
            else
            {
                ideSetTextCallback(strAll.Replace(strToBeHandled, strAfterHandle));
            }

        }

        //处理UnEscape功能的方法
        public void HandleUnEscape()
        {
            //先拉文本
            string strToBeHandled = ideGetSelectedTextCallback();
            string strAll = ideGetTextCallback();
            //如果根本就没有文本直接退出
            if (string.IsNullOrWhiteSpace(strAll))
            {
                return;
            }
            //标识是否为选中的文本
            bool flagIsSelected = true;
            //如果没有选中文本，则为否
            if (string.IsNullOrWhiteSpace(strToBeHandled))
            {
                flagIsSelected = false;
            }

            //如果没有选中文本则处理全部文本
            if (!flagIsSelected)
            {
                strToBeHandled = strAll;
            }

            //处理文本
            string strAfterHandle = UnEscapeSentence(strToBeHandled);

            //如果没有选中文本直接输出全部文本
            if (!flagIsSelected)
            {
                ideSetTextCallback(strAfterHandle);
            }
            //否则在strAll里替换一下输出回去
            else
            {
                ideSetTextCallback(strAll.Replace(strToBeHandled, strAfterHandle));
            }

        }

        //处理注释功能的方法
        private void HandleComment()
        {
            //先拉文本
            string strToBeHandled = ideGetSelectedTextCallback();
            string strAll = ideGetTextCallback();
            //如果根本就没有文本直接退出
            if (string.IsNullOrWhiteSpace(strAll))
            {
                return;
            }
            //标识是否为选中的文本
            bool flagIsSelected = true;
            //如果没有选中文本，则为否
            if (string.IsNullOrWhiteSpace(strToBeHandled))
            {
                flagIsSelected = false;
            }

            //如果没有选中文本则处理全部文本
            if (!flagIsSelected)
            {
                strToBeHandled = strAll;
            }

            string strAfterHandle = "";
            //按行切割
            string[] lines = strToBeHandled.Split(new string[] {"\r\n"}, StringSplitOptions.None);
            //默认功能为加注释
            bool flagAllHaveComment = true;

            //如果选中每行都有注释，功能就变成去注释
            foreach (var line in lines)
            {
                if (line.Length <= 0)
                {
                    continue;
                }
                if (line.IndexOf("--") < 0)
                {
                    flagAllHaveComment = false;
                }
            }

            //去注释的情况
            if (flagAllHaveComment)
            {
                foreach (var line in lines)
                {
                    if (line.Length <= 2)
                    {
                        strAfterHandle += line + "\r\n";
                        continue;
                    }
                    //删掉--
                    var strLineAfterHandle = line.Replace("--","");
                    strAfterHandle += strLineAfterHandle + "\r\n";
                }
            }
            //加注释的情况
            else
            {
                foreach (var line in lines)
                {
                    if (line.Length <= 0)
                    {
                        strAfterHandle += line + "\r\n";
                        continue;
                    }
                    var strLineAfterHandle = "--" + line;
                    strAfterHandle += strLineAfterHandle + "\r\n";
                }

            }

            //删除最后多的换行符
            strAfterHandle = strAfterHandle.Remove(strAfterHandle.Length - 2, 2);

            //如果没有选中文本直接输出全部文本
            if (!flagIsSelected)
            {
                ideSetTextCallback(strAfterHandle);
            }
            //否则在strAll里替换一下输出回去
            else
            {
                ideSetTextCallback(strAll.Replace(strToBeHandled, strAfterHandle));
            }
        }

        //显示设置界面
        private void ShowSettingsForm()
        {
            SettingsUI frm = new SettingsUI();
            frm.Show(thisPlugin);
        }

        //显示关于界面
        private void ShowAboutForm()
        {
            AboutForm frm = new AboutForm();
            frm.Show(thisPlugin);
        }

        //常用查询：锁表情况
        private void MostUsedSql_LockedTable()
        {
            CreateSqlWindow("select a.object_name,s.sid,s.serial# from v$locked_object lo,dba_objects a, v$session s where a.object_id=lo.object_id and lo.session_id=s.sid;\r\n\r\n--alter system kill session '&sid,&serial';");
            idePerformCallback(1);
        }

        //常用查询：正在运行的存储过程
        private void MostUsedSql_StopJob()
        {
            CreateSqlWindow("--1.查询出正在执行的Job\r\nselect * from dba_jobs_running;\r\n\r\n--2.将Job标记为Broken\r\nbegin\r\n    DBMS_JOB.BROKEN(&JOB, true);\r\nend;\r\n\r\n--3.根据sid查询出session信息\r\nselect SID,SERIAL# from V$Session where SID=&sid;\r\n\r\n--4.Kill Session\r\nalter system kill session '&sid,&serial';");
        }

        //常用查询：终止JOB运行
        private void MostUsedSql_WhichJob()
        {
            CreateSqlWindow("select job,last_date,last_sec,next_sec,total_time,interval,what from user_jobs\r\nwhere what like '%&PROCNAME%' or what like upper('%&PROCNAME%')");
            idePerformCallback(1);
        }

        //常用查询：存储过程写在哪个JOB
        private void MostUsedSql_ProcRunning()
        {
            CreateSqlWindow("select * from v$db_object_cache where type like 'PROCE%' and locks >0 and pins >0;");
            idePerformCallback(1);
        }

        //常用查询：表在哪个存储过程创建
        private void MostUsedSql_TableInWhichProc()
        {
            CreateSqlWindow("SELECT DISTINCT * FROM user_source WHERE TYPE = 'PROCEDURE' AND upper(text) LIKE '%CREATE TABLE%&TABLENAME%';");
            idePerformCallback(1);
        }

        //刷新设置项，重新读取配置文件
        public void RefreshSetting()
        {
            var iniDataParser = new FileIniDataParser();
            settings = iniDataParser.ReadFile(pluginSettingFile);
        }

        //测试向编辑器输出
        private void OutputEditorHandle()
        {
            IntPtr intCurrentEditorHandle = ideGetEditorHandleCallback();
            SendStringMessage(intCurrentEditorHandle, "Hello World");
            MessageBox.Show(intCurrentEditorHandle.ToString());
        }

        //在编辑器输出输出一个字符串
        private static void SendStringMessage(IntPtr intHandle, string text)
        {
            for (int i = 0;i < text.Length; i++)
            {
                Win32API.SendMessage(intHandle, WM.CHAR, (int)(text[i]), 0);
            }
        }

        //在编辑器向前删除n个字符
        private static void SendBackSpaceNTimes(IntPtr intHandle, int n)
        {
            for (int i = 0; i < n; i++)
            {
                //8是BackSpace的ASCII编码
                //这里需要用WM.KEYDOWN而不是WM.CHAR,因为WM.CHAR是翻译后的字符，详见
                //https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-keydown
                Win32API.SendMessage(intHandle, WM.KEYDOWN, 8, 0);
            }
        }

        //自动替换钩子方法
        //https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644984(v=vs.85)?redirectedfrom=MSDN
        private static IntPtr AutoReplaceHookProcCallback(int code, IntPtr wParam, IntPtr lParam)
        {
            //按键后会发现3次调用：code=0;lParam[0]=0一次；code=0;lParam[0]=1一次；code=3;lParam[0]=0一次；
            //如果code<0按文档要求返回CallNextHookEx
            if (code < 0)
            {
                //you need to call CallNextHookEx without further processing
                //and return the value returned by CallNextHookEx
                return Win32API.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
            }
            //MessageBox.Show(code.ToString()+"\n"+Convert.ToString((int)lParam, 2));
            //code=HC_ACTION，包含信息，lParam用来判断第一位是否为0，捕获下判断KeyDown事件
            //https://docs.microsoft.com/zh-cn/windows/win32/inputdev/about-keyboard-input?redirectedfrom=MSDN#keyboard-focus-and-activation
            if (code == 0 && ((int)lParam & 0x80000000) == 0)
            {
                //把wParam里的按键拉出来
                Keys keyPressed = (Keys)wParam.ToInt32();
                if (keyPressed == Keys.Tab)
                {
                    //获取当前文本编辑框的句柄
                    IntPtr intCurrentEditorHandle = ideGetEditorHandleCallback();
                    //获取当前光标所在的单词
                    string strCursorWord = ideGetCursorWordCallback();
                    //获取当前光标所在的单词的位置
                    int intCursorWordPosition = ideGetCursorWordPositionCallback();

                    //intCursorWordPosition=3意味着当前光标处于所在单词的末尾
                    if (!string.IsNullOrEmpty(strCursorWord) && intCursorWordPosition == 3)
                    {
                        if (!string.IsNullOrEmpty(settings["AutoReplace"][strCursorWord]))
                        {
                            //先把要替换的部分删了
                            SendBackSpaceNTimes(intCurrentEditorHandle, strCursorWord.Length);
                            //把替换的塞进去
                            SendStringMessage(intCurrentEditorHandle, settings["AutoReplace"][strCursorWord]);
                        }
                        //返回非空值使得键盘键入事件不再传入pl/sql自己处理（打出tab的效果）
                        return (IntPtr)1;
                    }
                    
                }
            }
            
            //如果不处于可以替换的情况，还把Tab键传回PL/SQL以打出tab
            return Win32API.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

    }
}  
