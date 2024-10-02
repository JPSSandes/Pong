using System;
using Raylib_cs;

namespace Pong
{
    class Program
    {
        static int windowWidth = 800;
        static int windowHeight = 480;

        static FirstScreen firstScreen = new FirstScreen(windowWidth, windowHeight);

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