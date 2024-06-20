using System.Text.RegularExpressions;

namespace GameOfLife
{
    class UserInterface
    {
        public static short[] requestCoord(string text)
        {
            string coord = "";

            while (true)
            {
                Console.WriteLine(text);
                coord = Console.ReadLine();
                string pattern = """^\d+,\d+$""";

                if (coord != null && regxCheck(pattern, coord))
                {
                    break;
                }

                Console.WriteLine($"Coordinate must be between [x] 0 - {Viewport.curWidth} and [y] 0 - {Viewport.curHeight}");
            }
            return convertStringtoShortArray(coord, ',');
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

        private static short[] convertStringtoShortArray(string text, char seperator)
        {
            short[] ints = text.Split(seperator).Select(n => Convert.ToInt16(n)).ToArray();
            return ints;
        }
    }
}
