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
                "Text",
                "Rectangle",
                "Triangle",
                "Random",
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
            else if (selectedShape == shapesList[5])
            {
                Draw_Text(skCanvas);
            }
            else if (selectedShape == shapesList[6])
            {
                Draw_Rectangle(skCanvas);
            }
            else if (selectedShape == shapesList[7])
            {
                Draw_Triangle(skCanvas);
            }
            else if (selectedShape == shapesList[8])
            {
                Draw_RandomShape(skCanvas);
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

        private void Draw_Text(SKCanvas skCanvas)
        {
            // Drawing Text
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.DarkSlateBlue;
                skPaint.TextAlign = SKTextAlign.Center;
                skPaint.TextSize = 20;

                skCanvas.DrawText("Hello World!", 0, 0, skPaint);
            }
        }

        private void Draw_Rectangle(SKCanvas skCanvas)
        {
            // Draw Rectangle
            SKPaint skPaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.DeepPink,
                StrokeWidth = 10,
                IsAntialias = true,
            };

            SKRect skRectangle = new SKRect();
            skRectangle.Size = new SKSize(100, 100);
            skRectangle.Location = new SKPoint(-100f / 2, -100f / 2);

            skCanvas.DrawRect(skRectangle, skPaint);
        }

        private void Draw_Triangle(SKCanvas skCanvas)
        {
            // Draw Rectangle
            SKPaint skPaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.DeepSkyBlue,
                StrokeWidth = 10,
                IsAntialias = true,
                StrokeCap = SKStrokeCap.Round
            };

            SKPoint[] skPointsList = new SKPoint[]
            {
                // Path 1
                new SKPoint(+50,0),
                new SKPoint(0,-70),

                // path 2
                new SKPoint(0,-70),
                new SKPoint(-50,0),

                // path 3
                new SKPoint(-50,0),
                new SKPoint(+50,0),
            };

            skCanvas.DrawPoints(SKPointMode.Lines, skPointsList, skPaint);
        }

        private void Draw_RandomShape(SKCanvas skCanvas)
        {
            // Draw any kind of Shape
            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 10,
                IsAntialias = true,
            };

            // Create the path
            SKPath path = new SKPath();

            // Define the drawing path points
            path.MoveTo(+50, 0); // start point
            path.LineTo(+50, -50); // first move to this point
            path.LineTo(-30, -80); // move to this point
            path.LineTo(-70, 0); // then move to this point
            path.LineTo(-10, +90); // then move to this point
            path.LineTo(+50, 0); // end point

            path.Close(); // make sure path is closed
            // Fill and stroke the path
            skCanvas.DrawPath(path, strokePaint);
        }
    }
}