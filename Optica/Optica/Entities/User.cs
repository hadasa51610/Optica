namespace Optica.Entities
{
    public enum Status { WORKER, CUSTOMER, MANAGER }
    public enum SickFund { MEUCHEDET, MACABI, LEUMIT, CLALIT,NULL }
    public class User
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime BirthDay { get; set; }

        public string Mail { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Status EStatus { get; set; }
        public SickFund ESickFund { get; set; }
    }
}
