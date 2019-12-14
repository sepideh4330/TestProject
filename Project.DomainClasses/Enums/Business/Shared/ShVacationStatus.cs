namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShVacationStatus : short
    {
        /// <summary>
        /// در انتظار بررسی 
        /// </summary>
        Pending = 100,

        /// <summary>
        /// تایید شده
        /// </summary>
        Accepted = 200,

        /// <summary>
        /// رد شده
        /// </summary>
        Rejected = 300
    }
}