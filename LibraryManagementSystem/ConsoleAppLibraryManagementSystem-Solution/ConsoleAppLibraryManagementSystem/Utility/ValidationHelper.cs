using System;
using System.Globalization;

namespace LibraryManagementSystem2025.Utility
{
    public static class ValidationHelper
    {
        // Validates date in dd/mm/yyyy format
        public static bool IsValidDate(string input, out DateTime date)
        {
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out date);
        }
    }
}
