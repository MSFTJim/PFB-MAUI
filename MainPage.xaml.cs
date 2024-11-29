//using static Android.Gestures.GestureOverlayView;
using Microsoft.Maui.Controls;
using System;

namespace PFBv01
{
    public partial class MainPage : ContentPage
    {
        private bool[] checkBoxStates = new bool[10];
        private int GuessNumber;
        private int CurrentGuess1;
        private int CurrentGuess2;
        private int CurrentGuess3;
        private int Answer1;
        private int Answer2;
        private int Answer3;
        private string? CurrentGuessImage1;
        private string? CurrentGuessImage2;
        private string? CurrentGuessImage3;

        public MainPage()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            GuessNumber = 0;
            Answer1 = new Random().Next(0, 10);
            Answer2 = new Random().Next(0, 10);
            Answer3 = new Random().Next(0, 10);

            CurrentGuess1 = new Random().Next(0, 10);
            CurrentGuess2 = new Random().Next(0, 10);
            CurrentGuess3 = new Random().Next(0, 10);
            
            //CurrentGuessImage1 = $"swipe{CurrentGuess1}.png";
            //CurrentGuessImage2 = $"swipe{CurrentGuess2}.png";
            //CurrentGuessImage3 = $"swipe{CurrentGuess3}.png";

            SpinningWheelGuess3.Source = $"swipe{CurrentGuess3}.png";
            SpinningWheelGuess2.Source = $"swipe{CurrentGuess2}.png";
            SpinningWheelGuess1.Source = $"swipe{CurrentGuess1}.png";

            for (int i = 0; i < checkBoxStates.Length; i++)
            {
                checkBoxStates[i] = false;
            }

            for (int i = 0; i < 10; i++)
            {
                var checkBox = this.FindByName<Image>($"CheckBox{i}");
                if (checkBox != null)
                {
                    checkBox.Source = $"unchecked{i}.png";
                }
            }

        }

        #region ExampleRegionBlock
        #endregion  // ExampleRegionBlock

        private void OnCheckBoxTapped(object sender, EventArgs e)
        {
            if (sender is Image checkBox)
            {
                int index = int.Parse(checkBox.StyleId);
                checkBoxStates[index] = !checkBoxStates[index];

                checkBox.Source = checkBoxStates[index] ? $"checked{index}.png" : $"unchecked{index}.png";
            }
        }

        private void MakeGuess_Click(object sender, EventArgs e)
        {
            
            DisplayAlert("Guess", $"You guessed G1: {CurrentGuess1} - G2: {CurrentGuess2} - G3: {CurrentGuess3}", "OK");
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            // Add your event handler code here
           StartGame();
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (sender is Image image)
            {
                string imageId = image.StyleId;
                int currentGuess = 0;

                switch (imageId)
                {
                    case "1":
                        currentGuess = CurrentGuess1;
                        break;
                    case "2":
                        currentGuess = CurrentGuess2;
                        break;
                    case "3":
                        currentGuess = CurrentGuess3;
                        break;
                }

                switch (e.Direction)
                {
                    case SwipeDirection.Up:
                        // Handle swipe up
                        currentGuess = (currentGuess + 1) % 10; // Increment and wrap around at 10
                        //DisplayAlert("Swiped", $"You swiped up on SpinningWheelGuess{imageId}", "OK");
                        break;
                    case SwipeDirection.Down:
                        // Handle swipe down
                        currentGuess = (currentGuess - 1 + 10) % 10; // Decrement and wrap around at 0
                        //DisplayAlert("Swiped", $"You swiped down on SpinningWheelGuess{imageId}", "OK");
                        break;
                }

                // Update the corresponding CurrentGuess variable and image source
                switch (imageId)
                {
                    case "1":
                        CurrentGuess1 = currentGuess;
                        SpinningWheelGuess1.Source = $"swipe{CurrentGuess1}.png";
                        break;
                    case "2":
                        CurrentGuess2 = currentGuess;
                        SpinningWheelGuess2.Source = $"swipe{CurrentGuess2}.png";
                        break;
                    case "3":
                        CurrentGuess3 = currentGuess;
                        SpinningWheelGuess3.Source = $"swipe{CurrentGuess3}.png";
                        break;
                }
            }
        }
    }

}
