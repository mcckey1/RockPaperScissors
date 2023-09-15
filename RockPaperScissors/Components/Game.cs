using Microsoft.AspNetCore.Components;

namespace RockPaperScissors.Components
{
    public partial class Game
    { 
        const string defaultMessage = "Please make a selection";
        const string lizardSpockExpansion = "Lizard-Spock";
        const string enableExpansion = $"Enable {lizardSpockExpansion}";
        const string disableExpansion = $"Disable {lizardSpockExpansion}";

        private int humanScore;
        private int computerScore;
        private int humanLastSelection;
        private int gameCount;
        private string humanSelectedImage = string.Empty;
        private string computerSelectedImage = string.Empty;
        private string messageString = defaultMessage;

        private bool lizardSpockExpansionEnabled = false;
        private string expansionButtonString = enableExpansion;

        private bool computerUsesLastSelection = false;

        private readonly Random random;

        [Inject]
        public GameRules? GameRules { get; set; }

        [Inject]
        public GameOptions? GameOptions { get; set; }

        public Game()
        {
            random = new();
        }

        protected override void OnInitialized() => SetDefaultMessage();

        private void OnHumanSelected(int playerSelection)
        {       
            humanSelectedImage = GameOptions![playerSelection];
            GetGameResult(playerSelection, GetComputerSelection());
            humanLastSelection = playerSelection;
            gameCount++;
        }

        private void OnExpansion()
        {
            lizardSpockExpansionEnabled = !lizardSpockExpansionEnabled;
            if (lizardSpockExpansionEnabled)
            {
                expansionButtonString = disableExpansion;
                GameOptions!.AddExpansionItems();
            }
            else
            {
                expansionButtonString = enableExpansion;
                GameOptions!.RemoveExpansionItems();
            }
            Reset();
        }

        private void OnReset()
        {
            Reset();
        }

        private void Reset()
        {
            SetDefaultMessage();
            humanScore = 0;
            computerScore = 0;
            gameCount = 0;
            humanSelectedImage = string.Empty;
            computerSelectedImage = string.Empty;
        }

        private void SetDefaultMessage() => messageString = defaultMessage; 

        private int GetComputerSelection()
        {
            var computerSelection = computerUsesLastSelection ?  humanLastSelection : random.Next(GameOptions!.optionCount);
            computerSelectedImage = GameOptions![computerSelection];
            return computerSelection;
        }

        private void GetGameResult(int humanSelection, int computerSelection)
        {
            if (GameRules != null)
            {
                var (_, _, humanWins, computerWins, resultMessage) = GameRules[humanSelection, computerSelection];
                messageString = resultMessage;
                if (humanWins)
                {
                    humanScore++;
                }
                if (computerWins)
                {
                    computerScore++;
                }
            }          
        }      
    }
}
