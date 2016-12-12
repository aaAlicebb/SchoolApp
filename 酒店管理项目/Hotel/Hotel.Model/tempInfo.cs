using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class tempInfo
    {
        public int roomId { get; set; }
        public string roomType { get; set; }
        public decimal roomPrice { get; set; }
        public string roomState { get; set; }
        public tempInfo()
        { }
        public tempInfo(int roomId, string roomType, decimal roomPrice, string roomState)
        {
            this.roomId = roomId;
            this.roomType = roomType;
            this.roomPrice = roomPrice;
            this.roomState = roomState;
        }
    }
}
