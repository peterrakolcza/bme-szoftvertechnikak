namespace WinFormExpl
{
    public partial class MainForm_IMO7KC : Form
    {
        FileInfo loadedFile = null;
        int counter;
        readonly int counterInitialValue;

        public MainForm_IMO7KC()
        {
            InitializeComponent();

            // 5 * (1 / 0.1)
            counterInitialValue = 50;
        }

        private void miOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputDialog dlg = new InputDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string result = dlg.Path;
                //MessageBox.Show(result);
                // TODO: tov�bbi l�p�sek...

                //Ha vannak el�z� elemek, akkor azokat ki kell t�r�lni
                listView1.Items.Clear();

                DirectoryInfo parentDI = new DirectoryInfo(result);
                try
                {
                    //Adatok beolvas�sa
                    foreach (FileInfo fi in parentDI.GetFiles())
                        listView1.Items.Add(new ListViewItem(new string[] { fi.Name, fi.Length.ToString(), fi.CreationTime.ToString(), fi.DirectoryName.ToString() }));
                }
                catch { }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ha nincs kiv�lasztva semmi, akkor ne pr�b�lja meg bet�lteni a file adatait
            if (listView1.SelectedItems.Count > 0)
            {
                lName.Text = listView1.SelectedItems[0].SubItems[0].Text;
                lCreated.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //File tartalm�nak olvas�sa
                tContent.Text = File.ReadAllText(listView1.SelectedItems[0].SubItems[3].Text + "\\" + listView1.SelectedItems[0].SubItems[0].Text);
            }
            catch { }

            reloadTimer.Start();
            counter = counterInitialValue;
            loadedFile = new FileInfo(listView1.SelectedItems[0].SubItems[3].Text + "\\" + listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            // Fontos! Ez v�ltja ki a Paint esem�nyt �s ezzel a
            // a t�glalap �jrarajzol�s�t
            detailsPanel.Invalidate();
            if (counter <= 0)
            {
                counter = counterInitialValue;
                tContent.Text = File.ReadAllText(loadedFile.FullName);
            }
        }

        private void detailsPanel_Paint(object sender, PaintEventArgs e)
        {
            if (loadedFile != null)
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0, 0, Convert.ToInt32(120 * (counter / (double)counterInitialValue)), 6));
            // A t�glalap sz�less�ge a t�glalap kezd�hossz�s�g�b�l (adott
            // a feladatki�r�sban) sz�m�that�,
            // szorozva a sz�ml�l� aktu�lis �s max �rt�k�nek ar�ny�val 
        }

        private void miExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Alkalmaz�s bez�r�sa
            Application.Exit();
        }
    }
}