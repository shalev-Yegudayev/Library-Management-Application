using System;

namespace Logic.DataMembers
{
    public class Book : AbstractItem
    {
        public override int DiscountPercentage
        {
            get
            {
                int discount = 0;
                if (genres.HasFlag(Genres.Action) && discount < 5) discount = 5;
                if (genres.HasFlag(Genres.Adventure) && discount < 7) discount = 7;
                if (genres.HasFlag(Genres.Classics) && discount < 10) discount = 10;
                if (genres.HasFlag(Genres.Comics) && discount < 12) discount = 12;
                if (genres.HasFlag(Genres.Fantasy) && discount < 15) discount = 15;
                if (genres.HasFlag(Genres.History) && discount < 20) discount = 20;
                if (genres.HasFlag(Genres.Horror) && discount < 22) discount = 22;
                if (genres.HasFlag(Genres.Drama) && discount < 25) discount = 25;
                if (genres.HasFlag(Genres.Other) && discount < 30) discount = 30;

                return discount;

            }
        }

        [Flags]
        public enum Genres
        {
            Action = 1,
            Adventure = 2,
            Classics = 4,
            Comics = 8,
            Fantasy = 16,
            History = 32,
            Horror = 64,
            Drama = 128,
            Other = 256,
        }
        public Genres genres;

        public Book(string name, string creator, double price, int id, DateTime publishDate, Genres genres) : base(name, price, id, publishDate)
        {
            Name = name;
            Creator = creator;
            Price = price;
            Id = id;
            PublishDate = publishDate;

            this.genres = genres;

        }

        public override string ToString() => $"ISBN:{Id}.   Book Name: {Name}\nPrice After Discount {PriceAfterDiscount}";

        public override string ShowItemDetails() => $"ItemType: Book\nId:{Id}\nName: {Name}\nCreator Name: {Creator}\nPrice Before Discount: {Price}\nDiscount Percentage: {DiscountPercentage}%\nPrice After Discount:{PriceAfterDiscount}\nPublished At: {PublishDate:d}\nGenres are: {genres}";
      
        public override string ManagerLogMessage(string action) => $"A Book has been {action}, Book id: {Id}, Book name: {Name} at {DateTime.Now}";

    }
}
