using Raylib_cs;
using engine;
using System.Numerics;
using System.Linq.Expressions;

namespace marching_squres
{
    internal class Program
    {
        const int screenWidth = 800;
        const int screenHeight = 800;

        const int rows = 20;
        const int columns = 20;

        const int tile_x = screenWidth / columns;
        const int tile_y = screenHeight / rows;

        static int[,] grid = new int[columns, rows];

        public static void Main()
        {
            Raylib.InitWindow(screenWidth, screenHeight, "raylib [other] example - marching squres algorithm");

            Raylib.SetTargetFPS(60);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = Raylib.GetRandomValue(0, 1);
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
                        Raylib.DrawCircle(tile_x * r, tile_y * c, 5, grid[r, c] == 1 ? Color.WHITE : Color.BLACK);
                    }
                }

                for (int r = 0; r < rows - 1; r++)
                {
                    for (int c = 0; c < columns - 1; c++)
                    {
                        int Case = getTileCase(grid[r, c], grid[r + 1, c], grid[r, c + 1], grid[r + 1, c + 1]);

                        Vector2 topleftPoint = new Vector2(r * tile_x, c * tile_y);
                        Vector2 toprightPoint = new Vector2((r + 1) * tile_x, c * tile_y);
                        Vector2 buttomleftPoint = new Vector2(r * tile_x, (c + 1) * tile_y);
                        Vector2 buttomrightPoint = new Vector2((r + 1) * tile_x, (c + 1) * tile_y);

                        Vector2 middleUpPoint = (topleftPoint + toprightPoint) / 2;
                        Vector2 middleDownPoint = (buttomleftPoint + buttomrightPoint) / 2;
                        Vector2 middleRightPoint = (toprightPoint + buttomrightPoint) / 2;
                        Vector2 middleLeftPoint = (topleftPoint + buttomleftPoint) / 2;

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
                                break;

                            case 6:
                                break;

                            case 7:
                                break;

                            case 8:
                                break;

                            case 9:
                                break;

                            case 10:
                                break;

                            case 11:
                                break;

                            case 12:
                                break;

                            case 13:
                                break;

                            case 14:
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