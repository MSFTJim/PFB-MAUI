//using static Android.Gestures.GestureOverlayView;
using Microsoft.Maui.Controls;
using System;

namespace PFBv01
{
    public partial class MainPage : ContentPage
    {
        private bool[] checkBoxStates = new bool[10];

        public MainPage()
        {
            InitializeComponent();
        }

        #region CheckBox DoubleTap      

        
        private void OnCheckBoxTapped(object sender, EventArgs e)
        {
            if (sender is Image checkBox)
            {
                int index = int.Parse(checkBox.StyleId);
                checkBoxStates[index] = !checkBoxStates[index];

                checkBox.Source = checkBoxStates[index] ? $"checked{index}.png" : $"unchecked{index}.png";
            }
        }
        #endregion  // checkbox doubletap

    }

}
