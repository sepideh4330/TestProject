using System.Collections.Generic;

namespace Project.Common.Utilities.MvcActionsDiscovery
{
    public interface IMvcActionsDiscoveryService
    {
        ICollection<MvcControllerViewModel> MvcControllers { get; }
        ICollection<MvcControllerViewModel> GetAllSecuredControllerActionsWithPolicy(string policyName);
    }
}
