﻿using System;
using System.Windows.Input;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            // 초기 세팅
            Console.ResetColor();           // 컬러를 초기화한다.
            Console.CursorVisible = false;  // 커서를 숨긴다.
            Console.Title = "My Sokoban";   // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.Cyan;    // 배경색을 설정한다.
            Console.Clear();                // 콘솔 창에 출력된 내용을 모두 지운다.

            Console.WriteLine("Hello, Console Game!");
        }
    }
}
