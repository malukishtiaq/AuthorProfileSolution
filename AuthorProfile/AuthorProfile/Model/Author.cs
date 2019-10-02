using System.Collections.Generic;
using System.ComponentModel;

namespace AuthorProfile.Models
{
    public class Author : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string From { get; set; }
        public string ImageSource { get; set; }
        public string Background { get; set; }
        public string Followers { get; set; }
        public List<Book> Books { get; set; }
        public string Qouts { get; internal set; }
        public int TotalBooks { get; internal set; }
    }
}
