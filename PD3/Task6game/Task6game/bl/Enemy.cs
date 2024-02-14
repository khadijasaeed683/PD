using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6game
{
    internal class Enemy
    {
        public char symbol;
        public int ex;
        public int ey;
        public Enemy(char symbol, int ex, int ey)
        {
            this.symbol = symbol;
            this.ex = ex;
            this.ey = ey;
        }
        public void MoveEnemy(int x, int y)
        {
            ex=x; ey=y;
        } 
        public void DisplayEnemy()
        {
            Console.SetCursorPosition(ex, ey);
            Console.WriteLine(symbol);
        }

    }
}
