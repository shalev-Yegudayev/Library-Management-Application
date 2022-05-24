using DataStructures;
using Logic.DataMembers;
using Logic.Managers;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class Manager
    {
        public ObservableDictionary<int, AbstractItem> ItemsInStock;
        public List<string> ManagerLog;
        public INotify notify;

        public Manager(INotify notify)
        {
            ItemsInStock = new ObservableDictionary<int, AbstractItem>();
            ManagerLog = new List<string>();
            this.notify = notify;
        }

        //Login Methods
        public int Login(int pinToCheck, out string employeeName)=> LoginManager.Login(notify,pinToCheck, out employeeName);

        public void AddEmployee(string firstName, string LastName, bool[] ranks) => SQLManager.InsertNewEmployee(firstName, LastName, ranks);


        //Filter Methods
        public bool CheckById(string idToCheck) => CheckSingleItemManager.CheckById(ItemsInStock, notify, idToCheck);

        public bool CheckByName(string nameToCheck) => CheckSingleItemManager.CheckByName(ItemsInStock, notify,  nameToCheck);

        public List<AbstractItem> Filter(bool[] selection, string creator, double price, int discountPercentage, DateTime date)
        {
            return FilterManager.Filter(ItemsInStock, selection, creator, price, discountPercentage, date);
        }


        //Add Item Methods
        public bool AddItem(AbstractItem item) => AddItemManager.AddItem(ItemsInStock, notify,ManagerLog, item);

        public T CreateCategoryEnum<T>(bool[] array) where T : Enum => CreateEnumManager.CreateCategoryEnum<T>(array);


        //Edit Item Methods
        public void EditBook(Book book, string nameS, string creatorS, string priceBeforeDiscountS, DateTime selectedDate, bool[] genreSelection)
        {
            EditItemManager.EditBook(book,nameS,creatorS,priceBeforeDiscountS,selectedDate,genreSelection);
        }
        public void EditRecord(Record record, string nameS, string creatorS, string priceBeforeDiscountS, DateTime selectedDate,string numOfSongsS, bool[] genreSelection)
        {
            EditItemManager.EditRecord(record, nameS,creatorS,priceBeforeDiscountS,selectedDate, numOfSongsS, genreSelection);
        }

        //Input Validation Methods
        public bool InputValidation(string isbnS, string name, string creator, string priceS, DateTime publishDate, bool[] selection)
        {
            return InputValidationManager.InputValidation(notify, isbnS, name, creator, priceS, publishDate, selection);
        }

        public bool CheckCategories(bool[] vs) => InputValidationManager.CheckCategories(vs);

        //Managers Methods
        public bool DeleteItem(AbstractItem item) => DeleteItemManager.DeleteItem(ItemsInStock, ManagerLog ,item);
        


        //Text Methods
        public void CreateReport(List<AbstractItem> list) => CreateReportManager.CreateReport(notify, list);
    }
}
