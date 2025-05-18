namespace ishin.Models
{
    public class Conversation
    {
        public string Title { get; set; } = string.Empty;
        public List<ConversationMessage> Messages { get; set; } = new();
    }
}
