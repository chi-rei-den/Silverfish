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
        public static T ParseEnum<T>(this string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static TOut Convert<TIn, TOut>(TIn value) where TIn : Enum where TOut : Enum
        {
            return (TOut)Enum.Parse(typeof(TOut), value.ToString());
        }

        public static CardClass Convert(this TAG_CLASS value)
        {
            return Convert<TAG_CLASS, CardClass>(value);
        }
    }
}
