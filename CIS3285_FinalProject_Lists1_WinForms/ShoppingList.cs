using System;
using System.Collections.Generic;
using System.Text;

namespace CIS3285_FinalProject
{
    class ShoppingList
    {
        List<ShoppingItem> shoppingList;

        public ShoppingList()
        {
            shoppingList = new List<ShoppingItem>();
        }

        public ShoppingList(List<ShoppingItem> newList)
        {
            shoppingList = newList;
        }

        public void AddItem(ShoppingItem newItem)
        {
            shoppingList.Add(newItem);
        }

        public void CheckItem(IListItem item)
        {
            item.markChecked();
        }

        public IEnumerable<IListItem> GetUnPurchased()
        {
            List<ShoppingItem> unpurchased = new List<ShoppingItem>();
            foreach (ShoppingItem item in shoppingList)
            {
                if (!item.PuchasedYN)
                {
                    unpurchased.Add(item);
                }
            }
            return unpurchased;
        }

        public IEnumerable<IListItem> GetItems ( )
        {
            List<ShoppingItem> uncheckList = new List<ShoppingItem>();
            
            foreach (ShoppingItem item in shoppingList)
            {
                if (!item.PuchasedYN)
                {
                    uncheckList.Add(item);
                }
            }
            
            return uncheckList;
        }



    }
}
