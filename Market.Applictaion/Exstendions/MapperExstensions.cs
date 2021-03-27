using AutoMapper;
using System.Linq;

namespace Market.Applictaion.Exstendions
{
    // This extension has been added for successful execution of mapper unit tests
    public static class MapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(
                        this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destProperties = typeof(TDestination).GetProperties();

            foreach (var property in destProperties.Where(dp => !sourceProperties.Any(sp => sp.Name == dp.Name)))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
}
