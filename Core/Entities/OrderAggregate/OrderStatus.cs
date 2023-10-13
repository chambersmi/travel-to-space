using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending, //0

        [EnumMember(Value ="Payment Received")]
        PaymentReceived, //1
        
        [EnumMember(Value ="Payment Failed")]
        PaymentFailed //2
    }
}