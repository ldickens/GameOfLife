using System.Text.RegularExpressions;

namespace GameOfLife
{
    class UserInterface
    {
        public static int[] RequestPositions()
        {
            string? coord = "";

            while (true)
            {
                Console.WriteLine($"Insert your starting Positions (0 - {Viewport.buffWidth * Viewport.buffHeight})");
                coord = Console.ReadLine();
                string pattern = """(\d+ )\d+$""";

                if (coord != null && RegxCheck(pattern, coord))
                {
                    break;
                }

            }
            return ConvertStringtoIntArray(coord, ' ');
        }

        private static bool RegxCheck(string pattern, string text)
        {
            Regex rg = new Regex(pattern);

            Match valid = rg.Match(text);

            if (valid.Success)
            {
                return true;
            }
            return false;
        }

        private static int[] ConvertStringtoIntArray(string text, char seperator)
        {
            int[] ints = text.Split(seperator).Select(n => Convert.ToInt32(n)).ToArray();
            return ints;
        }
    }
}
