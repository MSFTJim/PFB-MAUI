using Microsoft.Maui.Controls;

namespace PFBv01;

public partial class GameSettings : ContentPage
{
    public GameSettings()
    {
        InitializeComponent();

        // Load the saved setting for game sounds
        GameSoundsCheckBox.IsChecked = LoadGameSoundsSetting();

        // Handle the CheckBox checked change event
        GameSoundsCheckBox.CheckedChanged += OnGameSoundsCheckBoxCheckedChanged;
    }

    private void OnGameSoundsCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Save the setting for game sounds
        SaveGameSoundsSetting(e.Value);
    }

    private bool LoadGameSoundsSetting()
    {
        // Load the setting from storage (e.g., Preferences, file, etc.)
        // For demonstration, returning a default value of true (sounds on)
        return true;
    }

    private void SaveGameSoundsSetting(bool isChecked)
    {
        // Save the setting to storage (e.g., Preferences, file, etc.)
    }
}
