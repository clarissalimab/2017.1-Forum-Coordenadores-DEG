using ForumDEG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForumDEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumAddPage : ContentPage
    {
        public ForumAddPage()
        {
            InitializeComponent();

            var toolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new FormAddPage() { BindingContext = new Form() });
            };

            ToolbarItems.Add(toolbarItem);
        }

        async void Save_Clicked(object sender, System.EventArgs e) {
			var coordForum = (Forum)BindingContext;

            coordForum.CreatedOn = DateTime.Now;
            await App.ForumDatabase.SaveForum(coordForum);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
