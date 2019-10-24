using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    /// <summary>
    /// Klasa, w ktorej tworzymy menu
    /// </summary>
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Tworzymy prycisk "Start"
        /// </summary>
        
        private void button1_Click(object sender, EventArgs e)
        {

            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            
            
            
        }

        /// <summary>
        /// Tworzymy prycisk "Exit"
        /// </summary>
       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
