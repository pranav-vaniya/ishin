using ishin.Models;

namespace ishin.Services
{
    public class IshinService
    {
        public Conversation GetSampleConversation()
        {
            Conversation sampleConversation = new Conversation
            {
                Title = "Weekend App Brainstorm",
                Messages = {
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Yo Ishin, got a minute? I’ve been toying with a new app idea."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Always got a minute for your half-baked ideas. What’s this one about?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Rude 😂 But fair. Okay—what if we built a lightweight journal app with daily prompts and mood tracking?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Hmm. Like a minimalist Notion meets Daylio kinda thing?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Exactly. Super clean UI, optional tags, maybe a calendar view."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "I like it. Could be a good playground for animations and transitions too."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Yes! I was thinking we use SvelteKit for the frontend. It’s fast and looks slick."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "You’re obsessed with SvelteKit lately. Not that I’m complaining—works for me."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "For backend, what do you say to using PocketBase? Lightweight, file support, and self-hostable."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Nice pick. Haven’t used it yet, but I’ve read good things. Let’s try it."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Cool. Let's scope it for a weekend sprint. Just MVP: auth, entries, mood tracker."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Deal. Let’s whiteboard the flows Friday night, build through Saturday, polish on Sunday."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "I’ll mock up some UI wireframes tonight. Want to handle the backend setup?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "On it. Clean API routes, auth, and maybe basic file storage for images or voice notes."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Perfect. Let’s actually finish this one. I can already see the Product Hunt launch post 👀"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Bro. Let’s just ship an MVP first before we start tweeting buzzwords 😆"
                    }
                }
            };

            return sampleConversation;
        }
    }
}
