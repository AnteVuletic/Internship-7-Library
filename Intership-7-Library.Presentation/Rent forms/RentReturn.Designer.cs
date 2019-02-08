namespace Intership_7_Library.Presentation.Rent_forms
{
    partial class RentReturn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.srchBookLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookListView = new System.Windows.Forms.ListView();
            this.bookSearchTexBox = new System.Windows.Forms.TextBox();
            this.memberSearchTextBox = new System.Windows.Forms.TextBox();
            this.listOfMembers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(342, 573);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(83, 45);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(514, 573);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 45);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 73);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rent";
            // 
            // srchBookLabel
            // 
            this.srchBookLabel.AutoSize = true;
            this.srchBookLabel.Location = new System.Drawing.Point(406, 297);
            this.srchBookLabel.Name = "srchBookLabel";
            this.srchBookLabel.Size = new System.Drawing.Size(106, 13);
            this.srchBookLabel.TabIndex = 25;
            this.srchBookLabel.Text = "Search books by title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Search member by surname";
            // 
            // bookListView
            // 
            this.bookListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookListView.Location = new System.Drawing.Point(12, 348);
            this.bookListView.MultiSelect = false;
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(892, 178);
            this.bookListView.TabIndex = 23;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            this.bookListView.View = System.Windows.Forms.View.Tile;
            // 
            // bookSearchTexBox
            // 
            this.bookSearchTexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookSearchTexBox.Location = new System.Drawing.Point(284, 313);
            this.bookSearchTexBox.Name = "bookSearchTexBox";
            this.bookSearchTexBox.Size = new System.Drawing.Size(350, 29);
            this.bookSearchTexBox.TabIndex = 22;
            this.bookSearchTexBox.TextChanged += new System.EventHandler(this.bookSearchTexBox_TextChanged);
            // 
            // memberSearchTextBox
            // 
            this.memberSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberSearchTextBox.Location = new System.Drawing.Point(284, 121);
            this.memberSearchTextBox.Name = "memberSearchTextBox";
            this.memberSearchTextBox.Size = new System.Drawing.Size(350, 29);
            this.memberSearchTextBox.TabIndex = 21;
            this.memberSearchTextBox.TextChanged += new System.EventHandler(this.memberSearchTextBox_TextChanged);
            // 
            // listOfMembers
            // 
            this.listOfMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfMembers.Location = new System.Drawing.Point(12, 156);
            this.listOfMembers.MultiSelect = false;
            this.listOfMembers.Name = "listOfMembers";
            this.listOfMembers.Size = new System.Drawing.Size(892, 131);
            this.listOfMembers.TabIndex = 20;
            this.listOfMembers.UseCompatibleStateImageBehavior = false;
            this.listOfMembers.View = System.Windows.Forms.View.Tile;
            this.listOfMembers.SelectedIndexChanged += new System.EventHandler(this.listOfMembers_SelectedIndexChanged);
            // 
            // RentReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 630);
            this.Controls.Add(this.srchBookLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bookListView);
            this.Controls.Add(this.bookSearchTexBox);
            this.Controls.Add(this.memberSearchTextBox);
            this.Controls.Add(this.listOfMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RentReturn";
            this.Text = "RentReturn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label srchBookLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView bookListView;
        private System.Windows.Forms.TextBox bookSearchTexBox;
        private System.Windows.Forms.TextBox memberSearchTextBox;
        private System.Windows.Forms.ListView listOfMembers;
    }
}