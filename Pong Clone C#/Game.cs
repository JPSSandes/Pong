using Raylib_cs;

public class Game (int width, int height)
{
    // variables //

    int racketWidth = width / 40;   // Defines a racket's thickness
    int racketHeight = height / 4;  // Defines a racket's height
    int playerOneScore = 0;         // How many points Player One got
    int playerTwoScore = 0;         // How many points Player Two got
    int speed = 5;                  // Movement Speed

    double playerOneY = height * 0.4;   // Variable used to move left racket
    double playerTwoY = height * 0.4;   // Variable used to move right racket

    bool ballIsGoingUp = true;      // Variable used to move ball up and down
    bool ballIsGoingRight = true;   // Variable used to move ball right and left

    // Method 1 - Main Program

    /*
        Basically the method used to call all the other methods to run the thing.
        Aaaaaaaand that's it, nothing fancy about it
    */
    public void DrawGame()
    {
        DrawPlayerOne();
        DrawPlayerTwo();
    }

    // Methods 2 - Drawing Shapes
    private void DrawPlayerOne()
    {
        MovePlayerOne();
        Raylib.DrawRectangle((int)(width * 0.02), (int) playerOneY, racketWidth, racketHeight, Color.DarkBlue);
    }

    private void DrawPlayerTwo()
    {
        MovePlayerTwo();
        Raylib.DrawRectangle((int)(width * 0.95), (int) playerTwoY, racketWidth, racketHeight, Color.Red);
    }

    // Methods 3 - Basic Movement

    private void MovePlayerOne()
    {
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            playerOneY -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            playerOneY += speed;
        }
    }

    private void MovePlayerTwo()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            playerTwoY -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            playerTwoY += speed;
        }
    }
}