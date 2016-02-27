using System;
using System.Collections.Generic;
using System.Text;

namespace VladkosNotebook
{
    public class VladkosNotebook
    {
        private static List<string> arg = new List<string>();
        private static SortedDictionary<string, ColorData> colors = new SortedDictionary<string, ColorData>();

        public static void Main()
        {
            ReadInput();

            foreach (string row in arg)
            {
                CommandParameters parameters = ParseInput(row);
                ProcessData(parameters);
            }

            Print();
        }

        private static void Print()
        {
            StringBuilder output = new StringBuilder();

            foreach (KeyValuePair<string, ColorData> color in colors)
            {
                if (color.Value.Age.HasValue && color.Value.Name != null)
                {
                    string opponents = color.Value.Opponents.Count > 0 ?
                        string.Join(", ", color.Value.Opponents) :
                        "(empty)";
                    output.AppendFormat("Color: {0}", color.Key).AppendLine();
                    output.AppendFormat("-age: {0}", color.Value.Age).AppendLine();
                    output.AppendFormat("-name: {0}", color.Value.Name).AppendLine();
                    output.AppendFormat("-opponents: {0}", opponents).AppendLine();
                    output.AppendFormat("-rank: {0:f2}", color.Value.Rank).AppendLine();
                }
            }

            if (output.ToString() != "")
            {
                Console.Write(output);
            }
            else
            {
                Console.WriteLine("No data recovered.");
            }
        }

        private static void ProcessData(CommandParameters parameters)
        {
            if (!colors.ContainsKey(parameters.Color))
            {
                colors[parameters.Color] = new ColorData
                {
                    Win = 0,
                    Loss = 0
                };
            }

            switch (parameters.Option)
            {
                case "win":
                    colors[parameters.Color].Win++;
                    colors[parameters.Color].Opponents.Add(parameters.Value);
                    break;
                case "loss":
                    colors[parameters.Color].Loss++;
                    colors[parameters.Color].Opponents.Add(parameters.Value);
                    break;
                case "name":
                    colors[parameters.Color].Name = parameters.Value;
                    break;
                case "age":
                    colors[parameters.Color].Age = int.Parse(parameters.Value);
                    break;
            }
        }

        private static CommandParameters ParseInput(string row)
        {
            string[] rowData = row.Split('|');

            CommandParameters parameters = new CommandParameters
            {
                Color = rowData[0],
                Option = rowData[1],
                Value = rowData[2]
            };

            return parameters;
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                arg.Add(line);

                line = Console.ReadLine();
            }
        }
    }

    public class CommandParameters
    {
        public string Color { get; set; }
        public string Option { get; set; }
        public string Value { get; set; }
    }

    public class ColorData
    {
        private List<string> opponents;

        public ColorData()
        {
            this.Opponents = new List<string>();
        }

        public string Name { get; set; }
        public int? Age { get; set; }        
        public int Win { get; set; }
        public int Loss { get; set; }
        public double Rank
        {
            get
            {
                return ((double)this.Win + 1) / (this.Loss + 1);
            }
        }
        public List<string> Opponents
        {
            get
            {
                this.opponents.Sort(StringComparer.Ordinal);
                return this.opponents;
            }
            set
            {
                this.opponents = value;
            }
        }
    }
}