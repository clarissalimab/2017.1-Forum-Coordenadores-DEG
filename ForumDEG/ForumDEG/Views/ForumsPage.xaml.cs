using Android.Util;
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
            Log.Info("ForumsPage", "Entrando na pagina");
            InitializeComponent();
            this.Title = "Forum List";

            var toolbarItem = new ToolbarItem {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) => {
                Log.Info("ForumsPage", "Entrando na pagina de adição");
                await Navigation.PushAsync(new ForumAddPage() { BindingContext = new Forum()});
            };

            Log.Info("ForumsPage", "Adicionando item clicado");
            ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            Log.Info("OnAppearing", "Setando coisas.");
            base.OnAppearing();

            Log.Info("OnAppearing", "Pegando todos os forums");
            ForumListView.ItemsSource = await App.ForumDatabase.GetAllForums();
        }

        async void Forum_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null) {
                Log.Info("Forum_ItemSelected", "Entrando na pagina de detalhes do forum");
                await Navigation.PushAsync(new ForumPage() { BindingContext = e.SelectedItem as Forum });
            }
        }
    }
}
