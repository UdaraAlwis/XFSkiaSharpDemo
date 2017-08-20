using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XFSkiaSharpDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void DrawShapesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DrawingShapesPage());
        }

        private void HandlingTouchInteractionsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HandlingTouchPage());
        }

        private void HandlingImagesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HandlingImagesPage());
        }

        private void RenderingAnimationsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RenderingAnimationsPage());
        }
    }
}
