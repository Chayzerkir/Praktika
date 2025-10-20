using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5._1._1
{
    public partial class MainWindow : Window
    {
        private string selectedShape = "";
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawLine_Click(object sender, RoutedEventArgs e) => selectedShape = "Line";
        private void DrawCircle_Click(object sender, RoutedEventArgs e) => selectedShape = "Circle";
        private void DrawSquare_Click(object sender, RoutedEventArgs e) => selectedShape = "Square";
        private void ClearCanvas_Click(object sender, RoutedEventArgs e) => DrawingCanvas.Children.Clear();

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(DrawingCanvas);
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point endPoint = e.GetPosition(DrawingCanvas);
            Shape shape = null;

            switch (selectedShape)
            {
                case "Line":
                    shape = new Line { X1 = startPoint.X, Y1 = startPoint.Y, X2 = endPoint.X, Y2 = endPoint.Y, Stroke = System.Windows.Media.Brushes.Black, StrokeThickness = 2 };
                    break;
                case "Circle":
                    double radius = (endPoint - startPoint).Length / 2;
                    shape = new Ellipse { Width = radius * 2, Height = radius * 2, Stroke = System.Windows.Media.Brushes.Black, StrokeThickness = 2 };
                    Canvas.SetLeft(shape, startPoint.X - radius);
                    Canvas.SetTop(shape, startPoint.Y - radius);
                    break;
                case "Square":
                    double side = System.Math.Min(System.Math.Abs(endPoint.X - startPoint.X), System.Math.Abs(endPoint.Y - startPoint.Y));
                    shape = new Rectangle { Width = side, Height = side, Stroke = System.Windows.Media.Brushes.Black, StrokeThickness = 2 };
                    Canvas.SetLeft(shape, System.Math.Min(startPoint.X, endPoint.X));
                    Canvas.SetTop(shape, System.Math.Min(startPoint.Y, endPoint.Y));
                    break;
            }

            if (shape != null) DrawingCanvas.Children.Add(shape);
        }
    }
}
