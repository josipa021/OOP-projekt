using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class PrazanString : Exception
    {
        public static string poruka = "Morate unijeti ime!";

        public PrazanString() : base(poruka)
        {

        }
    }

    public class PostojeceIme : Exception
    {
        public static string poruka = "To ime je zauzeto, izaberite neko drugo!";

        public PostojeceIme() : base(poruka)
        {

        }
    }
}

