namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IIdentityDataInitializerService
    {
        void SeedRoles();

        void SeedGroups();

        void SeedUsers();

        void AddReferenceRoles();
    }
}
