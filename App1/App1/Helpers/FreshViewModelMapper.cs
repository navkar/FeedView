using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Helpers
{
    public class FreshViewModelMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName
                .Replace("ViewModel", "View");
        }
    }
}
