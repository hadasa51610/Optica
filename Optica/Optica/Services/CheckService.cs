using Optica.Entities;

namespace Optica.Services
{
    public class CheckService
    {
        public List<Checks> GetAll() => DataContextManager.Data.ChecksList;

        public Checks GetByCode(int code) => DataContextManager.Data.ChecksList.FirstOrDefault<Checks>(c => c.Code == code);

        public void PostCheck(Checks check) => DataContextManager.Data.ChecksList.Add(check);

        public void PutCheck(int code, Checks check)
        {
            int index = DataContextManager.Data.ChecksList.FindIndex((c) => c.Code == code);
            if (index != -1)
            {
                DataContextManager.Data.ChecksList[index].UserId = check.UserId;
                DataContextManager.Data.ChecksList[index].CheckerId = check.CheckerId;
                DataContextManager.Data.ChecksList[index].CheckDate = check.CheckDate;
                DataContextManager.Data.ChecksList[index].Branch = check.Branch;
                DataContextManager.Data.ChecksList[index].Number = check.Number;
                DataContextManager.Data.ChecksList[index].NeedGlass = check.NeedGlass;
            }
        }

        public void DeleteCheck(int code) => DataContextManager.Data.ChecksList.Remove(GetByCode(code));
    }
}
