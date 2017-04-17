using ForumDEG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForumDEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumsPage : ContentPage
    {
        public ForumsPage()
        {
            InitializeComponent();
            this.Title = "Forum List";

            var toolbarItem = new ToolbarItem {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new ForumAddPage() { BindingContext = new Forum()});
            };

            ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ForumListView.ItemsSource = await App.ForumDatabase.GetAllForums();
        }

        async void Forum_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null) {
                await Navigation.PushAsync(new ForumAddPage() { BindingContext = e.SelectedItem as Forum });
            }
        }
    }
}
