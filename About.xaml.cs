using Microsoft.Maui.Storage;
using System.Diagnostics;
using System.Reflection;

namespace PFBv01;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
        //var version = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

        string filePath = "Resources/BuildDate.txt";
        // filePath = "Raw/AboutAssets.txt";  // results in error could not find file
        filePath = "AboutAssets.txt";

      

        if (File.Exists(filePath))
        {
            BuildDateLabel.Text = File.ReadAllText(filePath);
        }
        else
        {
            BuildDateLabel.Text = "Build ID not found";
        }

        //BuildDateLabel.Text = ReadTextFileAsync(filePath).Result;

        //BuildDateLabel.Text = "Last Build Date: " + DateTime.Now.ToString("MM/dd/yyyy");
        //BuildDateLabel.Text = version.LegalCopyright;
    }
    public async Task<string> ReadTextFileAsync(string filePath)
    {
        try
        {
            string fileContents = string.Empty;

            if (File.Exists(filePath))
            {
                fileContents = File.ReadAllText(filePath);
            }
            else
            {
                using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
                //using Stream fileStream = await FileSystem.OpenAppPackageFileAsync(filePath);
                using StreamReader reader = new StreamReader(fileStream);

                fileContents = await reader.ReadToEndAsync();
                
            }
            return fileContents;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Debug.WriteLine($"Error reading file: {ex.Message}");
            return "Error reading build date";
        }
    }

}