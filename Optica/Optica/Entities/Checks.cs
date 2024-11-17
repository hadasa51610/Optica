namespace Optica.Entities
{
    public class Checks
    {
        public int Code { get; set; }
        public string UserId { get; set; }
        public string CheckerId { get; set; }
        public string Branch { get; set; }
        public DateTime CheckDate { get; set; }
        public bool NeedGlass { get; set; }
        public double Number { get; set; }
    }
}
