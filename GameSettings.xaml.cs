using Microsoft.Maui.Controls;

namespace PFBv01;

public partial class GameSettings : ContentPage
{
    public GameSettings()
    {
        InitializeComponent();

        // Load the saved setting 
        GameSoundsCheckBox.IsChecked = LoadGameSoundsSetting();
        LearnModeCheckBox.IsChecked = LoadLearnModeSetting();
   
    }

    
    private void OnLearnModeCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Save the setting 
        SaveLearnModeSetting(e.Value);

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

    private bool LoadLearnModeSetting()
    {
        // Load the setting from storage (e.g., Preferences, file, etc.)                
        return Preferences.Default.Get("LearnModeOn", false);
    }

    private void SaveLearnModeSetting(bool isChecked)
    {
        Preferences.Default.Set("LearnModeOn", isChecked);
    }
}
