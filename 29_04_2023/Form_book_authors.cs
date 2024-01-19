using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _29_04_2023
{
    public partial class Form_book_authors : Form
    {
        private List<authors> free_authors;
        private List<authors> book_authors;
        public Form_book_authors(books book)
        {
            InitializeComponent();
            free_authors = new List<authors>();
            book_authors = new List<authors>();
            Refresh_c_box();
            c_box_books.SelectedItem = book.name;
        }
        public Form_book_authors()
        {
            InitializeComponent();
            free_authors = new List<authors>();
            book_authors = new List<authors>();
            Refresh_c_box();
        }
        private void Refresh_c_box()
        {
            foreach (var item in libraryEntities.get_instance().books.ToList())
                c_box_books.Items.Add(item.name);
        }
        private void Refresh_l_boxes()
        {
            l_box_book_authors.Items.Clear();
            l_box_free_authors.Items.Clear();
            if (c_box_books.SelectedIndex != -1)
            {
                book_authors = libraryEntities.get_instance().books.ToList()[c_box_books.SelectedIndex].get_list_of_authors();
                free_authors = libraryEntities.get_instance().authors.ToList().Except(libraryEntities.get_instance().books.ToList()[c_box_books.SelectedIndex].get_list_of_authors()).ToList();
                foreach (var item in book_authors)
                    l_box_book_authors.Items.Add(item.name);
                foreach (var item in free_authors)
                    l_box_free_authors.Items.Add(item.name);
            }
        }

        private void c_box_books_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh_l_boxes();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (c_box_books.SelectedIndex != -1 && l_box_free_authors.SelectedIndex != -1)
            {
                try
                {
                    authors_books ab = new authors_books
                    {
                        id_book = libraryEntities.get_instance().books.ToList()[c_box_books.SelectedIndex].id,
                        id_author = free_authors[l_box_free_authors.SelectedIndex].id
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
            if (c_box_books.SelectedIndex != -1 && l_box_book_authors.SelectedIndex != -1)
            {
                authors_books ab = new authors_books
                {
                    id_book = libraryEntities.get_instance().books.ToList()[c_box_books.SelectedIndex].id,
                    id_author = book_authors[l_box_book_authors.SelectedIndex].id
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
