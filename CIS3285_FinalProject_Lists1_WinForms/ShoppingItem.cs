using System;
using System.Collections.Generic;
using System.Text;


namespace CIS3285_FinalProject
{
    class ShoppingItem : IListItem
    {
        Guid id;
        string name;
        int amount;
        DateTime dateAddedToList;
        bool puchasedYN;

        public ShoppingItem(string name, int amount)
        {
            Id = Guid.NewGuid();
            this.Name = name;
            this.Amount = amount;
            puchasedYN = false;
            dateAddedToList = DateTime.Now;
        }

        public ShoppingItem(Guid id, string name, int amount, bool puchasedYN)
        {
            this.id = id;
            this.name = name;
            this.Amount = amount;
            this.dateAddedToList = dateAddedToList;
            this.puchasedYN = puchasedYN;
        }

        public bool PuchasedYN { get => puchasedYN; }
        public string Name { get => name; set => name = value; }
        public Guid Id { get => id; set => id = value; }

        public string Description { get => getDescription(); }
        public int Amount { get => amount; set => amount = value; }

        public bool IsChecked()
        {
            return PuchasedYN;
        }

        public void markChecked()
        {
            puchasedYN = true;
        }
        
        public string ToString()
        {
            return getDescription();
        }

        public string getDescription()
        {
            string des = Name + " ( " + Amount + " )";
            return des;
        }

    }
}
