using System;
using Microsoft.Maui.Controls;

namespace biblioteka
{
    public partial class MainPage : ContentPage
    {
      
        private readonly List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Potop - Henryk Sienkiewicz", AvailableQuantity = 2 },
            new Book { Id = 2, Title = "Pan Tadeusz - Adam Mickiewicz", AvailableQuantity = 1 },
            new Book { Id = 3, Title = "Zbrodnia i Kara - Fiodor Dostojewski", AvailableQuantity = 4 }
        };

        public MainPage()
        {
            InitializeComponent();
            UpdateBookList();
        }

      
        private void UpdateBookList()
        {
            
            Book1Quantity.Text = books[0].AvailableQuantity.ToString();
            Book2Quantity.Text = books[1].AvailableQuantity.ToString();
            Book3Quantity.Text = books[2].AvailableQuantity.ToString();
        }

      
        private void BorrowBook(object sender, EventArgs e)
        {
            if (int.TryParse(BorrowBookIdEntry.Text, out int bookId))
            {
                var book = books.Find(b => b.Id == bookId);
                if (book != null)
                {
                    if (book.AvailableQuantity > 0)
                    {
                        book.AvailableQuantity--;
                        UpdateBookList();
                        DisplayAlert("Dziękujemy", "Dziękujemy za wypożyczenie u nas książki. Życzymy miłego czytania", "OK");
                    }
                    else
                    {
                        DisplayAlert("Błąd", "Brak dostępnych egzemplarzy!", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Nie ma u nas książki o takim ID", "OK");
                }
            }
            else
            {
                DisplayAlert("Error!", "Niepoprawna wartość", "OK");
            }
        }

        
        private void ReturnBook(object sender, EventArgs e)
        {
            if (int.TryParse(ReturnBookIdEntry.Text, out int bookId))
            {
                var book = books.Find(b => b.Id == bookId);
                if (book != null)
                {
                    book.AvailableQuantity++;
                    UpdateBookList();
                    DisplayAlert("Dziękujemy", "Dziękujemy za zwrócenie nam książki. Zapraszamy ponownie", "OK");
                }
                else
                {
                    DisplayAlert("Błąd", "Nieprawidłowy ID książki!", "OK");
                }
            }
            else
            {
                DisplayAlert("Błąd", "Proszę podać prawidłowy numer ID!", "OK");
            }
        }
    }

    
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
