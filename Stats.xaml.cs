using Syncfusion.Maui.Charts;

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
        ChartWinsLosses();
        ChartWinTimes();
        
    }    

    private void ChartWinsLosses()
    {
        // Get the number of wins and losses from the Preferences
        int games = Preferences.Default.Get(Constants.Games, 0);
        int wins = Preferences.Default.Get(Constants.Wins, 0);
        int losses = Preferences.Default.Get(Constants.Losses, 0);
        

        // Create a data source for the PieSeries
        var pieData = new List<ChartDataPoint>
        {
            new ChartDataPoint("Wins", wins),
            new ChartDataPoint("Losses", losses)
        };

        // Set the ItemsSource for the PieSeries
        var pieSeries = (PieSeries)WinLossChart.Series[0];
        pieSeries.ItemsSource = pieData;

        // Set the colors for the PieSeries
        pieSeries.PaletteBrushes = new List<Brush>
        {
            new SolidColorBrush(Color.FromArgb("#7DDA58")), // Color for Wins
            new SolidColorBrush(Color.FromArgb("#D20103"))  // Color for Losses
        };

        // calculate win percentage
        double winPercentage = (double)wins / games * 100;
        string formattedWinPercentage = winPercentage.ToString("F1");

        // Update the chart title
        WinLossChart.Title = $"Total games played: {games}, Win %: {formattedWinPercentage}";

    }

    private async void ResetStats_Click(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirm Reset", "Are you sure you want to reset your game statistics?", "Yes", "No");
        if (answer)
        {
            Preferences.Default.Clear();
            await DisplayAlert("Reset Successful", "Your game statistics have been reset.", "OK");
            ChartWinsLosses();
            ChartWinTimes();
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

        var data = new List<ChartDataPoint>
        {
            new ChartDataPoint("1", guessIn1Try),
            new ChartDataPoint("2", guessIn2Tries),
            new ChartDataPoint("3", guessIn3Tries),
            new ChartDataPoint("4", guessIn4Tries),
            new ChartDataPoint("5", guessIn5Tries),
            new ChartDataPoint("6", guessIn6Tries),
            new ChartDataPoint("7", guessIn7Tries),
            new ChartDataPoint("8", guessIn8Tries),
            new ChartDataPoint("9", guessIn9Tries),
            new ChartDataPoint("10", guessIn10Tries)
        };



        var series = new ColumnSeries
        {
            ItemsSource = data,
            ShowDataLabels = true,
            XBindingPath = "Category",
            YBindingPath = "Value",            
            PaletteBrushes = new List<Brush>
            {
                new SolidColorBrush(Color.FromArgb("#FF0000")), // Red
                new SolidColorBrush(Color.FromArgb("#00FF00")), // Green
                new SolidColorBrush(Color.FromArgb("#0000FF")), // Blue
                new SolidColorBrush(Color.FromArgb("#FFFF00")), // Yellow
                new SolidColorBrush(Color.FromArgb("#FF00FF")), // Magenta
                new SolidColorBrush(Color.FromArgb("#00FFFF")), // Cyan
                new SolidColorBrush(Color.FromArgb("#FFA500")), // Orange
                new SolidColorBrush(Color.FromArgb("#800080")), // Purple
                new SolidColorBrush(Color.FromArgb("#008000")), // Dark Green
                new SolidColorBrush(Color.FromArgb("#000080"))  // Navy
            }
        };

        chartWinTimes.Series.Clear();
        chartWinTimes.Series.Add(series);

    }


}

public class ChartDataPoint
{
    public string Category { get; set; }
    public double Value { get; set; }

    public ChartDataPoint(string category, double value)
    {
        Category = category;
        Value = value;
    }
}
