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

            const string BOX_STRING = "B";

            const int INITIAL_WALL_X = 6;
            const int INITIAL_WALL_Y = 5;
            const string WALL_STRING = "W";
            
            const int INITIAL_GOAL_X = 7;
            const int INITIAL_GOAL_Y = 8;
            const string GOAL_STRING = "G";

            const int GOAL_COUNT = 3;
            const int BOX_COUNT = GOAL_COUNT;

            // 플레이어 위치 좌표
            int playerX = INITIAL_PLAYER_X;
            int playerY = INITIAL_PLAYER_Y;
            Direction playerDirection = Direction.Left;

            // 박스 좌표
            int[] boxPositionsX = new int[BOX_COUNT] { 1, 3, 5 };
            int[] boxPositionsY = new int[BOX_COUNT] { 4, 2, 9 };

            // 벽 좌표
            int wallX = INITIAL_WALL_X;
            int wallY = INITIAL_WALL_Y;
            
            // 골 좌표
            int[] goalPositionsX = new int[GOAL_COUNT] { 3, 5, 8 };
            int[] goalPositionsY = new int[GOAL_COUNT] { 3, 6, 3 };
            
            // 게임 루프
            while (true)
            {
                // Render
                Console.Clear();    // 이전 프레임을 지운다.

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER_STRING);

                // 박스를 그려준다.
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    Console.SetCursorPosition(boxPositionsX[i], boxPositionsY[i]);
                    Console.Write(BOX_STRING);
                }

                // 벽을 그려준다.
                Console.SetCursorPosition(wallX, wallY);
                Console.Write(WALL_STRING);
                
                // 목표 지점을 그려준다.
                for (int i = 0; i < GOAL_COUNT; ++i)
                {
                    Console.SetCursorPosition(goalPositionsX[i], goalPositionsY[i]);
                    Console.Write(GOAL_STRING);
                }

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

                // 벽 충돌 처리
                if (playerX == wallX && playerY == wallY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            playerX = playerX + PLAYER_MOVE_RANGE;
                            break;
                        case Direction.Right:
                            playerX = playerX - PLAYER_MOVE_RANGE;
                            break;
                        case Direction.Up:
                            playerY = playerY + PLAYER_MOVE_RANGE;
                            break;
                        case Direction.Down:
                            playerY = playerY - PLAYER_MOVE_RANGE;
                            break;
                        default:
                            Console.WriteLine("오류 발생");
                            break;
                    }
                }

                // 박스 이동
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    int boxX = boxPositionsX[i];
                    int boxY = boxPositionsY[i];

                    if (playerX != boxX || playerY != boxY)
                    {
                        continue;
                    }

                    switch (playerDirection)
                    {
                        case Direction.Left:
                            if (boxX == CONSOLE_MIN_X || (boxX - PLAYER_MOVE_RANGE == wallX && boxY == wallY))
                            {
                                playerX = boxX + PLAYER_MOVE_RANGE;
                            }
                            else
                            {
                                boxX = boxX - PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Right:
                            if (boxX == CONSOLE_MAX_X || (boxX + PLAYER_MOVE_RANGE == wallX && boxY == wallY))
                            {
                                playerX = boxX - PLAYER_MOVE_RANGE;
                            }
                            else
                            {
                                boxX = boxX + PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Up:
                            if (boxY == CONSOLE_MIN_Y || (boxY - PLAYER_MOVE_RANGE == wallY && boxX == wallX))
                            {
                                playerY = boxY + PLAYER_MOVE_RANGE;
                            }
                            else
                            {
                                boxY = boxY - PLAYER_MOVE_RANGE;
                            }
                            break;
                        case Direction.Down:
                            if (boxY == CONSOLE_MAX_Y || (boxY + PLAYER_MOVE_RANGE == wallY && boxX == wallX))
                            {
                                playerY = boxY - PLAYER_MOVE_RANGE;
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

                    boxPositionsX[i] = boxX;
                    boxPositionsY[i] = boxY;
                }

                // 목표 달성 확인
                int matchCount = 0;
                for (int i = 0; i < GOAL_COUNT; ++i)
                {
                    for (int j = 0; j < BOX_COUNT; ++j)
                    {
                        if (goalPositionsX[i] == boxPositionsX[j] && goalPositionsY[i] == boxPositionsY[j])
                        {
                            ++matchCount;
                        }
                    }
                }

                if (matchCount == GOAL_COUNT)
                {
                    Console.Clear();
                    Console.WriteLine("축하합니다. 클리어 하셨습니다.");

                    break;
                }
            }
        }
    }
}

