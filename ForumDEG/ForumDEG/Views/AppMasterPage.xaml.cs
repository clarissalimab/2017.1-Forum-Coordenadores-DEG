﻿using ForumDEG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForumDEG.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppMasterPage : MasterDetailPage {
        private AppMasterViewModel viewModel = new AppMasterViewModel(new PageService());

        public AppMasterPage() {
            BindingContext = viewModel;
            InitializeComponent();
        }

    }
}

