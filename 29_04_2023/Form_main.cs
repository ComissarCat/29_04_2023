using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _29_04_2023
{
    public partial class Form_main : Form
    {
        libraryEntities library;
        List<books> free_books;
        List<readers> readers;
        public Form_main()
        {
            InitializeComponent();
            library = libraryEntities.get_instance();
            free_books = new List<books>();
            Refresh_lw_books(0);
            Refresh_lw_authors();
            Refresh_lw_readers();
            Refresh_lw_logs(0);
        }
        private void Refresh_lw_books(int type)
        {
            lw_books.Items.Clear();
            if (type == 0)
            {
                foreach (var book in library.books)
                    lw_books.Items.Add(new ListViewItem(new string[] { book.id.ToString(), book.name, book.get_authors(), book.available ? "Доступна" : "Недоступна" }));
            }
            else if (type == 1)
            {
                foreach (var book in library.books)
                    if (book.available) lw_books.Items.Add(new ListViewItem(new string[] { book.id.ToString(), book.name, book.get_authors(), book.available ? "Доступна" : "Недоступна" }));
            }
            else if (type == 2)
                foreach (var book in library.books)
                    if (!book.available) lw_books.Items.Add(new ListViewItem(new string[] { book.id.ToString(), book.name, book.get_authors(), book.available ? "Доступна" : "Недоступна" }));
            lw_books.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void books_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_books(0);
        }

        private void available_books_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_books(1);
        }

        private void unavailable_books_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_books(2);
        }

        private void btn_add_book_Click(object sender, EventArgs e)
        {
            if (t_box_book_name != null && c_box_book_available.SelectedIndex != -1)
            {
                try
                {
                    books book = new books
                    {
                        name = t_box_book_name.Text,
                        available = c_box_book_available.SelectedIndex == 0 ? true : false
                    };
                    library.books.Add(book);
                    library.SaveChanges();
                    Refresh_lw_books(0);
                    Refresh_lw_logs(0);
                    t_box_book_name.Clear();
                    c_box_book_available.SelectedIndex = -1;
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void btn_change_book_Click(object sender, EventArgs e)
        {
            if (t_box_book_name != null && c_box_book_available.SelectedIndex != -1 && lw_books.SelectedItems.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(lw_books.SelectedItems[0].SubItems[0].Text);
                    books book = (from b in library.books where b.id == id select b).FirstOrDefault();
                    book.name = t_box_book_name.Text;
                    book.available = c_box_book_available.SelectedIndex == 0 ? true : false;
                    library.SaveChanges();
                    Refresh_lw_books(0);
                    Refresh_lw_authors();
                    Refresh_lw_logs(0);
                    t_box_book_name.Clear();
                    c_box_book_available.SelectedIndex = -1;
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void btn_change_book_authors_Click(object sender, EventArgs e)
        {
            if (lw_books.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lw_books.SelectedItems[0].SubItems[0].Text);
                Form_book_authors book_authors = new Form_book_authors((from b in library.books where b.id == id select b).FirstOrDefault());
                book_authors.ShowDialog();
            }
            else
            {
                Form_book_authors book_authors = new Form_book_authors();
                book_authors.ShowDialog();
            }
            Refresh_lw_books(0);
            Refresh_lw_authors();
        }

        private void lw_books_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lw_books.SelectedItems.Count > 0)
            {
                t_box_book_name.Text = lw_books.SelectedItems[0].SubItems[1].Text;
                c_box_book_available.SelectedIndex = lw_books.SelectedItems[0].SubItems[3].Text == "Доступна" ? 0 : 1;
            }
        }
        private void Refresh_lw_authors()
        {
            lw_authors.Items.Clear();
            foreach (var author in library.authors)
                lw_authors.Items.Add(new ListViewItem(new string[] { author.id.ToString(), author.name, author.get_books() }));
            lw_authors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btn_add_author_Click(object sender, EventArgs e)
        {
            if (t_box_author_name != null)
            {
                try
                {
                    authors author = new authors
                    {
                        name = t_box_author_name.Text
                    };
                    library.authors.Add(author);
                    library.SaveChanges();
                    Refresh_lw_authors();
                    t_box_author_name.Clear();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void lw_authors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lw_authors.SelectedItems.Count > 0)
                t_box_author_name.Text = lw_authors.SelectedItems[0].SubItems[1].Text;
        }

        private void btn_change_author_Click(object sender, EventArgs e)
        {
            if (t_box_author_name != null && lw_authors.SelectedItems.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(lw_authors.SelectedItems[0].SubItems[0].Text);
                    authors author = (from a in library.authors where a.id == id select a).FirstOrDefault();
                    author.name = t_box_author_name.Text;
                    library.SaveChanges();
                    Refresh_lw_authors();
                    t_box_author_name.Clear();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
            Refresh_lw_books(0);
        }

        private void btn_change_author_books_Click(object sender, EventArgs e)
        {
            if (lw_authors.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lw_authors.SelectedItems[0].SubItems[0].Text);
                Form_author_books author_books = new Form_author_books((from a in library.authors where a.id == id select a).FirstOrDefault());
                author_books.ShowDialog();
            }
            else
            {
                Form_author_books author_books = new Form_author_books();
                author_books.ShowDialog();
            }
            Refresh_lw_books(0);
            Refresh_lw_authors();
        }

        private void t_page_books_Enter(object sender, EventArgs e)
        {
            Refresh_lw_books(0);
        }

        private void t_page_authors_Enter(object sender, EventArgs e)
        {
            Refresh_lw_authors();
        }
        private void Refresh_lw_readers()
        {
            lw_readers.Items.Clear();
            foreach (var reader in library.readers)
                lw_readers.Items.Add(new ListViewItem(new string[] { reader.id.ToString(), reader.name }));
            lw_readers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btn_add_reader_Click(object sender, EventArgs e)
        {
            if (t_box_reader_name != null)
            {
                try
                {
                    readers reader = new readers
                    {
                        name = t_box_reader_name.Text
                    };
                    library.readers.Add(reader);
                    library.SaveChanges();
                    Refresh_lw_readers();
                    Refresh_lw_logs(0);
                    t_box_reader_name.Clear();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void btn_change_reader_Click(object sender, EventArgs e)
        {
            if (t_box_reader_name != null && lw_readers.SelectedItems.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(lw_readers.SelectedItems[0].SubItems[0].Text);
                    readers reader = (from r in library.readers where r.id == id select r).FirstOrDefault();
                    reader.name = t_box_reader_name.Text;
                    library.SaveChanges();
                    Refresh_lw_readers();
                    Refresh_lw_logs(0);
                    t_box_reader_name.Clear();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void lw_readers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lw_readers.SelectedItems.Count > 0)
                t_box_reader_name.Text = lw_readers.SelectedItems[0].SubItems[1].Text;
        }
        private void Refresh_lw_logs(int i)
        {
            c_box_reader_name.Items.Clear();
            readers = library.readers.ToList();
            foreach (var item in readers)
                c_box_reader_name.Items.Add(item.name);
            c_box_book_name.Items.Clear();
            free_books = (from b in library.books where b.available select b).ToList();
            foreach (var item in free_books)
                c_box_book_name.Items.Add(item.name);
            lw_logs.Items.Clear();
            if (i == 0)
            {
                foreach (var item in library.taken_books)
                    lw_logs.Items.Add(new ListViewItem(new string[] { item.id.ToString(), item.get_reader_name(), item.get_book_name(), item.receiving.ToShortDateString().ToString(), item.should_return.ToShortDateString().ToString(), item.fact_return.ToString() }));
            }
            else if (i == 1)
            {
                foreach (var item in library.taken_books)
                    if (item.fact_return != null) lw_logs.Items.Add(new ListViewItem(new string[] { item.id.ToString(), item.get_reader_name(), item.get_book_name(), item.receiving.ToShortDateString().ToString(), item.should_return.ToShortDateString().ToString(), item.fact_return.ToString() }));
            }
            else if (i == 2)
            {
                foreach (var item in library.taken_books)
                    if (item.fact_return == null) lw_logs.Items.Add(new ListViewItem(new string[] { item.id.ToString(), item.get_reader_name(), item.get_book_name(), item.receiving.ToShortDateString().ToString(), item.should_return.ToShortDateString().ToString(), item.fact_return.ToString() }));
            }
            lw_logs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) dtp_fact_return.Enabled = true;
            else dtp_fact_return.Enabled = false;
        }

        private void btn_add_log_Click(object sender, EventArgs e)
        {
            if (c_box_reader_name.SelectedIndex != -1 && c_box_book_name.SelectedIndex != -1)
            {
                taken_books taken_book = new taken_books
                {
                    id_reader = readers[c_box_reader_name.SelectedIndex].id,
                    id_book = free_books[c_box_book_name.SelectedIndex].id,
                    receiving = dtp_receiving_date.Value,
                    should_return = dtp_should_return.Value
                };
                if (checkBox1.Checked) taken_book.fact_return = dtp_fact_return.Value;
                try
                {
                    library.taken_books.Add(taken_book);
                    if (checkBox1.Checked)
                    {
                        books book = (from b in library.books where b.id == taken_book.id_book select b).FirstOrDefault();
                        book.available = true;
                    }
                    else
                    {
                        books book = (from b in library.books where b.id == taken_book.id_book select b).FirstOrDefault();
                        book.available = false;
                    }
                    library.SaveChanges();
                    Refresh_lw_logs(0);
                    Refresh_lw_books(0);
                    c_box_book_name.SelectedIndex = -1;
                    c_box_reader_name.SelectedIndex = -1;
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void btn_change_log_Click(object sender, EventArgs e)
        {
            if (lw_logs.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lw_logs.SelectedItems[0].SubItems[0].Text);
                taken_books taken_book = (from tb in library.taken_books where tb.id == id select tb).FirstOrDefault();
                taken_book.should_return = dtp_should_return.Value;
                if (checkBox1.Checked) taken_book.fact_return = dtp_fact_return.Value;
                try
                {
                    if (checkBox1.Checked)
                    {
                        books book = (from b in library.books where b.id == taken_book.id_book select b).FirstOrDefault();
                        book.available = true;
                    }
                    else
                    {
                        books book = (from b in library.books where b.id == taken_book.id_book select b).FirstOrDefault();
                        book.available = false;
                    }
                    library.SaveChanges();
                    Refresh_lw_logs(0);
                    Refresh_lw_books(0);
                    c_box_book_name.SelectedIndex = -1;
                    c_box_reader_name.SelectedIndex = -1;
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void lw_logs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lw_logs.SelectedItems.Count > 0)
            {
                dtp_receiving_date.Value = Convert.ToDateTime(lw_logs.SelectedItems[0].SubItems[3].Text);
                dtp_should_return.Value = Convert.ToDateTime(lw_logs.SelectedItems[0].SubItems[4].Text);
                if (lw_logs.SelectedItems[0].SubItems[5].Text != "")
                {
                    checkBox1.Checked = true;
                    dtp_fact_return.Value = Convert.ToDateTime(lw_logs.SelectedItems[0].SubItems[5].Text);
                }
                else checkBox1.Checked = false;
                c_box_book_name.SelectedIndex = -1;
                c_box_reader_name.SelectedIndex = -1;
            }
        }

        private void t_page_logs_Enter(object sender, EventArgs e)
        {
            Refresh_lw_logs(0);
        }

        private void logs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_logs(0);
        }

        private void returned_logs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_logs(1);
        }

        private void unreturned_logs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh_lw_logs(2);
        }
    }
}
