using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShModemCityType : short
    {
        /// <summary>
        /// FD 
        /// </summary>
        [Display(Name = "FD")]
        FD = 100,

        /// <summary>
        /// TD
        /// </summary>
        [Display(Name = "TD")]
        TD =  200,
    }
}
