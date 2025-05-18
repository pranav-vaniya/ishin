namespace ishin.Models
{
    public class ConversationMessage
    {
        public User Sender { get; set; }
        public string Content { get;set; }=string.Empty;
    }
}
