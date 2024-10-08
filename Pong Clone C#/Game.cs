using Raylib_cs;

public class Game
{
    // constants //
    const int windowWidth = (int) WindowSizes.windowWidth;      // defines game window's width
    const int windowHeight = (int) WindowSizes.windowHeight;    // defines game window's height

    // variables //
    
    // integers
    int racketWidth = windowWidth / 40;   // Defines a racket's thickness
    static int racketHeight = windowHeight / 4;  // Defines a racket's height
    int playerOneScore = 0;         // How many points Player One got
    int playerTwoScore = 0;         // How many points Player Two got
    int speed = 5;                  // Movement Speed

    // doubles
    static double playerOneY = windowHeight * 0.4;   // Variable used to move left racket
    static double playerTwoY = windowHeight * 0.4;   // Variable used to move right racket
    double ballX = windowWidth / 2;           // Variable used to move ball in X axis
    double ballY = windowWidth * 0.33;          // Variable used to move ball in Y axis
    static double playerOneCollision = racketHeight % Math.Round(playerOneY);  // Variable used for coliding the ball with player one
    static double playerTwoCollision = racketHeight % Math.Round(playerTwoY);  // Variable used for coliding the ball with player two

    // booleans
    bool ballIsGoingUp = true;      // Variable used to move ball up and down
    bool ballIsGoingRight = true;   // Variable used to move ball right and left

    // Method 1 - Main Program //

    /*
        Basically the method used to call all the other methods to run the thing.
        Aaaaaaaand that's it, nothing fancy about it
    */
    public void DrawGame()
    {
        GameOver();
    }

    // Methods 2 - Drawing Shapes //

    /*
        Exclusive for Player One.
        Uses W and S to move left racket.
    */
    private void DrawPlayerOne()
    {
        MovePlayerOne();
        Raylib.DrawRectangle((int)(windowWidth * 0.02), (int) playerOneY, racketWidth, racketHeight, Color.DarkBlue);
    }

    /*
        Exclusive for Player Two
        Uses Up and Down arrows to move right racket.
    */
    private void DrawPlayerTwo()
    {
        MovePlayerTwo();
        Raylib.DrawRectangle((int)(windowWidth * 0.95), (int) playerTwoY, racketWidth, racketHeight, Color.Red);
    }

    /*
        Exclusive for the ball
        It moves kinda like the DVD logo on screen
    */
    private void DrawBall()
    {
        MoveBallX();
        MoveBallY();
        Raylib.DrawCircle((int) ballX, (int) ballY, 10, Color.Black);
    }

    private void DrawScore()
    {
        Raylib.DrawText($"{playerOneScore}", (windowWidth / 2) - 20, 10, 20, Color.DarkBlue);
        Raylib.DrawText("|", windowWidth / 2, 10, 20, Color.Black);
        Raylib.DrawText($"{playerTwoScore}", (windowWidth / 2) + 10, 10, 20, Color.Red);
    }

    // Methods 3 - Basic Movement

    /*
        Both methds are auxiliary methods for the Draw Methods
        Both of them and the ball's methods use the speed variable.
        Why? Because only now I've set a target FPS for the game of 60.
        
    */

    private void MovePlayerOne()
    {
        PlayerOneLimits();
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
        PlayerTwoLimits();
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            playerTwoY -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            playerTwoY += speed;
        }
    }

    private void MoveBallX()
    {
        BallXLimit();
        if (ballIsGoingRight)
        {
            ballX += speed * 0.75;
        }
        else
        {
            ballX -= speed * 0.75;
        }
    }

    private void MoveBallY()
    {
        BallYLimit();
        if (ballIsGoingUp)
        {
            ballY -= speed * 0.75;
        }
        else
        {
            ballY += speed * 0.75;
        }
    }

    private void ResetBallPosition()
    {
        ballX = windowWidth / 2;
        ballY = windowHeight / 3;
    }

    // Methods 4 - Limits

    /*
        Defines both upper and bottom limits for player one.
        For context, this game grid functions like the godot one,
        so in practice the top most point of the grid is 0 and
        the bottom most point is the one defined by the height
        of the window. What I thought is: if I tries to go below
        zero, what could I think to stop it? The answer I got was:
        If going up uses playerOneY--, I'll just need to use playerOne++
        to anulate both, thus stopping movement for that area. The same
        applies for the bottom limit but inverting playerOneY-- with
        playerOne++ and vice-versa.
    */
    private void PlayerOneLimits()
    {
        if (playerOneY < 0)
        {
            playerOneY += speed;
        }
        else if (playerOneY > windowHeight - racketHeight)
        {
            playerOneY -= speed;
        }
    }

    /*
        Basically the same logic of the prior method.
        The only difference is that instead of 
        playerOneY it's playerTwoY
    */
    private void PlayerTwoLimits()
    {
        if (playerTwoY < 0)
        {
            playerTwoY += speed;
        }
        else if (playerTwoY > windowHeight - racketHeight)
        {
            playerTwoY -= speed;
        }
    }

    private void BallYLimit()
    {
        if (ballY < 0 || ballY > windowHeight)
        {
            ballIsGoingUp = !ballIsGoingUp;
        }
    }

    private void BallXLimit()
    {
        if (ballX <= racketWidth)
        {
            playerTwoScore++;
            ResetBallPosition();
        }
        else if (ballX >= windowWidth - racketWidth)
        {
            playerOneScore++;
            ResetBallPosition();
        }
    }

    private void PlayerVersusBall()
    {
        if (ballX <= windowWidth * 0.05)
        {
            if (!(ballY <= playerOneY || ballY >= playerOneY + playerOneCollision))
            {
                ballIsGoingRight = true;
            }
        }
        else if (ballX >= windowWidth * 0.95)
        {
            if (!(ballY <= playerTwoY || ballY >= playerTwoY + playerTwoCollision))
            {
                ballIsGoingRight = false;
            }
        }
    }

    private void GameOver()
    {
        if (playerOneScore < 10 && playerTwoScore < 10)
        {
            DrawPlayerOne();
            DrawPlayerTwo();
            DrawBall();
            DrawScore();
            PlayerVersusBall();
        }
        else
        {
            if (playerTwoScore >= 10)
            {
                Raylib.DrawText("Player 2 Wins!", windowWidth / 2 - 75, windowHeight / 2, 20, Color.Red);
            }
            else if (playerOneScore >= 10)
            {
                Raylib.DrawText("Player 1 Wins!", windowWidth / 2 - 75, windowHeight / 2, 20, Color.DarkBlue);
            }
        }
    }
}