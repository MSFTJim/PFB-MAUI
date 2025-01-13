//using static Android.Gestures.GestureOverlayView;
//using AndroidX.CardView.Widget;
using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
using System;
using System.Numerics;
using System.Xml.Linq;

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
        public bool GameOver;
        public bool SwipeUp;
        public bool GameAudioOn;
        
        private IAudioPlayer? SwipeUpSoundEffect;
        private IAudioPlayer? SwipeDownSoundEffect;
        public List<string> SwipeWheelList { get; set; }


        public MainPage()
        {
            
            InitializeComponent();
            SwipeWheelList = new List<string>
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

            SpinningWheelGuess1.ItemsSource = SwipeWheelList;
            SpinningWheelGuess2.ItemsSource = SwipeWheelList;
            SpinningWheelGuess3.ItemsSource = SwipeWheelList;
            
            StartGame();

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Add your code here to handle the event when the page appears
            AnswerHint();
            GameAudioOn = Preferences.Default.Get("GameSoundOn", false);
            // woosh = up, click = down
            SwipeUpSoundEffect = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Woosh.wav"));
            SwipeDownSoundEffect = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("RVBCLICK.wav"));            

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            // Add your code here to handle the event when the page disappears            
            SwipeUpSoundEffect!.Dispose();
            SwipeUpSoundEffect = null;
            SwipeDownSoundEffect!.Dispose();
            SwipeDownSoundEffect = null;            
        }

        private void StartGame()
        {
            GuessNumber = 1;
            GameOver = false;
            SwipeUp = false;                        
            

            Answer1 = new Random().Next(0, 10);
            Answer2 = new Random().Next(0, 10);
            Answer3 = new Random().Next(0, 10);

            CurrentGuess1 = new Random().Next(0, 10);
            CurrentGuess2 = new Random().Next(0, 10);
            CurrentGuess3 = new Random().Next(0, 10);
            
            SpinningWheelGuess3.Position = CurrentGuess3;
            SpinningWheelGuess2.Position = CurrentGuess2;
            SpinningWheelGuess1.Position = CurrentGuess1;


            // Set Tick Marks for new game status
            ClearTickMarks();

            // Set all Guess Highlight BoxView colors to transparent
           SetGuessHighlightColorsToTransparent();

            MakeGuess.IsEnabled = true;

            ResetGuessGrid();                     

        }

        private void ResetGuessGrid()
        {
            Guess1_1.Text = "?";
            Guess1_2.Text = "?";
            Guess1_3.Text = "?";
            Guess1Grade.Text = "???";
            Guess2_1.Text = "?";
            Guess2_2.Text = "?";
            Guess2_3.Text = "?";
            Guess2Grade.Text = "???";
            Guess3_1.Text = "?";
            Guess3_2.Text = "?";
            Guess3_3.Text = "?";
            Guess3Grade.Text = "???";
            Guess4_1.Text = "?";
            Guess4_2.Text = "?";
            Guess4_3.Text = "?";
            Guess4Grade.Text = "???";
            Guess5_1.Text = "?";
            Guess5_2.Text = "?";
            Guess5_3.Text = "?";
            Guess5Grade.Text = "???";
            Guess6_1.Text = "?";
            Guess6_2.Text = "?";
            Guess6_3.Text = "?";
            Guess6Grade.Text = "???";
            Guess7_1.Text = "?";
            Guess7_2.Text = "?";
            Guess7_3.Text = "?";
            Guess7Grade.Text = "???";
            Guess8_1.Text = "?";
            Guess8_2.Text = "?";
            Guess8_3.Text = "?";
            Guess8Grade.Text = "???";
            Guess9_1.Text = "?";
            Guess9_2.Text = "?";
            Guess9_3.Text = "?";
            Guess9Grade.Text = "???";
            Guess10_1.Text = "?";
            Guess10_2.Text = "?";
            Guess10_3.Text = "?";
            Guess10Grade.Text = "???";

        }

        private void SetGuessHighlightColorsToTransparent()
        {
            for (int i = 1; i <= 10; i++)
            {
                // Construct the name of the BoxView dynamically
                string highlightBorderName = $"Guess{i}Border";

                // Find the Border by name
                var highlightBox = this.FindByName<Border>(highlightBorderName);

                // Set the color of the Border to transparent
                if (highlightBox != null)
                {
                    highlightBox.BackgroundColor = Colors.Transparent;
                }
            }
        }

        private void ClearTickMarks()
        {
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

        public void AnswerHint()
        {
            if (GameOver) return;
            bool ShowHint = Preferences.Default.Get("LearnModeOn", false);

            if (ShowHint)
            {                
                Guess10_1.Text = Answer1.ToString();
                Guess10_2.Text = Answer2.ToString();
                Guess10_3.Text = Answer3.ToString();
            }
            else
            {
                Guess10_1.Text = "?";
                Guess10_2.Text = "?";
                Guess10_3.Text = "?";
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
        
        private void NewGame_Click(object sender, EventArgs e)
        {
            // Add your event handler code here
           StartGame();
        }     


        //private void OnSwiped(object sender, SwipedEventArgs e)
        //{
        //    if (sender is Image image)
        //    {
        //        string imageId = image.StyleId;
        //        int currentGuess = 0;

        //        switch (imageId)
        //        {
        //            case "1":
        //                currentGuess = CurrentGuess1;
        //                break;
        //            case "2":
        //                currentGuess = CurrentGuess2;
        //                break;
        //            case "3":
        //                currentGuess = CurrentGuess3;
        //                break;
        //        }

        //        switch (e.Direction)
        //        {
        //            case SwipeDirection.Up:
        //                // Handle swipe up
        //                currentGuess = (currentGuess + 1) % 10; // Increment and wrap around at 10
        //                //DisplayAlert("Swiped", $"You swiped up on SpinningWheelGuess{imageId}", "OK");
        //                if (GameAudioOn)
        //                    SwipeUpSoundEffect!.Play();
        //                break;
        //            case SwipeDirection.Down:
        //                // Handle swipe down
        //                currentGuess = (currentGuess - 1 + 10) % 10; // Decrement and wrap around at 0
        //                //DisplayAlert("Swiped", $"You swiped down on SpinningWheelGuess{imageId}", "OK");
        //                if (GameAudioOn)
        //                    SwipeDownSoundEffect!.Play();
        //                break;
        //        }

        //        // Update the corresponding CurrentGuess variable and image source
        //        switch (imageId)
        //        {
        //            case "1":
        //                CurrentGuess1 = currentGuess;
        //                SpinningWheelGuess1.Source = $"swipe{CurrentGuess1}.png";
        //                break;
        //            case "2":
        //                CurrentGuess2 = currentGuess;
        //                SpinningWheelGuess2.Source = $"swipe{CurrentGuess2}.png";
        //                break;
        //            case "3":
        //                CurrentGuess3 = currentGuess;
        //                SpinningWheelGuess3.Source = $"swipe{CurrentGuess3}.png";
        //                break;
        //        }
        //    }
        //}

        private async void MakeGuess_Click(object sender, EventArgs e)
        {
            //DisplayAlert("Guess", $"You guessed G1: {CurrentGuess1} - G2: {CurrentGuess2} - G3: {CurrentGuess3}", "OK");
            CurrentGuess1 = SpinningWheelGuess1.Position;
            CurrentGuess2 = SpinningWheelGuess2.Position;
            CurrentGuess3 = SpinningWheelGuess3.Position;

            string CurrentAnswer;

            CurrentAnswer = GradeGuess();

            //DisplayAlert("Guess Grade", $"Your guess grade: {CurrentAnswer}", "OK");

            RecordGuess(CurrentAnswer);

            // Construct the name of the control dynamically
            string highlightBorderName = $"Guess{GuessNumber}Border";

            // Find the control by name
            var highlightBorder = this.FindByName<Border>(highlightBorderName);

            // Set the color of the control
            if (highlightBorder != null)
            {
                highlightBorder.BackgroundColor = Colors.LightGray;
            }

            if (GuessNumber == 10 || CurrentAnswer == "FFF")
            {
                CurrentGuess1 = Answer1;                                
                SpinningWheelGuess1.Position = Answer1;

                CurrentGuess2 = Answer2;
                SpinningWheelGuess2.Position = Answer2;

                CurrentGuess3 = Answer3;
                SpinningWheelGuess3.Position = Answer3;
                bool DidYouWin = false;

                if (CurrentAnswer == "FFF")
                {
                    //MessageBox.Show("Congratulations!!.  You guessed the right numbers within 10 tries!!"); 
                    await DisplayAlert("Congratulations!!", $"You guessed the right numbers in {GuessNumber} tries!!", "OK");
                    //LayoutYouWon.Visibility = Visibility.Visible;
                    //Winner.Begin();
                    DidYouWin = true;
                    UpdateStats(GuessNumber, DidYouWin);
                }
                else
                {
                    await DisplayAlert("You lost!!", $"You DID NOT guess the right numbers within 10 tries!!", "OK");
                    //LayoutYouLost.Visibility = Visibility.Visible;
                    //Explode.Begin();
                    //VibrationDevice pfbVibrationonLoss = VibrationDevice.GetDefault();
                    //pfbVibrationonLoss.Vibrate(TimeSpan.FromSeconds(1));
                    DidYouWin = false;
                    UpdateStats(GuessNumber, DidYouWin);
                }
                
                await DisplayGameStats();

                GuessNumber = 10;
                GameOver = true;
                MakeGuess.IsEnabled = false;
            }

            GuessNumber++;

        }

        string GradeGuess()
        { // first grading logic
            string GradetoReturn = "???";

            // Default everyone to Bagel.
            int Grade = 0;
            Boolean OKtoGrade1 = true;
            Boolean OKtoGrade2 = true;
            Boolean OKtoGrade3 = true;
            Boolean A1OKtoUse = true;
            Boolean A2OKtoUse = true;
            Boolean A3OKtoUse = true;

            // Check for Fermi's to start.  They get precedence
            if (Answer1 == CurrentGuess1)
            { Grade += 4; OKtoGrade1 = false; A1OKtoUse = false; };
            if (Answer2 == CurrentGuess2)
            { Grade += 4; OKtoGrade2 = false; A2OKtoUse = false; };
            if (Answer3 == CurrentGuess3)
            { Grade += 4; OKtoGrade3 = false; A3OKtoUse = false; };

            if (Grade < 8) // if Grade is 8 or greater, there can be no Pico's
            {
                // Check for Pico's next.
                if (A1OKtoUse)
                    if (Answer1 == CurrentGuess2 & OKtoGrade2)
                    { Grade++; OKtoGrade2 = false; A1OKtoUse = false; }
                    else
                        if (Answer1 == CurrentGuess3 & OKtoGrade3)
                    { Grade++; OKtoGrade3 = false; A1OKtoUse = false; }

                if (A2OKtoUse)
                    if (Answer2 == CurrentGuess1 & OKtoGrade1)
                    { Grade++; OKtoGrade1 = false; A2OKtoUse = false; }
                    else
                        if (Answer2 == CurrentGuess3 & OKtoGrade3)
                    { Grade++; OKtoGrade3 = false; A2OKtoUse = false; }

                if (A3OKtoUse)
                    if (Answer3 == CurrentGuess2 & OKtoGrade2)
                        Grade++;
                    else
                        if (Answer3 == CurrentGuess1 & OKtoGrade1)
                        Grade++;
            } // end if less than 8

            switch (Grade)
            {
                case 0:  // ALL WRONG
                    GradetoReturn = "BBB";
                    break;
                case 1: // ONE RIGHT NUMBER, WRONG SPOT
                    GradetoReturn = "PBB";
                    break;
                case 2: // TWO RIGHT NUMBERS, BOTH WRONG SPOTS
                    GradetoReturn = "PPB";
                    break;
                case 3: // ALL RIGHT NUMBERS, ALL WRONG SPOTS
                    GradetoReturn = "PPP";
                    break;
                case 4: // ONE RIGHT NUMBER IN RIGHT SPOT
                    GradetoReturn = "FBB";
                    break;
                case 5: // ONE RIGHT NUMBER IN RIGHT SPOT, A 2ND RIGHT NUMBER BUT IN WRONG SPOT
                    GradetoReturn = "FPB";
                    break;
                case 6: // ALL RIGHT NUMBERS, ONE IN RIGHT SPOT
                    GradetoReturn = "FPP";
                    break;
                case 8: // TWO RIGHT NUMBERS, BOTH IN WRONG SPOTS
                    GradetoReturn = "FFB";
                    break;
                case 12: // ALL NUMBERS CORRECT
                    GradetoReturn = "FFF";
                    break;
                default:
                    GradetoReturn = "XXX";
                    break;

            }

            return GradetoReturn;

        }

        private void RecordGuess(string TheAnswer)
        {
            switch (GuessNumber)
            {
                case 1:
                    Guess1_1.Text = CurrentGuess1.ToString();
                    Guess1_2.Text = CurrentGuess2.ToString();
                    Guess1_3.Text = CurrentGuess3.ToString();
                    Guess1Grade.Text = TheAnswer;
                    break;
                case 2:
                    Guess2_1.Text = CurrentGuess1.ToString();
                    Guess2_2.Text = CurrentGuess2.ToString();
                    Guess2_3.Text = CurrentGuess3.ToString();
                    Guess2Grade.Text = TheAnswer;
                    break;
                case 3:
                    Guess3_1.Text = CurrentGuess1.ToString();
                    Guess3_2.Text = CurrentGuess2.ToString();
                    Guess3_3.Text = CurrentGuess3.ToString();
                    Guess3Grade.Text = TheAnswer;
                    break;
                case 4:
                    Guess4_1.Text = CurrentGuess1.ToString();
                    Guess4_2.Text = CurrentGuess2.ToString();
                    Guess4_3.Text = CurrentGuess3.ToString();
                    Guess4Grade.Text = TheAnswer;
                    break;
                case 5:
                    Guess5_1.Text = CurrentGuess1.ToString();
                    Guess5_2.Text = CurrentGuess2.ToString();
                    Guess5_3.Text = CurrentGuess3.ToString();
                    Guess5Grade.Text = TheAnswer;
                    break;
                case 6:
                    Guess6_1.Text = CurrentGuess1.ToString();
                    Guess6_2.Text = CurrentGuess2.ToString();
                    Guess6_3.Text = CurrentGuess3.ToString();
                    Guess6Grade.Text = TheAnswer;
                    break;
                case 7:
                    Guess7_1.Text = CurrentGuess1.ToString();
                    Guess7_2.Text = CurrentGuess2.ToString();
                    Guess7_3.Text = CurrentGuess3.ToString();
                    Guess7Grade.Text = TheAnswer;
                    break;
                case 8:
                    Guess8_1.Text = CurrentGuess1.ToString();
                    Guess8_2.Text = CurrentGuess2.ToString();
                    Guess8_3.Text = CurrentGuess3.ToString();
                    Guess8Grade.Text = TheAnswer;
                    break;
                case 9:
                    Guess9_1.Text = CurrentGuess1.ToString();
                    Guess9_2.Text = CurrentGuess2.ToString();
                    Guess9_3.Text = CurrentGuess3.ToString();
                    Guess9Grade.Text = TheAnswer;
                    break;
                case 10:
                    Guess10_1.Text = CurrentGuess1.ToString();
                    Guess10_2.Text = CurrentGuess2.ToString();
                    Guess10_3.Text = CurrentGuess3.ToString();
                    Guess10Grade.Text = TheAnswer;
                    break;
                case 11:                    
                    DisplayAlert("Game Over!", "Please Try a new game or exit.Thank you!!", "OK");
                    break;
                case 12:                    
                    DisplayAlert("Opps!", "You pressed the Make guess button but the game is over!!", "OK");
                    break;
                case 13:                    
                    DisplayAlert("Again?!?", "You can keep pressing but it won't help!!", "OK");
                    GameOver = true;
                    MakeGuess.IsEnabled = false;
                    break;
                default:                    
                    DisplayAlert("Boo in Case!", "Improbability error.  How did you get here??", "OK");
                    break;
            }
        }


        private void UpdateStats(int guessNumber, bool didYouWin)
        {
            // TODO: Implement the logic to update game statistics            
            int statsGamesPlayed = Preferences.Default.Get("Games", 0);
            statsGamesPlayed++;
            Preferences.Default.Set("Games", statsGamesPlayed);          
            
            if (didYouWin)
            {
                int statsGamesWon = Preferences.Default.Get("Wins", 0);
                statsGamesWon++;
                Preferences.Default.Set("Wins", statsGamesWon);
            }
            else
            {
                int statsGamesLost = Preferences.Default.Get("Losses", 0);
                statsGamesLost++;
                Preferences.Default.Set("Losses", statsGamesLost);
            }


        }
        private async Task DisplayGameStats()
        {
            int statsGamesPlayed = Preferences.Default.Get("Games", 0);
            int statsGamesWon = Preferences.Default.Get("Wins", 0);
            int statsGamesLost = Preferences.Default.Get("Losses", 0);

            string message = $"Games Played: {statsGamesPlayed}\nGames Won: {statsGamesWon}\nGames Lost: {statsGamesLost}";
            await DisplayAlert("Game Stats", message, "OK");
            
        }

    }  // end class MainPage

} // End Namespace
