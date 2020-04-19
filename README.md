# WXCPLSQLPlugin

这是一个为PL/SQL Developer开发的插件，用于替代年久失修的CnPlugin

## Features Already Have
1. 点击按钮自动将一串字符a{sep}b{sep}c拼接成where x in ('a','b','c'),{sep}可为{',',' ',TAB,CR,LF,CRLF}
2. 自动将语句替换增加/去除转义的功能。（针对需要Execute Immediate时需要将语句放入字符串的情况）

## Todo List
1. 比自带的自动替换更好用的Auto Replace功能，可自定义替换按键
2. 打开PL/SQL自动启动一个SQL查询窗口
3. 自动Commit （软件自带有，提供个设置）

## Better Experience
1. wherexin功能直接从剪切板拉取数据
2. 去除Execute Immediate还没有做到字符串内拼接的变量名自动变成&变量
3. 代码块和存储过程的转换？值得考虑
