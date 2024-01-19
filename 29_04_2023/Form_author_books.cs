using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _29_04_2023
{
    public partial class Form_author_books : Form
    {
        private List<books> free_books;
        private List<books> author_books;
        public Form_author_books(authors author)
        {
            InitializeComponent();
            free_books = new List<books>();
            author_books = new List<books>();
            Refresh_c_box();
            c_box_authors.SelectedItem = author.name;
        }
        public Form_author_books()
        {
            InitializeComponent();
            free_books = new List<books>();
            author_books = new List<books>();
            Refresh_c_box();
        }
        private void Refresh_c_box()
        {
            foreach (var item in libraryEntities.get_instance().authors.ToList())
                c_box_authors.Items.Add(item.name);
        }
        private void Refresh_l_boxes()
        {
            l_box_author_books.Items.Clear();
            l_box_free_books.Items.Clear();
            if (c_box_authors.SelectedIndex != -1)
            {
                author_books = libraryEntities.get_instance().authors.ToList()[c_box_authors.SelectedIndex].get_list_of_books();
                free_books = libraryEntities.get_instance().books.ToList().Except(libraryEntities.get_instance().authors.ToList()[c_box_authors.SelectedIndex].get_list_of_books()).ToList();
                foreach (var item in author_books)
                    l_box_author_books.Items.Add(item.name);
                foreach (var item in free_books)
                    l_box_free_books.Items.Add(item.name);
            }
        }

        private void c_box_authors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh_l_boxes();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (c_box_authors.SelectedIndex != -1 && l_box_free_books.SelectedIndex != -1)
            {
                try
                {
                    authors_books ab = new authors_books
                    {
                        id_author = libraryEntities.get_instance().authors.ToList()[c_box_authors.SelectedIndex].id,
                        id_book = free_books[l_box_free_books.SelectedIndex].id
                    };
                    libraryEntities.get_instance().authors_books.Add(ab);
                    libraryEntities.get_instance().SaveChanges();
                    Refresh_l_boxes();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (c_box_authors.SelectedIndex != -1 && l_box_author_books.SelectedIndex != -1)
            {
                authors_books ab = new authors_books
                {
                    id_author = libraryEntities.get_instance().authors.ToList()[c_box_authors.SelectedIndex].id,
                    id_book = author_books[l_box_author_books.SelectedIndex].id
                };
                ab = (from db_ab in libraryEntities.get_instance().authors_books where ab.id_book == db_ab.id_book && ab.id_author == db_ab.id_author select db_ab).FirstOrDefault();
                try
                {
                    libraryEntities.get_instance().authors_books.Remove(ab);
                    libraryEntities.get_instance().SaveChanges();
                    Refresh_l_boxes();
                }
                catch { MessageBox.Show("Одна ошибка и ты ошибся"); }
            }
        }
    }
}
