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

namespace Intership_7_Library.Presentation.Publisher__forms
{
    public partial class PublisherAdd : Form
    {
        private readonly PublisherRepo _publisherRepo;
        public PublisherAdd()
        {
            InitializeComponent();
            _publisherRepo = new PublisherRepo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _publisherRepo.AddPublisher(nameTextBox.Text, countryTextBox.Text);
            nameTextBox.Text = "";
            countryTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
