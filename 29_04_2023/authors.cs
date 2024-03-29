//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _29_04_2023
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class authors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public authors()
        {
            this.authors_books = new HashSet<authors_books>();
        }

        public int id { get; set; }
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<authors_books> authors_books { get; set; }
        public string get_books()
        {
            string books = "";
            foreach (var book_id in (from ab in libraryEntities.get_instance().authors_books where id == ab.id_author select ab.id_book).ToList())
                books += $"{((from b in libraryEntities.get_instance().books where book_id == b.id select b.name).FirstOrDefault())};\n";
            return books;
        }
        public List<books> get_list_of_books()
        {
            List<books> books = new List<books>();
            foreach (var book_id in (from ab in libraryEntities.get_instance().authors_books where id == ab.id_author select ab.id_book).ToList())
                books.Add(((from b in libraryEntities.get_instance().books where book_id == b.id select b).FirstOrDefault()));
            return books;
        }
    }
}
