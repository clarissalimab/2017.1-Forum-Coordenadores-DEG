using ForumDEG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForumDEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoordinatorsPage : ContentPage
    {
        public CoordinatorsPage()
        {
            InitializeComponent();
            this.Title = "Coordinator List";

            var toolbarItem = new ToolbarItem {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new CoordinatorAddPage() { BindingContext = new Coordinator()});
            };

            ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            CoordinatorListView.ItemsSource = await App.CoordinatorDatabase.GetAllCoordinators();
        }

        async void Coordinator_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null) {
                await Navigation.PushAsync(new CoordinatorAddPage() { BindingContext = e.SelectedItem as Coordinator });
            }
        }
    }
}
