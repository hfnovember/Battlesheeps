using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSheeps {
    static class Taunt {
        public const int TAUNT_SIZE = 10;
        public static string[] TAUNTS = new String[TAUNT_SIZE] {
            "There is more BattleSheeps to bomb, but you ran away from the fight...",
            "Go ahead and leave, see if I care!",
            "BattleSheeps will hunt you in your sleep!",
            "Running home to momma?",
            "Y U GO?",
            "Next time try turning the safety off!",
            "Retiring too soon?",
            "RUN COWARD!",
            "Are you too weak for this game?",
            "What a quitter..."
        };
        public const int MESSAGE_SIZE = 10;
        public static string[] MESSAGES = new String[MESSAGE_SIZE] {
            "Includes sound!",
            "As played by the cowboys!",
            "Better than the original!",
            "Inappropriate for office!",
            "TL-Engine sucks!",
            "Undocumented version!",
            "Limited Edition!",
            "I'm afraid of an army of lions led by a battlesheep!",
            "Not user friendly!",
            "Extremely scientific!"
        };
    }
}
