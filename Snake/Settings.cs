namespace Snake
{

    /// <summary>
    /// tworzymy kierunek 
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

        /// <summary>
        /// tworzymy сlas ustawienia
        /// </summary>
    public class Settings
    {

       
        public static int Width { get; set; } //szerokość
        public static int Height { get; set; } // wysokość
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 10;
            Score = 0;
            Points = 10;
            GameOver = false;
            direction = Direction.Down;
        }
    }


}
