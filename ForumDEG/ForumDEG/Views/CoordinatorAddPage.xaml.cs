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
    public partial class CoordinatorAddPage : ContentPage
    {
        public CoordinatorAddPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, System.EventArgs e) {
			var coordUser = (Coordinator)BindingContext;

			// Check if there is no space in firsts characters
			coordUser.Registration.Trim();

            coordUser.CreatedOn = DateTime.Now;
            await App.CoordinatorDatabase.SaveCoordinator(coordUser);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
