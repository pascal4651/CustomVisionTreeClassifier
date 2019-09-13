using System;
using System.Drawing;

namespace CustomVisionTreeClassifier
{
    class RectangleBox
    {
        public double Left { get; private set; }
        public double Top { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public RectangleBox(double left, double top, double width, double height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public bool Contains(Image image, int x, int y)
        {
            Rectangle rectangle = new Rectangle((int)Math.Round(image.Width * Left), (int)Math.Round(image.Height * Top), 
                (int)Math.Round(image.Width * Width), (int)Math.Round(image.Height * Height));
            return rectangle.Contains(x, y);
        }
    }
}
