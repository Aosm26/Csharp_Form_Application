using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public class Ogrenci
    {
        OgrNoKayit ogrKyt = new OgrNoKayit();
        public String OgrNo;
        public Ogrenci()
        {
            OgrNo = ogrKyt.GetOgrNo();
            MessageBox.Show(OgrNo + "asdasddasd");
            MessageBox.Show(OgrNo + "    :adshfn");
        }
    }
}
