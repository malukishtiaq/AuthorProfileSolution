using System.ComponentModel;

namespace AuthorProfile.Models
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string BookImageSource { get; set; }
        public int AutorId { get; set; }
    }
}
