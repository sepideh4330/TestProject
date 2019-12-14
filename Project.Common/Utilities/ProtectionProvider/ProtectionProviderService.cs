﻿using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Project.Common.Extensions;

namespace Project.Common.Utilities.ProtectionProvider
{
    public class ProtectionProviderService : IProtectionProviderService
    {
        private readonly ILogger<ProtectionProviderService> _logger;
        private readonly IDataProtector _dataProtector;

        /// <summary>
        /// The default captcha protection provider
        /// </summary>
        public ProtectionProviderService(
            IDataProtectionProvider dataProtectionProvider,
            ILogger<ProtectionProviderService> logger)
        {
            dataProtectionProvider.CheckArgumentIsNull(nameof(dataProtectionProvider));
            logger.CheckArgumentIsNull(nameof(logger));

            _logger = logger;
            _dataProtector = dataProtectionProvider.CreateProtector(typeof(ProtectionProviderService).FullName);
        }

        /// <summary>
        /// Decrypts the message
        /// </summary>
        public string Decrypt(string inputText)
        {
            inputText.CheckArgumentIsNull(nameof(inputText));

            try
            {
                var inputBytes = Convert.FromBase64String(inputText);
                var bytes = _dataProtector.Unprotect(inputBytes);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex.Message, "Invalid base 64 string. Fall through.");
            }
            catch (CryptographicException ex)
            {
                _logger.LogError(ex.Message, "Invalid protected payload. Fall through.");
            }

            return null;
        }

        /// <summary>
        /// Encrypts the message
        /// </summary>
        public string Encrypt(string inputText)
        {
            inputText.CheckArgumentIsNull(nameof(inputText));

            var inputBytes = Encoding.UTF8.GetBytes(inputText);
            var bytes = _dataProtector.Protect(inputBytes);
            return Convert.ToBase64String(bytes);
        }
    }

}
