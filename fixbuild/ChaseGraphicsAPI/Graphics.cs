using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System;

namespace fixbuild.ChaseGraphicsAPI
{

    class Graphics
    {
        public static bool THE;
        private Canvas canvas;
        private Pen pen;
        private MouseState mouseState;
        private UInt32 px, py;
        private List<Tuple<Sys.Graphics.Point, Color>> savedPixels;
        public Graphics()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Black);
            pen = new Pen(Color.White);
            mouseState = MouseState.None;
            px = 3;
            py = 3;
            savedPixels = new List<Tuple<Sys.Graphics.Point, Color>>();
            MouseManager.ScreenHeight = (UInt32)canvas.Mode.Rows;
            MouseManager.ScreenWidth = (UInt32)canvas.Mode.Columns;
            for (int i = 0; i <= 30; i++)
            {
                canvas.DrawRectangle(pen, 0, 0, i, i);
                pen.Color = Color.Blue;
            }
            pen.Color = Color.White;
            /* A PaleVioletRed rectangle */


        }
        public void MouseHandler()
        {

            px = MouseManager.X;
            py = MouseManager.Y;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X, (int)MouseManager.Y),
                    new Sys.Graphics.Point((int)MouseManager.X-1, (int)MouseManager.Y-1),
                    new Sys.Graphics.Point((int)MouseManager.X-1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y-1),
            };
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
            }
            if (THE == true)
            {
                for (int i = 0; i <= 350; i++)
                {
                    canvas.DrawRectangle(pen, i, i, i, i);
                    pen.Color = Color.Blue;
                }
                pen.Color = Color.White;
            }
        }
        }
    }

