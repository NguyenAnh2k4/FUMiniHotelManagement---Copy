using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class RoomInfomation
    {
        public int RoomID {  get; set; }
        public string RoomNumber {  get; set; }
        public string? RoomDetailDescription {  get; set; }
        public int RoomMaxCapacity {  get; set; }
        public int RoomTypeID {  get; set; }
        public short RoomStatus {  get; set; }
        public decimal RoomPricePerDay {  get; set; }
    }
}
