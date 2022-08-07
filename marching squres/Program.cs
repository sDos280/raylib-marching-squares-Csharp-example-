using Raylib_cs;
using engine;

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
                        Raylib.DrawCircle(tile_x * c, tile_y * r, 5, grid[c, r] == 1 ? Color.BLACK : Color.WHITE);
                    }
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}