namespace MultiThreadedApp
{
    public partial class MainForm_IMO7KC : Form
    {
        delegate void BikeAction(Button bike);

        private ManualResetEvent bicycleOnStart = new ManualResetEvent(false);
        private AutoResetEvent bicycleOnDepo = new AutoResetEvent(false);

        private long distance;
        private object lockObject = new object();
        private int startPoz;

        public MainForm_IMO7KC()
        {
            InitializeComponent();

            // Kezdõállapot elmentése
            startPoz = bBike1.Left;
        }

        public void BikeThreadFunction(object param)
        {
            try
            {

                Button bike = (Button)param;
                bike.Tag = Thread.CurrentThread;
                while (bike.Left < pStart.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                // Összes bringa bevárása
                if (bicycleOnStart.WaitOne())
                {
                    while (bike.Left < pDepo.Left)//mozgatása a depo mezõig ha még nincs ott
                    {
                        MoveBike(bike);
                        Thread.Sleep(100);
                    }
                }

                // Mindegyik bringa külön indul, nem jelzett állapotba állítja
                bicycleOnDepo.Reset();

                if (bicycleOnDepo.WaitOne())
                {
                    while (bike.Left < pTarget.Left)
                    {
                        MoveBike(bike);
                        Thread.Sleep(100);
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                // Lenyeljük, de szigorúan kizárólag a ThreadInterruptedException-t.
                // Ha nem kezelnénk az Interrupt hatására a szállfüggvényünk
                // és az alkalmazásunk is csúnyán "elszállna".
            }
        }

        Random random = new Random();
        public void MoveBike(Button bike)
        {
            // Szálbiztosság
            if (InvokeRequired)
            {
                Invoke(new BikeAction(MoveBike), bike);
            }
            else
            {
                int dist= random.Next(3, 9);
                bike.Left += dist;
                increasePixels(dist);
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            startBike(bBike1);
            startBike(bBike2);
            startBike(bBike3);
        }

        private void startBike(Button bBike)
        {
            Thread t = new Thread(BikeThreadFunction);
            bBike.Tag = t;
            t.IsBackground = true; // Ne blokkolja a szál a processz megszûnését
            t.Start(bBike);
        }

        private void bStep_Click(object sender, EventArgs e)
        {
            //Ha mindhárom bringa a Start panelen van
            if (bBike1.Left >= pStart.Left && bBike2.Left >= pStart.Left && bBike3.Left >= pStart.Left)
            {
                // A jelzõ flag set beállítása
                bicycleOnStart.Set();
            }
        }

        private void bStep2_Click(object sender, EventArgs e)
        {
            bicycleOnDepo.Set();
        }

        void increasePixels(long step)
        {
            // Távolság szálbiztos növelése
            lock (lockObject)
            {
                distance += step;
            }
        }

        long getPixels()
        {
            // Távolság kiolvasása
            lock (lockObject)
            {
                return distance;
            }
        }

        private void bDistance_Click(object sender, EventArgs e)
        {
            bDistance.Text = getPixels().ToString() + " km";
        }

        private void bBike_Click(object sender, EventArgs e)
        {
            Button bike = (Button)sender;
            Thread thread = (Thread)bike.Tag;
            // Ha még nem indítottuk ez a szálat, ez null.
            if (thread == null)
                return;
            // Megszakítjuk a szál várakozását, ez az adott szálban egy
            // ThreadInterruptedException-t fog kiváltani
            // A függvény leírásáról részleteket az elõadás anyagaiban találsz
            thread.Interrupt();

            bike.Left = startPoz;
            bicycleOnStart.Reset();
            // Megvárjuk, amíg a szál leáll
            thread.Join();
        }
    }
}