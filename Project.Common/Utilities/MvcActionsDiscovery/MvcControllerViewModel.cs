using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Common.Utilities.MvcActionsDiscovery
{
    public class MvcControllerViewModel
    {
        public string AreaName { get; set; }
        public IList<Attribute> ControllerAttributes { get; set; }
        public string ControllerDisplayName { get; set; }
        public string ControllerId => $"{AreaName}:{ControllerName}";
        public string ControllerName { get; set; }
        public IList<MvcActionViewModel> MvcActions { get; set; } = new List<MvcActionViewModel>();

        public override string ToString()
        {
            const string attribute = "Attribute";
            var controllerAttributes = string.Join(",", ControllerAttributes.Select(a => a.GetType().Name.Replace(attribute, "")));
            return $"[{controllerAttributes}]{AreaName}.{ControllerName}";
        }
    }
}