using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.Shared.Models;

namespace Project.Common.SeedDatas.Shared
{
    public class ShSettingData
    {
        private static readonly Lazy<IEnumerable<ShSettingDataModel>> SystemShSettingsLazy =
            new Lazy<IEnumerable<ShSettingDataModel>>(
                GetSystemUsers, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<ShSettingDataModel> GetSystemUsers()
        {
            return new List<ShSettingDataModel>
            {
                //تنظیمات پایه
                new ShSettingDataModel(
                    ProjectRulesContent,
                    "متن تستی",
                    "متن قوانین مبین یار",
                    700,100,300),
                new ShSettingDataModel(
                    ApplicationVersion,
                    "1",
                    "نسخه اپلیکیشن",
                    200,100,100),
                new ShSettingDataModel(
                    AndroidApplicationDownloadLink,
                    "متن تستی",
                    "لینک دانلود اپلیکیشن برای اندروید",
                    200,100,100),
                new ShSettingDataModel(
                    IosApplicationDownloadLink,
                    "متن تستی",
                    "لینک دانلود اپلیکیشن برای ios",
                    200,100,100),
                new ShSettingDataModel(
                    LastChangeAppDescription,
                    "متن تستی",
                    "توضیحات آخرین تغییرات اپلیکیشن",
                    200,100,100),
                new ShSettingDataModel(
                    LocationChangeMinute,
                    "1",
                    "فاصله زمانی ثبت موقعیت کاربر(دقیقه)",
                    300,100,100),
                //Crm مبین نت
                new ShSettingDataModel(
                    ConnectionTimeout,
                    "90",
                    "میزان زمان انتظار برای اتصال",
                    100,200,500),
                new ShSettingDataModel(
                    ConnectionIp,
                    "10.104.52.35",
                    "آی پی CRM",
                    200,200,500),
                new ShSettingDataModel(
                    UploadConnectionIp,
                    "http://10.104.53.20/Home/Upload",
                    "آدرس بارگزاری تصاویر CRM",
                    200,200,500),
                new ShSettingDataModel(
                    ConnectionUserName,
                    "52110011",
                    "نام کاربری عامل",
                    200,200,500),
                new ShSettingDataModel(
                    ConnectionPassword,
                    "ShTs001@lte",
                    "کلمه عبور عامل",
                    200,200,500),
                new ShSettingDataModel(
                    CompanyMobinNetFullName,
                    "شکوه تجارت صدف مدیر نصب",
                    "نام کامل عامل",
                    200,200,500),
                new ShSettingDataModel(
                    CompanyMobinNetId,
                    "13C9FEAC-F9D7-E711-80C9-005056B6C839",
                    "شناسه عامل",
                    200,200,500),
                new ShSettingDataModel(
                    WillTheRobotBeActive,
                    "true",
                    "آیا ربات فعال سازی فعال باشد؟",
                    500,200,400),
                new ShSettingDataModel(
                    MiTicketManualActivationByRobot,
                    "true",
                    "آیا فعال سازی دستی تیکت های نصب انبوه فعال باشد؟",
                    500,200,400),
                new ShSettingDataModel(
                    WillTheTicketFetchRobotBeActive,
                    "true",
                    "آیا ربات دریافت تیکت فعال باشد؟",
                    500,200,400),
                //پنل پیامکی
                new ShSettingDataModel(
                    SendSmsTestPhoneNumber,
                    "09121111111",
                    "شماره تستی ارسال پیامک(SMS)",
                    100,300,600),
                new ShSettingDataModel(
                    UserNameForSendSms,
                    "ShokouhTejarat",
                    "نام کاربری ارسال پیامک(SMS)",
                    200,300,600),
                new ShSettingDataModel(
                    PassWordForSendSms,
                    "s@d@f70523",
                    "کلمه عبور ارسال پیامک(SMS)",
                    200,300,600),
                new ShSettingDataModel(
                    PhoneNumberForSendSms,
                    "10001575000000",
                    "شماره تلفن ارسال پیامک(SMS)",
                    100,300,600),
                new ShSettingDataModel(
                    SendSmsAfterRedemptionPaymentSuccessfullToCustomer,
                    "true",
                    "آیا بعد از پرداخت مبلغ بازخرید به مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SmsContentAfterRedemptionPaymentSuccessfullToCustomer,
                    "مبلغ {0} ریال با شماره مرجع {1} بابت خرید مودم به حساب شما واریز شد.",
                    "متن پیام پیامک (SMS) پرداخت به مشتری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterRedemptionSuccessfullToCustomer,
                    "true",
                    "آیا بعد از ثبت موفق بازخرید برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SmsContentAfterRedemptionSuccessfullToCustomer,
                    "جهت تسریع دسترسی کارشناسان ما به شما ، لطفا با کلیک بر روی لینک زیر موقعیت مکانی خود را ثبت کنید. {0}",
                    "متن پیام پیامک (SMS) بازخرید موفق",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSuccessfullRedemption,
                    "true",
                    "آیا بعد از انجام بازخرید توسط کارشناس بازخرید برای مسئول پرداخت پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SmsContentAfterSuccessfullRedemption,
                    "یک بازخرید توسط  کارشناس بازخرید با موفقیت انجام شده لطفا وضعیت پرداخت آن را مشخص کنید",
                    "متن پیام پیامک (SMS) جهت پرداخت بازخرید انجام شده برای ارسال به مسئول پرداخت ",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAddMiTicketToCustomer,
                    "true",
                    "آیا بعداز ثبت تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAddMiTicketToCustomerContent,
                    "جهت تسریع دسترسی کارشناسان ما به شما ، لطفا با کلیک بر روی لینک زیر موقعیت مکانی خود را ثبت کنید. {0}",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز ثبت تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAddMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز ثبت تیکت پستی برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAddMiPostalTicketToCustomerContent,
                    "مشتری گرامی، پیرو ثبت درخواست سرویس LTE، لطفاً مدارک ذیل را حداکثر طی 24 ساعت آینده به شماره تلگرام یا واتس آپ 09018720981 ارسال فرمایید."
                    +
                    "1) کارت ملی شخص ثبت نام کننده"+
                    "2) یکی از قبوض(تلفن،برق)"+
                    "3) تصویر فیش واریزی به مبلغ {0} ریال"+
                    "4) 4 رقم آخر کارت مبداء (کارتی که با آن پرداخت صورت میگیرد)"+
                    "شماره کارت: 5859837003361504 به نام ارتباطات مبین نت"+
                    "در صورت هرگونه ابهام، سوال و نیاز به اطلاعات بیشتر با شماره تلفن 88864923-021 تماس حاصل فرمایید."+
                    "در صورت عدم پرداخت و ارسال مدارک درخواست شما به صورت خودکار لغو خواهد شد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز ثبت تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCoordinationMiTicketToCustomer,
                    "true",
                    "آیا بعداز هماهنگی تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCoordinationMiTicketToCustomerContent,
                    "مشتری گرامی درخواست شما به کارشناس نصب، آقای {0}، ارجاع داده شد."+
                    "لطفاً جهت تسریع در فرآیند خدمت رسانی هنگام مراجعه کارشناس مدارک ذیل را در دسترس داشته باشید:"+
                    "1-اصل کارت ملی (گواهینامه یا شناسنامه جدید نیز مورد تایید است)"+
                    "2-اصل یکی از قبوض خدماتی (تلفن،برق)"+
                    "3-مبلغ {1} ریال جهت پرداخت هزینه سرویس",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز هماهنگی تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCoordinationMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز هماهنگی تیکت پستی برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCoordinationMiPostalTicketToCustomerContent,
                    "جهت تسریع دسترسی کارشناسان ما به شما ، لطفا با کلیک بر روی لینک زیر موقعیت مکانی خود را ثبت کنید. {0}",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز هماهنگی تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterChangeMiInstallationExpertToCustomer,
                    "true",
                    "آیا بعداز تغییر کارشناس نصب برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterChangeMiInstallationExpertToCustomerContent,
                    "مشترک گرامی جهت تسریع در روند تحویل سرویس، درخواست شما به کارشناس نصب آقای {0} ارجاع داده شد و مراجعه حضوری برای روز {1} و بازه زمانی {2} الی {3} ثبت گردید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز تغییر کارشناس نصب",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterActivationMiTicketToCustomer,
                    "true",
                    "آیا بعداز فعال سازی تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterActivationMiTicketToCustomerContent,
                    "مشترک گرامی از اینکه به خانواده سبز مبین نت پیوستید سپاسگزاریم جهت آگاهی از وضعیت سرویس خود، تغییر و تمدید طرح به https://my.mobinnet.ir مراجعه فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز فعال سازی تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterFirstNotAnswerMiTicketToCustomer,
                    "true",
                    "آیا بعداز اولین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterFirstNotAnswerMiTicketToCustomerContent,
                    "1.	مشتری گرامی در ساعت {0} روز {1} جهت هماهنگی و مراجعه با شما تماس گرفته شد و شما پاسخگو نبودید. لطفاً جهت هماهنگی با کارشناس مربوطه به شماره {2} تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز اولین عدم پاسخ تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSecondNotAnswerMiTicketToCustomer,
                    "true",
                    "آیا بعداز دومین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSecondNotAnswerMiTicketToCustomerContent,
                    "مشتری گرامی، ساعت {0} روز {1} جهت هماهنگی برای مراجعه با شما تماس گرفته شد و شما پاسخگو نبودید. به دلیل عدم پاسخگویی درخواست شما لغو می گردد. برای ثبت درخواست مجدد با شماره 1575 تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز دومین عدم پاسخ تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterThirdNotAnswerMiTicketToCustomer,
                    "true",
                    "آیا بعداز سومین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterThirdNotAnswerMiTicketToCustomerContent,
                    "	مشتری گرامی، ساعت {0} روز {1} جهت هماهنگی برای مراجعه با شما تماس گرفته شد و شما پاسخگو نبودید. به دلیل عدم پاسخگویی درخواست شما لغو می گردد. برای ثبت درخواست مجدد با شماره 1575 تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز سومین عدم پاسخ تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancellationDueSignalWeeknessMiTicketToCustomer,
                    "true",
                    "آیا بعداز لغو تیکت به علت ضعف سیگنال برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancellationDueSignalWeeknessMiTicketToCustomerContent,
                    "مشتری گرامی به دلیل عدم دریافت پارامترهای مناسب جهت تحویل سرویس،درخواست شما لغو گردید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت به علت ضعف سیگنال",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSignalWeeknessConvertTo360MiTicketToCustomer,
                    "true",
                    "آیا بعداز تبدیل ضعف سیگنال تیکت به 360 برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSignalWeeknessConvertTo360MiTicketToCustomerContent,
                    "مشترک گرامی به دلیل عدم دریافت پارامترهای مناسب جهت ارائه خدمات مناسب، در صورت تمایل، امکان بهبود وضعیت سیگنال های دریافتی درخواست شما با تبدیل به 360 و ارائه سرویس مناسب فراهم می باشد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز تبدیل ضعف سیگنال تیکت به 360",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterUnableToCallMiTicketToCustomer,
                    "true",
                    "آیا بعداز عدم امکان تماس تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterUnableToCallMiTicketToCustomerContent,
                    "مشترک گرامی، ساعت {0} روز {1} جهت هماهنگی برای مراجعه تماس حاصل شد و امکان تماس با شما وجود نداشت. لطفا پس از دریافت پیام با شماره {2} تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم امکان تماس تیکت حضوری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDueLackOfCoverageMiTicketToCustomer,
                    "true",
                    "آیا بعداز عدم پوشش تیکت برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDueLackOfCoverageMiTicketToCustomerContent,
                    "مشترک گرامی به دلیل عدم دریافت پارامترهای مناسب و استاندارد جهت تحویل سرویس، درخواست شما لغو می گردد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم پوشش تیکت",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDemandMiTicketToCustomer,
                    "true",
                    "آیا بعداز لغو تیکت به درخواست مشتری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDemandMiTicketToCustomerContent,
                    "مشترک گرامی طی مذاکره تلفنی انجام شده و دلایل مذکور از جانب شما، درخواست شما لغو می گردد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت به درخواست مشتری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterDuplicateRequestMiTicketToCustomer,
                    "true",
                    "آیا بعداز درخواست تکراری تیکت برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterDuplicateRequestMiTicketToCustomerContent,
                    "مشترک گرامی به دلیل تکراری بودن درخواست شما، درخواست با کد رهگیری {0} لغو می گردد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز درخواست تکراری تیکت",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterActivationMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز فعال سازی تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterActivationMiPostalTicketToCustomerContent,
                    "مشترک گرامی از اینکه به خانواده سبز مبین نت پیوستید سپاسگزاریم جهت آگاهی از وضعیت سرویس خود، تغییر و تمدید طرح به https://my.mobinnet.ir مراجعه فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز فعال سازی تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAllocateMiPostalTicketToPostalCompanyToCustomer,
                    "true",
                    "آیا بعداز تخصیص تیکت به شرکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterAllocateMiPostalTicketToPostalCompanyToCustomerContent,
                    "مشترک گرامی، ساعت {0} روز {1} مرسوله  شما با کد رهگیری {2} ارسال گردید. جهت پیگیری از طریق کد مذکور و شرکت پست استان خود اقدام فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز تخصیص تیکت به شرکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDemandMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز لغو تیکت پستی به درخواست مشتری برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterCancelDemandMiPostalTicketToCustomerContent,
                    "مشترک گرامی به دلیل تکراری بودن درخواست شما، درخواست با کد رهگیری {0} لغو می گردد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت پستی به درخواست مشتری",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterUnableToCallMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز عدم امکان تماس تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterUnableToCallMiPostalTicketToCustomerContent,
                    "مشترک گرامی، ساعت {0} روز {1} جهت هماهنگی برای مراجعه تماس حاصل شد و امکان تماس با شما وجود نداشت. لطفا پس از دریافت پیام با شماره {2} تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم امکان تماس تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterFirstNotAnswerMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز اولین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterFirstNotAnswerMiPostalTicketToCustomerContent,
                    ".مشترک گرامی، ساعت {0} روز {1} از شما درخواست ارسال مدارک شد و شما پاسخگو نبودید. لطفا جهت تکمیل ثبت نام مدارک خود را به شماره {2} ارسال بفرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز اولین عدم پاسخ تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSecondNotAnswerMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز دومین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterSecondNotAnswerMiPostalTicketToCustomerContent,
                    "مشترک گرامی، ساعت {0} روز {1} از شما درخواست ارسال مدارک شد و شما پاسخگو نبودید. لطفا جهت تکمیل ثبت نام مدارک خود را به شماره {2} ارسال بفرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز دومین عدم پاسخ تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterThirdNotAnswerMiPostalTicketToCustomer,
                    "true",
                    "آیا بعداز سومین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterThirdNotAnswerMiPostalTicketToCustomerContent,
                    "	مشترک گرامی، ساعت {0} روز {1} از شما درخواست ارسال مدارک شد و شما پاسخگو نبودید. به دلیل عدم پاسخگویی درخواست شما لغو می گردد. برای ثبت درخواست مجدد با شماره 1575 تماس حاصل فرمایید.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز سومین عدم پاسخ تیکت پستی",
                    200,300,700),
                new ShSettingDataModel(
                    SendSmsAfterDelayToInstallationMiTicketToCustomer,
                    "true",
                    "آیا بعداز تاخیر در نصب تیکت برای مشتری پیامک(SMS) ارسال شود؟",
                    500,300,700),
                new ShSettingDataModel(
                    SendSmsAfterDelayToInstallationMiTicketToCustomerContent,
                    "مشترک گرامی طی مذاکره تلفنی انجام شده و دلایل مذکور از جانب شما، درخواست شما در تاریخ {0} پیگیری می گردد.",
                    "متن پیام پیامک (SMS) ارسال به مشتری بعداز تاخیر در نصب تیکت",
                    200,300,700),
                //نصب انبوه
                new ShSettingDataModel(
                    AddNewMiPlanPosibility,
                    "true",
                    "امکان ثبت طرح جدید وجود داشته باشد؟",
                    500,500,1200),
                new ShSettingDataModel(
                    MinMiInstallationPriceAmount,
                    "200000",
                    "حداقل هزینه نصب طرح تیکت",
                    600,500,1300),
                new ShSettingDataModel(
                    MaxMiInstallationPriceAmount,
                    "10000000",
                    "حداکثر هزینه نصب طرح تیکت",
                    600,500,1300),
                new ShSettingDataModel(
                    MaxMiProductDiscountAmount,
                    "10000000",
                    "حداکثر تخفیف طرح تیکت",
                    600,500,1300),
                new ShSettingDataModel(
                    MinMiFinalAmount,
                    "50000",
                    "حداقل قیمت نهایی طرح تیکت",
                    600,500,1300),
                new ShSettingDataModel(
                    MaxMiFinalAmount,
                    "10000000",
                    "حداکثر قیمت نهایی طرح تیکت",
                    600,500,1300),
                new ShSettingDataModel(
                    MiTicketReleaseTimeAfterNoAnswerByInstallationExpert,
                    "120",
                    "مدت زمان (دقیقه) آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس نصب ثبت شد",
                    300,500,1200),
                new ShSettingDataModel(
                    MiTicketReleaseTimeAfterNoAnswerByCoordinationExpert,
                    "120",
                    "مدت زمان (دقیقه) آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس هماهنگی ثبت شد",
                    300,500,1200),
                new ShSettingDataModel(
                    AddNewMiPacketPosibility,
                    "true",
                    "امکان ثبت بسته جدید وجود داشته باشد؟",
                    500,500,1200),
                new ShSettingDataModel(
                    WaitingForActivationByInstallationExpertMinute,
                    "15",
                    "مدت زمان (دقیقه) انتظار کارشناس نصب برای فعال سازی",
                    300,500,1200),
                new ShSettingDataModel(
                    AddNewMiTicketPosibility,
                    "true",
                    "امکان ثبت تیکت جدید وجود داشته باشد؟",
                    500,500,1200),
                new ShSettingDataModel(
                    InstallationMiTicketPosibility,
                    "true",
                    "امکان نصب تیکت وجود داشته باشد؟",
                    500,500,1200),
                new ShSettingDataModel(
                    ConvertSignalWeaknessTo360PriceAmount,
                    "500000",
                    "قیمت تبدیل ضعف سیگنال به 360",
                    600,500,1300),
                new ShSettingDataModel(
                    InstallationExpertFinalDescription,
                    "توضیحات1 # توضیحات2 # توضیحات3",
                    "توضیحات نهایی کارشناس نصب در نصب موفق نصب انبوه",
                    200,500,1200),
                new ShSettingDataModel(
                    MaximumWorkingHoursOfInstallationExpert,
                    "00:00",
                    "حداکثر ساعت کار کارشناسان نصب انبوه",
                    800,500,1200),
                new ShSettingDataModel(
                    MinimumWorkingHoursOfInstallationExpert,
                    "00:00",
                    "حداقل ساعت کار کارشناسان نصب انبوه",
                    800,500,1200),
                new ShSettingDataModel(
                    MaximumNumberOfMiTicketsInStream,
                    "3",
                    "حداکثر تعداد تیکت نصب انبوه در جریان",
                    100,500,1200),
                new ShSettingDataModel(
                    MaximumNumberOfMiTicketsPerDay,
                    "10",
                    "حداکثر تعداد دریافت تیکت نصب انبوه در روز",
                    100,500,1200),
                new ShSettingDataModel(
                    PostPickupTime,
                    "14:00",
                    "ساعت PickUp پست",
                    800,500,1400),
                new ShSettingDataModel(
                    CoordinateNewMiTicketByInstallationExpertPosibility,
                    "true",
                    "امکان هماهنگی تیکت جدید توسط کارشناس وجود داشته باشد؟",
                    500,500,1200),
                //بازخرید
                new ShSettingDataModel(
                    AddReRedemptionPosibility,
                    "true",
                    "امکان ثبت بازخرید وجود داشته باشد؟",
                    500,400,900),
                new ShSettingDataModel(
                    GetReTicketPosibility,
                    "true",
                    "امکان دریافت تیکت وجود داشته باشد؟",
                    500,400,900),
                new ShSettingDataModel(
                    AddNewRePacketPosibility,
                    "true",
                    "امکان ثبت بسته بندی جدید وجود داشته باشد؟",
                    500,400,900),
                new ShSettingDataModel(
                    TicketReleaseTimeAfterNoAnswer,
                    "120",
                    "مدت زمان آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس بازخرید ثبت شد ",
                    300,400,900),
                new ShSettingDataModel(
                    WaitingForPaymentAfterRedemptionByRedemptionExpertMinute,
                    "15",
                    "مدت زمان (دقیقه) انتظار کارشناس بازخرید برای پرداخت",
                    300,400,900),
                new ShSettingDataModel(
                    MinReModemPrice,
                    "500000",
                    "حداقل قیمت مودم",
                    600,400,1100),
                new ShSettingDataModel(
                    MaxReModemPrice,
                    "1200000",
                    "حداکثر قیمت مودم",
                    600,400,1100),
                new ShSettingDataModel(
                    LanCablePrice,
                    "150000",
                    "قیمت کابل Lan",
                    600,400,1000),
                new ShSettingDataModel(
                    AdapterPrice,
                    "150000",
                    "قیمت آداپتور",
                    600,400,1000),
                new ShSettingDataModel(
                    MaximumWorkingHoursOfRedemptionExpert,
                    "00:00",
                    "حداکثر ساعت کار کارشناسان بازخرید",
                    800,400,900),
                new ShSettingDataModel(
                    MinimumWorkingHoursOfRedemptionExpert,
                    "00:00",
                    "حداقل ساعت کار کارشناسان بازخرید",
                    800,400,900),
                new ShSettingDataModel(
                    MaximumNumberOfReTicketsInStream,
                    "3",
                    "حداکثر تعداد تیکت بازخرید در جریان",
                    200,400,900),
                new ShSettingDataModel(
                    MaximumNumberOfReTicketsPerDay,
                    "10",
                    "حداکثر تعداد دریافت تیکت بازخرید در روز",
                    200,400,900),
                //پشتیبانی
                new ShSettingDataModel(
                    TdModemMoneyBackPrice,
                    "250000",
                    "قیمت بازگشت پول مودم TD",
                    600,600,1500),
                new ShSettingDataModel(
                    FdModemDifferenceMoneyBackPrice,
                    "0",
                    "اختلاف بازگشت پول مودم FD",
                    600,600,1500),
                new ShSettingDataModel(
                    MinimumNumberOfCallingPhoneNumberPerDay,
                    "3",
                    "حداقل تعداد تماس با تلفن همراه مشتری در روز",
                    100,500,100),
                new ShSettingDataModel(
                    MinimumNumberOfCallingHomeNumberPerDay,
                    "3",
                    "حداقل تعداد تماس با تلفن منزل مشتری در روز",
                    100,500,100),
                new ShSettingDataModel(
                    SlaTicketTimeMinute,
                    "6000",
                    "مدت زمان SLA تیکت نصب انبوه",
                    300,500,1200),
                new ShSettingDataModel(
                    SlaPostalTicketTimeMinute,
                    "6000",
                    "مدت زمان SLA تیکت پستی نصب انبوه",
                    300,500,1200),
                new ShSettingDataModel(
                SystemLogMonthCount,
                "3",
                "تعداد ماه های نمایش لاگ های سیستم",
                100,100,1600),
                new ShSettingDataModel(
                    SystemLogErrorToBeDeleted,
                    "true",
                    "آیا لاگ های سیستم خطا نیز حذف شوند؟",
                    500,100,1600),
            };
        }

        public static IEnumerable<ShSettingDataModel> GetAll => SystemShSettingsLazy.Value;
        //عمومی
        public const string ProjectRulesContent = "متن قوانین مبین یار";
        public const string LocationChangeMinute = "فاصله زمانی ثبت موقعیت کاربر(دقیقه)";
        public const string ApplicationVersion = "نسخه اپلیکیشن";
        public const string AndroidApplicationDownloadLink = "لینک دانلود اپلیکیشن برای اندروید";
        public const string IosApplicationDownloadLink = "لینک دانلود اپلیکیشن برای ios";
        public const string LastChangeAppDescription = "توضیحات آخرین تغییرات اپلیکیشن";
        public const string SystemLogMonthCount = "تعداد ماه های نمایش لاگ های سیستم";
        public const string SystemLogErrorToBeDeleted = "آیا لاگ های سیستم خطا نیز حذف شوند؟";

        //Crm مبین نت
        public const string ConnectionTimeout = "میزان زمان انتظار برای اتصال";
        public const string ConnectionIp = "آی پی CRM";
        public const string UploadConnectionIp = "آدرس بارگزاری تصاویر CRM";
        public const string ConnectionUserName = "نام کاربری عامل";
        public const string ConnectionPassword = "کلمه عبور عامل";
        public const string CompanyMobinNetFullName = "نام کامل عامل";
        public const string CompanyMobinNetId = "شناسه عامل";
        public const string WillTheRobotBeActive = "آیا ربات فعال سازی فعال باشد؟";
        public const string MiTicketManualActivationByRobot = "آیا فعال سازی دستی تیکت های نصب انبوه فعال باشد؟";
        public const string WillTheTicketFetchRobotBeActive = "آیا ربات دریافت تیکت فعال باشد؟";
        //پنل پیامکی
        public const string SendSmsTestPhoneNumber = "شماره تستی ارسال پیامک(SMS)";
        public const string UserNameForSendSms = "نام کاربری ارسال پیامک(SMS)";
        public const string PassWordForSendSms = "کلمه عبور ارسال پیامک(SMS)";
        public const string PhoneNumberForSendSms = "شماره تلفن ارسال پیامک(SMS)";

        public const string SendSmsAfterAddMiTicketToCustomer = "آیا بعداز ثبت تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterAddMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز ثبت تیکت حضوری";
        public const string SendSmsAfterRedemptionSuccessfullToCustomer = "آیا بعد از ثبت موفق بازخرید برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SmsContentAfterRedemptionSuccessfullToCustomer = "متن پیام پیامک (SMS) بازخرید موفق برای مشتری";
        public const string SmsContentAfterRedemptionPaymentSuccessfullToCustomer = "متن پیام پیامک (SMS)  پرداخت بازخرید برای مشتری";
        public const string SendSmsAfterRedemptionPaymentSuccessfullToCustomer = "آیا بعد از پرداخت مبلغ بازخرید به مشتری پیامک (SMS) ارسال شود؟";
        public const string SmsContentAfterSuccessfullRedemption = "متن پیام پیامک (SMS) جهت پرداخت بازخرید انجام شده برای ارسال به مسئول پرداخت ";
        public const string SendSmsAfterSuccessfullRedemption = "آیا بعد از انجام بازخرید توسط کارشناس بازخرید برای مسئول پرداخت پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterAddMiPostalTicketToCustomer = "آیا بعداز ثبت تیکت پستی برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterAddMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز ثبت تیکت پستی";
        public const string SendSmsAfterCoordinationMiPostalTicketToCustomer = "آیا بعداز هماهنگی تیکت پستی برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterCoordinationMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز هماهنگی تیکت پستی";
        public const string SendSmsAfterCoordinationMiTicketToCustomer = "آیا بعداز هماهنگی تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterCoordinationMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز هماهنگی تیکت حضوری";
        public const string SendSmsAfterChangeMiInstallationExpertToCustomer =
            "آیا بعداز تغییر کارشناس نصب برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterChangeMiInstallationExpertToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز تغییر کارشناس نصب";
        public const string SendSmsAfterActivationMiTicketToCustomer = "آیا بعداز فعال سازی تیکت حضوری برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterActivationMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز فعال سازی تیکت حضوری";
        public const string SendSmsAfterFirstNotAnswerMiTicketToCustomer = "آیا بعداز اولین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterFirstNotAnswerMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز اولین عدم پاسخ تیکت حضوری";
        public const string SendSmsAfterSecondNotAnswerMiTicketToCustomer = "آیا بعداز دومین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterSecondNotAnswerMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز دومین عدم پاسخ تیکت حضوری";
        public const string SendSmsAfterThirdNotAnswerMiTicketToCustomer = "آیا بعداز سومین عدم پاسخ تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterThirdNotAnswerMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز سومین عدم پاسخ تیکت حضوری";
        public const string SendSmsAfterCancellationDueSignalWeeknessMiTicketToCustomer = "آیا بعداز لغو تیکت به علت ضعف سیگنال برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterCancellationDueSignalWeeknessMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت به علت ضعف سیگنال";
        public const string SendSmsAfterSignalWeeknessConvertTo360MiTicketToCustomer = "آیا بعداز تبدیل ضعف سیگنال تیکت به 360 برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterSignalWeeknessConvertTo360MiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز تبدیل ضعف سیگنال تیکت به 360";
        public const string SendSmsAfterUnableToCallMiTicketToCustomer = "آیا بعداز عدم امکان تماس تیکت حضوری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterUnableToCallMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم امکان تماس تیکت حضوری";
        public const string SendSmsAfterCancelDueLackOfCoverageMiTicketToCustomer = "آیا بعداز عدم پوشش تیکت برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterCancelDueLackOfCoverageMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم پوشش تیکت";
        public const string SendSmsAfterCancelDemandMiTicketToCustomer = "آیا بعداز لغو تیکت به درخواست مشتری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterCancelDemandMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت به درخواست مشتری";
        public const string SendSmsAfterDuplicateRequestMiTicketToCustomer = "آیا بعداز درخواست تکراری تیکت برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterDuplicateRequestMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز درخواست تکراری تیکت";
        public const string SendSmsAfterActivationMiPostalTicketToCustomer = "آیا بعداز فعال سازی تیکت پستی برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterActivationMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز فعال سازی تیکت پستی";
        public const string SendSmsAfterAllocateMiPostalTicketToPostalCompanyToCustomer = "آیا بعداز تخصیص تیکت به شرکت پستی برای مشتری پیامک (SMS) ارسال شود؟";
        public const string SendSmsAfterAllocateMiPostalTicketToPostalCompanyToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز تخصیص تیکت به شرکت پستی";
        public const string SendSmsAfterCancelDemandMiPostalTicketToCustomer = "آیا بعداز لغو تیکت پستی به درخواست مشتری برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterCancelDemandMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز لغو تیکت پستی به درخواست مشتری";
        public const string SendSmsAfterUnableToCallMiPostalTicketToCustomer = "آیا بعداز عدم امکان تماس تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterUnableToCallMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز عدم امکان تماس تیکت پستی";
        public const string SendSmsAfterFirstNotAnswerMiPostalTicketToCustomer = "آیا بعداز اولین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterFirstNotAnswerMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز اولین عدم پاسخ تیکت پستی";
        public const string SendSmsAfterSecondNotAnswerMiPostalTicketToCustomer = "آیا بعداز دومین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterSecondNotAnswerMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز دومین عدم پاسخ تیکت پستی";
        public const string SendSmsAfterThirdNotAnswerMiPostalTicketToCustomer = "آیا بعداز سومین عدم پاسخ تیکت پستی برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterThirdNotAnswerMiPostalTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز سومین عدم پاسخ تیکت پستی";
        public const string SendSmsAfterDelayToInstallationMiTicketToCustomer = "آیا بعداز تاخیر در نصب تیکت برای مشتری پیامک(SMS) ارسال شود؟";
        public const string SendSmsAfterDelayToInstallationMiTicketToCustomerContent = "متن پیام پیامک (SMS) ارسال به مشتری بعداز تاخیر در نصب تیکت";

        //نصب انبوه
        public const string WaitingForActivationByInstallationExpertMinute = "مدت زمان انتظار (دقیقه) کارشناس نصب برای فعال سازی";
        public const string AddNewMiPlanPosibility = "امکان ثبت طرح جدید وجود داشته باشد؟";
        public const string MinMiInstallationPriceAmount = "حداقل هزینه نصب طرح تیکت";
        public const string MaxMiInstallationPriceAmount = "حداکثر هزینه نصب طرح تیکت";
        public const string MaxMiProductDiscountAmount = "حداکثر تخفیف طرح تیکت";
        public const string MinMiFinalAmount = "حداقل قیمت نهایی طرح تیکت";
        public const string MaxMiFinalAmount = "حداکثر قیمت نهایی طرح تیکت";
        public const string MiTicketReleaseTimeAfterNoAnswerByInstallationExpert =
            "مدت زمان (دقیقه) آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس نصب ثبت شد";
        public const string MiTicketReleaseTimeAfterNoAnswerByCoordinationExpert =
            "مدت زمان (دقیقه) آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس هماهنگی ثبت شد";
        public const string AddNewMiPacketPosibility = "امکان ثبت بسته جدید وجود داشته باشد؟";
        public const string AddNewMiTicketPosibility = "امکان ثبت تیکت جدید وجود داشته باشد؟";
        public const string InstallationMiTicketPosibility = "امکان نصب تیکت وجود داشته باشد؟";
        public const string ConvertSignalWeaknessTo360PriceAmount = "قیمت تبدیل ضعف سیگنال به 360";
        public const string InstallationExpertFinalDescription = "توضیحات نهایی کارشناس نصب در نصب موفق نصب انبوه";
        public const string MaximumWorkingHoursOfInstallationExpert = "حداکثر ساعت کار کارشناسان نصب";
        public const string MinimumWorkingHoursOfInstallationExpert = "حداقل ساعت کار کارشناسان نصب";
        public const string MaximumNumberOfMiTicketsInStream = "حداکثر تعداد تیکت در جریان";
        public const string MaximumNumberOfMiTicketsPerDay = "حداکثر تعداد دریافت تیکت نصب انبوه در روز";
        public const string PostPickupTime = "ساعت PickUp پست";
        public const string CoordinateNewMiTicketByInstallationExpertPosibility = "امکان هماهنگی تیکت جدید توسط کارشناس وجود داشته باشد؟";
        public const string MinimumNumberOfCallingPhoneNumberPerDay = "حداقل تعداد تماس با تلفن همراه مشتری در روز";
        public const string MinimumNumberOfCallingHomeNumberPerDay = "حداقل تعداد تماس با تلفن منزل مشتری در روز";
                public const string SlaTicketTimeMinute = "مدت زمان SLA تیکت نصب انبوه";
        public const string SlaPostalTicketTimeMinute = "مدت زمان SLA تیکت پستی نصب انبوه";

        //بازخرید
        public const string TicketReleaseTimeAfterNoAnswer = "مدت زمان آزاد سازی یک تیکت پس از اینکه عدم پاسخ گویی توسط کارشناس بازخرید ثبت شد";
        public const string WaitingForPaymentAfterRedemptionByRedemptionExpertMinute = "مدت زمان انتظار (دقیقه)  کارشناس بازخرید برای پرداخت";
        public const string MinReModemPrice = "حداقل قیمت مودم";
        public const string MaxReModemPrice = "حداکثر قیمت مودم";
        public const string LanCablePrice = "قیمت کابل Lan";
        public const string AdapterPrice = "قیمت آداپتور";
        public const string AddReRedemptionPosibility = "امکان ثبت بازخرید وجود داشته باشد؟";
        public const string GetReTicketPosibility = "امکان دریافت تیکت وجود داشته باشد؟";
        public const string AddNewRePacketPosibility = "امکان ثبت بسته بندی جدید وجود داشته باشد؟";
        public const string MaximumWorkingHoursOfRedemptionExpert = "حداکثر ساعت کار کارشناسان بازخرید";
        public const string MinimumWorkingHoursOfRedemptionExpert = "حداقل ساعت کار کارشناسان بازخرید";
        public const string MaximumNumberOfReTicketsInStream = "حداکثر تعداد تیکت در جریان";
        public const string MaximumNumberOfReTicketsPerDay = "حداکثر تعداد دریافت تیکت بازخرید در روز";
        //پشتیبانی
        public const string TdModemMoneyBackPrice = "قیمت بازگشت پول مودم TD";
        public const string FdModemDifferenceMoneyBackPrice = "اختلاف قیمت بازگشت پول مودم FD";

    }
}
