using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{

    //Name: James Hopper
    //Class: ICS4U
    //Date: 04/12/23
    
    //This game is a riff on the classsic game snake execpt the snake doesnt grow, only its speed.
    //To compinsate for the snake not growing obstacles will spawn that will kill the snake if it runs into it.
    //Red squares will appear across the game boad that the snake tries to collect.
    //Collecting these squares will increase the players score.
    //When collecting squares the players speed will increase and more obstacles will spawn.
    //The goal of the game is to get as many points as possible before dieing.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //load the menu screen
            ChangeScreen(this, new MenuScreen());
        }
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;                          //f is sender
            }
            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender
                f = current.FindForm();                     //find Form UserControl is on
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }
    }
}
