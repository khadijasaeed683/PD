using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6game
{
    internal class Player
    {
        public char symbol;
        public int px;
        public int py;
        public Player(char symbol, int px, int py)
        {
            this.symbol = symbol;
            this.px = px;
            this.py = py;
        }
        public void MovePlayer(int x, int y)
        {
              px=x; py = y;
        }
        public void DisplayPlayer()
        {
            Console.SetCursorPosition(px, py);
            Console.Write(symbol);s
        }
    }
}
