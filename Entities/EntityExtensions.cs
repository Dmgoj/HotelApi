using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities
{
    public static class EntityExtensions
    {
        public static void Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var prop in sourceProperties)
            {
                var destProp = destinationProperties.FirstOrDefault(p => p.Name == prop.Name && p.PropertyType == prop.PropertyType);
                if (destProp != null && destProp.CanWrite)
                {
                    var newValue = prop.GetValue(source); 
                    destProp.SetValue(destination, newValue); 
                }
            }
        }
    }
}
