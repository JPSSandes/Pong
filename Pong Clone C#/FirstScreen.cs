using Raylib_cs;

public class FirstScreen
{
    Game game = new Game();
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
        Raylib.DrawText("Pong C#", (int) ((int)WindowSizes.windowWidth * 0.23), (int) ((int)WindowSizes.windowHeight * 0.25), 100, Color.Black);
        Raylib.DrawText("Press \"Space\" to Start Playing", (int)((int)WindowSizes.windowWidth * 0.33), (int)WindowSizes.windowHeight / 2, 20, Color.Black);
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