using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSkiaSharpDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HandlingTouchPage : ContentPage
    {
        public HandlingTouchPage()
        {
            InitializeComponent();
        }

        private void SkCanvasView_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            if (e.ActionType == SkiaSharp.Views.Forms.SKTouchAction.Pressed)
            {
                _lastTouchPoint = e.Location;
                e.Handled = true;
            }

            _lastTouchPoint = e.Location;

            SkCanvasView.InvalidateSurface();
        }

        private SKPoint _lastTouchPoint = new SKPoint();
        private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // Init skcanvas
            SKImageInfo skImageInfo = e.Info;
            SKSurface skSurface = e.Surface;
            SKCanvas skCanvas = skSurface.Canvas;

            skCanvas.Clear();
            
            using (SKPaint paintTouchPoint = new SKPaint())
            {
                paintTouchPoint.Style = SKPaintStyle.Fill;
                paintTouchPoint.Color = SKColors.Red;
                paintTouchPoint.IsDither = true;
                skCanvas.DrawCircle(
                    _lastTouchPoint.X,
                    _lastTouchPoint.Y,
                    50, paintTouchPoint); // 45
            }

        }

    }
}