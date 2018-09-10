using Xamarin.Forms;
using Core;
using StdModelCore;

namespace EFClient
{
    public class MainPageViewModel : BindableObject
    {
        string _name = "-";
        string _ip = "localhost";
        int _searchid;
        public string Name {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Ip
        {
            get => _ip;
            set
            {
                _ip = value;
                OnPropertyChanged();
            }
        }

        public int SearchId
        {
            get => _searchid;
            set
            {
                _searchid = value;
                OnPropertyChanged();
            }
        }
        public Command ConnectCommand { get; set; }

        public MainPageViewModel()
        {
            Name = "Not connected";
            ConnectCommand = new Command(async () =>
            {
                var apiClientService = new ApiService(Ip);
                var result = await apiClientService.PostAsync<Person, Person>(new Person() { Id = SearchId });
                Name = result?.Name;
            });
        }        
    }
}
    

