using System.Text.RegularExpressions;

namespace GameOfLife
{
    class UserInterface
    {
        public static int[] requestPositions()
        {
            string? coord = "";

            while (true)
            {
                Console.WriteLine($"Insert your starting Positions (0 - {Viewport.curWidth * Viewport.curHeight})");
                coord = Console.ReadLine();
                string pattern = """^(\d+)+$""";

                if (coord != null && regxCheck(pattern, coord))
                {
                    break;
                }

                Console.WriteLine($"Coordinate must be between [x] 0 - {Viewport.curWidth} and [y] 0 - {Viewport.curHeight}");
            }
            return convertStringtoIntArray(coord, ' ');
        }

        private static bool regxCheck(string pattern, string text)
        {
            Regex rg = new Regex(pattern);

            Match valid = rg.Match(text);

            if (valid.Success)
            {
                return true;
            }
            return false;
        }

        private static int[] convertStringtoIntArray(string text, char seperator)
        {
            int[] ints = text.Split(seperator).Select(n => Convert.ToInt32(n)).ToArray();
            return ints;
        }
    }
}
