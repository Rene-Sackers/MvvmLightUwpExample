using System;
using MvvmLightUwpExample.Helpers.Extensions;

namespace MvvmLightUwpExample.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class DependencyInformationAttribute : Attribute
    {
        public Type RuntimeImplementation { get; set; }
        public Type DesigntimeImplementation { get; set; }

        public DependencyInformationAttribute(Type interfaceType, Type runtimeImplementation, Type designtimeImplementation = null)
        {
            RuntimeImplementation = runtimeImplementation;
            DesigntimeImplementation = designtimeImplementation;

            ValidateByInterface(interfaceType);
        }

        private void ValidateByInterface(Type @interface)
        {
            if (!RuntimeImplementation.ImplementsInterface(@interface))
                throw new InvalidOperationException($"Type specified for {nameof(RuntimeImplementation)} does not implement interface {@interface.Name}");

            if (DesigntimeImplementation != null && !DesigntimeImplementation.ImplementsInterface(@interface))
                throw new InvalidOperationException($"Type specified for {nameof(DesigntimeImplementation)} does not implement interface {@interface.Name}");
        }
    }
}
