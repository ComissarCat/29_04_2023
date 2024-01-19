namespace _29_04_2023
{
    partial class Form_book_authors
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
            this.c_box_books = new System.Windows.Forms.ComboBox();
            this.l_box_book_authors = new System.Windows.Forms.ListBox();
            this.l_box_free_authors = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_box_books
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.c_box_books, 3);
            this.c_box_books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_box_books.FormattingEnabled = true;
            this.c_box_books.Location = new System.Drawing.Point(3, 3);
            this.c_box_books.Name = "c_box_books";
            this.c_box_books.Size = new System.Drawing.Size(978, 28);
            this.c_box_books.TabIndex = 0;
            this.c_box_books.SelectedIndexChanged += new System.EventHandler(this.c_box_books_SelectedIndexChanged);
            // 
            // l_box_book_authors
            // 
            this.l_box_book_authors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_box_book_authors.FormattingEnabled = true;
            this.l_box_book_authors.ItemHeight = 20;
            this.l_box_book_authors.Location = new System.Drawing.Point(3, 37);
            this.l_box_book_authors.Name = "l_box_book_authors";
            this.l_box_book_authors.Size = new System.Drawing.Size(456, 538);
            this.l_box_book_authors.TabIndex = 1;
            // 
            // l_box_free_authors
            // 
            this.l_box_free_authors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_box_free_authors.FormattingEnabled = true;
            this.l_box_free_authors.ItemHeight = 20;
            this.l_box_free_authors.Location = new System.Drawing.Point(524, 37);
            this.l_box_free_authors.Name = "l_box_free_authors";
            this.l_box_free_authors.Size = new System.Drawing.Size(457, 538);
            this.l_box_free_authors.TabIndex = 2;
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(47, 41);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "🠔";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.AutoSize = true;
            this.btn_remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_remove.Location = new System.Drawing.Point(3, 50);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(47, 41);
            this.btn_remove.TabIndex = 4;
            this.btn_remove.Text = "➞";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.c_box_books, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.l_box_free_authors, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.l_box_book_authors, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 561);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_add, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_remove, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(465, 259);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(53, 94);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Form_book_authors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_book_authors";
            this.Text = "Form_book_authors";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox c_box_books;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox l_box_book_authors;
        private System.Windows.Forms.ListBox l_box_free_authors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_remove;
    }
}