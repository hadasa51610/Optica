using Optica.Entities;
namespace Optica.Services
{
    public class CheckService
    {
        static List<Checks> Checks { get; }
        public CheckService() { }
        static CheckService()
        {
            Checks = new List<Checks>();
        }
        public List<Checks> GetAll()
        {
            return Checks;
        }
        public Checks GetById(int code)
        {
            foreach (var check in Checks)
            {
                if(check.Code==code)
                    return check;
            }
            return null;
        }
        public void PostCheck(Checks check)
        {
            Checks.Add(check);
        }
        public void PutCheck(int code,Checks check)
        {
            for (int i = 0; i < Checks.Count(); i++)
            {
                if (Checks[i].Code == code)
                    Checks[i]=check;
            }
        }
        public void DeleteCheck(int code)
        {
            foreach (var check in Checks)
            {
                if (check.Code == code)
                {
                    Checks.Remove(check);
                    return;
                }
            }
        }
    }
}
