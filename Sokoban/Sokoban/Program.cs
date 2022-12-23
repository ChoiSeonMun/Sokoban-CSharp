using System;
using System.Windows.Input;

namespace Sokoban
{
    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

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

            // 상수 정의
            const int CONSOLE_MIN_X = 0;
            const int CONSOLE_MIN_Y = 0;
            const int CONSOLE_MAX_X = 15;
            const int CONSOLE_MAX_Y = 10;

            const int INITIAL_PLAYER_X = 0;
            const int INITIAL_PLAYER_Y = 0;
            const int PLAYER_MOVE_RANGE = 1;
            const string PLAYER_STRING = "P";

            const int INITIAL_BOX_X = 5;
            const int INITIAL_BOX_Y = 5;
            const string BOX_STRING = "B";

            // 플레이어 위치 좌표
            int playerX = INITIAL_PLAYER_X;
            int playerY = INITIAL_PLAYER_Y;
            Direction playerDirection = Direction.Left;

            // 박스 좌표
            int boxX = INITIAL_BOX_X;
            int boxY = INITIAL_BOX_Y;

            // 게임 루프
            while (true)
            {
                // Render
                Console.Clear();    // 이전 프레임을 지운다.

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER_STRING);
                // 박스를 그려준다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write(BOX_STRING);

                // ProcessInput
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // Update
                // 플레이어 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)   // 위로 이동 
                {
                    playerY = (int)Math.Max(0, playerY - PLAYER_MOVE_RANGE);
                    playerDirection = Direction.Up;
                }

                if (currentKeyInfo.Key == ConsoleKey.DownArrow) // 아래로 이동 
                {
                    playerY = (int)Math.Min(playerY + PLAYER_MOVE_RANGE, CONSOLE_MAX_Y);
                    playerDirection = Direction.Down;
                }

                if (currentKeyInfo.Key == ConsoleKey.LeftArrow) // 왼쪽으로 이동 
                {
                    playerX = (int)Math.Max(0, playerX - PLAYER_MOVE_RANGE);
                    playerDirection = Direction.Left;
                }

                if (currentKeyInfo.Key == ConsoleKey.RightArrow) // 오른쪽으로 이동 
                {
                    playerX = (int)Math.Min(playerX + PLAYER_MOVE_RANGE, CONSOLE_MAX_X);
                    playerDirection = Direction.Right;
                }

                // 박스 이동
                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            if (boxX == CONSOLE_MIN_X)
                            {
                                playerX = CONSOLE_MIN_X + 1;
                            }
                            else
                            {
                                boxX = boxX - PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Right:
                            if (boxX == CONSOLE_MAX_X)
                            {
                                playerX = CONSOLE_MAX_X - 1;
                            }
                            else
                            {
                                boxX = boxX + PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Up:
                            if (boxY == CONSOLE_MIN_Y)
                            {
                                playerY = CONSOLE_MIN_Y + 1;
                            }
                            else
                            {
                                boxY = boxY - PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Down:
                            if (boxY == CONSOLE_MAX_Y)
                            {
                                playerY = CONSOLE_MAX_Y - 1;
                            }
                            else
                            {
                                boxY = boxY + PLAYER_MOVE_RANGE;
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

