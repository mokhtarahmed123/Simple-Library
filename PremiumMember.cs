    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Simple_Library
    {
        internal class PremiumMember : Member, INotification
        {
            public decimal MonthlyFee { get; } = 3;
            public double DiscountRate { get; } = 0.2;

            public string SendNotification(string message)
            {
                { return $"You {message} the Book"; }
            }
        }
    }
