using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    interface IListRepository
    {

        void createItem(ShoppingItem item);
        List<ShoppingItem> ReadAll();
        void updateChecked(Guid id);

    }
}
