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
    public partial class GameOver : UserControl
    {
        //local variables
        SoundPlayer gameoversong = new SoundPlayer(Properties.Resources.gameOverSound);
        public GameOver()
        {
            InitializeComponent();
            //play gameover song
            gameoversong.Play();
            //gameover label
            gameOverLabel.Text += $"GAME OVER \nYour score was {GameScreen.score} \nPlay Again?";
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }

        //restart a new game
        private void restartButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        //close game
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
