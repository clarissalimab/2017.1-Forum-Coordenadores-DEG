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
    public partial class FormAddPage : ContentPage
    {
        public FormAddPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, System.EventArgs e) {
			var coordForum = (Forum)BindingContext;
            var forumForm = new Form();

            forumForm.Id = 1;
            forumForm.CreatedOn = DateTime.Now;
            coordForum.FormId = forumForm.Id;

            await App.FormDatabase.SaveForm(forumForm);
            await App.ForumDatabase.SaveForum(coordForum);

            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
