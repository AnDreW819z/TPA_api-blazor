namespace tparf.Api.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public const string New = "На рассотрении";
        public const string Ok = "Одобрен";
        public const string End = "Завершен";
        public const string Reject = "Отклонен";
    }
}
