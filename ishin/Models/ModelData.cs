namespace ishin.Models
{
    public class ModelData
    {
        public Dictionary<int, string> Itos { get; set; } = new();
        public Dictionary<string, List<int>> TrainedModel { get; set; } = new();
    }
}
