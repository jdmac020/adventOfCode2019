namespace AdventLibrary
{
    public class CodeSegment
    {
        public int Index { get; set; }
        public OpCodes OpCode { get; set; }
        public (int, int) Arguments { get; set; }
        public int UpdatePosition { get; set; }
    }
}