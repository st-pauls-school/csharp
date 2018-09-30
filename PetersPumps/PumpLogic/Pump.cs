using System;
using System.Timers;

namespace PumpLogic
{
    public class Pump : IPump
    {
        PumpState _state;
        decimal _pricePerLitre;
        readonly float _flowRatePerSecond;
        Timer _timer;
        DateTime _startTime;
        decimal _transactionQuantity;

        public event EventHandler<DispenseEventArgs> DispenseUpdated;

        public Pump(decimal price, float flowRatePerSecond, int updateMs)
        {
            _pricePerLitre = price;
            _state = PumpState.Holstered;
            _flowRatePerSecond = flowRatePerSecond;
            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Interval = updateMs;
            _timer.Enabled = false;
        }

        #region Event Handling 

        void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            TriggerDispenseEvent(e.SignalTime - _startTime);
        }

        void TriggerDispenseEvent(TimeSpan elapsed)
        { 
            _transactionQuantity = (decimal)((elapsed.Milliseconds / 1000) / _flowRatePerSecond);
            OnDispenseUpdated(new DispenseEventArgs(_transactionQuantity, TransactionCost, CurrentPumpState == PumpState.Dispensing));
        }

        void OnDispenseUpdated(DispenseEventArgs de)
        {
            if (DispenseUpdated != null)
                DispenseUpdated(this, de);

            DispenseUpdated?.Invoke(this, de);
        }

        #endregion

        #region Properties 
        public PumpState CurrentPumpState { get { return _state; } }

        public decimal TransactionCost { get { return _transactionQuantity * _pricePerLitre; } }

        public decimal TransactionQuantity { get { return _transactionQuantity; } }

        public decimal PricePerLitre
        {
            get { return _pricePerLitre; }
            set
            {
                if (CurrentPumpState != PumpState.Holstered)
                    throw new PumpException("Cannot change price while pump is unholstered.");
                _pricePerLitre = value;
            }
        }

        #endregion 


        public void LiftNozzle()
        {
            if (CurrentPumpState != PumpState.Holstered)
                throw new PumpException("Cannot lift - Pump is not holstered.");
            _state = PumpState.Unholstered;
        }

        public void ReplaceNozzle()
        {
            if (CurrentPumpState != PumpState.Unholstered)
                throw new PumpException("Cannot replace - Pump is not unholstered");

            _state = PumpState.Holstered;
        }

        public void StartDispensing()
        {
            if (CurrentPumpState != PumpState.Unholstered)
                throw new PumpException("Cannot start dispensing - Pump is not unholstered.");

            _state = PumpState.Dispensing;
            _timer.Enabled = true;
            _startTime = DateTime.Now;
        }

        public void StopDispensing()
        {
            if (CurrentPumpState != PumpState.Dispensing)
                throw new PumpException("Cannot stop dispensing - Pump is not dispensing.");

            _state = PumpState.Holstered;
            _timer.Enabled = false;
            TriggerDispenseEvent(DateTime.Now - _startTime);

        }

    }
}
