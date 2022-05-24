using System;

namespace Logic.DataMembers
{
    public class Record : AbstractItem
    {
        public override int DiscountPercentage
        {
            get
            {
                int discount = 0;
                if (categories.HasFlag(Categories.HipHop) && discount < 5) discount = 5;
                if (categories.HasFlag(Categories.Rap) && discount < 7) discount = 7;
                if (categories.HasFlag(Categories.Pop) && discount < 10) discount = 10;
                if (categories.HasFlag(Categories.Jazz) && discount < 12) discount = 12;
                if (categories.HasFlag(Categories.Country) && discount < 15) discount = 15;
                if (categories.HasFlag(Categories.Reggae) && discount < 20) discount = 20;

                return discount;
            }
        }

        private int numOfSongs;
        public int NumOfSongs { get => numOfSongs; set => numOfSongs = value; }

        [Flags]
        public enum Categories
        {
            HipHop = 1,
            Rap = 2,
            Pop = 4,
            Jazz = 8,
            Country = 16,
            Reggae = 32
        }
        public Categories categories;

        public Record(string name, string creator, double price, int id, int numOfSongs, DateTime publishDate, Categories categories) : base(name, price, id, publishDate)
        {
           Name = name;
           Creator = creator;
           Price = price;
           Id = id;

           PublishDate = publishDate;
           this.numOfSongs = numOfSongs;
           this.categories = categories;
        }

        public override string ToString() => $"Id:{Id}. Record Name: {Name}\nPrice After Discount {PriceAfterDiscount}";

        public override string ShowItemDetails() => $"ItemType: Record\nId:{Id}\nName: {Name}\nCreator Name: {Creator}\nPrice Before Discount: {Price}\nDiscount Percentage: {DiscountPercentage}%\nPrice After Discount:{PriceAfterDiscount}\nPublished At: {PublishDate:d}\nNumber Of Songs Is: {NumOfSongs}\nCategories are: {categories}";

        public override string ManagerLogMessage(string action) => $"A Record has been {action}, Record id: {Id}, Record name: {Name} at {DateTime.Now}";
    }
}
