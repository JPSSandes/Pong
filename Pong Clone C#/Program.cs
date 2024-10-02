using System;
using Raylib_cs;

namespace Pong
{
    class Program
    {
        static int windowWidth = (int)WindowSizes.windowWidth;
        static int windowHeight = (int)WindowSizes.windowHeight;

        static FirstScreen firstScreen = new FirstScreen();

        public static void Main(string[] args)
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Pong Clone C#: Remastered");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                firstScreen.DrawFirstScreen();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}