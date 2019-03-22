using System;
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
        //public Byte[] Images { get; set; }


        public ToUpload() { }


    }
}
