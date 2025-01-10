using Microsoft.Maui.Storage;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Maui.ApplicationModel;
namespace PFBv01;

public partial class CaroScroll : ContentPage
{
    public List<string> ImageList { get; set; }
    public CaroScroll()
	{
        InitializeComponent();

        ImageList = new List<string>
            {
                "swipe0.png",
                "swipe1.png",
                "swipe2.png",
                "swipe3.png",
                "swipe4.png",
                "swipe5.png",
                "swipe6.png",
                "swipe7.png",
                "swipe8.png",
                "swipe9.png"
            };

        CaroView1.ItemsSource = ImageList;
        CaroView2.ItemsSource = ImageList;
        CaroView3.ItemsSource = ImageList;
    }

    private void MakeGuess_Click(object sender, EventArgs e)
    {
        var dog = CaroView1.CurrentItem;
        var cat = CaroView1.Position;
        DisplayAlert("Swiped", $"SpinningWheel1 Guess = {cat}", "OK");
    }


}