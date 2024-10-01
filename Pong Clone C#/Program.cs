using System;
using Raylib_cs;

namespace Pong
{
    class Program
    {
        static int windowWidth = 800;
        static int windowHeight = 480;

        public static void Main(string[] args)
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Pong Clone C#: Remastered");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}