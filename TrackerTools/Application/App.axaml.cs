using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace TrackerTools.Application;

public partial class App : Avalonia.Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Application.MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}