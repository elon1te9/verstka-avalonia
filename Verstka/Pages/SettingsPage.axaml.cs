using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;

namespace Verstka.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
        ThemeSwitch.IsChecked = Application.Current?.RequestedThemeVariant == ThemeVariant.Dark;
        UpdateTheme();
    }

    private void ThemeSwitch_Changed(object? sender, RoutedEventArgs e)
    {
        UpdateTheme();
    }

    private void UpdateTheme()
    {
        if (Application.Current is null || ThemeText is null)
            return;

        bool dark = ThemeSwitch.IsChecked == true;
        Application.Current.RequestedThemeVariant = dark ? ThemeVariant.Dark : ThemeVariant.Light;
        ThemeText.Text = dark ? "Текущая тема: тёмная" : "Текущая тема: светлая";
    }
}

