using System;

namespace PumpLogic
{

    public interface IPump
    {
        void LiftNozzle();
        void StartDispensing();
        void StopDispensing();
        void ReplaceNozzle();
        PumpState CurrentPumpState { get; }
        decimal PricePerLitre { get; set; }
        decimal TransactionCost { get; }
        decimal TransactionQuantity { get; }
        event EventHandler<DispenseEventArgs> DispenseUpdated;
    }
}
