using System.Threading.Tasks;

namespace Popups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Random rnd = new Random(); 
        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            string input = await DisplayPromptAsync("Toevoegen", "Geef een naam:");

            if (string.IsNullOrWhiteSpace(input))
            {
                await DisplayAlert("Fout", "U heeft geen naam ingegeven, probeer opnieuw!", "OK");
            }
            else
            {
                var button = new Button
                {
                    Text = input,
                    BackgroundColor = GetRandomColor(),
                    TextColor = Colors.White,
                    CornerRadius = 10,
                    Margin = new Thickness(0),
                    Padding = new Thickness(20),
                    FontSize = 18,
                };

                button.Clicked += DynamicButton_Clicked;

                flexLayout.Children.Add(button);
            }
        }

        private async void DynamicButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                bool confirm = await DisplayAlert("Verwijderen?", $"Wil je '{button.Text}' verwijderen?", "Ja", "Nee");
                if (confirm)
                {
                    flexLayout.Children.Remove(button);
                }
            }
        }
    }
}
