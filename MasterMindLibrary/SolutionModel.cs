namespace MasterMindLibrary
{
    public class SolutionModel
    {
        public int[] Values { get; set; }
        public int[] Scores { get; set; }
        public SolutionModel()
        {
            Values = new int[4];
            Scores = new int[4];
        }
        public bool AddValues(int[] values)
        {
            Values = values;
            return true;
        }
        public string ValuesToString()
        {
            return $"{Values[0]},{Values[1]},{Values[2]},{Values[3]}";
        }
        public string ScoresToString()
        {
            return $"{Scores[0]},{Scores[1]},{Scores[2]},{Scores[3]}";
        }
        public bool IsValid()
        {
            try
            {

                foreach (var item in Values)
                {
                    if (Values.Where(x => x == item).Count() != 1)
                    {
                        return false;
                    }
                    else if (item > 6 || item < 1)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddValues(string line)
        {
            try
            {
                line = line.Replace(",", "");
                List<int> numbers = new List<int>();
                numbers.Add(Int32.Parse(line[0].ToString()));
                numbers.Add(Int32.Parse(line[1].ToString()));
                numbers.Add(Int32.Parse(line[2].ToString()));
                numbers.Add(Int32.Parse(line[3].ToString()));

                if (line.Length > 4)
                {
                    return false;
                }

                foreach (var item in numbers)
                {
                    if (numbers.Where(x => x == item).Count() != 1)
                    {
                        return false;
                    }
                    else if (item > 6 || item < 1)
                    {
                        return false;
                    }
                }

                Values = numbers.ToArray();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ScoreIt(int[] solutionValues)
        {
            for (int i = 0; i < solutionValues.Length; i++)
            {
                if (Values[i] == solutionValues[i])
                {
                    Scores[i] = 2;
                }
                else if (solutionValues.Contains(Values[i]))
                {
                    Scores[i] = 1;
                }
            }
            Scores = Scores.ToList().OrderBy(x => x).ToArray();
        }

        private static string[] Colors = new string[] { "transparent", "white", "yellow", "green", "blue", "red", "purple" };
        private static string[] ScoreColors = new string[] { "transparent", "black", "white" };
        public static SolutionModel CreateRandomSolution()
        {
            Random rnd = new Random();
            int[] resultValues = new int[4];
            for (int j = 0; j < resultValues.Length; j++)
            {
                while (true)
                {
                    int newValue = rnd.Next(1, 6);
                    if (resultValues.Contains(newValue) == false)
                    {
                        resultValues[j] = newValue;
                        break;
                    }
                }
            }
            SolutionModel result = new SolutionModel();
            result.AddValues(resultValues);

            return result;
        }
        public static string ColorFromNumber(int number)
        {
            return Colors[number];
        }
        public static string ColorFromScoreNumber(int number)
        {
            return ScoreColors[number];
        }
        public static int NumberFromColor(string color)
        {
            return Colors.ToList().IndexOf(color);
        }

        public static int[] StringToIntArray(string input)
        {
            input = input.Replace(",", "");
            List<int> result = new List<int>();

            foreach (var item in input)
            {
                result.Add(Int32.Parse(item.ToString()));
            }

            return result.ToArray();
        }
    }
}