using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.StaticValues.Security.Models;

namespace Project.Common.StaticValues.Security
{
    public class SystemRoles
    {
        private static readonly Lazy<IEnumerable<SystemRoleItem>> SystemRolesLazy = new Lazy
            <IEnumerable<SystemRoleItem>>(
                GetSystemRoles, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<SystemRoleItem> GetSystemRoles()
        {
            #region RoleType

            var miModemManagement = 100;
            var miSimcartManagement = 200;
            var miStore = 300;
            var miInformationManagement = 400;
            var reRedemptionList = 500;
            var reTicketManagement = 600;
            var reFinancial = 700;
            var reStore = 800;
            var reInformationManagement = 900;
            var umRole = 1000;
            var umGroup = 1100;
            var umUser = 1200;
            var profile = 1300;
            var umHome = 1400;
            var reHome = 1500;
            var miHome = 1600;
            var miTicket = 1700;
            //var miSetting = 1800;
            //var reSetting = 1900;
            var shCity = 2000;
            var shLog = 2100;
            var shSetting = 2200;
            var general = 2300;
            var oppositeOfRobot = 2400;
            var financialDepartment = 2500;
            var shProvince = 2600;
            var umInformationManagement = 2700;
            var suHome = 2800;
            var saHome = 2900;
            var fiHome = 3000;
            var wlHome = 3100;
            var miWarehouse = 3200;
            var suTicket = 3300;
            var suInformationManagement = 3400;
            var peHome = 3500;
            var peCourse = 3600;
            var miPostalTicket = 3700;
            var peSurvey = 3800;
            var saTicket = 3900;
            var peUserCourse = 4000;
            var wlTicket = 4100;
            var bsHome = 4200;
            var wlInformationManagement = 4300;
            var suDeclareDelay = 4400;
            var saCustomerDocument = 4600;
            var miReport = 4700;
            var shSystemLog = 4800;

            #endregion

            #region RoleCategory
            var userManagement = 100;
            var massInstallation = 200;
            var redemption = 300;
            var support = 400;
            var sale = 500;
            var financial = 600;
            var warehouseAndLogestic = 700;
            var performanceEvaluation = 800;
            var basicSetting = 900;
            var shGeneral = 1100;
            #endregion

            return new List<SystemRoleItem>
            {
                #region UserManagement

                new SystemRoleItem(ShowUserManagementMainPage, "مشاهده صفحه اصلی مدیریت کاربران",
                    "",umHome,"",userManagement),
                new SystemRoleItem(ShowUmRoles, "مشاهده نقش های در مدیریت کاربران",
                    "",umRole,"",userManagement),
                new SystemRoleItem(DetailUmRole, "نمایش جزئیات نقش سیستم در مدیریت کاربران",
                    "",umRole,ShowUmRoles,userManagement),
                new SystemRoleItem(ShowUmGroups, "مشاهده گروه های کاربری در مدیریت کاربران",
                    "",umGroup,"",userManagement),
                new SystemRoleItem(DetailUmGroup, "نمایش جزئیات گروه کاربری در مدیریت کاربران",
                    "",umGroup,ShowUmGroups,userManagement),
                new SystemRoleItem(ShowUmUsers, "مشاهده لیست کاربران در مدیریت کاربران",
                    "",umUser,"",userManagement),
                new SystemRoleItem(AddNewUmGroup, "اضافه کردن گروه کاربری جدید در مدیریت کاربران",
                    "",umGroup,ShowUmGroups,userManagement),
                new SystemRoleItem(DeleteUmGroup, "حذف گروه کاربری در مدیریت کاربران",
                    "",umGroup,ShowUmGroups,userManagement),
                new SystemRoleItem(AddNewUmUser, "اضافه کردن کاربر جدید در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(EditUmGroup, "ویرایش گروه کاربری در مدیریت کاربران",
                    "",umGroup,ShowUmGroups,userManagement),
                new SystemRoleItem(ChangeUmGroupStatus, "تغییر وضعیت گروه کاربری در مدیریت کاربران",
                    "",umGroup,ShowUmGroups,userManagement),
                new SystemRoleItem(EditUmUser, "ویرایش کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(DeleteUmUser, "حذف کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(ChangeUmUserPassword, "تغییر کلمه عبور کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(UploadAvatarUmUser, "آپلود عکس پرسنلی اعضا در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(CoordinateUmUser, "نمایش مختصات کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(TotalCoordinateUmUser, "نمایش مختصات تمامی کاربران در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(UploadSignatureUmUser, "آپلود امضا اعضای در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(ConfirmUmUserPhoneNumber, "تایید شماره موبایل کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(FiredUmUser, "اخراج کردن کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(InactiveUmUser, "غیرفعال کردن کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(ActiveUmUser, "فعال کردن کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(ChangeUmUserSignature, "تغییر وضعیت امضا در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(ConfirmOrRejectUmUserSignature, "تایید یا رد امضا کاربر در مدیریت کاربران",
                    "",umUser,ShowUmUsers,userManagement),
                new SystemRoleItem(DisplayBoxInUmMainPage, "نمایش باکس های صفحه اصلی مدیریت کاربران",
                    "",umHome,"",userManagement),
                new SystemRoleItem(UmExpertLiveLocationReport, "گزارش موقعیت فعلی کارشناسان آنلاین",
                    "",umHome,ListShCity,userManagement),

                #endregion

                #region MassInstallation

                new SystemRoleItem(ShowMassInstallationMainPage, "مشاهده صفحه اصلی نصب انبوه",
                    "",miHome,"",massInstallation),
                new SystemRoleItem(ListMiModem, "نمایش لیست مودم های نصب انبوه",
                    "",miModemManagement,"",massInstallation),
                new SystemRoleItem(DetailMiModem, "نمایش جزئیات مودم نصب انبوه",
                    "",miModemManagement,ListMiModem,massInstallation),
                new SystemRoleItem(EditMiModem, "ویرایش مودم نصب انبوه",
                    "",miModemManagement,ListMiModem,massInstallation),
                new SystemRoleItem(ListMiSimcart, "نمایش لیست سیم کارت های نصب انبوه",
                    "",miSimcartManagement,"",massInstallation),
                new SystemRoleItem(DetailMiSimcart, "نمایش جزئیات سیم کارت نصب انبوه",
                    "",miSimcartManagement,ListMiSimcart,massInstallation),
                new SystemRoleItem(EditMiSimcart, "ویرایش سیم کارت نصب انبوه",
                    "",miSimcartManagement,ListMiSimcart,massInstallation),
                new SystemRoleItem(SwitchMiInstallationExpert, "تغییر کارشناس نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(LockOrUnlockMiModem, "قفل یا بازگشایی مودم نصب انبوه",
                    "",miModemManagement,ListMiModem,massInstallation),
                new SystemRoleItem(BirthdayModeMiModem, "حالت تولد مودم نصب انبوه",
                    "",miModemManagement,ListMiModem,massInstallation),
                new SystemRoleItem(BirthdayModeMiSimcart, "حالت تولد سیم کارت نصب انبوه",
                    "",miSimcartManagement,ListMiSimcart,massInstallation),
                new SystemRoleItem(LockOrUnlockMiSimcart, "قفل یا بازگشایی سیم کارت نصب انبوه",
                    "",miSimcartManagement,ListMiSimcart,massInstallation),
                new SystemRoleItem(AllocateToMiInstallationExpert, "تخصیص کارشناس نصب برای تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(TakenMiInstallationExpert, "گرفتن از کارشناس نصب برای تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ListMiTicket, "نمایش لیست تیکت های نصب انبوه",
                    "",miTicket,"",massInstallation),
                new SystemRoleItem(AddNewMiTicket, "اضافه کردن تیکت نصب انبوه جدید",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(EditMiTicket, "ویرایش کردن تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(DeleteMiTicket, "حذف کردن تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(DetailMiTicket, "نمایش جزئیات تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(CoordinateMiTicket, "تنظیم موقعیت تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(BirthdayModeMiTicket, "برگرداندن تیکت نصب انبوه به حالت اولیه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(LockOrUnlockMiTicket, "بستن یا باز کردن تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(UndoFromNotAnswerMiTicket, "بازگشت تیکت از عدم پاسخ به حالت اول نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(OperationMiTicket, "عملیات تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(CoordinationMiTicket, "ثبت زمان هماهنگی تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(MiOutputDraftInstallationOutput, "خروجی مجدد حواله خروج نصب انبوه",
                    "",miStore,"",massInstallation),
                new SystemRoleItem(ListMiInstallation, "لیست تیکت های نصب شده نصب انبوه",
                    "",miTicket,"",massInstallation),
                new SystemRoleItem(DetailMiInstallation, "نمایش جزئیات تیکت های نصب شده نصب انبوه",
                    "",miTicket,ListMiInstallation,massInstallation),
                new SystemRoleItem(DisplayBoxInMiMainPage, "نمایش باکس های صفحه اصلی نصب انبوه",
                    "",miHome,"",massInstallation),
                new SystemRoleItem(ManualActivationMiTicket, "فعال سازی دستی تیکت های نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ListActivationMiTicket, "لیست تیکت های منتظر فعال سازی نصب انبوه",
                    "",miTicket,"",massInstallation),
                new SystemRoleItem(MassInstallationDoOppositeOfRobot, "انجام مغایرت توسط ربات در نصب انبوه",
                    "",oppositeOfRobot,"",massInstallation),
                new SystemRoleItem(ListCancelledMiInstallation, "لیست نصب های لغو شده نصب انبوه",
                    "",miTicket,"",massInstallation),
                new SystemRoleItem(ListCancelDueToSignalWeaknessFor360, "لیست ضعف سیگنال های 360 نصب انبوه",
                    "",miTicket,"",massInstallation),
                new SystemRoleItem(ConfirmCancelledMiInstallation, "تایید نصب های لغو شده نصب انبوه",
                    "",miTicket,ListCancelledMiInstallation,massInstallation),
                new SystemRoleItem(MiInstallation360SignalWeaknessConfirm, "تایید ضعف سیگنال های 360 نصب انبوه",
                    "",miTicket,ListCancelDueToSignalWeaknessFor360,massInstallation),
                new SystemRoleItem(MiOperationRobot, "انجام فعال سازی توسط ربات در نصب انبوه",
                    "",oppositeOfRobot,"",massInstallation),
                new SystemRoleItem(MiFetchRobot, "انجام دریافت تیکت توسط ربات در نصب انبوه",
                    "",oppositeOfRobot,"",massInstallation),
                new SystemRoleItem(MiCancellationRobot, "انجام لغو تیکت توسط ربات در نصب انبوه",
                    "",oppositeOfRobot,"",massInstallation),
                new SystemRoleItem(ListOmbArchives, "لیست بایگانی های نصب انبوه",
                    "",miInformationManagement,"",massInstallation),
                new SystemRoleItem(MiTicketManualActivationByRobot, "فعال سازی دستی تیکت های نصب انبوه توسط ربات",
                    "",oppositeOfRobot,ListActivationMiTicket,massInstallation),
                new SystemRoleItem(DetailOmbArchive, "جزئیات بایگانی نصب انبوه",
                    "",miInformationManagement,ListOmbArchives,massInstallation),
                new SystemRoleItem(MiTicketLiveLocationReport, "گزارش موقعیت تیکت",
                    "",miHome,"",massInstallation),
                new SystemRoleItem(GetMiTicketStatusBasedOnProvinceReport, "گزارش وضعیت تیکت بر اساس شهر و استان",
                    "",miHome,"",massInstallation),
                new SystemRoleItem(GetMiTicketDensityAndEfficiencyReport, "گزارش تراکم و راندمان تیکت",
                    "",miHome,"",massInstallation),
                new SystemRoleItem(MiReportTicket, "گزارش تیکت نصب انبوه",
                    "",miReport,"",massInstallation),
                new SystemRoleItem(DetailMiReportTicket, "جزئیات گزارش تیکت نصب انبوه",
                    "",miReport,MiReportTicket,massInstallation),
                new SystemRoleItem(CoordinatePostalTicket, "هماهنگی تیکت پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ManualActivationMiPostalTicket, "فعال سازی دستی تیکت پستی نصب انبوه",
                    "",miPostalTicket,ListActivationMiTicket,massInstallation),
                new SystemRoleItem(OperationMiPostalTicket, "عملیات تیکت پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ListActivationMiPostalTicket, "مشاهده لیست تیکت های پستی منتظر فعال سازی نصب انبوه",
                    "",miPostalTicket,"",massInstallation),
                new SystemRoleItem(DetailPostalTicket, "جزئیات تیکت پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(TrackMiPostalTicket, "پیگیری تیکت پستی نصب انبوه",
                    "",oppositeOfRobot,"",massInstallation),
                new SystemRoleItem(BirthdayModeMiPostalTicket, "حالت تولد تیکت پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(CancellationDueToInabilityToCallMiPostalTicket, "لغو به علت عدم امکان تماس تیکت پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ConvertToMiPostalTicket, "تبدیل تیکت حضوری به پستی نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ConvertToMiTicket, "تبدیل تیکت پستی به حضوری نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(ListMiTicketInstallationExpertCallLog, "مشاهده لاگ های تماس کارشناس نصب",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(DownloadInstallationInvoice, "دانلود فاکتور نصب تیکت نصب انبوه",
                    "",miTicket,ListMiTicket,massInstallation),
                new SystemRoleItem(MobinnetPerformanceMiReport, "گزارش عملکرد مبین نت نصب انبوه",
                    "",miReport,"",massInstallation),
                new SystemRoleItem(MobinnetPerformanceMiReportExcelFile, "دانلود فایل اکسل گزارش عملکرد مبین نت نصب انبوه",
                    "",miReport,MobinnetPerformanceMiReport,massInstallation),

                #endregion

                #region Redemption
                
                new SystemRoleItem(ShowRedemptionEquipmentMainPage, "مشاهده صفحه اصلی بازخرید",
                    "",reHome,"",redemption),
                new SystemRoleItem(ImportReBatchTicket, "ایمپورت دسته ی تیکت بازخرید",
                    "",reTicketManagement,"",redemption),
                new SystemRoleItem(ListReBatchTicket, "لیست دسته ی تیکت بازخرید",
                    "",reTicketManagement,"",redemption),
                new SystemRoleItem(DeleteReBatchTicket, "حذف دسته ی تیکت بازخرید",
                    "",reTicketManagement,ListReBatchTicket,redemption),
                new SystemRoleItem(ReBatchTicketDetail, "جزئیات دسته تیکت بازخرید",
                    "",reTicketManagement,ListReBatchTicket,redemption),
                new SystemRoleItem(EditReTicket, "ویرایش تیکت های بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(ListReTicket, "لیست تیکت های بازخرید",
                    "",reTicketManagement,"",redemption),
                new SystemRoleItem(DeleteReTicket, "حذف تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(DetailReTicket, "جزئیات تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(CoordinateReTicket, "تنظیم موقعیت تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(BirthdayModeReTicket, "حالت تولد تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(LockOrUnlockReTicket, "قفل یا بازگشایی تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(ExportReBatchTicketFile, "دریافت فایل خروجی Excel دسته تیکت بازخرید",
                    "",reTicketManagement,"",redemption),
                new SystemRoleItem(SwitchReRedemptionExpert, "تغییر کارشناس بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(AllocateToReRedemptionExpert, "تخصیص کارشناس بازخرید برای تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(TakenReRedemptionExpert, "گرفتن از کارشناس بازخرید برای تیکت بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(ListReRedemption, "مشاهده لیست بازخرید شده ها",
                    "",reRedemptionList,"",redemption),
                new SystemRoleItem(DetailReRedemption, "جزئیات بازخرید",
                    "",reRedemptionList,ListReRedemption,redemption),
                new SystemRoleItem(RedemptionReTicket, "اقدام به خرید تیکت بازخرید",
                    "",reTicketManagement,ListReRedemption,redemption),
                new SystemRoleItem(UndoFromNotAnswerReTicket, "بازگشت تیکت از عدم پاسخ به حالت اول بازخرید",
                    "",reTicketManagement,ListReTicket,redemption),
                new SystemRoleItem(DisplayBoxInReMainPage, "نمایش باکس های صفحه اصلی بازخرید",
                    "",reHome,"",redemption),
                new SystemRoleItem(ReTicketLiveLocationReport, "گزارش تیکت های بازخرید با موفقیت بروزرسانی شد",
                    "",reHome,"",redemption),

                #endregion

                #region Support

                new SystemRoleItem(ShowSupportMainPage, "مشاهده صفحه اصلی پشتیبانی",
                    "",suHome,"",support),
                new SystemRoleItem(ListMiTicketInstalledForSupport, "لیست تیکت های نصب شده پشتیبانی",
                    "",suTicket,"",support),
                new SystemRoleItem(MoneyBackRequestForSupport, "درخواست بازگشت پول پشتیبانی",
                    "",suTicket,"",support),
                new SystemRoleItem(ListSuTicket, "مشاهده لیست تیکت های پشتیبانی",
                    "",suTicket,"",support),
                new SystemRoleItem(ListMiDeclareDelay, "مشاهده لیست اعلام تاخیرهای تیکت نصب انبوه پشتیبانی",
                    "",suDeclareDelay,"",support),
                new SystemRoleItem(ListMiPostalDeclareDelay, "مشاهده لیست اعلام تاخیرهای تیکت پستی پشتیبانی",
                    "",suDeclareDelay,"",support),
                new SystemRoleItem(ListMiMoneyBack, "مشاهده لیست بازگشت های پول تیکت نصب انبوه پشتیبانی",
                    "",suTicket,"",support),
                new SystemRoleItem(ReferenceSuMoneyBackTicketToWl, "ارجاع تیکت به انبار و لجستیک در پشتیبانی",
                    "",suTicket,"",support),

                #endregion

                #region Sale

                new SystemRoleItem(ShowSaleMainPage, "مشاهده صفحه اصلی فروش",
                    "",saHome,"",sale),
                new SystemRoleItem(ListSaleTicket, "مشاهده لیست تیکت های فروش",
                    "",saTicket,"",sale),
                new SystemRoleItem(AddNewSaleTicket, "افزودن تیکت فروش",
                    "",saTicket,ListSaleTicket,sale),
                new SystemRoleItem(DetailSaTicket, "جزئیات تیکت فروش",
                    "",saTicket,ListSaleTicket,sale),
                new SystemRoleItem(ListSaCustomerDocument, "مشاهده لیست مدارک مشتریان فروش",
                    "",saCustomerDocument,"",sale),
                new SystemRoleItem(CheckSaCustomerDocument, "بررسی مدرک مشتری فروش",
                    "",saCustomerDocument,ListSaCustomerDocument,sale),

                #endregion

                #region Financial

                new SystemRoleItem(ShowFinancialMainPage, "مشاهده صفحه اصلی مالی",
                    "",fiHome,"",financial),
                new SystemRoleItem(CheckMiInstallationPayments, "امکان بررسی فیش های پرداختی مالی",
                    "",financialDepartment,ListMiInstallationPayments,financial),
                new SystemRoleItem(ListMiInstallationPayments, "لیست فیش های پرداختی مالی",
                    "",financialDepartment,"",financial),
                new SystemRoleItem(ListReCreditCard, "لیست کارت های اعتباری مالی",
                    "",reFinancial,"",financial),
                new SystemRoleItem(AddNewReCreditCard, "اضافه کردن کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(EditReCreditCard, "ویرایش کردن کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(DeleteReCreditCard, "حذف کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(DetailReCreditCard, "نمایش جزئیات کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(ChangeStatusReCreditCard, "تغییر وضعیت کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(ChangeReCreditCardStatus, "تغییر وضعیت کارت اعتباری مالی",
                    "",reFinancial,ListReCreditCard,financial),
                new SystemRoleItem(ListReRedemptionWaitingForPayment, "نمایش لیست مالی های منتظر پرداخت",
                    "",reFinancial,"",financial),
                new SystemRoleItem(SuccessfulReRedemption, "پرداخت موفق مالی",
                    "",reFinancial,ListReRedemptionWaitingForPayment,financial),
                new SystemRoleItem(ListReRedemptionPayments, "لیست فیش های پرداختی مالی",
                    "",reFinancial,"",financial),
                new SystemRoleItem(ChangeReReferenceNumber, "تغییر شماره مرجع مالی",
                    "",reFinancial,"",financial),

                #endregion

                #region WarehouseAndLogestic
                
                new SystemRoleItem(ShowWarehouseAndLogisticMainPage, "مشاهده صفحه اصلی انبار و لجستیک",
                    "",wlHome,"",warehouseAndLogestic),
                new SystemRoleItem(ListMiModemForWarehouseAndLogistic, "نمایش لیست مودم های انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(DetailMiModemForWarehouseAndLogistic, "نمایش جزئیات مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(EditMiModemForWarehouseAndLogistic, "ویرایش مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(LockOrUnlockMiModemForWarehouseAndLogistic, "قفل یا بازگشایی مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(BirthdayModeMiModemForWarehouseAndLogistic, "حالت تولد مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DeliveryMiModemForWarehouseAndLogistic, "تحویل مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ReceiveReturnedMiModemForWarehouseAndLogistic, "دریافت مودم مرجوعی نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(OperationMiModemForWarehouseAndLogistic, "عملیات بررسی مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(WasteMiModemForWarehouseAndLogistic, "ضایعاتی کردن مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiSimcartForWarehouseAndLogistic, "نمایش لیست سیم کارت های نصب انبوه انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(DetailMiSimcartForWarehouseAndLogistic, "نمایش جزئیات سیم کارت  نصب انبوهانبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(EditMiSimcartForWarehouseAndLogistic, "ویرایش سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(BirthdayModeMiSimcartForWarehouseAndLogistic, "حالت تولد سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(LockOrUnlockMiSimcartForWarehouseAndLogistic, "قفل یا بازگشایی سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DeliveryMiSimcartForWarehouseAndLogistic, "تحویل سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ReceiveReturnedMiSimcartForWarehouseAndLogistic, "دریافت سیم کارت مرجوعی نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(OperationMiSimcartForWarehouseAndLogistic, "عملیات بررسی سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(WasteMiSimcartForWarehouseAndLogistic, "ضایعاتی کردن سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiSimcartForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiPacketForWarehouseAndLogistic, "نمایش لیست بسته های نصب انبوه انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(AddNewMiPacketForWarehouseAndLogistic, "اضافه کردن بسته جدید نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiPacketForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(EditMiPacketForWarehouseAndLogistic, "ویرایش کردن بسته نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiPacketForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DeleteMiPacketForWarehouseAndLogistic, "حذف کردن بسته نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiPacketForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DetailMiPacketForWarehouseAndLogistic, "نمایش جزئیات بسته نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiPacketForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(SendMiPacketsToMobinnetForWarehouseAndLogistic, "ارسال بسته های نصب انبوه به مبین نت انبار و لجستیک",
                    "",miWarehouse,ListMiPacketWaitingSendToMobinnetForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiPacketWaitingSendToMobinnetForWarehouseAndLogistic, "لیست بسته های نصب انبوه منتظر ارسال به مبین نت انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ClosingMiPacketForWarehouseAndLogistic, "بستن بسته مودم های نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiPacketForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ReOutputMiPacketPdfToMobinnetForWarehouseAndLogistic, "خروجی مجدد لیبل کارتن های انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ReOutputReceiptMiWiMaxModemForWarehouseAndLogistic, "خروجی مجدد رسید دریافت مودم های وایمکس انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ReOutputDraftInstallationOutputForWarehouseAndLogistic, "خروجی مجدد حواله خروج انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(AddNewMiEquipmentBorrowedForWarehouseAndLogistic, "افزودن تجهیز امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(EditMiEquipmentBorrowedForWarehouseAndLogistic, "ویرایش تجهیز امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiEquipmentBorrowedForWarehouseAndLogistic, "نمایش لیست تجهیزات امانی انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(DetailMiEquipmentBorrowedForWarehouseAndLogistic, "نمایش جزئیات تجهیز امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DeleteMiEquipmentBorrowedForWarehouseAndLogistic, "حذف تجهیز امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiEquipmentBorrowedAllocationForWarehouseAndLogistic, "لیست تجهیزات امانی در دست کارشناس انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ReceiveMiEquipmentBorrowedFromInstallationExpertForWarehouseAndLogistic, "دریافت تجهیز امانی از کارشناس انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedAllocationForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(DeliveryMiEquipmentBorrowedToInstallationExpertForWarehouseAndLogistic, "تحویل تجهیز امانی به کارشناس انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(WasteOrFreeMiEquipmentBorrowedForWarehouseAndLogistic, "آزاد یا ضایعاتی کردن تجهیز امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ChangeStatusMiEquipmentBorrowedForWarehouseAndLogistic, "تغییر وضعیت تجهیزات امانی انبار و لجستیک",
                    "",miWarehouse,ListMiEquipmentBorrowedForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ReceiveMiWiMaxModemForWarehouseAndLogistic, "دریافت مودم وایمکس نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiWiMaxModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListMiWiMaxModemForWarehouseAndLogistic, "نمایش لیست مودم وایمکس نصب انبوه انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(DetailMiWiMaxModemForWarehouseAndLogistic, "نمایش جزئیات مودم وایمکس نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiWiMaxModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(OperationMiWiMaxModemForWarehouseAndLogistic, "عملیات مودم وایمکس نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiWiMaxModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(EditMiWiMaxModemForWarehouseAndLogistic, "ویرایش مودم وایمکس نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiWiMaxModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(UndoMiWiMaxModemForWarehouseReviewForWarehouseAndLogistic, "بازگشت مودم وایمکس نصب انبوه انبار و لجستیک برای بررسی",
                    "",miWarehouse,ListMiWiMaxModemForWarehouseAndLogistic,warehouseAndLogestic),
                new SystemRoleItem(ListPostalTicket, "مشاهده لیست تیکت های پستی انبار و لجستیک",
                    "",wlTicket,"",warehouseAndLogestic),
                new SystemRoleItem(PostalAllocationTicket, "تخصیص تیکت های پستی انبار و لجستیک",
                    "",wlTicket,ListPostalTicket,warehouseAndLogestic),
                new SystemRoleItem(ListMiBatchModem, "لیست دسته ی مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ImportMiBatchModem, "ایمپورت دسته ی مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiBatchModem,warehouseAndLogestic),
                new SystemRoleItem(DeleteMiBatchModem, "حذف دسته ی مودم نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiBatchModem,warehouseAndLogestic),
                new SystemRoleItem(ListMiBatchSimcart, "لیست دسته ی سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,"",warehouseAndLogestic),
                new SystemRoleItem(ImportMiBatchSimcart, "ایمپورت دسته ی سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiBatchSimcart,warehouseAndLogestic),
                new SystemRoleItem(DeleteMiBatchSimcart, "حذف دسته ی سیم کارت نصب انبوه انبار و لجستیک",
                    "",miWarehouse,ListMiBatchSimcart,warehouseAndLogestic),
                new SystemRoleItem(ListMiPostalMoneyBack, "مشاهده لیست بازگشت های پول تیکت پستی پشتیبانی انبار و لجستیک",
                    "",suTicket,"",warehouseAndLogestic),
                new SystemRoleItem(DetailPostalTicketForWl, "جزئیات تیکت پستی انبار و لجستیک",
                    "",wlTicket,ListPostalTicket,warehouseAndLogestic),
                new SystemRoleItem(AllocationMiPostalTicketToMiPostalCompany, "تخصیص تیکت به شرکت پستی انبار و لجستیک",
                    "",wlTicket,ListPostalTicket,warehouseAndLogestic),
                new SystemRoleItem(ListRePacket, "نمایش لیست بسته های بازخرید انبار و لجستیک",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(AddNewRePacket, "اضافه کردن بسته جدید بازخرید انبار و لجستیک",
                    "",reStore,ListRePacket,warehouseAndLogestic),
                new SystemRoleItem(EditRePacket, "ویرایش کردن بسته بازخرید انبار و لجستیک",
                    "",reStore,ListRePacket,warehouseAndLogestic),
                new SystemRoleItem(DeleteRePacket, " انبار و لجستیکحذف کردن بسته بازخرید",
                    "",reStore,ListRePacket,warehouseAndLogestic),
                new SystemRoleItem(DetailRePacket, "نمایش جزئیات بسته بازخرید انبار و لجستیک",
                    "",reStore,ListRePacket,warehouseAndLogestic),
                new SystemRoleItem(SendRePacketsToMobinnet, " انبار و لجستیکارسال بسته ها به مبین نت بازخرید",
                    "",reStore,ListRePacketWaitingSendToMobinnet,warehouseAndLogestic),
                new SystemRoleItem(ListReModem, "نمایش لیست مودم های بازخرید انبار و لجستیک",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(DetailReModem, "جزئیات مودم بازخرید انبار و لجستیک",
                    "",reStore,ListReModem,warehouseAndLogestic),
                new SystemRoleItem(EditReModem, "ویرایش مودم بازخرید انبار و لجستیک",
                    "",reStore,ListReModem,warehouseAndLogestic),
                new SystemRoleItem(GetReModemFromRedemptionExpert, "گرفتن مودم از کارشناس بازخرید انبار و لجستیک",
                    "",reStore,ListReModem,warehouseAndLogestic),
                new SystemRoleItem(OperationReModem, "بررسی وضعیت مودم های بازخرید انبار و لجستیک",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(ListRePacketWaitingSendToMobinnet, "لیست بسته های منتظر ارسال به مبین نت بازخرید",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(ClosingRePacket, "بستن بسته مودم ها بازخرید",
                    "",reStore,ListRePacket,warehouseAndLogestic),
                new SystemRoleItem(UndoReModemForWarehouseReview, "برگرداندن مودم به وضعیت بررسی توسط مسئول انبار بازخرید",
                    "",reStore,ListReModem,warehouseAndLogestic),
                new SystemRoleItem(ReOutputRePacketPdfToMobinnet, "خروجی مجدد لیبل کارتن های بازخرید",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(ReOutputReceiptReModem, "خروجی مجدد رسید دریافت مودم های بازخرید",
                    "",reStore,"",warehouseAndLogestic),
                new SystemRoleItem(ReOutputDraftRedemptionOutput, "خروجی مجدد حواله خروج بازخرید",
                    "",reStore,"",warehouseAndLogestic),
                #endregion

                #region PerformanceEvaluation

                new SystemRoleItem(ShowPerformanceEvaluationMainPage, "مشاهده صفحه اصلی ارزیابی عملکرد",
                    "",peHome,"",performanceEvaluation),
                new SystemRoleItem(ListPeCourse, "مشاهده لیست دوره های آموزشی ارزیابی عملکرد",
                    "",peCourse,"",performanceEvaluation),
                new SystemRoleItem(AddNewPeCourse, "افزودن دوره آموزشی ارزیابی عملکرد",
                    "",peCourse,ListPeCourse,performanceEvaluation),
                new SystemRoleItem(ListPeCourseQuestion, "مشاهده لیست سوالات دوره آموزشی ارزیابی عملکرد",
                    "",peCourse,"",performanceEvaluation),
                new SystemRoleItem(AddNewPeCourseQuestion, "افزودن سوالات دوره آموزشی ارزیابی عملکرد",
                    "",peCourse,ListPeCourseQuestion,performanceEvaluation),
                new SystemRoleItem(ListPeSurvey, "مشاهده لیست نظرسنجی ارزیابی عملکرد",
                    "",peSurvey,"",performanceEvaluation),
                new SystemRoleItem(AddNewPeSurvey, "افزودن نظرسنجی ارزیابی عملکرد",
                    "",peSurvey,ListPeSurvey,performanceEvaluation),
                new SystemRoleItem(ListPeSurveyQuestion, "مشاهده لیست سوالات نظرسنجی ارزیابی عملکرد",
                    "",peSurvey,"",performanceEvaluation),
                new SystemRoleItem(AddNewPeSurveyQuestion, "افزودن سوالات نظرسنجی ارزیابی عملکرد",
                    "",peSurvey,ListPeSurveyQuestion,performanceEvaluation),
                new SystemRoleItem(DetailPeCourse, "جزئیات دوره آموزشی ارزیابی عملکرد",
                    "",peCourse,ListPeCourse,performanceEvaluation),
                new SystemRoleItem(EditPeCourse, "ویرایش دوره آموزشی ارزیابی عملکرد",
                    "",peCourse,ListPeCourse,performanceEvaluation),

                #endregion

                #region BasicSetting

                new SystemRoleItem(ShowBasicSettingMainPage, "مشاهده صفحه اصلی تنظیمات پایه",
                    "",bsHome,"",basicSetting),
                new SystemRoleItem(ShowShSetting, "نمایش تنظیمات عمومی تنظیمات پایه",
                    "",shSetting,"",basicSetting),
                new SystemRoleItem(EditShSetting, "ویرایش تنظیمات عمومی تنظیمات پایه",
                    "",shSetting,ShowShSetting,basicSetting),
                new SystemRoleItem(ListShLogs, "نمایش لیست لاگ های تنظیمات پایه",
                    "",shLog,"",basicSetting),
                new SystemRoleItem(DeleteShLog, "حذف لاگ تنظیمات پایه",
                    "",shLog,ListShLogs,basicSetting),
                new SystemRoleItem(ListShProvince, "لیست استان های مبین نت در تنظیمات پایه",
                    "",shProvince,"",basicSetting),
                new SystemRoleItem(DetailShProvince, "نمایش جزئیات استان های مبین نت در تنظیمات پایه",
                    "",shProvince,ListShProvince,basicSetting),
                new SystemRoleItem(ListShCity, "لیست شهرهای مبین نت در تنظیمات پایه",
                    "",shCity,"",basicSetting),
                new SystemRoleItem(DetailShCity, "نمایش جزئیات شهر مبین نت در تنظیمات پایه",
                    "",shCity,ListShCity,basicSetting),
                new SystemRoleItem(EditShCity, "ویرایش شهر مبین نت در تنظیمات پایه",
                    "",shCity,ListShCity,basicSetting),
                new SystemRoleItem(SendFireBaseNotification, "فرستادن نوتیفیکیشن فایربیس در تنظیمات پایه",
                    "",umInformationManagement,"",basicSetting),
                new SystemRoleItem(ListMiCoordinationTime, "لیست زمان های هماهنگی نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,"",basicSetting),
                new SystemRoleItem(DetailMiCoordinationTime, "نمایش جزئیات زمان هماهنگی نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiCoordinationTime,basicSetting),
                new SystemRoleItem(ListMiPlan, "لیست طرح های تیکت نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,"",basicSetting),
                new SystemRoleItem(AddNewMiPlan, "اضافه کردن طرح تیکت نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiPlan,basicSetting),
                new SystemRoleItem(EditMiPlan, "ویرایش کردن طرح تیکت نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiPlan,basicSetting),
                new SystemRoleItem(DeleteMiPlan, "حذف طرح تیکت نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiPlan,basicSetting),
                new SystemRoleItem(DetailMiPlan, "نمایش جزئیات تیکت نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiPlan,basicSetting),
                new SystemRoleItem(ListMiDocuments, "لیست اسناد نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,"",basicSetting),
                new SystemRoleItem(DetailMiDocument, "جزئیات سند نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiDocuments,basicSetting),
                new SystemRoleItem(ChangeStatusMiCoordinationTime, "تغییر وضعیت زمان هماهنگی نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiCoordinationTime,basicSetting),
                new SystemRoleItem(AddNewMiCoordinationTime, "افزودن زمان هماهنگی حضوری نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiCoordinationTime,basicSetting),
                new SystemRoleItem(DeleteMiCoordinationTime, "حذف زمان هماهنگی حضوری نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiCoordinationTime,basicSetting),
                new SystemRoleItem(EditMiCoordinationTime, "ویرایش زمان هماهنگی حضوری نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiCoordinationTime,basicSetting),
                new SystemRoleItem(AddNewMiEquipmentModel, "افزودن مدل تجهیزات جدید نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiEquipmentModel,basicSetting),
                new SystemRoleItem(EditMiEquipmentModel, "ویرایش مدل های تجهیزات نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiEquipmentModel,basicSetting),
                new SystemRoleItem(ListMiEquipmentModel, "لیست مدل های تجهیزات نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,"",basicSetting),
                new SystemRoleItem(DeleteMiEquipmentModel, "حذف مدل های تجهیزات نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiEquipmentModel,basicSetting),
                new SystemRoleItem(DetailMiEquipmentModel, "جزئیات مدل های تجهیزات نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiEquipmentModel,basicSetting),
                new SystemRoleItem(ChangeStatusMiEquipmentModel, "تغییر وضعیت مدل تجهیزات نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiEquipmentModel,basicSetting),
                new SystemRoleItem(AddNewMiContradictionPlan, "افزودن مغایرت طرح جدید نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiContradictionPlan,basicSetting),
                new SystemRoleItem(EditMiContradictionPlan, "ویرایش مغایرت طرح نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiContradictionPlan,basicSetting),
                new SystemRoleItem(ListMiContradictionPlan, "لیست مغایرت های طرح نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,"",basicSetting),
                new SystemRoleItem(DeleteMiContradictionPlan, "حذف مغایرت طرح نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiContradictionPlan,basicSetting),
                new SystemRoleItem(DetailMiContradictionPlan, "جزئیات مغایرت طرح نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiContradictionPlan,basicSetting),
                new SystemRoleItem(ChangeStatusMiContradictionPlan, "تغییر وضعیت مغایرت طرح نصب انبوه در تنظیمات پایه",
                    "",miInformationManagement,ListMiContradictionPlan,basicSetting),
                new SystemRoleItem(AddNewReModemModel, "افزودن مدل مودم جدید بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReModemModel,basicSetting),
                new SystemRoleItem(EditReModemModel, "ویرایش مدل های مودم بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReModemModel,basicSetting),
                new SystemRoleItem(ListReModemModel, "لیست مدل های مودم بازخرید در تنظیمات پایه",
                    "",reInformationManagement,"",basicSetting),
                new SystemRoleItem(DetailReModemModel, "نمایش جزئیات مدل مودم بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReModemModel,basicSetting),
                new SystemRoleItem(DeleteReModemModel, "حذف مدل های مودم بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReModemModel,basicSetting),
                new SystemRoleItem(DetailReCoordinationTime, "نمایش جزئیات زمان های هماهنگی بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReCoordinationTime,basicSetting),
                new SystemRoleItem(ListReCoordinationTime, "لیست زمان های هماهنگی بازخرید در تنظیمات پایه",
                    "",reInformationManagement,"",basicSetting),
                new SystemRoleItem(ChangeReCoordinationTimeStatus, "تغییر وضعیت زمان هماهنگی بازخرید در تنظیمات پایه",
                    "",reInformationManagement,ListReCoordinationTime,basicSetting),
                new SystemRoleItem(ListSuCoordinationTime, "لیست زمان های هماهنگی پشتیبانی در تنظیمات پایه",
                    "",suInformationManagement,"",basicSetting),
                new SystemRoleItem(ChangeStatusSuCoordinationTime, "تغییر وضعیت زمان هماهنگی پشتیبانی در تنظیمات پایه",
                    "",suInformationManagement,ListSuCoordinationTime,basicSetting),
                new SystemRoleItem(ListMiPostalCoordinationTime, "مشاهده لیست زمان های هماهنگی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,"",basicSetting),
                new SystemRoleItem(ChangeStatusMiPostalCoordinationTime, "تغییر وضعیت زمان هماهنگی انبار و لجستیک در تنظیمات پایه",
                    ListMiPostalCoordinationTime,wlInformationManagement,ListMiPostalCoordinationTime,basicSetting),
                new SystemRoleItem(ListMiPostalCompany, "مشاهده لیست شرکت های پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,"",basicSetting),
                new SystemRoleItem(ChangeStatusMiPostalCompany, "تغییر وضعیت شرکت پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,ListMiPostalCompany,basicSetting),
                new SystemRoleItem(AddNewMiPostalCompany, "اضافه کردن شرکت پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,ListMiPostalCompany,basicSetting),
                new SystemRoleItem(DetailMiPostalCompany, "جزئیات شرکت پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,ListMiPostalCompany,basicSetting),
                new SystemRoleItem(DeleteMiPostalCompany, "حذف شرکت پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,ListMiPostalCompany,basicSetting),
                new SystemRoleItem(EditMiPostalCompany, "ویرایش شرکت پستی انبار و لجستیک در تنظیمات پایه",
                    "",wlInformationManagement,ListMiPostalCompany,basicSetting),
                new SystemRoleItem(ListShSystemLog, "مشاهده لیست لاگ های سیستم",
                    "",shSystemLog,"",basicSetting),
                new SystemRoleItem(DownloadShSystemLogFile, "دانلود فایل لاگ های سیستم",
                    "",shSystemLog,ListShSystemLog,basicSetting),
                #endregion

                #region General

                new SystemRoleItem(ReRedemptionExpert, "کارشناس بازخرید",
                    "",general,"",shGeneral),
                new SystemRoleItem(MiInstallationExpert, "کارشناس نصب انبوه",
                    "",general,"",shGeneral),
                new SystemRoleItem(SaSaleExpert, "کارشناس فروش",
                    "",general,"",shGeneral),
                new SystemRoleItem(ShowMyProfile, "نمایش اطلاعات حساب کاربری شخص",
                    "",profile,"",shGeneral),
                new SystemRoleItem(ChangeMyPassword, "تغییر کلمه عبور هر شخص برای خودش",
                    "",profile,"",shGeneral),
                new SystemRoleItem(SupporterReTicket, "مسئول پشتیبانی تیکت های بازخرید مبین نت",
                    "",general,"",shGeneral),
                new SystemRoleItem(ReceiveSmsAfterSuccessfulReRedemption, "دریافت پیامک بعد از بازخرید موفق",
                    "",general,"",shGeneral),
                new SystemRoleItem(ListUserCourse, "مشاهده لیست دوره های آموزشی کاربر",
                    "",peUserCourse,"",shGeneral),
                new SystemRoleItem(JoinUserToCourse, "شرکت کاربر در آزمون دوره آموزشی",
                    "",peUserCourse,"",shGeneral),
                new SystemRoleItem(PostalInstallationExpert, "کارشناس نصب پستی",
                    "",general,"",shGeneral),
                new SystemRoleItem(ShopOrderRobot, "ربات سفارش فروشگاه",
                    "",general,"",shGeneral),

                #endregion
            };
        }

        public static IEnumerable<SystemRoleItem> GetAll => SystemRolesLazy.Value;

        #region UserManagement

        public const string ShowUserManagementMainPage = "ShowUserManagementMainPage";
        public const string ShowUmRoles = "ShowUmRoles";
        public const string DetailUmRole = "DetailUmRole";
        public const string ShowUmGroups = "ShowUmGroups";
        public const string DetailUmGroup = "DetailUmGroup";
        public const string ShowUmUsers = "ShowUmUsers";
        public const string AddNewUmGroup = "AddNewUmGroup";
        public const string DeleteUmGroup = "DeleteUmGroup";
        public const string AddNewUmUser = "AddNewUmUser";
        public const string EditUmGroup = "EditUmGroup";
        public const string ChangeUmGroupStatus = "ChangeUmGroupStatus";
        public const string EditUmUser = "EditUmUser";
        public const string DeleteUmUser = "DeleteUmUser";
        public const string ChangeUmUserPassword = "ChangeUmUserPassword";
        public const string UploadAvatarUmUser = "UploadAvatarUmUser";
        public const string CoordinateUmUser = "CoordinateUmUser";
        public const string TotalCoordinateUmUser = "TotalCoordinateUmUser";
        public const string UploadSignatureUmUser = "UploadSignatureUmUser";
        public const string ConfirmUmUserPhoneNumber = "ConfirmUmUserPhoneNumber";
        public const string FiredUmUser = "FiredUmUser";
        public const string InactiveUmUser = "InactiveUmUser";
        public const string ActiveUmUser = "ActiveUmUser";
        public const string ChangeUmUserSignature = "ChangeUmUserSignature";
        public const string ConfirmOrRejectUmUserSignature = "ConfirmOrRejectUmUserSignature";
        public const string DisplayBoxInUmMainPage = "DisplayBoxInUmMainPage";
        public const string UmExpertLiveLocationReport = "UmExpertLiveLocationReport";

        #endregion

        #region MassInstallation

        public const string ShowMassInstallationMainPage = "ShowMassInstallationMainPage";
        public const string ListMiModem = "ListMiModem";
        public const string DetailMiModem = "DetailMiModem";
        public const string EditMiModem = "EditMiModem";
        public const string ListMiSimcart = "ListMiSimcart";
        public const string DetailMiSimcart = "DetailMiSimcart";
        public const string EditMiSimcart = "EditMiSimcart";
        public const string LockOrUnlockMiModem = "LockOrUnlockMiModem";
        public const string BirthdayModeMiModem = "BirthdayModeMiModem";
        public const string BirthdayModeMiSimcart = "BirthdayModeMiSimcart";
        public const string LockOrUnlockMiSimcart = "LockOrUnlockMiSimcart";
        public const string ListMiTicket = "ListMiTicket";
        public const string AddNewMiTicket = "AddNewMiTicket";
        public const string EditMiTicket = "EditMiTicket";
        public const string DeleteMiTicket = "DeleteMiTicket";
        public const string DetailMiTicket = "DetailMiTicket";
        public const string CoordinateMiTicket = "CoordinateMiTicket";
        public const string BirthdayModeMiTicket = "BirthdayModeMiTicket";
        public const string LockOrUnlockMiTicket = "LockOrUnlockMiTicket";
        public const string SwitchMiInstallationExpert = "SwitchMiInstallationExpert";
        public const string AllocateToMiInstallationExpert = "AllocateToMiInstallationExpert";
        public const string TakenMiInstallationExpert = "TakenMiInstallationExpert";
        public const string UndoFromNotAnswerMiTicket = "UndoFromNotAnswerMiTicket";
        public const string OperationMiTicket = "OperationMiTicket";
        public const string CoordinationMiTicket = "CoordinationMiTicket";
        public const string ListMiInstallation = "ListMiInstallation";
        public const string DetailMiInstallation = "DetailMiInstallation";
        public const string MiOutputDraftInstallationOutput = "MiOutputDraftInstallationOutput";
        public const string ChangeStatusMiCoordinationTime = "ChangeStatusMiCoordinationTime";
        public const string DisplayBoxInMiMainPage = "DisplayBoxInMiMainPage";
        public const string ListActivationMiTicket = "ListActivationMiTicket";
        public const string ManualActivationMiTicket = "ManualActivationMiTicket";
        public const string MassInstallationDoOppositeOfRobot = "MassInstallationDoOppositeOfRobot";
        public const string ListCancelledMiInstallation = "ListCancelledMiInstallation";
        public const string ListCancelDueToSignalWeaknessFor360 = "ListCancelDueToSignalWeaknessFor360";
        public const string ConfirmCancelledMiInstallation = "ConfirmCancelledMiInstallation";
        public const string MiInstallation360SignalWeaknessConfirm = "MiInstallation360SignalWeaknessConfirm";
        public const string MiOperationRobot = "MiOperationRobot";
        public const string MiFetchRobot = "MiFetchRobot";
        public const string MiCancellationRobot = "MiCancellationRobot";
        public const string ListOmbArchives = "ListOmbArchives";
        public const string MiTicketManualActivationByRobot = "MiTicketManualActivationByRobot";
        public const string DetailOmbArchive = "DetailOmbArchive";
        public const string MiTicketLiveLocationReport = "MiTicketLiveLocationReport";
        public const string GetMiTicketStatusBasedOnProvinceReport = "GetMiTicketStatusBasedOnProvinceReport";
        public const string GetMiTicketDensityAndEfficiencyReport = "GetMiTicketDensityAndEfficiencyReport";
        public const string MiReportTicket = "MiReportTicket";
        public const string DetailMiReportTicket = "DetailMiReportTicket";
        public const string CoordinatePostalTicket = "CoordinatePostalTicket";
        public const string ManualActivationMiPostalTicket = "ManualActivationMiPostalTicket";
        public const string OperationMiPostalTicket = "OperationMiPostalTicket";
        public const string ListActivationMiPostalTicket = "ListActivationMiPostalTicket";
        public const string DetailPostalTicket = "DetailPostalTicket";
        public const string TrackMiPostalTicket = "TrackMiPostalTicket";
        public const string BirthdayModeMiPostalTicket = "BirthdayModeMiPostalTicket";
        public const string CancellationDueToInabilityToCallMiPostalTicket = "CancellationDueToInabilityToCallMiPostalTicket";
        public const string ConvertToMiPostalTicket = "ConvertToMiPostalTicket";
        public const string ConvertToMiTicket = "ConvertToMiTicket";
        public const string ListMiTicketInstallationExpertCallLog = "ListMiTicketInstallationExpertCallLog";
        public const string DownloadInstallationInvoice = "DownloadInstallationInvoice";
        public const string MobinnetPerformanceMiReport = "MobinnetPerformanceMiReport";
        public const string MobinnetPerformanceMiReportExcelFile = "MobinnetPerformanceMiReportExcelFile";
        #endregion

        #region Redemption

        public const string ShowRedemptionEquipmentMainPage = "ShowRedemptionEquipmentMainPage";
        public const string ImportReBatchTicket = "ImportReBatchTicket";
        public const string ListReBatchTicket = "ListReBatchTicket";
        public const string DeleteReBatchTicket = "DeleteReBatchTicket";
        public const string ReBatchTicketDetail = "ReBatchTicketDetail";
        public const string EditReTicket = "EditReTicket";
        public const string ListReTicket = "ListReTicket";
        public const string DeleteReTicket = "DeleteReTicket";
        public const string DetailReTicket = "DetailReTicket";
        public const string CoordinateReTicket = "CoordinateReTicket";
        public const string BirthdayModeReTicket = "BirthdayModeReTicket";
        public const string LockOrUnlockReTicket = "LockOrUnlockReTicket";
        public const string ExportReBatchTicketFile = "ExportReBatchTicketFile";
        public const string SwitchReRedemptionExpert = "SwitchReRedemptionExpert";
        public const string AllocateToReRedemptionExpert = "AllocateToReRedemptionExpert";
        public const string TakenReRedemptionExpert = "TakenReRedemptionExpert";
        public const string ListReRedemption = "ListReRedemption";
        public const string DetailReRedemption = "DetailReRedemption";
        public const string RedemptionReTicket = "RedemptionReTicket";
        public const string ListRePacket = "ListRePacket";
        public const string AddNewRePacket = "AddNewRePacket";
        public const string EditRePacket = "EditRePacket";
        public const string DeleteRePacket = "DeleteRePacket";
        public const string DetailRePacket = "DetailRePacket";
        public const string SendRePacketsToMobinnet = "SendRePacketsToMobinnet";
        public const string ListReModem = "ListReModem";
        public const string DetailReModem = "DetailReModem";
        public const string EditReModem = "EditReModem";
        public const string GetReModemFromRedemptionExpert = "GetReModemFromRedemptionExpert";
        public const string OperationReModem = "OperationReModem";
        public const string UndoFromNotAnswerReTicket = "UndoFromNotAnswerReTicket";
        public const string ListRePacketWaitingSendToMobinnet = "ListRePacketWaitingSendToMobinnet";
        public const string ClosingRePacket = "ClosingRePacket";
        public const string UndoReModemForWarehouseReview = "UndoReModemForWarehouseReview";
        public const string ReOutputRePacketPdfToMobinnet = "ReOutputRePacketPdfToMobinnet";
        public const string ReOutputReceiptReModem = "ReOutputReceiptReModem";
        public const string ReOutputDraftRedemptionOutput = "ReOutputDraftRedemptionOutput";
        public const string DisplayBoxInReMainPage = "DisplayBoxInReMainPage";
        public const string ReTicketLiveLocationReport = "ReTicketLiveLocationReport";

        #endregion

        #region Support

        public const string ShowSupportMainPage = "ShowSupportMainPage";
        public const string ListMiTicketInstalledForSupport = "ListMiTicketInstalledForSupport";
        public const string MoneyBackRequestForSupport = "MoneyBackRequestForSupport";
        public const string ListSuTicket = "ListSuTicket";
        public const string ListMiDeclareDelay = "ListMiDeclareDelay";
        public const string ListMiPostalDeclareDelay = "ListMiPostalDeclareDelay";
        public const string ListMiMoneyBack = "ListMiMoneyBack";
        public const string ReferenceSuMoneyBackTicketToWl = "ReferenceSuMoneyBackTicketToWl";

        #endregion

        #region Sale

        public const string ShowSaleMainPage = "ShowSaleMainPage";
        public const string ListSaleTicket = "ListSaleTicket";
        public const string AddNewSaleTicket = "AddNewSaleTicket";
        public const string DetailSaTicket = "DetailSaTicket";
        public const string ListSaCustomerDocument = "ListSaCustomerDocument";
        public const string CheckSaCustomerDocument = "CheckSaCustomerDocument";

        #endregion

        #region Financial

        public const string ShowFinancialMainPage = "ShowFinancialMainPage";
        public const string CheckMiInstallationPayments = "CheckMiInstallationPayments";
        public const string ListMiInstallationPayments = "ListMiInstallationPayments";
        public const string ListReCreditCard = "ListReCreditCard";
        public const string AddNewReCreditCard = "AddNewReCreditCard";
        public const string EditReCreditCard = "EditReCreditCard";
        public const string DeleteReCreditCard = "DeleteReCreditCard";
        public const string DetailReCreditCard = "DetailReCreditCard";
        public const string ChangeStatusReCreditCard = "ChangeStatusReCreditCard";
        public const string ChangeReCreditCardStatus = "ChangeReCreditCardStatus";
        public const string ListReRedemptionWaitingForPayment = "ListReRedemptionWaitingForPayment";
        public const string SuccessfulReRedemption = "SuccessfulReRedemption";
        public const string ChangeReReferenceNumber = "ChangeReReferenceNumber";
        public const string ListReRedemptionPayments = "ListReRedemptionPayments";

        #endregion

        #region WarehouseAndLogestic

        public const string ShowWarehouseAndLogisticMainPage = "ShowWarehouseAndLogisticMainPage";
        public const string ListMiModemForWarehouseAndLogistic = "ListMiModemForWarehouseAndLogistic";
        public const string DetailMiModemForWarehouseAndLogistic = "DetailMiModemForWarehouseAndLogistic";
        public const string EditMiModemForWarehouseAndLogistic = "EditMiModemForWarehouseAndLogistic";
        public const string LockOrUnlockMiModemForWarehouseAndLogistic = "LockOrUnlockMiModemForWarehouseAndLogistic";
        public const string BirthdayModeMiModemForWarehouseAndLogistic = "BirthdayModeMiModemForWarehouseAndLogistic";
        public const string DeliveryMiModemForWarehouseAndLogistic = "DeliveryMiModemForWarehouseAndLogistic";
        public const string ReceiveReturnedMiModemForWarehouseAndLogistic = "ReceiveReturnedMiModemForWarehouseAndLogistic";
        public const string WasteMiModemForWarehouseAndLogistic = "WasteMiModemForWarehouseAndLogistic";
        public const string OperationMiModemForWarehouseAndLogistic = "OperationMiModemForWarehouseAndLogistic";
        public const string ListMiSimcartForWarehouseAndLogistic = "ListMiSimcartForWarehouseAndLogistic";
        public const string DetailMiSimcartForWarehouseAndLogistic = "DetailMiSimcartForWarehouseAndLogistic";
        public const string EditMiSimcartForWarehouseAndLogistic = "EditMiSimcartForWarehouseAndLogistic";
        public const string BirthdayModeMiSimcartForWarehouseAndLogistic = "BirthdayModeMiSimcartForWarehouseAndLogistic";
        public const string LockOrUnlockMiSimcartForWarehouseAndLogistic = "LockOrUnlockMiSimcartForWarehouseAndLogistic";
        public const string DeliveryMiSimcartForWarehouseAndLogistic = "DeliveryMiSimcartForWarehouseAndLogistic";
        public const string ReceiveReturnedMiSimcartForWarehouseAndLogistic = "ReceiveReturnedMiSimcartForWarehouseAndLogistic";
        public const string OperationMiSimcartForWarehouseAndLogistic = "OperationMiSimcartForWarehouseAndLogistic";
        public const string WasteMiSimcartForWarehouseAndLogistic = "WasteMiSimcartForWarehouseAndLogistic";
        public const string ListMiPacketForWarehouseAndLogistic = "ListMiPacketForWarehouseAndLogistic";
        public const string AddNewMiPacketForWarehouseAndLogistic = "AddNewMiPacketForWarehouseAndLogistic";
        public const string EditMiPacketForWarehouseAndLogistic = "EditMiPacketForWarehouseAndLogistic";
        public const string DeleteMiPacketForWarehouseAndLogistic = "DeleteMiPacketForWarehouseAndLogistic";
        public const string DetailMiPacketForWarehouseAndLogistic = "DetailMiPacketForWarehouseAndLogistic";
        public const string SendMiPacketsToMobinnetForWarehouseAndLogistic = "SendMiPacketsToMobinnetForWarehouseAndLogistic";
        public const string ListMiPacketWaitingSendToMobinnetForWarehouseAndLogistic = "ListMiPacketWaitingSendToMobinnetForWarehouseAndLogistic";
        public const string ClosingMiPacketForWarehouseAndLogistic = "ClosingMiPacketForWarehouseAndLogistic";
        public const string ReOutputReceiptMiWiMaxModemForWarehouseAndLogistic = "ReOutputReceiptMiWiMaxModemForWarehouseAndLogistic ";
        public const string ReOutputMiPacketPdfToMobinnetForWarehouseAndLogistic = "ReOutputMiPacketPdfToMobinnetForWarehouseAndLogistic ";
        public const string ReOutputDraftInstallationOutputForWarehouseAndLogistic = "ReOutputDraftInstallationOutputForWarehouseAndLogistic";
        public const string AddNewMiEquipmentBorrowedForWarehouseAndLogistic = "AddNewMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string EditMiEquipmentBorrowedForWarehouseAndLogistic = "EditMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string ListMiEquipmentBorrowedForWarehouseAndLogistic = "ListMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string DetailMiEquipmentBorrowedForWarehouseAndLogistic = "DetailMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string DeleteMiEquipmentBorrowedForWarehouseAndLogistic = "DeleteMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string ListMiEquipmentBorrowedAllocationForWarehouseAndLogistic = "ListMiEquipmentBorrowedAllocationForWarehouseAndLogistic";
        public const string ReceiveMiEquipmentBorrowedFromInstallationExpertForWarehouseAndLogistic = "ReceiveMiEquipmentBorrowedFromInstallationExpertForWarehouseAndLogistic";
        public const string DeliveryMiEquipmentBorrowedToInstallationExpertForWarehouseAndLogistic = "DeliveryMiEquipmentBorrowedToInstallationExpertForWarehouseAndLogistic";
        public const string WasteOrFreeMiEquipmentBorrowedForWarehouseAndLogistic = "WasteOrFreeMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string ChangeStatusMiEquipmentBorrowedForWarehouseAndLogistic = "ChangeStatusMiEquipmentBorrowedForWarehouseAndLogistic";
        public const string ListMiWiMaxModemForWarehouseAndLogistic = "ListMiWiMaxModemForWarehouseAndLogistic";
        public const string DetailMiWiMaxModemForWarehouseAndLogistic = "DetailMiWiMaxModemForWarehouseAndLogistic";
        public const string OperationMiWiMaxModemForWarehouseAndLogistic = "OperationMiWiMaxModemForWarehouseAndLogistic";
        public const string ReceiveMiWiMaxModemForWarehouseAndLogistic = "ReceiveMiWiMaxModemForWarehouseAndLogistic";
        public const string EditMiWiMaxModemForWarehouseAndLogistic = "EditMiWiMaxModemForWarehouseAndLogistic";
        public const string UndoMiWiMaxModemForWarehouseReviewForWarehouseAndLogistic = "UndoMiWiMaxModemForWarehouseReviewForWarehouseAndLogistic";
        public const string ListPostalTicket = "ListPostalTicket";
        public const string PostalAllocationTicket = "PostalAllocationTicket";
        public const string ListMiBatchModem = "ListMiBatchModem";
        public const string ImportMiBatchModem = "ImportMiBatchModem";
        public const string DeleteMiBatchModem = "DeleteMiBatchModem";
        public const string ListMiBatchSimcart = "ListMiBatchSimcart";
        public const string ImportMiBatchSimcart = "ImportMiBatchSimcart";
        public const string DeleteMiBatchSimcart = "DeleteMiBatchSimcart";
        public const string ListMiPostalMoneyBack = "ListMiPostalMoneyBack";
        public const string DetailPostalTicketForWl = "DetailPostalTicketForWl";
        public const string AllocationMiPostalTicketToMiPostalCompany = "AllocationMiPostalTicketToMiPostalCompany";

        #endregion

        #region PerformanceEvaluation

        public const string ShowPerformanceEvaluationMainPage = "ShowPerformanceEvaluationMainPage";
        public const string ListPeCourse = "ListPeCourse";
        public const string AddNewPeCourse = "AddNewPeCourse";
        public const string ListPeCourseQuestion = "ListPeCourseQuestion";
        public const string AddNewPeCourseQuestion = "AddNewPeCourseQuestion";
        public const string ListPeSurvey = "ListPeSurvey";
        public const string AddNewPeSurvey = "AddNewPeSurvey";
        public const string ListPeSurveyQuestion = "ListPeSurveyQuestion";
        public const string AddNewPeSurveyQuestion = "AddNewPeSurveyQuestion";
        public const string DetailPeCourse = "DetailPeCourse";
        public const string EditPeCourse = "EditPeCourse";

        #endregion

        #region BasicSetting

        public const string ShowBasicSettingMainPage = "ShowBasicSettingMainPage";
        public const string ShowShSetting = "ShowShSetting";
        public const string EditShSetting = "EditShSetting";
        public const string ListShLogs = "ListShLogs";
        public const string DeleteShLog = "DeleteShLog";
        public const string DetailShProvince = "DetailShProvince";
        public const string ListShProvince = "ListShProvince";
        public const string DetailShCity = "DetailShCity";
        public const string ListShCity = "ListShCity";
        public const string EditShCity = "EditShCity";
        public const string SendFireBaseNotification = "SendFireBaseNotification";
        public const string ListMiCoordinationTime = "ListMiCoordinationTime";
        public const string DetailMiCoordinationTime = "DetailMiCoordinationTime";
        public const string ListMiPlan = "ListMiPlan";
        public const string AddNewMiPlan = "AddNewMiPlan";
        public const string EditMiPlan = "EditMiPlan";
        public const string DeleteMiPlan = "DeleteMiPlan";
        public const string DetailMiPlan = "DetailMiPlan";
        public const string AddNewMiEquipmentModel = "AddNewMiEquipmentModel";
        public const string EditMiEquipmentModel = "EditMiEquipmentModel";
        public const string ListMiEquipmentModel = "ListMiEquipmentModel";
        public const string ChangeStatusMiEquipmentModel = "ChangeStatusMiEquipmentModel";
        public const string DeleteMiEquipmentModel = "DeleteMiEquipmentModel";
        public const string DetailMiEquipmentModel = "DetailMiEquipmentModel";
        public const string AddNewMiCoordinationTime = "AddNewMiCoordinationTime";
        public const string DeleteMiCoordinationTime = "DeleteMiCoordinationTime";
        public const string EditMiCoordinationTime = "EditMiCoordinationTime";
        public const string AddNewMiContradictionPlan = "AddNewMiContradictionPlan";
        public const string EditMiContradictionPlan = "EditMiContradictionPlan";
        public const string ListMiContradictionPlan = "ListMiContradictionPlan";
        public const string DeleteMiContradictionPlan = "DeleteMiContradictionPlan";
        public const string DetailMiContradictionPlan = "DetailMiContradictionPlan";
        public const string ChangeStatusMiContradictionPlan = "ChangeStatusMiContradictionPlan";
        public const string ListMiDocuments = "ListMiDocuments";
        public const string DetailMiDocument = "DetailMiDocument";
        public const string AddNewReModemModel = "AddNewReModemModel";
        public const string EditReModemModel = "EditReModemModel";
        public const string ListReModemModel = "ListReModemModel";
        public const string DetailReModemModel = "DetailReModemModel";
        public const string DeleteReModemModel = "DeleteReModemModel";
        public const string DetailReCoordinationTime = "DetailReCoordinationTime";
        public const string ChangeReCoordinationTimeStatus = "ChangeReCoordinationTimeStatus";
        public const string ListReCoordinationTime = "ListReCoordinationTime";
        public const string ListSuCoordinationTime = "ListSuCoordinationTime";
        public const string ChangeStatusSuCoordinationTime = "ChangeStatusSuCoordinationTime";
        public const string ListMiPostalCoordinationTime = "ListMiPostalCoordinationTime";
        public const string ChangeStatusMiPostalCoordinationTime = "ChangeStatusMiPostalCoordinationTime";
        public const string ListMiPostalCompany = "ListMiPostalCompany";
        public const string ChangeStatusMiPostalCompany = "ChangeStatusMiPostalCompany";
        public const string AddNewMiPostalCompany = "AddNewMiPostalCompany";
        public const string DetailMiPostalCompany = "DetailMiPostalCompany";
        public const string DeleteMiPostalCompany = "DeleteMiPostalCompany";
        public const string EditMiPostalCompany = "EditMiPostalCompany";
        public const string ListShSystemLog = "ListShSystemLog";
        public const string DownloadShSystemLogFile = "DownloadShSystemLogFile";

        #endregion

        #region General

        public const string ShowMyProfile = "ShowMyProfile";
        public const string ChangeMyPassword = "ChangeMyPassword";
        public const string SupporterReTicket = "SupporterReTicket";
        public const string ReRedemptionExpert = "ReRedemptionExpert";
        public const string MiInstallationExpert = "MiInstallationExpert";
        public const string SaSaleExpert = "SaSaleExpert";
        public const string ReceiveSmsAfterSuccessfulReRedemption = "ReceiveSmsAfterSuccessfulReRedemption";
        public const string ListUserCourse = "ListUserCourse";
        public const string JoinUserToCourse = "JoinUserToCourse";
        public const string PostalInstallationExpert = "PostalInstallationExpert";
        public const string ShopOrderRobot = "ShopOrderRobot";

        #endregion
    }
}
