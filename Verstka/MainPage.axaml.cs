using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using System.Collections.Generic;
using Verstka.Pages;

namespace Verstka;

public partial class MainPage : Window
{
    // Страницы создаём один раз и переключаем содержимое окна.
    private readonly Dictionary<string, UserControl> _pages = new();

    public MainPage() : this("Пользователь") { }

    public MainPage(string fullName)
    {
        InitializeComponent();
        ProfileButton.Content = fullName;

        _pages.Add("Обзор", new OverviewPage());
        _pages.Add("Проекты", new ProjectsPage());
        _pages.Add("Задачи", new TasksPage());
        _pages.Add("Календарь", new CalendarPage());
        _pages.Add("Команда", new TeamPage());
        _pages.Add("Настройки", new SettingsPage());
        _pages.Add("Личный кабинет", new ProfilePage(fullName));
        PageContent.Content = _pages["Обзор"];
    }

    private void Navigate_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button || button.Tag is not string pageName)
            return;

        PageContent.Content = _pages[pageName];

        foreach (Button item in NavigationPanel.Children)
            item.Classes.Remove("active");

        ProfileButton.Classes.Remove("active");
        button.Classes.Add("active");
    }

    private void Logout_Click(object? sender, RoutedEventArgs e)
    {
        var login = new MainWindow();

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = login;

        login.Show();
        Close();
    }
}

