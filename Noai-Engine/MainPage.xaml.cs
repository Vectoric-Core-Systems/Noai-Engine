// C# System Namespaces
using System.Collections.ObjectModel;
using System.IO;

// Engine Namespaces
using Core.Startup; 

namespace Noai_Engine
{

    public partial class MainPage : ContentPage
    {
        // 2. The property that your XAML will look for
        public ObservableCollection<ProjectModel> Projects { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();

            // 3. Set the BindingContext so XAML bindings function
            BindingContext = this;

            LoadProjects();
        }

        private void LoadProjects()
        {
            // 4. Instantiate the class from your Core.Startup namespace
            var startup = new CoreStartup();

            // 5. Run the method to retrieve the file path strings
            List<string> paths = startup.Projects_NameOnly();

            Projects.Clear();

            // 6. Clean up paths into distinct display names for your buttons
            foreach (string path in paths)
            {
                Projects.Add(new ProjectModel
                {
                    ProjectName = Path.GetFileNameWithoutExtension(path),
                    FilePath = path
                });
            }
        }

        private async void OnProjectSelected(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is ProjectModel selectedProject)
            {
                // You now have the exact file path to load into your engine
                string projectToLoad = selectedProject.FilePath;

                await DisplayAlert("Loading", $"Opening: {selectedProject.ProjectName}", "OK");
            }
        }
    }

    public class ProjectModel
    {
        public string ProjectName { get; set; }
        public string FilePath { get; set; }
    }
}
