using Raylib_cs;

public class FirstScreen (int width, int height)
{
    Game game = new Game(width, height);
    bool isGameRunning = false;

        public void DrawFirstScreen()
    {
        if (isGameRunning == false)
        {
            Text();
            RunGame();
        }
        else
        {
            game.DrawGame();
        }
    }

    private void Text()
    {
        Raylib.DrawText("Pong C#", (int) (width * 0.23), (int) (height * 0.25), 100, Color.Black);
        Raylib.DrawText("Press \"Space\" to Start Playing", (int) (width * 0.30), (int) (height * 0.5), 20, Color.Black);
    }

    private void RunGame()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Space))
        {
            isGameRunning = true;
        }
        else
        {
            isGameRunning = false;
        }
    }
}