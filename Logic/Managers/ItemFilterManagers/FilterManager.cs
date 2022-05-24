using DataStructures;
using Logic.DataMembers;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class FilterManager
    {
        internal static List<AbstractItem> Filter(ObservableDictionary<int, AbstractItem> itemsInStock,
            bool[] selection, string creator, double price, int discountPercentage, DateTime date)
        {
            var fIlteredItems = new List<AbstractItem>();

            ParameterstoFilterBy parameters = CreateIndexesByCategory(creator, price, discountPercentage, date);

            foreach (var item in itemsInStock)
            {
                bool shouldBeDisplayed = FilterByParameters(parameters, item.Value, creator, price, discountPercentage, date);

                if (shouldBeDisplayed) FilterByType(selection, fIlteredItems, item);
            }
            return fIlteredItems;
        }

        private static bool FilterByParameters(ParameterstoFilterBy parameters, AbstractItem item, string creator, double price, int discountPercentage, DateTime date)
        {
            bool shouldBeDisplayed = true;
            if (parameters.HasFlag(ParameterstoFilterBy.Creator))
            {
                if (item.Creator == creator) shouldBeDisplayed = true;
                else
                {
                    return false;
                }

            }
            if (parameters.HasFlag(ParameterstoFilterBy.Price))
            {
                if (item.PriceAfterDiscount <= price) shouldBeDisplayed = true;
                else
                {
                    return false;
                }
            }

            if (parameters.HasFlag(ParameterstoFilterBy.DiscountPercentage))
            {
                if (item.DiscountPercentage >= discountPercentage) shouldBeDisplayed = true;
                else
                {
                    return false;
                }
            }
            if (parameters.HasFlag(ParameterstoFilterBy.Date))
            {
                if (item.PublishDate >= date) shouldBeDisplayed = true;
                else
                {
                    return false;
                }
            }
            return shouldBeDisplayed;
        }



  


        private static void FilterByType(bool[] selection, List<AbstractItem> fIlteredItems, KeyValuePair<int, AbstractItem> item)
        {
            if (selection[1])
            {
                if (item.Value.GetType() == typeof(Book)) fIlteredItems.Add(item.Value);
            }
            else if (selection[2])
            {
                if (item.Value.GetType() == typeof(Record)) fIlteredItems.Add(item.Value);
            }
            else fIlteredItems.Add(item.Value);
        }

        private static ParameterstoFilterBy CreateIndexesByCategory(string creator, double price, int discountPercentage, DateTime date)
        {
            ParameterstoFilterBy filterBy = new ParameterstoFilterBy();

            if (creator != null && creator != "") filterBy |= ParameterstoFilterBy.Creator;

            if (price != default) filterBy |= ParameterstoFilterBy.Price;

            if (discountPercentage != default) filterBy |= ParameterstoFilterBy.DiscountPercentage;

            if (date < DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))) filterBy |= ParameterstoFilterBy.Date;

            return filterBy;
        }

        [Flags]
        private enum ParameterstoFilterBy
        {
            Creator = 1,
            Price = 2,
            DiscountPercentage = 4,
            Date = 8
        }



    }
}
