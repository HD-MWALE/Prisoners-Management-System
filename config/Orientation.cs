using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.config
{
    internal class Orientation
    {
        // get location
        public Point GetLocation(Size app, Size popup, Point applocation)
        {
            return new Point(
                applocation.X + ((app.Width / 2) - (popup.Width / 2)),
                applocation.Y + ((app.Height / 2) - (popup.Height / 2)));
        }
        // loader location
        public Point LoaderLocation(Size app, Point applocation)
        {
            return new Point(
                applocation.X + ((app.Width / 2)),
                applocation.Y + ((app.Height / 2)));
        }
    }
}
