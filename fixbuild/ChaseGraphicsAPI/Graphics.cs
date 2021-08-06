﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System;
using fixbuild.ChaseGraphicsAPI.GUI;
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
        public List<Button> items = new List<Button>();
        public Button btnApps, btnFiles, btnSettings, btnTerminal, btnLogoff, btnRestart, btnOff, btnCLI, btnAbout;
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
            btnApps = new Button(x + 6, y + 6, "Applications       >");
            btnApps.width = width - 12; btnApps.height = 24;
            btnApps.style.SIZE_BORDER = 0;
            btnApps.textAlign = TextAlign.left;
            items.Add(btnApps);

            // file browser button
            btnFiles = new Button(x + 6, btnApps.y + btnApps.height, "File Browser");
            btnFiles.width = width - 12; btnFiles.height = 24;
            btnFiles.style.SIZE_BORDER = 0;
            btnFiles.textAlign = TextAlign.left;
            items.Add(btnFiles);

            // settings button
            btnSettings = new Button(x + 6, btnFiles.y + btnFiles.height, "Settings");
            btnSettings.width = width - 12; btnSettings.height = 24;
            btnSettings.style.SIZE_BORDER = 0;
            btnSettings.textAlign = TextAlign.left;
            items.Add(btnSettings);

            // terminal button
            btnTerminal = new Button(x + 6, btnSettings.y + btnSettings.height, "Terminal");
            btnTerminal.width = width - 12; btnTerminal.height = 24;
            btnTerminal.style.SIZE_BORDER = 0;
            btnTerminal.textAlign = TextAlign.left;
            items.Add(btnTerminal);

            // about button
            btnAbout = new Button(x + 6, btnTerminal.y + btnTerminal.height, "About...");
            btnAbout.width = width - 12; btnAbout.height = 24;
            btnAbout.style.SIZE_BORDER = 0;
            btnAbout.textAlign = TextAlign.left;
            items.Add(btnAbout);

            // cli button
            btnCLI = new Button(x + 6, btnAbout.y + btnAbout.height, "Return to CLI");
            btnCLI.width = width - 12; btnCLI.height = 24;
            btnCLI.style.SIZE_BORDER = 0;
            btnCLI.textAlign = TextAlign.left;
            items.Add(btnCLI);

            // log off button
            btnLogoff = new Button(x + 6, btnCLI.y + btnCLI.height, "Log Off...");
            btnLogoff.width = width - 12; btnLogoff.height = 24;
            btnLogoff.style.SIZE_BORDER = 0;
            btnLogoff.textAlign = TextAlign.left;
            items.Add(btnLogoff);

            // restart button
            btnRestart = new Button(x + 6, btnLogoff.y + btnLogoff.height, "Restart");
            btnRestart.width = width - 12; btnRestart.height = 24;
            btnRestart.style.SIZE_BORDER = 0;
            btnRestart.textAlign = TextAlign.left;
            items.Add(btnRestart);

            // shut down button
            btnOff = new Button(x + 6, btnRestart.y + btnRestart.height, "Shut Down");
            btnOff.width = width - 12; btnOff.height = 24;
            btnOff.style.SIZE_BORDER = 0;
            btnOff.textAlign = TextAlign.left;
            items.Add(btnOff);
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

