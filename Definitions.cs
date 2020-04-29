using System;
using System.Runtime.InteropServices;

namespace wxcPLSQLPlugin
{
    #region 委托回调方法定义

    //序号1，获得PL/SQL Developer版本信息
    delegate int SysVersion();
    //序号3，获得PL/SQL Developer根路径
    delegate string SysRootDir();
    //序号16，获得当前PL/SQL窗口的句柄
    delegate IntPtr IdeGetWindowHandle();
    //序号18，获得当前激活子窗口的句柄
    delegate IntPtr IdeGetChildHandle();
    //序号20，创建窗口
    delegate void IdeCreateWindow(int windowType, string text, [MarshalAs(UnmanagedType.Bool)] bool execute);
    //序号30，获得窗口中的值
    delegate string IdeGetText();
    //序号31，获得窗口中选中的值
    delegate string IdeGetSelectedText();
    //序号34，设置窗口中的值
    [return: MarshalAs(UnmanagedType.Bool)] delegate bool IdeSetText(string text);
    //序号39，执行特定操作
    [return: MarshalAs(UnmanagedType.Bool)] delegate bool IdePerform(int Param);
    //序号40，执行SQL语句
    [return: MarshalAs(UnmanagedType.Bool)] delegate bool SqlExecute(string SQL);
    //序号90，新建登录界面（会自动替换原有并加上进度条)
    delegate void IdeSplashCreate(int progressMax);
    //序号92，改变登录界面文字
    delegate void IdeSplashWrite(string s);
    //序号93，改变登录界面文字+换行
    delegate void IdeSplashWriteLn(string s);

    #endregion 委托回调方法定义

    #region 枚举定义
    //声明WinAPI:ShowWindow的参数列表
    enum ShowWindowCommands
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        Hide = 0,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window
        /// for the first time.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        ShowMinimized = 2,
        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        Maximize = 3, // is this the right value?
        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>      
        ShowMaximized = 3,
        /// <summary>
        /// Displays a window in its most recent size and position. This value
        /// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except
        /// the window is not activated.
        /// </summary>
        ShowNoActivate = 4,
        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        Show = 5,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level
        /// window in the Z order.
        /// </summary>
        Minimize = 6,
        /// <summary>
        /// Displays the window as a minimized window. This value is similar to
        /// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the
        /// window is not activated.
        /// </summary>
        ShowMinNoActive = 7,
        /// <summary>
        /// Displays the window in its current size and position. This value is
        /// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the
        /// window is not activated.
        /// </summary>
        ShowNA = 8,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// </summary>
        Restore = 9,
        /// <summary>
        /// Sets the show state based on the SW_* value specified in the
        /// STARTUPINFO structure passed to the CreateProcess function by the
        /// program that started the application.
        /// </summary>
        ShowDefault = 10,
        /// <summary>
        ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        /// that owns the window is not responding. This flag should only be
        /// used when minimizing windows from a different thread.
        /// </summary>
        ForceMinimize = 11
    }

    #endregion 枚举定义


}
