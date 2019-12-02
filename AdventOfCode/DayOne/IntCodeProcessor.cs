using System.Linq;

namespace AdventLibrary
{
    public class IntCodeProcessor
    {
        public int[] Code { get; }

        public IntCodeProcessor(string input)
        {
            var split = input.Split(',');
            Code = split.Select(item => int.Parse(item)).ToArray();
        }
    }
}
