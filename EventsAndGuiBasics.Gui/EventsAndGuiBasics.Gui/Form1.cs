using EventsAndGuiBasics.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsAndGuiBasics.Gui
{
    public partial class frmMain : Form
    {
        Ticker _ticker;

        public frmMain()
        {
            InitializeComponent();
            _ticker = new Ticker("Default message",2500);
            _ticker.Tick += _ticker_Tick;
            
        }

        #region nasty cross-thread handling code 
        // cross-thread avoidance - https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
        delegate void SetTickerTextCallBack(string msg);
        void SetTickerText(string msg)
        {
            if (lblTicker.InvokeRequired)
            {
                SetTickerTextCallBack cb = new SetTickerTextCallBack(SetTickerText);
                Invoke(cb, new object[] { msg });
            }
            else
                lblTicker.Text = msg;
        }
        #endregion

        void _ticker_Tick(object sender, TickerEventArgs e)
        {
            SetTickerText(e.ToString());
        }

        void btnStartTicker_Click(object sender, EventArgs e)
        {
            btnStartTicker.Enabled = false;
            btnStopTicker.Enabled = true;
            lblTicker.Text = "started";
            _ticker.Start();
        }

        void btnStopTicker_Click(object sender, EventArgs e)
        {
            btnStartTicker.Enabled = true;
            btnStopTicker.Enabled = false;
            _ticker.Stop();
        }
    }
}
