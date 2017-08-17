using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            
        }
    }
}
