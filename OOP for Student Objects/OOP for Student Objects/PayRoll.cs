using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_for_Student_Objects
{
    interface IPayee
    {
        void Pay();
    }
    class PayRoll
    {
        List<IPayee> payees = new List<IPayee>();

        //this is a constructor
        public PayRoll()
        {
            payees.Add(new Teacher());

            payees.Add(new Teacher());

            payees.Add(new Principal());

            Logger.Log("PayRoll started", "Payrool", 1);
        }
        public void PayAll()
        {
            foreach (var payee in payees)
            {
                payee.Pay();
            }

            Logger.Log("PayAll completed", "Payrool", 2);
        }
    }
}
