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
    public partial class MenuScreen : UserControl
    {
        // menu song variable
        SoundPlayer gameSong = new SoundPlayer(Properties.Resources.Tetris);
        public MenuScreen()
        {
            InitializeComponent();
            // play the menu song
            gameSong.Play();
            // intructions
            startLabel.Text = "Welcome to Snake! \nCollect the red squares for points \nAvoid the dead green snakes \nPress Start to play \nPress Exit to close the game";
        }

        //when the player clicks start change to game screen
        private void startButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        // if the player hits exit close the app
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
