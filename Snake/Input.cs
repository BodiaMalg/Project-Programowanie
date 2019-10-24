using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    /// <summary>
    /// tworzymy kontrolę gracza
    /// </summary>
    internal class Input
    {
        
        private static Hashtable keyTable = new Hashtable();

        /// <summary>
        /// Wykonaj kontrolę, aby sprawdzić, czy dany przycisk został naciśnięty.
        /// </summary>
     
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }

            return (bool) keyTable[key];
        }

        /// <summary>
        /// Wykryj, czy zostanie naciśnięty przycisk klawiatury
        /// </summary>
        
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
