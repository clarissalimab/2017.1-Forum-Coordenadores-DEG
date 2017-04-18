using ForumDEG.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForumDEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumPage : ContentPage
    {
        public ForumPage()
        {
            InitializeComponent();
            this.Title = "Forum Detail";

            var toolbarItemForm = new ToolbarItem {
                Text = "Novo Formulario"
            };

            toolbarItemForm.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new FormAddPage() { BindingContext = new Form()});
            };

            ToolbarItems.Add(toolbarItemForm);

            var toolbarItemEdit = new ToolbarItem {
                Text = "Editar"
            };

            toolbarItemEdit.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new ForumAddPage() { BindingContext = new Forum()});
            };

            ToolbarItems.Add(toolbarItemEdit);
        }
    }
}
