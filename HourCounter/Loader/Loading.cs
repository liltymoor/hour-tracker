using System;
using System.Windows.Forms;
using System.Threading;

namespace HourCounter
{
    public partial class Loading : Form
    {
        HourCounter form;
        int counter;
        public Loading()
        {
            InitializeComponent();
            counter = 0;
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.LoadComplete();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (form != null)
            {
                if (form.isLoad)
                    this.Close();
            }
            if (counter == 5)
            {
                counter = 0;
                label1.Text = "LOADING";
                form = (HourCounter)this.Owner;
            }
            label1.Text += ".";
            counter++;
        }
    }
}
