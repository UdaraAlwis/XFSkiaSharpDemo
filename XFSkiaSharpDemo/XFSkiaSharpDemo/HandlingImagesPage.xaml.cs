using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSkiaSharpDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HandlingImagesPage : ContentPage
    {
        List<string> imageEffectsList = new List<string>
            {
                "Default Image (No Effect)",
                "Blur Effect",
            };

        string selectedImageEffect;

        public HandlingImagesPage()
        {
            InitializeComponent();

            selectedImageEffect = imageEffectsList[0];
            EffectNameLabel.Text = $"{selectedImageEffect}";
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
            
            string resourceID = "XFSkiaSharpDemo.Resources.xamarinmonkey.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            SKBitmap skBitmap;
            using (Stream stream 
                    = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream
                    = new SKManagedStream(stream))
            {
                skBitmap = SKBitmap.Decode(skStream);
            }

            if (selectedImageEffect == imageEffectsList[0])
            {
                Draw_ImageDefault(skCanvas, skBitmap);
            }
            else if (selectedImageEffect == imageEffectsList[1])
            {
                Draw_ImageBlur(skCanvas, skBitmap);
            }
        }

        private void Draw_ImageBlur(SKCanvas skCanvas, SKBitmap skBitmap)
        {
            // Image Filter
            var filter = SKImageFilter.CreateBlur(5, 5);
            var skPaint = new SKPaint();
            skPaint.ImageFilter = filter;

            skCanvas.DrawBitmap(skBitmap,
                SKRect.Create(-50, -50, 100, 100), skPaint);
        }

        private void Draw_ImageDefault(SKCanvas skCanvas, SKBitmap skBitmap)
        {
            skCanvas.DrawBitmap(skBitmap,
                SKRect.Create(-50, -50, 100, 100), null);
        }

        private async void PickImageEffectButton_Clicked(object sender, EventArgs e)
        {
            var selection = await DisplayActionSheet("Pick an Image Effect", null, "Cancel", imageEffectsList.ToArray());

            if (selection != null && selection != "Cancel")
            {
                selectedImageEffect = selection;
                EffectNameLabel.Text = $"{selectedImageEffect}";
                SkCanvasView.InvalidateSurface();
            }
        }
    }
}