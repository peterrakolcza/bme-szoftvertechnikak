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

            // Kezd��llapot elment�se
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

                // �sszes bringa bev�r�sa
                if (bicycleOnStart.WaitOne())
                {
                    while (bike.Left < pDepo.Left)//mozgat�sa a depo mez�ig ha m�g nincs ott
                    {
                        MoveBike(bike);
                        Thread.Sleep(100);
                    }
                }

                // Mindegyik bringa k�l�n indul, nem jelzett �llapotba �ll�tja
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
                // Lenyelj�k, de szigor�an kiz�r�lag a ThreadInterruptedException-t.
                // Ha nem kezeln�nk az Interrupt hat�s�ra a sz�llf�ggv�ny�nk
                // �s az alkalmaz�sunk is cs�ny�n "elsz�llna".
            }
        }

        Random random = new Random();
        public void MoveBike(Button bike)
        {
            // Sz�lbiztoss�g
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
            t.IsBackground = true; // Ne blokkolja a sz�l a processz megsz�n�s�t
            t.Start(bBike);
        }

        private void bStep_Click(object sender, EventArgs e)
        {
            //Ha mindh�rom bringa a Start panelen van
            if (bBike1.Left >= pStart.Left && bBike2.Left >= pStart.Left && bBike3.Left >= pStart.Left)
            {
                // A jelz� flag set be�ll�t�sa
                bicycleOnStart.Set();
            }
        }

        private void bStep2_Click(object sender, EventArgs e)
        {
            bicycleOnDepo.Set();
        }

        void increasePixels(long step)
        {
            // T�vols�g sz�lbiztos n�vel�se
            lock (lockObject)
            {
                distance += step;
            }
        }

        long getPixels()
        {
            // T�vols�g kiolvas�sa
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
            // Ha m�g nem ind�tottuk ez a sz�lat, ez null.
            if (thread == null)
                return;
            // Megszak�tjuk a sz�l v�rakoz�s�t, ez az adott sz�lban egy
            // ThreadInterruptedException-t fog kiv�ltani
            // A f�ggv�ny le�r�s�r�l r�szleteket az el�ad�s anyagaiban tal�lsz
            thread.Interrupt();

            bike.Left = startPoz;
            bicycleOnStart.Reset();
            // Megv�rjuk, am�g a sz�l le�ll
            thread.Join();
        }
    }
}