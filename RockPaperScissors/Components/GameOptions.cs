namespace RockPaperScissors.Components
{
    public class GameOptions
    {
        public readonly Dictionary<int, string> options =
            new()
            {
                { 0, "✊" },
                { 1, "✋" },
                { 2, "✌" }
            };

        public string this[int optionKey] => options[optionKey];

        public int optionCount => options.Count;

        public void AddExpansionItems()
        {
            options.TryAdd(3, "🤏");
            options.TryAdd(4, "🖖");
        }

        public void RemoveExpansionItems()
        {
            options.Remove(3);
            options.Remove(4);
        }
    }
}
