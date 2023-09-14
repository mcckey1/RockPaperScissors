namespace RockPaperScissors.Components
{
    /*  THE RULES:
        Scissors cuts Paper
        Paper covers Rock
        Rock crushes Lizard
        Lizard poisons Spock
        Spock smashes Scissors
        Scissors decapitates Lizard
        Lizard eats Paper
        Paper disproves Spock
        Spock vaporizes Rock
        (and as it always has) Rock crushes Scissors
     */

    public class GameRules
    {
        // humanSelectedOption, computerSelectedOption, humanWins, computerWins, resultMessage
        private readonly IList<(int, int, bool, bool, string)> gameRules = 
            new List<(int, int, bool, bool, string)>
            {
                // Rock
                ( 0, 0, false, false, "TIE: both selected Rock" ),
                ( 0, 1, false, true, "COMPUTER WINS: Paper covers Rock" ),
                ( 0, 2, true, false, "HUMAN WINS: Rock crushes Scissors" ),
                ( 0, 3, true, false, "HUMAN WINS: Rock crushes Lizard"),
                ( 0, 4, false, true, "COMPUTER WINS: Spock vaporizes Rock"),
                // Paper
                ( 1, 0, true, false, "HUMAN WINS: Paper covers Rock" ),
                ( 1, 1, false, false, "TIE: both selected Paper" ),
                ( 1, 2, false, true, "COMPUTER WINS: Scissors cuts Paper" ),
                ( 1, 3, false, true, "COMPUTER WINS: Lizard eats Paper"),
                ( 1, 4, true, false, "HUMAN WINS: Paper disproves Spock"),
                // Scissors
                ( 2, 0, false, true, "COMPUTER WINS: Rock crushes Scissors" ),
                ( 2, 1, true, false, "HUMAN WINS: Scissors cuts Paper" ),
                ( 2, 2, false, false,"TIE: both selected Scissors" ),
                ( 2, 3, true, false, "HUMAN WINS: Scissors decapitates Lizard"),
                ( 2, 4, false, true, "COMPUTER WINS: Spock smashes Scissors"),
                // Lizard
                ( 3, 0, false, true, "COMPUTER WINS: Rock crushes Lizard" ),
                ( 3, 1, true, false, "HUMAN WINS: Lizard eats Paper" ),
                ( 3, 2, false, true,"COMPUTER WINS: Scissors decapitates Lizard" ),
                ( 3, 3, false, false, "TIE: both selected Lizard"),
                ( 3, 4, true, false, "HUMAN WINS: Lizard poisons Spock"),
                // Spock
                ( 4, 0, true, false, "HUMAN WINS: Spock vaporizes Rock" ),
                ( 4, 1, false, true, "COMPUTER WINS: Paper disproves Spock" ),
                ( 4, 2, true, false, "HUMAN WINS: Spock smashes Scissors" ),
                ( 4, 3, false, true, "COMPUTER WINS: Lizard poisons Spock"),
                ( 4, 4, false, false, "TIE: both selected Spock"),
            };

        public (int humanSelectedOption, int computerSelectedOption, bool humanWins, bool computerWins, string resultMessage) 
            this[int humanSelection, int computerSelection] 
            => gameRules.SingleOrDefault(w => w.Item1 == humanSelection && w.Item2 == computerSelection, (0, 0, false, false, ""));
    }
}
