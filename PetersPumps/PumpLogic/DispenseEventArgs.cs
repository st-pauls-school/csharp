using System;

namespace PumpLogic
{

    public class DispenseEventArgs : EventArgs
    {
        readonly decimal _transactionCost;
        readonly decimal _fuelQuantity;
        readonly bool _dispensing;

        public DispenseEventArgs(decimal litres, decimal pounds, bool dispensing)
        {
            _transactionCost = pounds;
            _fuelQuantity = litres;
            _dispensing = dispensing;
        }

        public decimal Cost { get { return _transactionCost; } }
        public decimal Quantity {  get { return _fuelQuantity; } }
    }
}
