# WXCPLSQLPlugin

这是一个为PL/SQL开发的插件，用于替代年久失修的CnPlugin

## Todo List
1. 点击按钮自动将一串字符a{sep}b{sep}c拼接成where x in ('a','b','c'),{sep}可为{',',' ','CRLF'}
2. 比自带的自动替换更好用的Auto Replace功能，可自定义替换按键
3. 自动将语句替换增加/去除转义的功能。（针对需要Execute Immediate时需要将语句放入字符串的情况）
