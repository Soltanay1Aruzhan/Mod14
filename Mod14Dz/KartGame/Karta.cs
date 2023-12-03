using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartGame
{
    public enum Mast
    {
        Chervi,
        Bubny,
        Kresri,
        Piki
    }

    public enum KartaType
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Karta : IComparable<Karta>
    {
        public Mast Mast { get; }
        public KartaType Type { get; }

        public Karta(Mast mast, KartaType type)
        {
            Mast = mast;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type} of {Mast}";
        }

        public int CompareTo(Karta other)
        {
            
            if (this.Type != other.Type)
            {
                return this.Type.CompareTo(other.Type);
            }
            return this.Mast.CompareTo(other.Mast);
        }
    }
}
