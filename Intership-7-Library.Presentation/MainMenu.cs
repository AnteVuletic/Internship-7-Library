using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intership_7_Library.Presentation
{
    public partial class MainMenu : Form
    {
        private bool _isBookManager = false;
        private bool _isStaffManager = false;
        private bool _isMemberManager = false;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void bookMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isBookManager)
            {
                bookMngDrpDwn.Size = bookMngDrpDwn.MaximumSize;
                _isBookManager = true;
            }
            else
            {
                bookMngDrpDwn.Size = bookMngDrpDwn.MinimumSize;
                _isBookManager = false;
            }
        }

        private void staffMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isStaffManager)
            {
                staffMngDrpDwn.Size = staffMngDrpDwn.MaximumSize;
                _isStaffManager = true;
            }
            else
            {
                staffMngDrpDwn.Size = staffMngDrpDwn.MinimumSize;
                _isStaffManager = false;
            }
        }

        private void memberMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isMemberManager)
            {
                memberMngDrpDwn.Size = memberMngDrpDwn.MaximumSize;
                _isMemberManager = true;
            }
            else
            {
                memberMngDrpDwn.Size = memberMngDrpDwn.MinimumSize;
                _isMemberManager = false;
            }
        }

        private void genreAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void genreRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void genreEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void authorRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void authorEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void publisherAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void publisherRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void publisherEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void subRemoveBtn_Click(object sender, EventArgs e)
        {

        }

        private void subEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void instAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void instRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void instEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberEditBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
