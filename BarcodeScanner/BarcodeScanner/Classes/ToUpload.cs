﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BarcodeScanner.Classes
{
    class ToUpload
    {
        public String Batch { get; set; }
        public String Client{ get; set; }


        //posisible cache overload
        public Stream Image { get; set; } 
        public Stream[] Images { get; set; }


        public ToUpload() { }
    }

    public class JsonResponse
    {
        public string d { get; set; }

    }

}
