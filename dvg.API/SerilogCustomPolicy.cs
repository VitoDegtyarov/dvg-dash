using dvg.Data.Entities;
using Serilog.Core;
using Serilog.Events;
using System.Diagnostics.CodeAnalysis;

namespace dvg.API
{
    public class SerilogCustomPolicy : IDestructuringPolicy
    {
        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, [NotNullWhen(true)] out LogEventPropertyValue? result)
        {
            if(value is Designer designer)
            {
                var properties = new[]
                {
                    new LogEventProperty("DesignerName", new ScalarValue(designer.FirstName)),
                    new LogEventProperty("DesignerProjects", new ScalarValue(designer.Projects))
                };

                result = new StructureValue(properties);
                return true;
            }

            result = null;
            return false;
        }
    }
}
