using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Verstka;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object? sender, RoutedEventArgs e)
    {
        bool nameIsEmpty = string.IsNullOrWhiteSpace(FullNameTextBox.Text);
        bool passwordIsEmpty = string.IsNullOrWhiteSpace(PasswordTextBox.Text);

        if (nameIsEmpty || passwordIsEmpty)
        {
            ErrorTextBlock.Text = "Заполните все поля";
            ErrorTextBlock.IsVisible = true;
            return;
        }

        ErrorTextBlock.IsVisible = false;

        string fullName = FullNameTextBox.Text!.Trim();

        var mainPage = new MainPage(fullName);
        if (Avalonia.Application.Current?.ApplicationLifetime is
            Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = mainPage;

        mainPage.Show();

        Close();
    }
}
