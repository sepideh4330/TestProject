namespace Project.Common.Helpers
{
    public static class Patterns
    {
        public const string PhoneNumber = "^[0][9][0-9]{2,2}[0-9]{3,3}[0-9]{4,4}$";
        public const string Email = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";
        public const string HomeNumber = "^0[0-9]{2,}[0-9]{7,}$";
        public const string PersianWordsAndSpace = "^[ \u0600-\u06FF\\s]+$";
        public const string EnglishWordsAndSpace = "^[A-Za-z ]+$";
        public const string PersianDate = "^[1][0-9]{3,3}-[0-9]{2,2}-[0-9]{2,2}$";
        public const string Number = "^[0-9]*$";
        public const string CreditCard = "[1-9]{1}[0-9]{15}";
        public const string NegativePositiveNumber = @"^[\-\+\s]*[1-9][0-9]+$";
        public const string DecimalNumber = @"^[0-9]*(?:\.[0-9]*)?$";
        public const string Address = @"^[\u0600-\u06ff0-9\s]+$|[\u0750-\u077f0-9\s]+$|[\ufb50-\ufc3f0-9\s]+$|[\ufe70-\ufefc0-9\s]+$|[\u06cc0-9\s]+$|[\u067e0-9\s]+$|[\u06af0-9\s]$|[\u06910-9\s]$|[ ]$";
    }
}
