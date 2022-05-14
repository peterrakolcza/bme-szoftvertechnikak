using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signals
{
    public partial class GraphicsSignalView : UserControl, IView
    {
        // A mejelenítendő dokumentum tárolása
        readonly SignalDocument Document;

        // Skálázó érték
        private readonly float _pixelPerSec = 150;
        private readonly float _pixelPerValue = 4;

        // Nagyítás mértéke
        private double _userZoom = 1;

        // Pont mérete
        private const float DotSize = 3;
        private const float DotOrigo = DotSize / 2;

        /// <summary>
        /// A view sorszáma
        /// </summary>
        private int viewNumber;

        /// <summary>
        /// A view sorszáma
        /// </summary>
        // IView interfész függvényeinek megvalósítása
        public int ViewNumber { get; set; }

        public GraphicsSignalView()
        {
            InitializeComponent();
        }

        public GraphicsSignalView(SignalDocument document)
        {
            InitializeComponent();
            this.Document = document;
        }

        public Document GetDocument()
        {
            return Document;
        }

        // Grafikon kirajzolása
        protected override void OnPaint(PaintEventArgs e)
        {
            // Ősosztály OnPaint eseménye
            base.OnPaint(e);

            // Tengely beállítása
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = DashStyle.Dot; // Pontozott vonal stílus beállítása
            pen.EndCap = LineCap.ArrowAnchor; // Nyíl rajzolása

            // Y tengely rajzolása
            if (AutoScrollPosition.X == 0)
                e.Graphics.DrawLine(pen, 2, ClientSize.Height, 2, 0);

            // X tengely mindig középen legyen
            int xCenter = Math.Max(ClientSize.Height, AutoScrollMinSize.Height) / 2;

            // X tengely rajzolása 
            e.Graphics.DrawLine(pen, 0, xCenter, Math.Max(ClientSize.Width, AutoScrollMinSize.Width), xCenter);

            int x = 0; // Jelenlegi X koordináta
            int lastX = 0; // Előző X koordináta
            int lastY = 0;// Előző Y koordináta

            // Az értékek pen-je
            SignalValue lastSignalValue = null;
            Pen penValues = new Pen(Color.Red, 1);
            penValues.DashStyle = DashStyle.Solid;

            // Az értékeket kirajzoljuk
            foreach (SignalValue value in Document.Signals)
            {

                // Y koordináta számolása
                int y = (int)(-1 * value.Value * _pixelPerValue * _userZoom) + (ClientSize.Height / 2);
                // Ha nincs utolsó érték
                if (lastSignalValue == null)
                {
                    // Első Pont rajzolása
                    e.Graphics.DrawRectangle(penValues, -DotOrigo, y - DotOrigo, DotSize, DotSize);
                }

                else
                {
                    // Időkülönbség
                    TimeSpan dateTimeSpan = value.TimeStamp - lastSignalValue.TimeStamp;
                    x += (int)(dateTimeSpan.Ticks / 10000000 * _pixelPerSec * _userZoom);
                    e.Graphics.DrawLine(penValues, lastX, lastY, x, y); // Vonal rajzolása
                    e.Graphics.DrawRectangle(penValues, x - DotOrigo, y - DotOrigo, DotSize, DotSize); // Pont rajzolása
                }
                // Előző érték beállítása
                lastSignalValue = value;
                // Előző koordináták beállítása
                lastX = x;
                lastY = y;

            }

        }

        private void bZoomIn_Click(object sender, EventArgs e)
        {
            // Zoom növelése
            _userZoom = _userZoom * 1.2;
            // Újrarajzolás
            Invalidate();
        }

        private void bZoomOut_Click(object sender, EventArgs e)
        {
            // Zoom csökkentése
            _userZoom = _userZoom / 1.2;
            // Újrarajzolás
            Invalidate();
        }
    }
}
