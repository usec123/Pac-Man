using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[,][] _coords = new int[29, 29][];
        public Label[,] _game = new Label[29,29];
        public PictureBox _player = new PictureBox();
        public char _direction = 'n';
        public Queue<char> _queuedDirections = new Queue<char>();
        public int _directionQueueTimeout = 2;
        public Point _playerSpawnPoint;

        private void Form1_Load(object sender, EventArgs e)
        {
            // no borders => FormBorderStyle = None

            for (int i = 0; i < 29; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    _coords[i, j] = new int[2] { i * (this.Width / 29), j * (this.Height / 29) };
                    _game[i, j] = new Label();
                    _game[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    _game[i,j].Size = new Size(this.Width/29, this.Height/29);
                    _game[i, j].Location = new Point(_coords[i, j][0], _coords[i, j][1]);
                    _game[i, j].ForeColor = Color.White;
                    _game[i, j].Text = "a";
                    this.Controls.Add(_game[i, j]);
                    _game[i, j].Show();
                }
            }

            _game[28, 0].Text = "X";
            _game[28, 0].Font = new Font(_game[28, 28].Font.FontFamily, 16, FontStyle.Bold);
            _game[28, 0].ForeColor = Color.Red;
            _game[28, 0].MouseDown += new MouseEventHandler(exitClick);
            _game[28, 0].Cursor = Cursors.Hand;
            
            _playerSpawnPoint = new Point(_coords[15, 24][0], _coords[15, 24][1]);

            // set up player
            _player.Name = "playerPb";
            _player.Size = new Size(28, 28);
            _player.BackgroundImage = Properties.Resources.pacman;
            _player.BackgroundImageLayout = ImageLayout.Stretch;
            _player.Location = _playerSpawnPoint;
            this.Controls.Add(_player);
            _player.Show();
            _player.BringToFront();
        }

        void exitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
