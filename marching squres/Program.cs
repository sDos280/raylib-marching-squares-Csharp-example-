using Raylib_cs;
using engine;
using System.Numerics;
using System.Linq.Expressions;

namespace marching_squares
{
    internal class Program
    {
        const int screenWidth = 800;
        const int screenHeight = 800;

        const int rows = 40;
        const int columns = 40;

        const float tile_x = screenWidth / (columns - 1);
        const float tile_y = screenHeight / (rows - 1);

        static int[,] grid = new int[columns, rows];

        static bool WithInterpolation = true;

        public static void Main()
        {
            Raylib.InitWindow(screenWidth, screenHeight, "raylib [other] example - marching squres algorithm");

            Raylib.SetTargetFPS(60);

            Raylib.SetRandomSeed(10);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[c, r] = Raylib.GetRandomValue(0, 1);
                }
            }

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        Raylib.DrawCircle((int)(c * tile_x), (int)(r * tile_y), 5, grid[c, r] == 1 ? Color.WHITE : Color.BLACK);
                    }
                }

                for (int r = 0; r < rows - 1; r++)
                {
                    for (int c = 0; c < columns - 1; c++)
                    {
                        int Case = getTileCase(grid[c, r], grid[c + 1, r], grid[c, r + 1], grid[c + 1, r + 1]);

                        Vector2 topleftPoint = new Vector2(c * tile_x, r * tile_y);
                        Vector2 toprightPoint = new Vector2((c + 1) * tile_x, r * tile_y);
                        Vector2 buttomleftPoint = new Vector2(c * tile_x, (r + 1) * tile_y);
                        Vector2 buttomrightPoint = new Vector2((c + 1) * tile_x, (r + 1) * tile_y);

                        float topleftPointValue = grid[c, r] + 1;
                        float toprightPointValue = grid[c + 1, r] + 1;
                        float buttomleftPointValue = grid[c, r + 1] + 1;
                        float buttomrightPointValue = grid[c + 1, r + 1] + 1;

                        Vector2 middleUpPoint = new Vector2();
                        Vector2 middleDownPoint = new Vector2();
                        Vector2 middleRightPoint = new Vector2();
                        Vector2 middleLeftPoint = new Vector2();

                        if (WithInterpolation)
                        {
                            middleUpPoint = Raymath.Vector2Lerp(topleftPoint, toprightPoint, (1 - topleftPointValue) / (toprightPointValue - topleftPointValue));
                            middleDownPoint = Raymath.Vector2Lerp(buttomleftPoint, buttomrightPoint, (1 - buttomleftPointValue) / (buttomrightPointValue - buttomleftPointValue));
                            middleRightPoint = Raymath.Vector2Lerp(toprightPoint, buttomrightPoint, (1 - toprightPointValue) / (buttomrightPointValue - toprightPointValue));
                            middleLeftPoint = Raymath.Vector2Lerp(topleftPoint, buttomleftPoint, (1 - topleftPointValue) / (buttomleftPointValue - topleftPointValue));
                        }
                        else
                        {
                            middleUpPoint = (topleftPoint + toprightPoint) / 2;
                            middleDownPoint = (buttomleftPoint + buttomrightPoint) / 2;
                            middleRightPoint = (toprightPoint + buttomrightPoint) / 2;
                            middleLeftPoint = (topleftPoint + buttomleftPoint) / 2;
                        }


                        

                        switch (Case)
                        {
                            case 0:
                                break;

                            case 1:
                                Raylib.DrawLineV(middleDownPoint, middleLeftPoint, Color.WHITE);
                                break;

                            case 2:
                                Raylib.DrawLineV(middleDownPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 3:
                                Raylib.DrawLineV(middleLeftPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 4:
                                Raylib.DrawLineV(middleUpPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 5:
                                Raylib.DrawLineV(middleUpPoint, middleLeftPoint, Color.WHITE);
                                Raylib.DrawLineV(middleDownPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 6:
                                Raylib.DrawLineV(middleUpPoint, middleDownPoint, Color.WHITE);
                                break;

                            case 7:
                                Raylib.DrawLineV(middleUpPoint, middleLeftPoint, Color.WHITE);
                                break;

                            case 8:
                                Raylib.DrawLineV(middleUpPoint, middleLeftPoint, Color.WHITE);
                                break;

                            case 9:
                                Raylib.DrawLineV(middleUpPoint, middleDownPoint, Color.WHITE);
                                break;

                            case 10:
                                Raylib.DrawLineV(middleUpPoint, middleRightPoint, Color.WHITE);
                                Raylib.DrawLineV(middleDownPoint, middleLeftPoint, Color.WHITE);
                                break;

                            case 11:
                                Raylib.DrawLineV(middleUpPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 12:
                                Raylib.DrawLineV(middleLeftPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 13:
                                Raylib.DrawLineV(middleDownPoint, middleRightPoint, Color.WHITE);
                                break;

                            case 14:
                                Raylib.DrawLineV(middleDownPoint, middleLeftPoint, Color.WHITE);
                                break;

                            case 15:
                                break;
                        }
                    }
                }
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        static int getTileCase(int topleft, int topright, int buttomleft, int buttomright)
        {
            return topleft * 8 + topright * 4 + buttomright * 2 + buttomleft;
        }
    }
}