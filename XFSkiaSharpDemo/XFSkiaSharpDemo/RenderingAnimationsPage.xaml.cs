using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSkiaSharpDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenderingAnimationsPage : ContentPage
    {
        public RenderingAnimationsPage()
        {
            InitializeComponent();
        }

        Stopwatch stopwatch = new Stopwatch();
        bool pageIsActive;
        float t;
        const double cycleTime = 1000; // in milliseconds

        private void InitAnimation()
        {
            pageIsActive = true;
            stopwatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(33), () =>
            {
                // calculate t for current tick with regards to cycletime
                t = (float)(stopwatch.Elapsed.TotalMilliseconds % cycleTime / cycleTime);
                SkCanvasView.InvalidateSurface();

                if (!pageIsActive)
                {
                    stopwatch.Stop();
                }
                return pageIsActive;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitAnimation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsActive = false;
        }

        private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // Init skcanvas
            SKImageInfo skImageInfo = e.Info;
            SKSurface skSurface = e.Surface;
            SKCanvas skCanvas = skSurface.Canvas;

            skCanvas.Clear(SKColors.White);

            var skCanvasWidth = skImageInfo.Width;
            var skCanvasheight = skImageInfo.Height;

            // move canvas X,Y to center of screen
            skCanvas.Translate((float)skCanvasWidth / 2, (float)skCanvasheight / 2);
            // set the pixel scale of the canvas
            skCanvas.Scale(skCanvasWidth / 200f);
            
            // get 
            float radius = 70 * t;

            // Drawing a Circle Stroke
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Red;
                skPaint.StrokeWidth = 10;

                skCanvas.DrawCircle(0, 0, radius, skPaint);
            }
        }
    }
}