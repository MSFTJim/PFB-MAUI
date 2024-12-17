using Microsoft.Maui.Storage;
using System.Diagnostics;
using System.Reflection;

namespace PFBv01;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string filePath = "AboutAssets.txt";

        BuildDateLabel.Text = await ReadTextFileAsync(filePath);

    }

    public async Task<string> ReadTextFileAsync(string filePath)
    {
        string fileContents = string.Empty;

        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);            
        using StreamReader reader = new StreamReader(fileStream);

        fileContents = await reader.ReadToEndAsync();            

        return fileContents;        
    }

}