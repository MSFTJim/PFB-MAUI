//using static Android.Gestures.GestureOverlayView;
using Microsoft.Maui.Controls;
using System;

namespace PFBv01
{
    public partial class MainPage : ContentPage
    {
        private bool CheckBox0Checked = false;

        public MainPage()
        {
            InitializeComponent();
        }

        #region CheckBox DoubleTap      

        private void OnCheckBox0DoubleTapped(object sender, EventArgs e)
        {
            if (CheckBox0Checked)
            {
                CheckBox0.Source = "unchecked0.png";
                CheckBox0Checked = false;
            }
            else
            {
                CheckBox0.Source = "checked0.png";
                CheckBox0Checked = true;
            }
        }
#endregion  // checkbox doubletap

    }

}
