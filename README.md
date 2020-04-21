# WXCPLSQLPlugin

这是一个为PL/SQL Developer开发的插件，用于提供一些PL/SQL缺失的实用功能。

## Features Already Have
1. 点击按钮自动将一串字符a{sep}b{sep}c拼接成where x in ('a','b','c'),{sep}可为{',',' ',TAB,CR,LF,CRLF}
2. 自动将语句替换增加/去除转义的功能。（针对Execute Immediate时需要将语句放入字符串/从Execute Immediate提取出的情况）
3. 打开PL/SQL自动启动一个SQL查询窗口
4. 关于窗口
5. 添加/去除注释（针对行、代码块、行中的一部分）

## Todo List
1. 比自带的自动替换更好用的Auto Replace功能，可自定义替换按键
2. 自动Commit （软件自带有，提供个设置）
3. 插件设置界面

## Better Experience
1. wherexin功能直接从剪切板拉取数据
2. [已基本完成]去除Execute Immediate还没有做到字符串内拼接的变量名自动变成&变量
3. 代码块和存储过程的转换？值得考虑

## Known Bugs
1. UnEscapeSentence时如果拼接的不是变量而是用到了Oracle函数，里面可能还会有单引号，括号。这种情况UnEscape不正常

## What Differs it from CnPlugin
 CnPlugin是本插件的启发来源，该插件有以下问题：
1. 非开源，无法fork，在已有基础上增删功能，使得我必须重写
2. 时间陈旧，最新版本1.5.5更新于2011年5月，年久失修，bug无人解决
3. 1.5.1之后的版本与Win8、Win10有严重兼容性问题，基本无法使用

## Thanks
1. (CnPlugin)[http://blog.sina.com.cn/marcconverter]
2. (DllExport)[https://github.com/3F/DllExport]
3. (Newtonsoft.Json)[https://github.com/JamesNK/Newtonsoft.Json]