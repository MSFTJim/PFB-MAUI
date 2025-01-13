namespace PFBv01;

public partial class Stats : ContentPage
{
    public Stats()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateStats();
    }

    private void UpdateStats()
    {
        int games = Preferences.Default.Get("Games", 0);
        int wins = Preferences.Default.Get("Wins", 0);
        int losses = Preferences.Default.Get("Losses", 0);

        var gamesLabel = this.FindByName<Label>("GamesLabel");
        var winsLabel = this.FindByName<Label>("WinsLabel");
        var lossesLabel = this.FindByName<Label>("LossesLabel");

        if (gamesLabel != null)
        {
            gamesLabel.Text = $"Games: {games}";
        }

        if (winsLabel != null)
        {
            winsLabel.Text = $"Wins: {wins}";
        }

        if (lossesLabel != null)
        {
            lossesLabel.Text = $"Losses: {losses}";
        }
    }

    private async void ResetStats_Click(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirm Reset", "Are you sure you want to reset your game statistics?", "Yes", "No");
        if (answer)
        {
            Preferences.Default.Clear();
            await DisplayAlert("Reset Successful", "Your game statistics have been reset.", "OK");
            UpdateStats();
        }
    }
}
