using AuthorProfile.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuthorProfile.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Author> authors;
        private Author currentItem;
        private ObservableRangeCollection<Book> books;
        private int position;
        #region Public Properties
        public ICommand PositionChangedCommand { get; set; }

        public int Position
        {
            get => position;
            set
            {
                if (position == value)
                    return;

                position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public ObservableRangeCollection<Book> Books
        {
            get => books; set
            {
                if (books == value)
                    return;

                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        public Author CurrentItem
        {
            get => currentItem;
            set
            {
                if (currentItem == value)
                    return;

                currentItem = value;

                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public ObservableRangeCollection<Author> Authors
        {
            get => authors;
            set
            {
                if (authors == value)
                    return;

                authors = value;

                OnPropertyChanged(nameof(Authors));
            }
        } 

        #endregion

        public MainViewModel()
        {
            position = 0;
            Authors = new ObservableRangeCollection<Author>()
            {
                new Author
                {
                      Id = 0,
                      Name = "J K Rowling",
                      Age = "1965 - ",
                      From = "British Author",
                      ImageSource = "JKRowling",
                      Background = "image1",
                      TotalBooks = 57,
                      Qouts = "471",
                      Followers = "33.7K",
                },
                new Author
                {
                      Id = 1,
                      Name = "Harper Lee",
                      Age = "1926 - 2016",
                      Background = "image2",
                      From = "American Novelist",
                      ImageSource = "HarperLee",
                      Followers = "59.1K",
                      Qouts = "720",
                      TotalBooks = 15,
                },
                new Author
                {
                      Id = 2,
                      Name = "V.S. Naipaul",
                      Age = "1932 - 2018",
                      From = "British-Trinidadian",
                      Qouts = "891",
                      ImageSource = "vsnaipaul",
                      Background = "image3",
                      TotalBooks = 37,
                      Followers = "42.3K",
                }
            };
            Books = new ObservableRangeCollection<Book>()
            {
                new Book()
                {
                    AutorId = 0,
                    BookImageSource = "JKRowling1",
                },new Book()
                {
                    AutorId = 0,
                    BookImageSource = "JKRowling2",
                },new Book()
                {
                    AutorId = 0,
                    BookImageSource = "JKRowling3",
                },
            };
            PositionChanged();
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                Position = (Position + 1) % 3;
                PositionChanged();
                return true;
            }));
        }

        private Task PositionChanged()
        {
            CurrentItem = Authors.Where(x => x.Id == Position).FirstOrDefault();
            List<Book> booksByAuthor = GetBooks().Where(x => x.AutorId == CurrentItem?.Id).Select(x => x).ToList();
            Books[0] = booksByAuthor[0];
            Books[1] = booksByAuthor[1];
            Books[2] = booksByAuthor[2];

            return Task.CompletedTask;
        }
        private List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book()
                {
                    BookImageSource = "JKRowlingbook1",
                    AutorId = 0,
                },
                new Book()
                {
                    AutorId = 0,
                    BookImageSource = "JKRowlingbook2",
                },
                new Book()
                {
                    AutorId = 0,
                    BookImageSource = "JKRowlingbook5",
                },
                new Book()
                {
                    AutorId = 1,
                    BookImageSource = "HarperLeebook1",
                },new Book()
                {
                    AutorId = 1,
                    BookImageSource = "HarperLeebook2",
                },new Book()
                {
                    AutorId = 1,
                    BookImageSource = "HarperLeebook3",
                },
                new Book()
                {
                    AutorId = 2,
                    BookImageSource = "vsnaipaulbook1",
                },new Book()
                {
                    AutorId = 2,
                    BookImageSource = "vsnaipaulbook2",
                },new Book()
                {
                    AutorId = 2,
                    BookImageSource = "vsnaipaulbook3",
                },
            };
        }
    }
}
