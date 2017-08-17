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

            //// Drawing Stroke
            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Stroke;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Red;
            //    skPaint.StrokeWidth = 10;
            //    skPaint.StrokeCap = SKStrokeCap.Round;

            //    skCanvas.DrawLine(-50, -50, 50, 50, skPaint);
            //}


            //// Drawing a Circle
            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Fill;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Blue;
            //    skPaint.StrokeWidth = 10;

            //    skCanvas.DrawCircle(0, 0, 70, skPaint);
            //}

            //// Drawing a Circle Stroke
            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Stroke;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Red;
            //    skPaint.StrokeWidth = 10;

            //    skCanvas.DrawCircle(0, 0, 70, skPaint);
            //}

            
            // Draw Arc / Ellipse
            SKPaint skPaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.OrangeRed,
                StrokeWidth = 10,
                IsAntialias = true,
            };

            SKRect skRectangle = new SKRect();
            skRectangle.Size = new SKSize(150, 100);
            skRectangle.Location = new SKPoint(-150f / 2, -100f / 2);

            //skCanvas.DrawOval(skRectangle, skPaint);

            // Draw Arc
            skPaint.Color = SKColors.BlueViolet;
            skRectangle.Size = new SKSize(150, 150);
            skRectangle.Location = new SKPoint(-150f / 2, -150f / 2);

            float startAngle = -90;
            float sweepAngle = 230; // (75 / 100) * 360

            SKPath skPath = new SKPath();
            skPath.AddArc(skRectangle, startAngle, sweepAngle);

            skCanvas.DrawPath(skPath, skPaint);
        }
    }
}
