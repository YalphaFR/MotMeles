using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1 {
    internal class Utile {
        public static int GenererCodeUnicodeInverse(string mot) {
            if (mot == null) {
                return -1;
            }
            int unicode = 0;
            string strUnicode = "";
            foreach (char cara in mot) {
                unicode = (int)cara;
                strUnicode = unicode.ToString() + strUnicode;
            }
            unicode = int.Parse(strUnicode);
            return unicode;
        }
    }
}
