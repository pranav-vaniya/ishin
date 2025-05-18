using ishin.Models;

namespace ishin.Services
{
    public class IshinService
    {
        public Conversation GetSampleConversation()
        {
            Conversation sampleConversation = new Conversation
            {
                Title = "Chat with Atlas",
                Messages = {
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Hey, Ishin. You alive or buried under Jira tickets again?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Also, random thought—do you still have that side project you were building with the TypeScript backend?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Haha barely alive. I've been debugging a nightmare race condition for two days straight. Send help 😩"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Oh, the TypeScript one? Yeah, still alive. I just haven’t had time to touch it lately. Why?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "I was looking at my own dusty GitHub repos yesterday and thought: we should actually finish one for once 😂"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Wow. Bold of you to assume I finish anything that doesn’t involve a sprint deadline."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Valid. But hear me out—we do a weekend code jam. Just pick one thing and build a working prototype. No scope creep."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Sounds tempting. But last time we said 'no scope creep' you tried to add CI/CD pipelines and dark mode in hour two."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Okay that was a fluke. Dark mode is a human right anyway."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Lmao. Fine. I’m in. What’re we building this time?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "I was thinking something simple but actually useful. Like a minimalist time tracker or habit logger for devs."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Something where we can play with some newer stack stuff too—maybe SvelteKit or tRPC?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Interesting. I’ve been meaning to try SvelteKit, so I’m down. What’s the backend?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Let’s go with Supabase for now. Quick setup, easy auth. If it grows, we refactor later."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "I like it. Let’s sketch it out Friday evening and then sprint through Saturday?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Perfect. I’ll prep a little Notion doc with core features. You handle setting up the repo?"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "You got it. Clean monorepo, turborepo setup maybe? Let’s keep things tidy this time."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Please. Last time your folder structure gave me anxiety 😬"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Bruh. Coming from the guy who commits 'final-final-FINAL-really-this-time.js' 😅"
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Touché. Alright, let’s aim for 6 PM Friday? Quick call, then go full dev mode on Saturday."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Ishin,
                        Content = "Deal. Let’s finally ship something before we’re 40."
                    },
                    new ConversationMessage
                    {
                        Sender = User.Atlas,
                        Content = "Now that’s the kind of mid-life motivation I needed 😂"
                    }
                }
            };

            return sampleConversation;
        }
    }
}
