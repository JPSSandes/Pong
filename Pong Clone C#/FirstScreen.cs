using Raylib_cs;

public class FirstScreen (int width, int height)
{
    Game game = new Game(width, height);

        public void DrawFirstScreen()
    {
        if (!Raylib.IsKeyDown(KeyboardKey.Space))
        {
            Raylib.DrawText("Pong C#", (int) (width * 0.23), (int) (height * 0.25), 100, Color.Black);
            Raylib.DrawText("Press \"Space\" to Start Playing", (int) (width * 0.30), (int) (height * 0.5), 20, Color.Black);
        }
        else
        {
            game.DrawGame();
        }
    }
}