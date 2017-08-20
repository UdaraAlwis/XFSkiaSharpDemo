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
    public partial class DrawingShapesPage : ContentPage
    {
        List<string> shapesList = new List<string>
            {
                "Line",
                "Circle (Filled)",
                "Circle (Unfilled)",
                "Arc",
                "Ellipse",
                "Ellipse",
                "Ellipse",
                "Ellipse",
                "Ellipse",
            };

        string selectedShape;

        public DrawingShapesPage()
        {
            InitializeComponent();
            
            selectedShape = shapesList[0];
            DrawingShapeNameLabel.Text = $"Drawing {selectedShape}";
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


            if (selectedShape == shapesList[0])
            {
                Draw_Line(skCanvas);
            }
            else if (selectedShape == shapesList[1])
            {
                Draw_CircleFilled(skCanvas);
            }
            else if (selectedShape == shapesList[2])
            {
                Draw_CircleUnfilled(skCanvas);
            }
            else if (selectedShape == shapesList[3])
            {
                Draw_Arc(skCanvas);
            }
            else if (selectedShape == shapesList[4])
            {
                Draw_Ellipse(skCanvas);
            }
        }

        private async void PickShapeToDrawButton_Clicked(object sender, EventArgs e)
        {
            var selection = await DisplayActionSheet("Pick a Shape", null, "Cancel", shapesList.ToArray());

            if (selection != null && selection != "Cancel")
            {
                selectedShape = selection;
                DrawingShapeNameLabel.Text = $"Drawing {selectedShape}";
                SkCanvasView.InvalidateSurface();
            }
        }

        private void Draw_Line(SKCanvas skCanvas)
        {
            // Drawing Stroke
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Red;
                skPaint.StrokeWidth = 10;
                skPaint.StrokeCap = SKStrokeCap.Round;

                skCanvas.DrawLine(-50, -50, 50, 50, skPaint);
            }
        }

        private void Draw_CircleFilled(SKCanvas skCanvas)
        {
            // Drawing a Circle
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Blue;
                skPaint.StrokeWidth = 10;

                skCanvas.DrawCircle(0, 0, 50, skPaint);
            }
        }

        private void Draw_CircleUnfilled(SKCanvas skCanvas)
        {
            // Drawing a Circle
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Red;
                skPaint.StrokeWidth = 10;

                skCanvas.DrawCircle(0, 0, 70, skPaint);
            }
        }

        private void Draw_Ellipse(SKCanvas skCanvas)
        {
            // Draw Ellipse
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

            skCanvas.DrawOval(skRectangle, skPaint);
        }

        private void Draw_Arc(SKCanvas skCanvas)
        {
            // Draw Arc
            SKPaint skPaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.BlueViolet,
                StrokeWidth = 10,
                IsAntialias = true,
            };

            SKRect skRectangle = new SKRect();
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