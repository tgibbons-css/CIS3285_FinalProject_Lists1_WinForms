using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS3285_FinalProject
{
    public partial class Form1 : Form
    {
        ListController listController;
        public Form1()
        {
            InitializeComponent();
            listController = new ListController();
            updateListBox();
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            string name = textBoxItemName.Text.ToString();
            int amount = Int32.Parse(textBoxItemAmount.Text);
            listController.CreateshoppingItem(name, amount);

            updateListBox();

        }

        private void updateListBox()
        {
            IEnumerable<IListItem> items = listController.GetListItems();

            listBox1.Items.Clear();
            //listBox1.Items = listController.GetItemDescriptionList();

            listBox1.DisplayMember = "Description";
            listBox1.ValueMember = "Id";
            foreach (ShoppingItem item in items)
            {
                listBox1.Items.Add(item);
            }
            
        }


        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IListItem selectedItem = (IListItem)listBox1.SelectedItem;
            listController.MarkItemAsChecked(selectedItem);

            updateListBox();
        }

    }
}
