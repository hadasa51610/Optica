using Optica.Services;

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

        public Checks(int code, string userId, string checkerId, string branch, DateTime checkDate, bool needGlass, double number)
        {
            Code = code;
            UserId = userId;
            CheckerId = checkerId;
            Branch = branch;
            CheckDate = checkDate;
            NeedGlass = needGlass;
            Number = number;
        }

        public static implicit operator Checks(CheckService v)
        {
            throw new NotImplementedException();
        }
    }
}
