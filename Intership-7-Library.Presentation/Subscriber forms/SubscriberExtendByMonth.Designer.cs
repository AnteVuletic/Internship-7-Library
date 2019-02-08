namespace Intership_7_Library.Presentation.Subscriber_forms
{
    partial class SubscriberExtendByMonth
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.memberSearchTextBox = new System.Windows.Forms.TextBox();
            this.listOfMembers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 73);
            this.label1.TabIndex = 15;
            this.label1.Text = "Subscribers";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(506, 573);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 45);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.Location = new System.Drawing.Point(333, 573);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(83, 45);
            this.btnExtend.TabIndex = 16;
            this.btnExtend.Text = "Extend";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Search member by surname";
            // 
            // memberSearchTextBox
            // 
            this.memberSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberSearchTextBox.Location = new System.Drawing.Point(284, 102);
            this.memberSearchTextBox.Name = "memberSearchTextBox";
            this.memberSearchTextBox.Size = new System.Drawing.Size(350, 29);
            this.memberSearchTextBox.TabIndex = 20;
            this.memberSearchTextBox.TextChanged += new System.EventHandler(this.memberSearchTextBox_TextChanged);
            // 
            // listOfMembers
            // 
            this.listOfMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfMembers.Location = new System.Drawing.Point(12, 137);
            this.listOfMembers.MultiSelect = false;
            this.listOfMembers.Name = "listOfMembers";
            this.listOfMembers.Size = new System.Drawing.Size(892, 408);
            this.listOfMembers.TabIndex = 19;
            this.listOfMembers.TileSize = new System.Drawing.Size(500, 53);
            this.listOfMembers.UseCompatibleStateImageBehavior = false;
            this.listOfMembers.View = System.Windows.Forms.View.Tile;
            this.listOfMembers.SelectedIndexChanged += new System.EventHandler(this.listOfMembers_SelectedIndexChanged);
            // 
            // SubscriberExtendByMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 630);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.memberSearchTextBox);
            this.Controls.Add(this.listOfMembers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubscriberExtendByMonth";
            this.Text = "SubscriberExtendByMonth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox memberSearchTextBox;
        private System.Windows.Forms.ListView listOfMembers;
    }
}