using Syncfusion.Maui.Charts;

namespace PFBv01;

public partial class ScrollView : ContentPage
{
	public ScrollView()
	{
		InitializeComponent();
     
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetTestData();       
    }

    private void SetTestData()
    {
        // Create a data source for the PieSeries
        var pieData = new List<ChartDataPoint>
        {
            new ChartDataPoint("Wins", 10),
            new ChartDataPoint("Losses", 5)
        };

        

        // Set the ItemsSource for the PieSeries
        var pieSeries = (PieSeries)WinLossChart.Series[0];
        pieSeries.PaletteBrushes = new List<Brush>
        {
            new SolidColorBrush(Color.FromArgb("#7DDA58")), // Color for Wins
            new SolidColorBrush(Color.FromArgb("#D20103"))  // Color for Losses
        };
        pieSeries.ItemsSource = pieData;
    }

}


  

