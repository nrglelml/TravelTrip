using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTrip.Helper
{
    public static class StringHelper
    {
        public static string KelimeBolmedenKisalt(this string metin, int karakterSiniri)
        {
            if (string.IsNullOrEmpty(metin) || metin.Length <= karakterSiniri)
                return metin;

            // Karakter sınırından sonraki ilk boşluğu bul
            int boslukIndex = metin.IndexOf(" ", karakterSiniri);

            // Eğer boşluk bulunamazsa (tek bir çok uzun kelimeyse) sınırı kullan
            if (boslukIndex == -1)
                return metin.Substring(0, karakterSiniri) + "...";

            return metin.Substring(0, boslukIndex) + "...";
        }
    }
}