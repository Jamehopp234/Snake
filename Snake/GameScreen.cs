using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{

    public partial class GameScreen : UserControl
    {
        //list all public variables
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;
        snake hero;
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.LimeGreen);
        List<Obstacles> obstacles = new List<Obstacles>();
        Random randGen = new Random();
        Food food;
        public static int score = 0;
        Rectangle player;
        Bitmap upSprite = new Bitmap(Properties.Resources.snakeUp);
        Bitmap leftSprite = new Bitmap(Properties.Resources.snakeLeft);
         Bitmap downSprite = new Bitmap(Properties.Resources.snakeDown);
        Bitmap rightSprite = new Bitmap(Properties.Resources.snakeRight);
        Bitmap deadSprite = new Bitmap(Properties.Resources.snakeDead);
        public string direction;
        SoundPlayer pointScored = new SoundPlayer(Properties.Resources.Point);




        public GameScreen()
        {
            InitializeComponent();
            //show score as 0
            scoreLabel.Text = "Score: 0";

           
            // set player and food attrubutes
            food = new Food(randGen.Next(50, 350),randGen.Next(50,350));

            hero = new snake(50, 100);
            player = new Rectangle(hero.x,hero.y,hero.width,hero.height);

        }
        //setting up the movment
        private void GameScreen_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    direction = "left";
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    direction = "right";
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    direction = "up";
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    direction = "down";
                    downArrowDown = true;
                    break;

            }
        }

        private void GameScreen_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
        { // paint the hero hitbox
            e.Graphics.FillRectangle(greenBrush, hero.x, hero.y, hero.width, hero.height);
            //paint the obstacles
            foreach(Obstacles o in obstacles)
            {
                e.Graphics.DrawImage(deadSprite, o.x, o.y, o.width, o.height);
            }
            // paint the food
            e.Graphics.FillRectangle(redBrush, food.x, food.y, food.width, food.height);
           
            //paint the movement direction
            if(direction == "up")
            {
                e.Graphics.DrawImage(upSprite, hero.x, hero.y, hero.width, hero.height);
            }
          else  if (direction == "left")
            {
                e.Graphics.DrawImage(leftSprite, hero.x, hero.y, hero.width, hero.height);
            }
           else if (direction == "down")
            {
                e.Graphics.DrawImage(downSprite, hero.x, hero.y, hero.width, hero.height);
            }
          else  if (direction == "right")
            {
                e.Graphics.DrawImage(rightSprite, hero.x, hero.y, hero.width, hero.height);
            }

        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            //update player position
            player = new Rectangle(hero.x, hero.y, hero.width, hero.height);

            //player movement
            if (direction == "up" && hero.y > 20)
            {
                hero.Move("up");

            }
            if (direction == "down" && hero.y < this.Height - hero.height -20)
            {
                hero.Move("down");
            }
            if (direction == "right" && hero.x < this.Width - hero.width - 10)
            {
                hero.Move("right");
            }
            if (direction == "left" && hero.x > 10)
            {
                hero.Move("left");
            }

            //point scoring system
            if(player.IntersectsWith(food.food))
            {
                score++;
                pointScored.Play();
                scoreLabel.Text = "";
                scoreLabel.Text += $"Score: {score}";
                int x = randGen.Next(50, 800);
                int y = randGen.Next(50, 600);
                foreach(Obstacles o in obstacles)
                {
                    if(Math.Abs(x - o.x) < 30)
                    {
                        x = randGen.Next(50, 800);
                    }
                    if (Math.Abs(y - o.y) < 30)
                    {
                        y = randGen.Next(50,600);
                    }
                }

                food = new Food(x,y);
                snake.speed++;
                Obstacles newObstacle = new Obstacles(randGen.Next(0, this.Width), randGen.Next(0, this.Height));
                obstacles.Add(newObstacle);
            }
            // how to lose
            foreach(Obstacles o in obstacles)
            {
                if (player.IntersectsWith(o.obstacle))
                {
                    Form1.ChangeScreen(this, new GameOver());
                    gameEngine.Enabled = false;
                    break;
                }
            }

            

            Refresh();
        }
    }
}
