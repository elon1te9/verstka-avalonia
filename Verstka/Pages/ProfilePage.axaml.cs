using Avalonia.Controls;

namespace Verstka.Pages;

public partial class ProfilePage : UserControl
{
    public ProfilePage() : this("Пользователь") { }

    public ProfilePage(string fullName)
    {
        InitializeComponent();
        ProfileNameText.Text = fullName;
        AvatarText.Text = string.IsNullOrWhiteSpace(fullName) ? "П" : fullName[0].ToString().ToUpper();
    }
}

