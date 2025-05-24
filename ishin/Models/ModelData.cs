namespace ishin.Models
{
    public class ModelData
    {
        public string Name { get; set; } = string.Empty;
        public int NGram { get; set; }
        public Dictionary<int, string> Itos { get; set; } = new();
        public Dictionary<string, List<int>> TrainedModel { get; set; } = new();
    }
}
