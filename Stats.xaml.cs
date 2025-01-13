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
        int games = Preferences.Default.Get(Constants.Games, 0);
        int wins = Preferences.Default.Get(Constants.Wins, 0);
        int losses = Preferences.Default.Get(Constants.Losses, 0);

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

        // Update the labels for guesses in various tries
        var guessIn1TryLabel = this.FindByName<Label>("GuessIn1TryLabel");
        var guessIn2TriesLabel = this.FindByName<Label>("GuessIn2TriesLabel");
        var guessIn3TriesLabel = this.FindByName<Label>("GuessIn3TriesLabel");
        var guessIn4TriesLabel = this.FindByName<Label>("GuessIn4TriesLabel");
        var guessIn5TriesLabel = this.FindByName<Label>("GuessIn5TriesLabel");
        var guessIn6TriesLabel = this.FindByName<Label>("GuessIn6TriesLabel");
        var guessIn7TriesLabel = this.FindByName<Label>("GuessIn7TriesLabel");
        var guessIn8TriesLabel = this.FindByName<Label>("GuessIn8TriesLabel");
        var guessIn9TriesLabel = this.FindByName<Label>("GuessIn9TriesLabel");
        var guessIn10TriesLabel = this.FindByName<Label>("GuessIn10TriesLabel");

        if (guessIn1TryLabel != null)
        {
            int guessIn1Try = Preferences.Default.Get(Constants.GuessIn1Try, 0);
            guessIn1TryLabel.Text = $"Guess in 1 try: {guessIn1Try}";
        }

        if (guessIn2TriesLabel != null)
        {
            int guessIn2Tries = Preferences.Default.Get(Constants.GuessIn2Tries, 0);
            guessIn2TriesLabel.Text = $"Guess in 2 tries: {guessIn2Tries}";
        }

        if (guessIn3TriesLabel != null)
        {
            int guessIn3Tries = Preferences.Default.Get(Constants.GuessIn3Tries, 0);
            guessIn3TriesLabel.Text = $"Guess in 3 tries: {guessIn3Tries}";
        }

        if (guessIn4TriesLabel != null)
        {
            int guessIn4Tries = Preferences.Default.Get(Constants.GuessIn4Tries, 0);
            guessIn4TriesLabel.Text = $"Guess in 4 tries: {guessIn4Tries}";
        }

        if (guessIn5TriesLabel != null)
        {
            int guessIn5Tries = Preferences.Default.Get(Constants.GuessIn5Tries, 0);
            guessIn5TriesLabel.Text = $"Guess in 5 tries: {guessIn5Tries}";
        }

        if (guessIn6TriesLabel != null)
        {
            int guessIn6Tries = Preferences.Default.Get(Constants.GuessIn6Tries, 0);
            guessIn6TriesLabel.Text = $"Guess in 6 tries: {guessIn6Tries}";
        }

        if (guessIn7TriesLabel != null)
        {
            int guessIn7Tries = Preferences.Default.Get(Constants.GuessIn7Tries, 0);
            guessIn7TriesLabel.Text = $"Guess in 7 tries: {guessIn7Tries}";
        }

        if (guessIn8TriesLabel != null)
        {
            int guessIn8Tries = Preferences.Default.Get(Constants.GuessIn8Tries, 0);
            guessIn8TriesLabel.Text = $"Guess in 8 tries: {guessIn8Tries}";
        }

        if (guessIn9TriesLabel != null)
        {
            int guessIn9Tries = Preferences.Default.Get(Constants.GuessIn9Tries, 0);
            guessIn9TriesLabel.Text = $"Guess in 9 tries: {guessIn9Tries}";
        }

        if (guessIn10TriesLabel != null)
        {
            int guessIn10Tries = Preferences.Default.Get(Constants.GuessIn10Tries, 0);
            guessIn10TriesLabel.Text = $"Guess in 10 tries: {guessIn10Tries}";
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
