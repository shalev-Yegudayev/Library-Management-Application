using System;

namespace Logic.DataMembers
{
    public abstract class AbstractItem
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public double Price { get; set; }

        public virtual int DiscountPercentage { get; }

        public double PriceAfterDiscount { get => Price - (Price * DiscountPercentage / 100); }

        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public  AbstractItem(string name, double price, int id, DateTime PublishDate)
        {
            Name = name;
            Price = price;
            Id = id;
            this.PublishDate = PublishDate;
        }

        public abstract string ShowItemDetails();

        public abstract string ManagerLogMessage(string action);
    }
}
