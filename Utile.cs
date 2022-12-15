using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace MotMeles_v1 {

    internal class Utile {
        /// <summary>
        /// Vérifie si le mot trouvé existe et s'il est bien dans la position décrite dans le tableau
        /// </summary>
        /// <param name="mot">string</param>
        /// <returns>int</returns>
        public static int GenererCodeUnicodeInverse(string mot) {
            if (mot == null) {
                return -1;
            }
            int unicode = 0;
            string strUnicode = "";
            foreach (char cara in mot) {
                unicode = (int)cara;
                strUnicode += unicode.ToString();
            }
            bool estNumerique = int.TryParse(strUnicode, out unicode);
            if (estNumerique) {
                return unicode;
            }
            return -1;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="chemin"></param>
        /// <returns></returns>
        public static IEnumerable<string> LireFichier(string chemin) {
            if (File.Exists(chemin)) {
                IEnumerable<string> lines = File.ReadLines(chemin);
                return lines;
            }
            return null;
        }
        /// <summary>
        /// Verifie si un string est un nombre
        /// </summary>
        /// <param name="entree"></param>
        /// <param name="numberStyle"></param>
        /// <returns></returns>
        public static Boolean EstNumerique(String entree, NumberStyles numberStyle) {
            Boolean result = int.TryParse(entree, numberStyle, CultureInfo.CurrentCulture, out _);
            return result;
        }
    }
}
