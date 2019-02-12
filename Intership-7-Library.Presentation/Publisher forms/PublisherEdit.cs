using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories.Book;

namespace Intership_7_Library.Presentation.Publisher_forms
{
    public partial class PublisherEdit : Form
    {
        private readonly PublisherRepo _publisherRepo;
        private int _index;
        public PublisherEdit()
        {
            InitializeComponent();
            _publisherRepo = new PublisherRepo();
            _index = 0;
            SetData();
        }
        private bool SetData()
        {
            if (_publisherRepo.GetAllPublisher().Count == 0)
            {
                MessageBox.Show("No publishers have been added yet", "Publisher not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                countryTextBox.Text = "";
                btnSave.Enabled = false;
            }

            if (_publisherRepo.GetAllPublisher().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _publisherRepo.GetAllPublisher()[_index].Name;
            countryTextBox.Text = _publisherRepo.GetAllPublisher()[_index].Country;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmptyChecker.TryTextFieldsEmpty(Controls))
            {
                MessageBox.Show("Please make sure you enter a value for all text fields", "Value empty error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TextBoxParser.TextBoxChecker(Controls);
            if (!_publisherRepo.EditPublisher(_publisherRepo.GetAllPublisher()[_index].PublisherId, nameTextBox.Text,
                countryTextBox.Text))
            {
                MessageBox.Show("Publisher with this name already exists", "Publisher exists error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _index--;
            if (!SetData()) _index++;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _index++;
            if (!SetData()) _index--;
        }
    }
}
