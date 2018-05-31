using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordGrid.Models
{
    public class GridChar
    { 
        public GridChar()
        {
            
        }

        [NotMapped]
        public char Char { get { return CharStr[0]; }  set { CharStr = value.ToString(); } }

        public int Id { get; set; }

        [Column(TypeName="char(1)")]
        public string CharStr { get; set; }

        public GridChar Advance()
        {
            switch (Char)
            {
                case ' ':
                    Char = 'A';
                    break;
                case char ch when (char.ToLower(ch) >= 'a' && char.ToLower(ch) < 'z'):
                    Char = (char)(ch + 1);
                    break;
                default:
                    Char = ' ';
                    break;
            }
            return this;
        }
    }
}
