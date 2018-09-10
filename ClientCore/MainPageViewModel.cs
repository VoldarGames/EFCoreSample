using Xamarin.Forms;

namespace ClientCore
{
    public class MainPageViewModel
    {
        public string Name { get; set; } = "Not connected...";
        public Command ConnectCommand { get; set; }
    }
}
