using System;
using System.Collections.Generic;
using System.Text;

namespace CIS3285_FinalProject
{
    interface IListItem
    {
        bool IsChecked();
        void markChecked();
        string Description { get; }
        Guid Id { get; }

    }
}
