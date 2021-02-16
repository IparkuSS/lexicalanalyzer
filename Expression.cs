using System;
using System.Collections.Generic;
using System.Text;

namespace lexicalanalyzer
{
    public class Expression
    {
        public int EpresPLus { set; get; }
        public int EpresMinus { set; get; }
        public int EpresDel { set; get; }
        public int EpresUmn { set; get; }
        public int EpresPrs { set; get; }
        public string EpresId { set; get; }
        public string Epres16 { set; get; }
        public int EpresParantOpen { set; get; }
        public int EpresParantClouse { set; get; }

        public Expression()
        {

        }

    }
}
