using PumpLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpViewer
{
    public partial class PumpForm : Form
    {
        Pump _pump;

        string _price = string.Empty;
        string _cost = string.Empty;
        string _quantity = string.Empty;
        PumpState _state = PumpState.Holstered;

        BackgroundWorker _worker; 


        public PumpForm()
        {
            InitializeComponent();


            _worker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true,
                    WorkerReportsProgress = true
                };
            _worker.DoWork += _worker_DoWork;
            
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _pump = new Pump(120.9m, 0.2f, 100); // todo: load in the default from a config file 
            _pump.DispenseUpdated += pump_DispenseUpdated;

            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(i * 10);
            }
            
        }

        private void pump_DispenseUpdated(object sender, DispenseEventArgs e)
        {
            _price = _pump.PricePerLitre.ToString();
            _state = _pump.CurrentPumpState;
            _cost = e.Cost.ToString();
            _quantity = e.Quantity.ToString();

            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate {
                    UpdateLabels();
                }));
            }
        }

        

        void UpdateLabels()
        {
            _state = _pump.CurrentPumpState;
            switch (_state)
            {
                case (PumpState.Holstered):
                    UpdateButtons(true, false, false, false);
                    break;
                case (PumpState.Unholstered):
                    UpdateButtons(false, true, true, true);
                    break;
                case (PumpState.Dispensing):
                    UpdateButtons(false, false, true, false);
                    break;
            };

            lblPumpState.Text = _state.ToString();
            lblPricePerLitre.Text = _price;
            lblCost.Text = _cost;
            lblQuantity.Text = _quantity;
    }

        void UpdateButtons(bool lift, bool start, bool stop, bool replace)
        {
            btnLift.Enabled = lift;
            btnStop.Enabled = stop;
            btnStart.Enabled = start;
            btnReplace.Enabled = replace;
        }

#region button clicks 

        private void btnLift_Click(object sender, EventArgs e)
        {
            _pump.LiftNozzle();
            UpdateLabels();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _pump.StartDispensing();
            UpdateLabels();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _pump.StopDispensing();
            UpdateLabels();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            _pump.ReplaceNozzle();
            UpdateLabels();
        }
#endregion
    }
}
