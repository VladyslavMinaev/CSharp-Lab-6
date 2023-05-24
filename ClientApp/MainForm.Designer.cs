namespace ClientApp
{
    partial class MainForm
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
            label5 = new System.Windows.Forms.Label();
            bookingsListView = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            label1 = new System.Windows.Forms.Label();
            datesListView = new System.Windows.Forms.ListView();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            label2 = new System.Windows.Forms.Label();
            roomsListView = new System.Windows.Forms.ListView();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader8 = new System.Windows.Forms.ColumnHeader();
            columnHeader9 = new System.Windows.Forms.ColumnHeader();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(89, 35);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(129, 20);
            label5.TabIndex = 13;
            label5.Text = "Мої бронювання";
            // 
            // bookingsListView
            // 
            bookingsListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            bookingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            bookingsListView.FullRowSelect = true;
            bookingsListView.HideSelection = false;
            bookingsListView.Location = new System.Drawing.Point(26, 67);
            bookingsListView.Name = "bookingsListView";
            bookingsListView.Size = new System.Drawing.Size(285, 197);
            bookingsListView.TabIndex = 12;
            bookingsListView.UseCompatibleStateImageBehavior = false;
            bookingsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Кімната";
            columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Дата";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ціна";
            columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Місця";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(400, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 20);
            label1.TabIndex = 15;
            label1.Text = "Виберіть дату";
            // 
            // datesListView
            // 
            datesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            datesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader5 });
            datesListView.FullRowSelect = true;
            datesListView.HideSelection = false;
            datesListView.Location = new System.Drawing.Point(375, 67);
            datesListView.Name = "datesListView";
            datesListView.Size = new System.Drawing.Size(154, 197);
            datesListView.TabIndex = 14;
            datesListView.UseCompatibleStateImageBehavior = false;
            datesListView.View = System.Windows.Forms.View.Details;
            datesListView.ItemActivate += datesListView_ItemActivate;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "";
            columnHeader5.Width = 150;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(614, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(227, 20);
            label2.TabIndex = 17;
            label2.Text = "Вільні номери на вибрану дату";
            // 
            // roomsListView
            // 
            roomsListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            roomsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader6, columnHeader8, columnHeader9 });
            roomsListView.FullRowSelect = true;
            roomsListView.HideSelection = false;
            roomsListView.Location = new System.Drawing.Point(580, 67);
            roomsListView.Name = "roomsListView";
            roomsListView.Size = new System.Drawing.Size(305, 197);
            roomsListView.TabIndex = 16;
            roomsListView.UseCompatibleStateImageBehavior = false;
            roomsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Кімната";
            columnHeader6.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Ціна";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Місця";
            columnHeader9.Width = 100;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(951, 124);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(118, 86);
            button1.TabIndex = 18;
            button1.Text = "Забронювати вибраний номер";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1132, 323);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(roomsListView);
            Controls.Add(label1);
            Controls.Add(datesListView);
            Controls.Add(label5);
            Controls.Add(bookingsListView);
            Name = "MainForm";
            Text = "Готель";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView bookingsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView datesListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView roomsListView;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button button1;
    }
}