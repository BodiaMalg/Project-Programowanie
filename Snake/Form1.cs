using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    /// <summary>
    /// Tworzymy główną formę gry, w której tworzymy wszystkie funkcje.
    /// </summary>
    public partial class Form1 : Form
    {

        public List<Circle> Snake = new List<Circle>(); 
        public Circle food = new Circle();  

        
        public Form1()
        {
            InitializeComponent();

            

            new Settings();

            
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();


            StartGame();
        }
        /// <summary>
        /// Tworzymy funkcje startu gry, początkową pozycję graca
        /// </summary>
        private void StartGame()
        {
            lblGameOver.Visible = false;

            
            new Settings();

            Snake.Clear();
            Circle head = new Circle {X = 10, Y = 5};  //Startowa pozycja gracza
            Snake.Add(head);


            lblScore.Text = Settings.Score.ToString();   
            GenerateFood();

        }
        /// <summary>
        /// Umieścienie losowego jedzienia
        /// </summary>
      
        private string GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width; // ustawienie maksymalnej pozycji tworzenia jedzenia
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle {
                X = random.Next(0, maxXPos),
                Y = random.Next(0, maxYPos)
            };

            return "food generated";
        }

        /// <summary>
        /// Funkcja sprawdza błędne ruchy
        /// </summary>

        private void UpdateScreen(object sender, EventArgs e)
        {
           
            if (Settings.GameOver)
            {
                
                
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left) 
                    Settings.direction = Direction.Right; //jeśli naciśnięty przycisk Right, a kierunek nie rowna się Left to Direction = Right
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }

            pbCanvas.Invalidate(); //wszystkie dane zostaną usunięte i uruchomione ponownie

        }
        /// <summary>
        /// Funkcja rysuję mapę, gracza i jedzenie
        /// </summary>

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {

                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    if (i == 0)
                        snakeColour = Brushes.Black;     //Draw head
                    else
                        snakeColour = Brushes.Green;    //Rest of body

                    //Draw snake
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));


                    //Draw Food
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                             food.Y * Settings.Height, Settings.Width, Settings.Height));

                }
            }
            else
            {
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        /// <summary>
        /// Funkcja rysuję kontrole gracza
        /// </summary>
        public void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }


                    //Get maximum X and Y Pos
                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    //Detect collission with game borders.
                    if (Snake[i].X < 0 || Snake[i].Y < 0
                        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        Die();
                    }


                    //Detect collission with body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //Detect collision with food piece
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();
                    }

                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }
        
       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
      
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
        /// <summary>
        /// Tworzymy funkcje jedzenia
        /// </summary>
        private void Eat()
        {
            //Add circle to body
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(circle);

            //Update Score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            GenerateFood();
        }

        /// <summary>
        /// Funkcja sprawdza, czy gra skończona
        /// </summary>

        public string Die()
        {
            Settings.GameOver = true;
            return "You're dead";
        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }
    }
}
