﻿using System.Text.Json;
using System.Text.RegularExpressions;
using ishin.Models;

namespace ishin.Services
{
    public class IshinService
    {
        Dictionary<int, string> itos;
        int vocabularyCounter;
        List<int> data, Y;
        List<List<int>> X;
        Dictionary<string, Dictionary<int, int>> memory;
        Dictionary<string, List<int>> trainedModel;

        public IshinService()
        {
            itos = new();
            data = new();
            X = new();
            Y = new();
            memory = new();
            trainedModel = new();
        }

        public void FeedLine(string sentence, bool turnToLowerCase = true, bool areAlphabetsAllowed = true, bool areIntegersAllowed = false, bool areFullStopsAllowed = false, bool areSpecialCharactersAllowed = false)
        {
            string allowedChars = string.Empty;

            if (turnToLowerCase)
            {
                sentence = sentence.ToLower();
            }

            if (areAlphabetsAllowed)
            {
                allowedChars += "a-zA-Z";
            }

            if (areIntegersAllowed)
            {
                allowedChars += "0-9";
            }

            if (areFullStopsAllowed)
            {
                allowedChars += "\\.";
            }

            if (areSpecialCharactersAllowed)
            {
                allowedChars += "!@#$%^&*()_+=\\[\\]{}|;:'\",<>/?`~\\-";
            }

            allowedChars += "\\s";

            sentence = Regex.Replace(sentence, $"[^{allowedChars}]", "");
            sentence = Regex.Replace(sentence, @"\s+", " ");
            sentence = sentence.Trim();

            foreach (string word in sentence.Split(" ").ToList())
            {
                if (!itos.ContainsValue(word))
                {
                    itos[vocabularyCounter] = word;
                    vocabularyCounter++;
                }

                data.Add(itos.FirstOrDefault(x => x.Value == word).Key);
            }
        }

        public void CreateXandY(int n)
        {
            if (data == null || data.Count < n + 1)
            {
                return;
            }

            for (int i = 0; i <= data.Count - n - 1; i++)
            {
                var xSeq = data.GetRange(i, n);
                var yVal = data[i + n];

                X.Add(xSeq);
                Y.Add(yVal);
            }
        }

        public void TrainModel()
        {
            for (int i = 0; i < X.Count; i++)
            {
                string key = string.Join("-<>-", X[i]);

                if (memory.ContainsKey(key))
                {
                    if (memory[key].ContainsKey(Y[i]))
                    {
                        memory[key][Y[i]] += 1;
                    }
                    else
                    {
                        memory[key][Y[i]] = 1;
                    }
                }
                else
                {
                    memory[key] = new();
                    memory[key][Y[i]] = 1;
                }
            }

            foreach (var entry in memory)
            {
                var sortedY = entry.Value
                    .OrderByDescending(pair => pair.Value)
                    .Select(pair => pair.Key)
                    .ToList();

                trainedModel[entry.Key] = sortedY;
            }
        }

        public string SaveModelToStorage(int ngram, string modelName = "ishin")
        {
            var modelData = new ModelData
            {
                Name = modelName,
                NGram = ngram,
                Itos = itos,
                TrainedModel = trainedModel
            };

            string json = JsonSerializer.Serialize(modelData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            string filePath = Path.Combine(FileSystem.AppDataDirectory, modelName + ".json");
            File.WriteAllText(filePath, json);
            return filePath;
        }

        public List<ModelData> LoadAllModels()
        {
            var models = new List<ModelData>();
            string directory = FileSystem.AppDataDirectory;

            var jsonFiles = Directory.GetFiles(directory, "*.json");

            foreach (var filePath in jsonFiles)
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var model = JsonSerializer.Deserialize<ModelData>(json);

                    if (model != null)
                    {
                        models.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load {filePath}: {ex.Message}");
                }
            }

            return models;
        }

        public Dictionary<int, string> GetItoS()
        {
            return itos;
        }

        public List<List<int>> GetX()
        {
            return X;
        }

        public List<int> GetY()
        {
            return Y;
        }

        public Dictionary<string, Dictionary<int, int>> GetMemory()
        {
            return memory;
        }

        public int GetDataLength()
        {
            return data.Count;
        }

        public Dictionary<string, List<int>> GetTrainedModel()
        {
            return trainedModel;
        }

        public void ResetIshin()
        {
            itos.Clear();
            data.Clear();
            X.Clear();
            Y.Clear();
            memory.Clear();
            trainedModel.Clear();
            vocabularyCounter = 0;
        }

        public void ResetXandY()
        {
            X.Clear();
            Y.Clear();
        }

        public void ResetMemory()
        {
            memory.Clear();
        }

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
