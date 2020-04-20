using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triton.Game.Mapping;

namespace Chireiden.Silverfish
{
  public static  class Helper
    {
        public static TOut Convert<TIn, TOut>(TIn value)
        {
            return (TOut)Enum.Parse(typeof(TOut), value.ToString());
        }

        public static CardClass Convert(this TAG_CLASS value)
        {
            return Convert<TAG_CLASS, CardClass>(value);
        }
    }
}
