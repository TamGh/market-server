using System;
using System.Reflection;

namespace Market.Applictaion.Exstendions
{
    public static class EnumExstensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
          where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttribute<TAttribute>(false);
        }
    }
}
