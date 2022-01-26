using CadastroLivros.Enum;

namespace CadastroLivros.Classes
{
    public class Book : BaseEntity
    {
        private Genre genre { get; set; }
        private string title { get; set; }
        private string author { get; set; }
        private string description { get; set; }
        private int year { get; set; }

        private bool deleted { get; set; }

        public Book(int ID, Genre genre, string title, string author, string description, int year)
        {
            this.ID = ID;
            this.genre = genre;
            this.title = title;
            this.author = author;
            this.description = description;
            this.year = year;
            this.deleted = false;
        }

        public override String ToString()
        {
            string info = "----------------------------" + Environment.NewLine;
            info += "Gênero: " + this.genre + Environment.NewLine;
            info += "Título: " + this.title + Environment.NewLine;
            info += "Autor(a): " + this.author + Environment.NewLine;
            info += "Descrição: " + this.description + Environment.NewLine;
            info += "Ano: " + this.year + Environment.NewLine;
            info += "----------------------------" + Environment.NewLine;
            return info;
        }

        public int getID()
        {
            return this.ID;
        }

        public string getTitle()
        {
            return this.title;
        }

        public void deleteBook()
        {
            this.deleted = true;
        }



    }
}
