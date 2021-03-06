﻿using System;
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
    public partial class PublisherRemove : Form
    {
        private readonly PublisherRepo _publisherRepo;
        private int _index;
        public PublisherRemove()
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
                btnDelete.Enabled = false;
            }

            if (_publisherRepo.GetAllPublisher().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _publisherRepo.GetAllPublisher()[_index].Name;
            countryTextBox.Text = _publisherRepo.GetAllPublisher()[_index].Country;
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_publisherRepo.RemovePublisher(_publisherRepo.GetAllPublisher()[_index].PublisherId))
            {
                MessageBox.Show("Cannot remove publisher which is being used to describe an book",
                    "Cascading delete not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _index = 0;
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
