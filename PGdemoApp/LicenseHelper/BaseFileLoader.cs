using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseHelper
{
    public class BaseFileLoader
    {
        public string FilePath { get; }

        public BaseFileLoader(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            FilePath = filePath;
        }
    }
}
