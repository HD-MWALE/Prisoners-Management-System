using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System
{
    internal class ColorBuilder
    {
        private static Color GetNearestLeftColor(Color c)
        {
            if ((c.R <= c.G) & (c.R <= c.B))
            {
                return Color.FromArgb(0, c.G, c.B);
            }
            if ((c.G <= c.R) & (c.G <= c.B))
            {
                return Color.FromArgb(c.R, 0, c.B);
            }
            if ((c.B <= c.G) & (c.B <= c.R))
            {
                return Color.FromArgb(c.R, c.G, 0);
            }
            return c;
        }

        private static Color GetNearestRigthColor(Color c)
        {
            if ((c.R >= c.G) & (c.R >= c.B))
            {
                return Color.FromArgb(255, c.G, c.B);
            }
            if ((c.G >= c.R) & (c.G >= c.B))
            {
                return Color.FromArgb(c.R, 255, c.B);
            }
            if ((c.B >= c.G) & (c.B >= c.R))
            {
                return Color.FromArgb(c.R, c.G, 255);
            }
            return c;
        }

        public static Color[] GetColorDiagram(List<ControlPoint> points)
        {
            Color[] colors = new Color[256];
            points.Sort(new PointsComparer());

            for (int i = 0; i < 256; i++)
            {
                ControlPoint leftColor = new ControlPoint(0, GetNearestLeftColor(points[0].Color)); //new ControlPoint(0, Color.Black);
                ControlPoint rightColor = new ControlPoint(255, GetNearestRigthColor(points[points.Count - 1].Color));
                if (i < points[0].Level)
                {
                    rightColor = points[0];
                }
                if (i > points[points.Count - 1].Level)
                {
                    leftColor = points[points.Count - 1];
                }
                else
                {
                    for (int j = 0; j < points.Count - 1; j++)
                    {
                        if ((points[j].Level <= i) & (points[j + 1].Level > i))
                        {
                            leftColor = points[j];
                            rightColor = points[j + 1];
                        }
                    }
                }
                if ((rightColor.Level - leftColor.Level) != 0)
                {
                    double koef = (double)(i - leftColor.Level) / (double)(rightColor.Level - leftColor.Level);
                    int r = leftColor.Color.R + (int)(koef * (rightColor.Color.R - leftColor.Color.R));
                    int g = leftColor.Color.G + (int)(koef * (rightColor.Color.G - leftColor.Color.G));
                    int b = leftColor.Color.B + (int)(koef * (rightColor.Color.B - leftColor.Color.B));
                    colors[i] = Color.FromArgb(r, g, b);
                }
                else
                {
                    colors[i] = leftColor.Color;
                }

            }

            return colors;
        }
    }
    public struct ControlPoint
    {
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public ControlPoint(int level, Color color)
        {
            this.color = color;
            this.level = level;
        }
        public override string ToString()
        {
            return "Level: " + level.ToString() + "; Color: " + color.ToString();
        }
    }
    public class PointsComparer : IComparer<ControlPoint>
    {
        #region IComparer<ControlPoint> Members
        public int Compare(ControlPoint x, ControlPoint y)
        {
            if (x.Level > y.Level)
            {
                return 1;
            }
            if (x.Level < y.Level)
            {
                return -1;
            }
            return 0;
        }
        #endregion
    }
    public class Grayscale
    {
        private static double red = 0.11;

        public static double Red
        {
            get { return Grayscale.red; }
            set { Grayscale.red = value; }
        }
        private static double green = 0.59;

        public static double Green
        {
            get { return Grayscale.green; }
            set { Grayscale.green = value; }
        }
        private static double blue = 0.30;

        public static double Blue
        {
            get { return Grayscale.blue; }
            set { Grayscale.blue = value; }
        }

        public static Bitmap GetGrayScale(Bitmap source)
        {
            Bitmap gray = new Bitmap(source);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    //Lum = G * 0.59 + B * 0.30 + R * 0.11;
                    int g = (int)((c.R * red + c.G * green + c.B * blue));
                    gray.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }
            return gray;
        }

        public static string XMLString
        {
            get
            {
                return "<GrayscaleSettings><R>" + red.ToString() + "</R><G>" + green.ToString() +
                        "</G><B>" + blue.ToString() + "</B></GrayscaleSettings>";
            }
        }
    }
}
