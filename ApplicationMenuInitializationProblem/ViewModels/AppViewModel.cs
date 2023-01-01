using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace ApplicationMenuInitializationProblem.ViewModels;

public class AppViewModel : ViewModelBase
{
    
    public bool CanChange { get; set; } = true;

    public ReactiveCommand<Unit, Unit> QuitApplicationCommand { get; private set; }
    
    public AppViewModel()
    {
        QuitApplicationCommand = ReactiveCommand.Create(QuitApplication,this.WhenAnyValue(x => x.CanChange));
    }
    
    private void QuitApplication()
    {
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
        {
            desktopLifetime.Shutdown();
        }
    }
    
}