using Microsoft.Maui.Storage;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Maui.ApplicationModel;
namespace PFBv01;

public partial class CaroScroll : ContentPage
{
	public CaroScroll()
	{
        InitializeComponent();
    }

    private void MakeGuess_Click(object sender, EventArgs e)
    {
        var dog = CaroView1.CurrentItem;
        var cat = CaroView1.Position;
        DisplayAlert("Swiped", $"SpinningWheel1 Guess = {cat}", "OK");
    }


}