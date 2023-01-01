using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ApplicationMenuInitializationProblem.ViewModels;
using ApplicationMenuInitializationProblem.Views;

namespace ApplicationMenuInitializationProblem;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DataContext = new AppViewModel();
            
            // Like Any well designed Mac Application, it should be able ot run without a MainWindow. 
            // I wanted to see if I could run the application and display the Application Menu 
            // With the idea that one could spawn separate windows that each represent their own document.
            // Essentially, I want to be able to replicate the behaviour of 
            // If you add these lines back in, you'll see that only then the Native Menu's defined in the App.axaml is available
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
