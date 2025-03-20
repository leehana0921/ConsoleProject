namespace project_hana
{
    internal class Program
    {
        //플레이어 위치 설청해주기 위한 구조체
        struct Position
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            bool gameEnd = false;
            Position playerPos;
            Position goalpos;
            bool[,] map;

            Title();
            



            StartGame(out playerPos, out goalpos, out map);

            while (gameEnd == false)
            {


                Render(playerPos, goalpos, map);
                ConsoleKey key =  Input();
                Update(key, ref playerPos, goalpos, map, ref gameEnd);
            }

            GameEnd();

        }

        // 시작 시 출력 될 타이틀 적어주기

        static void Title()
        {

 

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("★☆★☆★☆★☆★☆★☆★");



            Console.WriteLine("☆위대한 미로 좋은 미로!☆");


            Console.WriteLine("★☆★☆★☆★☆★☆★☆★");
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("아무 키나 눌러 시작하세요!");

            Console.ReadKey(true);
            Console.Clear();

        }
        // 플레이어 위치 값 입력 받기
        static ConsoleKey Input()
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            return input;
        }
        // 게임 시작
        static void StartGame(out Position playerPos, out Position goalPos, out bool[,] map)
        {
            // 게임 설정
            Console.CursorVisible = false;

            // 플레이어 초기 위치 설정하기
            playerPos.x = 1;
            playerPos.y = 1;

            // Goal 초기 위치 설정하기
            goalPos.x = 28;
            goalPos.y = 13;

            // 맵 크기 지정
            map = new bool[15, 30]
            {  
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false, false },
                { false,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false,  true,false, true, true,false, true, true, true, true, true, false, true, true, true, true, true, false },
                { false,  true, true,  true, false,  true, false,  true, false,  true,  true,  true,  true,  true, true, true, true,false, true, false, true, true, true, false, true,false,false,false, true, false },
                { false,  true, false,  true, false,  true, false,  true, false,  true,  true, false,  true, false, true,false, true, true, true,false, true, true, true, false, true,false, true, true, true, false },
                { false,  true, false, false, false, false, false,  true, true,  true,  true, false, false, false,false,false,false, false, true, false, true, true, true,false, true,false,false,false, true, false },
                { false,  true, false,  true, false,  true,  true,  true, false,  true,  true,  true,  true,  true, true, true, true, true, true,false, true,false, true, false, true, true, true,false, true, false },
                { false,  true, false,  true, false,  true, false, false, false, false, false, false,  true,  true, true, true, true, true, true,false, true,false, true, false,false,false,false,false, true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,false, true,false,false,false,false, true,false, true, true, true, true, true, false, true, false },
                { false,  true, false,  true, false, false, false, false, false,  true,  true, false, false, false,false, true, true, true, true, true, true,false, true, true, true, false, true, true, true, false },
                { false,  true, false,  true,  true,  true,  true, true,  true,  true,  true,  false,  true,  true,false, true,false, true, true, true, true,false,false,false, true,false, true, false, true, false },
                { false,  true, false,  true, false,  true,  true, false,  true,  true, true,  false,  true,  true,false, true,false,false,false, true,false,false, true, true, true,false, true, false, true, false },
                { false,  true,  true,  true, false,  true, false, false, false, false, false, false,  true,  true, true, true, true, true,false, true, true,false,false,false,false,false,false, false, true, false },
                { false, false, false, false, false,  true,  true, false,  true,  true,  true,  true, false, false,false, true, true,false,false, true, true, true, true, true, true, true, true, false, true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,false, true, true, true, true, true, true, true, true, true, false, true, true,false, true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false,false,false,false,false,false,false,false,false,false,false,false,false,false, false },
            };



        }

        // 출력 하기
        static void Render(Position playerPos, Position goalPos, bool[,] map)
        {
            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            PrintGoal(goalPos);
            PrintPlayer(playerPos);

        }

        // 맵 출력
        static void PrintMap(bool[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('#');
                        
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        // 플레이어 움직임 설정하기
        static void Move(ConsoleKey key, ref Position playerPos, bool[,] map)
        {
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        if (map[playerPos.y, playerPos.x - 1] == true)
                        {
                            playerPos.x--;
                        }
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        if (map[playerPos.y, playerPos.x + 1] == true)
                        {
                            playerPos.x++;
                        }
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        if (map[playerPos.y - 1, playerPos.x] == true)
                        {
                            playerPos.y--;
                        }
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (map[playerPos.y + 1, playerPos.x] == true)
                        {
                            playerPos.y++;
                        }
                    }
                    break;
            }
        }


        // 플레이어 표시
        static void PrintPlayer(Position playerPos)
        {
            // 플레이어 위치로 커서 옮기기
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            // 플레이어 표시
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('o');
            Console.ResetColor();
        }

        // Goal 표시
        static void PrintGoal(Position goalPos)
        {
            Console.SetCursorPosition(goalPos.x, goalPos.y);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('O');
            Console.ResetColor();
        }

        // 목표 설정하기 Goal
        static bool Purpose(Position playerPos, Position goalPos)
        {
            bool success = (goalPos.x == playerPos.x) && (goalPos.y == playerPos.y);

            return success;
        }

        // 플레이어의 플레이에 맞춰 계속 업데이트 해 주기
        static void Update(ConsoleKey key , ref Position playerPos, Position goalPos, bool[,] map, ref bool gameEnd)
        {
            Move(key, ref playerPos, map);
            bool isClear = Purpose(playerPos, goalPos);
            if (isClear)
            {
                gameEnd = true;
            }
        }


        // 게임 종료 시 출력

        static void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Goal in~!! 축하합니다! 미로찾기에 성공하셨습니다~!!");
            Console.WriteLine("게임을 종료합니다!");
        }
    }
}
