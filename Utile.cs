using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        
        public static IEnumerable<string> LireFichier(string chemin) {
            if (File.Exists(chemin)) {
                IEnumerable<string> lignes = File.ReadLines(chemin);
                return lignes;
            }
            return null;
        }
    }
}
