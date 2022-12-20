using System;
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
            //Console.BackgroundColor = ConsoleColor.;    // 배경색을 설정한다.
            Console.Clear();                // 콘솔 창에 출력된 내용을 모두 지운다.

            // 플레이어 위치 좌표
            int playerX = 0;
            int playerY = 0;
            int playerDir = 0; // 1 : Left / 2 : Right / 3 : Up / 4 : Down

            // 박스 좌표
            int boxX = 5;
            int boxY = 5;

            // 게임 루프
            while (true)
            {
                // Render
                Console.Clear();    // 이전 프레임을 지운다.

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");
                // 박스를 그려준다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");

                // ProcessInput
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // Update
                // 플레이어 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)   // 위로 이동 
                {
                    playerY = (int)Math.Max(0, playerY - 1);
                    playerDir = 3;
                }

                if (currentKeyInfo.Key == ConsoleKey.DownArrow) // 아래로 이동 
                {
                    playerY = (int)Math.Min(playerY + 1, 10);
                    playerDir = 4;
                }

                if (currentKeyInfo.Key == ConsoleKey.LeftArrow) // 왼쪽으로 이동 
                {
                    playerX = (int)Math.Max(0, playerX - 1);
                    playerDir = 1;
                }

                if (currentKeyInfo.Key == ConsoleKey.RightArrow) // 오른쪽으로 이동 
                {
                    playerX = (int)Math.Min(playerX + 1, 15);
                    playerDir = 2;
                }

                // 박스 이동
                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerDir)
                    {
                        case 1: // Left
                            if (boxX == 0)
                            {
                                playerX = 1;
                            }
                            else
                            {
                                boxX = boxX - 1;
                            }
                            break;
                        case 2: // Right
                            if (boxX == 15)
                            {
                                playerX = 14;
                            }
                            else
                            {
                                boxX = boxX + 1;
                            }
                            break;
                        case 3: // Up
                            if (boxY == 0)
                            {
                                playerY = 1;
                            }
                            else
                            {
                                boxY = boxY - 1;
                            }
                            break;
                        case 4: // Down
                            if (boxY == 10)
                            {
                                playerY = 9;
                            }
                            else
                            {
                                boxY = boxY + 1;
                            }
                            break;
                        default:
                            Console.WriteLine("오류 발생");
                            break;
                    }
                }
            }
        }
    }
}

