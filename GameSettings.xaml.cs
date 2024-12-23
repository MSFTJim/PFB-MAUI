using Microsoft.Maui.Controls;

namespace PFBv01;

public partial class GameSettings : ContentPage
{
    public GameSettings()
    {
        InitializeComponent();

        // Load the saved setting 
        GameSoundsCheckBox.IsChecked = LoadGameSoundsSetting();
        GameHintCheckBox.IsChecked = LoadGameHintSetting();

        // Handle the CheckBox checked change event
        GameSoundsCheckBox.CheckedChanged += OnGameSoundsCheckBoxCheckedChanged!;
    }

    
    private void OnGameHintCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Save the setting 
        SaveGameHintSetting(e.Value);

    }

    private void OnGameSoundsCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Save the setting for game sounds
        SaveGameSoundsSetting(e.Value);
        
    }

    private bool LoadGameSoundsSetting()
    {
        // Load the setting from storage (e.g., Preferences, file, etc.)                
        return Preferences.Default.Get("GameSoundOn", false);
    }

    private void SaveGameSoundsSetting(bool isChecked)
    {        
        Preferences.Default.Set("GameSoundOn", isChecked);
    }

    private bool LoadGameHintSetting()
    {
        // Load the setting from storage (e.g., Preferences, file, etc.)                
        return Preferences.Default.Get("GameHintOn", false);
    }

    private void SaveGameHintSetting(bool isChecked)
    {
        Preferences.Default.Set("GameHintOn", isChecked);
    }
}
