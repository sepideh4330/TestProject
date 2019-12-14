using System;
using Microsoft.AspNetCore.Identity;

namespace Project.Common.AppSettings
{
    public class SiteSettings
    {
        public GeneratorMiCoordinationTimes[] GeneratorMiCoordinationTimes { get; set; }

        public GeneratorReCoordinationTimes[] GeneratorReCoordinationTimes { get; set; }

        public GeneratorMiPlanTypes[] GeneratorMiPlanTypes { get; set; }

        public GeneratorMiCities[] GeneratorMiCities { get; set; }

        public GeneratorMiProvinces[] GeneratorMiProvinces { get; set; }

        public Logging Logging { get; set; }

        public MobinnetAccess MobinnetAccess { get; set; }

        public Connectionstrings ConnectionStrings { get; set; }

        public int NotAllowedPreviouslyUsedPasswords { get; set; }

        public int ChangePasswordReminderDays { get; set; }

        public int VerificationEmailTokenLength { get; set; }

        public int ForgotPasswordTokenLength { get; set; }

        public int SendSmsCount { get; set; }

        public int IonicPageSize { get; set; }

        public string RobotServerUrl { get; set; }

        public PasswordOptions PasswordOptions { get; set; }

        public ApiSettings ApiSettings { get; set; }

        public LockoutOptions LockoutOptions { get; set; }

        public BearerTokensOptions BearerTokensOptions { get; set; }

        public SmsTemplates SmsTemplates { get; set; }

        public string[] PasswordsBanList { get; set; }

        public string[] EmailsBanList { get; set; }

        public TimeSpan ConfirmationTokenProviderLifespan { get; set; }

        public bool RequireConfirmedEmail { get; set; }

        public bool RequireConfirmedPhoneNumber { get; set; }

        public int AvatarWidth { get; set; }

        public int AvatarHeight { get; set; }

        public int SignatureWidth { get; set; }

        public int SignatureHeight { get; set; }

        public string SendSmsAfterReRedemptionForCoordinate { get; set; }

        public string SendSmsAfterAddTicketForCoordinate { get; set; }
    }
}