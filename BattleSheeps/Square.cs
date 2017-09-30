using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BattleSheeps {

    public class Square : System.Windows.Controls.Button {

        private Player owner;
        private SquareState state;

        public Point Location { get; internal set; }
        public Size Size { get; internal set; }

        public Square(Player tOwner) {
            owner = tOwner;
        }

        public Player GetOwner() {
            return owner;
        }

        public SquareState GetState() {
            return state;
        }

        public void SetState(SquareState newState) {
            state = newState;
        }

        public void SetOwner(Player tOwner) {
            owner = tOwner;
        }
    }

    public struct Point {
        public int i;
        public int j;
    }
}
