
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

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
        ShowStats();
    }

    private void ShowStats()
    {
        ChartWinsLosses();
        ChartWinTimes();
    }

    private void ChartWinsLosses()
    {
        // Get the number of wins and losses from the Preferences
        int games = Preferences.Default.Get(Constants.Games, 0);
        int wins = Preferences.Default.Get(Constants.Wins, 0);
        int losses = Preferences.Default.Get(Constants.Losses, 0);

        ChartEntry[] wins_losses = new[]
        {
            new ChartEntry(wins)
            {
                Label = "Wins",
                ValueLabel = wins.ToString(),
                ValueLabelColor = SKColor.Parse("#7DDA58"),
                Color = SKColor.Parse("#7DDA58")
            },
            new ChartEntry(losses)
            {
                Label = "Losses",
                ValueLabel = losses.ToString(),
                ValueLabelColor = SKColor.Parse("#D20103"),
                Color = SKColor.Parse("#D20103")
            }
        };

        chartWinLoss.Chart = new PieChart
        {
            Entries = wins_losses
        };
    }

    private async void ResetStats_Click(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirm Reset", "Are you sure you want to reset your game statistics?", "Yes", "No");
        if (answer)
        {
            Preferences.Default.Clear();
            await DisplayAlert("Reset Successful", "Your game statistics have been reset.", "OK");
            ShowStats();
        }
    }

    private void FakeStats_Clicked(object sender, EventArgs e)
    {        
        Preferences.Default.Set(Constants.GuessIn1Try, 0);
        Preferences.Default.Set(Constants.GuessIn2Tries, 2);
        Preferences.Default.Set(Constants.GuessIn3Tries, 3);
        Preferences.Default.Set(Constants.GuessIn4Tries, 5);
        Preferences.Default.Set(Constants.GuessIn5Tries, 6);
        Preferences.Default.Set(Constants.GuessIn6Tries, 8);
        Preferences.Default.Set(Constants.GuessIn7Tries, 11);
        Preferences.Default.Set(Constants.GuessIn8Tries, 14);
        Preferences.Default.Set(Constants.GuessIn9Tries, 9);
        Preferences.Default.Set(Constants.GuessIn10Tries, 21);

    }

    private void ChartWinTimes()
    {
        int guessIn1Try = Preferences.Default.Get(Constants.GuessIn1Try, 0);
        int guessIn2Tries = Preferences.Default.Get(Constants.GuessIn2Tries, 0);
        int guessIn3Tries = Preferences.Default.Get(Constants.GuessIn3Tries, 0);
        int guessIn4Tries = Preferences.Default.Get(Constants.GuessIn4Tries, 0);
        int guessIn5Tries = Preferences.Default.Get(Constants.GuessIn5Tries, 0);
        int guessIn6Tries = Preferences.Default.Get(Constants.GuessIn6Tries, 0);
        int guessIn7Tries = Preferences.Default.Get(Constants.GuessIn7Tries, 0);
        int guessIn8Tries = Preferences.Default.Get(Constants.GuessIn8Tries, 0);
        int guessIn9Tries = Preferences.Default.Get(Constants.GuessIn9Tries, 0);
        int guessIn10Tries = Preferences.Default.Get(Constants.GuessIn10Tries, 0);

        ChartEntry[] GuessEntries = new[]
        {
            new ChartEntry(guessIn1Try)
            {
                Label = "1 Try",
                ValueLabel = guessIn1Try.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn2Tries)
            {
                Label = "2 Tries",
                ValueLabel = guessIn2Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn3Tries)
            {
                Label = "3 Tries",
                ValueLabel = guessIn3Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn4Tries)
            {
                Label = "4 Tries",
                ValueLabel = guessIn4Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn5Tries)
            {
                Label = "5 Tries",
                ValueLabel = guessIn5Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn6Tries)
            {
                Label = "6 Tries",
                ValueLabel = guessIn6Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn7Tries)
            {
                Label = "7 Tries",
                ValueLabel = guessIn7Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn8Tries)
            {
                Label = "8 Tries",
                ValueLabel = guessIn8Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn9Tries)
            {
                Label = "9 Tries",
                ValueLabel = guessIn9Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            },
            new ChartEntry(guessIn10Tries)
            {
                Label = "10 Tries",
                ValueLabel = guessIn10Tries.ToString(),
                Color = SKColor.Parse("#0000ff")
            }
        };

        chartGuesses.Chart = new BarChart
        {
            Entries = GuessEntries
        };
    }


}
