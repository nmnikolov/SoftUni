namespace Scoreboard
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Scoreboard
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var scoreboard = new ScoreboardData();

            var commandLine = Console.ReadLine();
            while (commandLine != "End")
            {

                if (!string.IsNullOrWhiteSpace(commandLine))
                {
                    try
                    {
                        var result = scoreboard.ExecuteCommand(commandLine);
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                commandLine = Console.ReadLine();
            }
        }
    }

    public class ScoreboardData
    {
        private Dictionary<string, User> usersByUsername = new Dictionary<string, User>();
        private Dictionary<string, Game> gamesByName = new Dictionary<string, Game>();
        private Dictionary<string, OrderedBag<Score>> scoreByGameName = new Dictionary<string, OrderedBag<Score>>();
        private Trie<bool> gameNames = new Trie<bool>();

        public string ExecuteCommand(string commandLine)
        {
            var commandParams = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result;
            switch (commandParams[0])
            {
                case "RegisterUser":
                    result = this.RegisterUser(commandParams[1], commandParams[2]);
                    break;
                case "RegisterGame":
                    result = this.RegisterGame(commandParams[1], commandParams[2]);
                    break;
                case "AddScore":
                    result = this.AddScore(commandParams);
                    break;
                case "ShowScoreboard":
                    result = this.ShowScoreboard(commandParams[1]);
                    break;
                case "ListGamesByPrefix":
                    result = this.ListGamesByPrefix(commandParams[1]);
                    break;
                case "DeleteGame":
                    result = this.DeleteGame(commandParams[1], commandParams[2]);
                    break;
                default: throw new InvalidOperationException();
            }

            return result;
        }

        public string DeleteGame(string gameName, string passWord)
        {
            Game game;
            this.gamesByName.TryGetValue(gameName, out game);

            if (game == null || game.Password != passWord)
            {
                return "Cannot delete game";
            }

            this.scoreByGameName.Remove(gameName);
            this.gameNames.Remove(gameName);
            this.gamesByName.Remove(gameName);

            return "Game deleted";
        }

        public string ListGamesByPrefix(string prefix)
        {
            var games = this.gameNames.GetByPrefix(prefix).Take(10).Select(g => g.Key).ToArray();

            if (games.Length == 0)
            {
                return "No matches";
            }

            return string.Join(", ", games);
        }

        public string ShowScoreboard(string gameName)
        {
            if (!this.scoreByGameName.ContainsKey(gameName))
            {
                return "Game not found";
            }

            var scores = this.scoreByGameName[gameName].Take(10).ToList();
            if (scores.Count == 0)
            {
                return "No score";
            }

            var result = string.Empty;
            for (int i = 0; i < scores.Count; i++)
            {
                if (result != string.Empty)
                {
                    result += "\n";
                }

                result += string.Format("#{0} {1}", i + 1, scores[i]);
            }

            return result;
        }

        public string AddScore(string[] command)
        {
            User user;
            this.usersByUsername.TryGetValue(command[1], out user);
            if (user == null || user.Password != command[2])
            {
                return "Cannot add score";
            }

            Game game;
            this.gamesByName.TryGetValue(command[3], out game);
            if (game == null || game.Password != command[4])
            {
                return "Cannot add score";
            }

            var score = new Score
            {
                User = user,
                Game = game,
                Points = int.Parse(command[5])
            };

            this.scoreByGameName[command[3]].Add(score);

            return "Score added";
        }

        public string RegisterUser(string username, string password)
        {
            if (this.usersByUsername.ContainsKey(username))
            {
                return "Duplicated user";
            }

            var user = new User
            {
                Username = username,
                Password = password
            };

            this.usersByUsername.Add(username, user);

            return "User registered";
        }

        public string RegisterGame(string name, string password)
        {
            if (this.gamesByName.ContainsKey(name))
            {
                return "Duplicated game";
            }

            var game = new Game
            {
                Name = name,
                Password = password
            };

            this.gamesByName.Add(name, game);
            this.scoreByGameName[name] = new OrderedBag<Score>((x, y) => -x.CompareTo(y));
            this.gameNames.Add(new TrieEntry<bool>(name, false));

            return "Game registered";
        }
    }

    public class User : IComparable<User>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int CompareTo(User other)
        {
            var result = string.Compare(this.Username, other.Username, StringComparison.InvariantCulture);

            return result;
        }
    }

    public class Game : IComparable<Game>
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int CompareTo(Game other)
        {
            var result = string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);

            return result;
        }
    }

    public class Score : IComparable<Score>
    {
        public Game Game { get; set; }

        public User User { get; set; }

        public long Points { get; set; }

        public int CompareTo(Score other)
        {
            var result = this.Points.CompareTo(other.Points);
            if (result == 0)
            {
                result = -string.Compare(this.User.Username, other.User.Username, StringComparison.InvariantCulture);
            }
            return result;
        }

        public override string ToString()
        {
            return this.User.Username + " " + this.Points;
        }
    }
}