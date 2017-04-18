using Android.Util;
using ForumDEG.Utils;
using ForumDEG.Views;
using Xamarin.Forms;

namespace ForumDEG {
    public partial class App : Application {

        static AdministratorDatabase _administratorDatabase;
        static CoordinatorDatabase _coordinatorDatabase;
        static ForumDatabase _forumDatabase;
        static FormDatabase _formDatabase;

        public App() {
            InitializeComponent();


            Log.Info("App()", "Abrindo a pagina principal");
            MainPage = new NavigationPage(new ForumsPage());
            //MainPage = new NavigationPage(new CoordinatorsPage());
            //MainPage = new NavigationPage(new AdministratorsPage());
            //MainPage = new ForumDEG.MainPage();
        }

        public static FormDatabase FormDatabase
        {
            get
            {
                if (_formDatabase == null)
                {
                    Log.Info("FormDatabase", "Criando banco de formulário");
                    _formDatabase = new FormDatabase(DependencyService.Get<InterfaceSQLite>().GetLocalFilePath("Form.db3"));
                    Log.Info("FormDatabase", "Banco form criado");
                }
                Log.Info("FormDatabase", "Mandando o banco de volta");
                return _formDatabase;
            }
        }

        public static ForumDatabase ForumDatabase
        {
            get
            {
                if (_forumDatabase == null)
                {
                    Log.Info("ForumDatabase", "Criando banco de forum");
                    _forumDatabase = new ForumDatabase(DependencyService.Get<InterfaceSQLite>().GetLocalFilePath("Forum.db3"));
                    Log.Info("ForumDatabase", "Banco forum criado");
                }
                Log.Info("ForumDatabase", "Mandando o banco de volta");
                return _forumDatabase;
            }
        }

        public static CoordinatorDatabase CoordinatorDatabase
        {
            get
            {
                if (_coordinatorDatabase == null)
                {
                    _coordinatorDatabase = new CoordinatorDatabase(DependencyService.Get<InterfaceSQLite>().GetLocalFilePath("Coordinator.db3"));
                }
                return _coordinatorDatabase;
            }
        }

        public static AdministratorDatabase AdministratorDatabase{
            get {
                if(_administratorDatabase == null){
                    _administratorDatabase = new AdministratorDatabase(DependencyService.Get<InterfaceSQLite>().GetLocalFilePath("Administrator.db3"));
                }
                return _administratorDatabase;
            }
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
