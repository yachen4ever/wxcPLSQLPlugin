﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxcPLSQLPlugin
{
    class MyFunc
    {
        //转义
        public static string MyEscape(string text)
        {
            text += "wxc_EOL";
            text = text.Replace("\r\n", "wxc_ENTER");
            return text;
        }

        //去转义
        public static string MyUnEscape(string text)
        {
            text = text.Replace("wxc_ENTER", "\r\n");
            text = text.Replace("wxc_EOL", "");
            return text;
        }

        //判断是否为合法变量字符
        public static bool IsLegalVariableChar(char v)
        {
            if (char.IsLetterOrDigit(v) || v == '_')
            {
                return true;
            }
            return false;
        }

        //在编辑器输出输出一个字符串
        public static void SendStringMessage(IntPtr intHandle, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\r')
                {
                    continue;
                }
                else if (text[i] == '\n' && i > 0 && text[i - 1] == '\r')
                {
                    Win32API.SendMessage(intHandle, WM.KEYDOWN, 13, 0);
                }
                else
                {
                    Win32API.SendMessage(intHandle, WM.CHAR, (int)(text[i]), 0);
                }
            }
        }

        //在编辑器向前删除n个字符
        public static void SendBackSpaceNTimes(IntPtr intHandle, int n)
        {
            for (int i = 0; i < n; i++)
            {
                //8是BackSpace的ASCII编码
                //这里需要用WM.KEYDOWN而不是WM.CHAR,因为WM.CHAR是翻译后的字符，详见
                //https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-keydown
                Win32API.SendMessage(intHandle, WM.KEYDOWN, 8, 0);
            }
        }

        //判断是否为合法的一句SQL查询语句
        public static bool IsLegalSQLSelectSentence(string sql)
        {

            return true;
        }
    }
}
