namespace MelonFinanceHelper.Models
{
    public class Transaction
    {

        public int Id { get; set; }
        public string category { get; set; }

        public int money { get; set; }
        public string type { get; set; }

        public string date { get; set; }
        public string comment { get; set; }
    }

}
