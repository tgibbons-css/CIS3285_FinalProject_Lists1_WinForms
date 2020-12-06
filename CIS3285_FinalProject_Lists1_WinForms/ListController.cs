using System;
using System.Collections.Generic;
using System.Text;

namespace CIS3285_FinalProject
{
    /// <summary>
    /// The list controller is used by the UI Form to manage the list. 
    /// This should contain all the busness and control login for managing the list.
    /// It makes use of the ShoppingList to hold the actual list
    /// </summary>
    class ListController
    {
        private ShoppingList shoppingList;
        private ShoppingItemRepository itemDbRepository;

        public ListController()
        {
            // Read the initial list from the database repository
            itemDbRepository = new ShoppingItemRepository();
            shoppingList = new ShoppingList(itemDbRepository.ReadAll());
        }
        public void CreateshoppingItem(string Name, int amount)
        {
            ShoppingItem newItem = new ShoppingItem(Name, amount);
            shoppingList.AddItem(newItem);
            itemDbRepository.createItem(newItem);
        }

        public IEnumerable<IListItem> GetListItems()
        {
            return shoppingList.GetItems();
        }

        public void MarkItemAsChecked(IListItem item)
        {
            shoppingList.CheckItem(item);
            ShoppingItem i = (ShoppingItem)item;
            itemDbRepository.updateChecked(item.Id);
        }
    }
}
