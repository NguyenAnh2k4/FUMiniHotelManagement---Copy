﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class RoomType
    {   
        public RoomType() { }
        public int RoomTypeID { get; set; }
        public string RoomTypeName {  get; set; }
        public string TypeDescription {  get; set; }
        public string TypeNote { get; set; } 
    }
}
