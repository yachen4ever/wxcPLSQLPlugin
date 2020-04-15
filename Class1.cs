using System;
using System.Runtime.InteropServices;

namespace wxcPLSQLPlugin
{
    delegate void IdeCreateWindow(int windowType, string text, [MarshalAs(UnmanagedType.Bool)] bool execute);

    [return: MarshalAs(UnmanagedType.Bool)]
    delegate bool IdeSetText(string text);

    delegate void IdeSplashWriteLn(string s);
    public class wxcPLSQLPlugin
    {

        private const string PLUGIN_NAME = "wxcPLSQLPlugin";
        
        
        private const int PLUGIN_MENU_INDEX = 3;

        //Callback Funtions
        private const int CONST_CB_IDE_CREATE_WINDOW = 20;
        private const int CONST_CB_IDE_SET_TEXT = 34;
        private const int CONST_CB_IDE_SPLASH_WRITELN = 93;

        private static wxcPLSQLPlugin me;

        private static IdeCreateWindow ideCreateWindowCallback;
        private static IdeSetText ideSetTextCallback;
        private static IdeSplashWriteLn ideSplashWriteLnCallback;

        private int pluginId;

        private wxcPLSQLPlugin(int id)
        {
            pluginId = id;
        }

        #region DLL exported API
        //Help PL/SQL Developer to identify this dll to be a plugin. A must-export function.
        [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (me == null)
            {
                me = new wxcPLSQLPlugin(id);
            }
            return PLUGIN_NAME;
        }


        [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            switch (index)
            {
                case CONST_CB_IDE_CREATE_WINDOW:
                    ideCreateWindowCallback = (IdeCreateWindow)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCreateWindow));
                    break;
                case CONST_CB_IDE_SET_TEXT:
                    ideSetTextCallback = (IdeSetText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSetText));
                    break;
                case CONST_CB_IDE_SPLASH_WRITELN:
                    ideSplashWriteLnCallback = (IdeSplashWriteLn)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSplashWriteLn));
                    break;
            }
        }

        [DllExport("OnActive", CallingConvention = CallingConvention.Cdecl)]
        public static void OnActive()
        {
            ideSplashWriteLnCallback("Loading Oryacle Plugin Written by WangXuChen");
        }

        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                me.CreateSqlWindow();
            }
        }

        [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            switch (index)
            {
                case 1:
                    return "TAB=wxcPQPlugin";

                case 2:
                    return "GROUP=Create window";

                case PLUGIN_MENU_INDEX:
                    return "ITEM=Create window";

                default:
                    return "";
            }
        }

        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return "This PL/SQL Developer Plugin is Written by WangXuChen(YaCHEN) Providing Some Useful Function to PL/SQL Developer.";
        }
        #endregion

        public string Name
        {
            get
            {
                return PLUGIN_NAME;
            }

        }
        public void CreateSqlWindow()
        {
            ideCreateWindowCallback(1, "", false);
            ideSetTextCallback("select 'Hello world!' from dual");
        }

    }
}
