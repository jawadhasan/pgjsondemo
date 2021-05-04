using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LicenseHelper
{

    public class ConfigData
    {
        public string RegisteredEmail { get; set; }
        public string LicenseKey { get; set; }
        public string ActivationKey { get; set; }
        public string InstallationType { get; set; }
        public DateTime InstallDate { get; set; }
        public DateTime FromJulianDate { get; set; }
        public string HardwareUId { get; set; }

        public bool MessageDesignerEnabled { get; set; }
        public bool PrinterManagmentEnabled { get; set; }
        public bool PrintJobManagementEnabled { get; set; }
    }

    public class ConfigFileLoader : BaseFileLoader
    {
        public ConfigFileLoader(string filePath) : base(filePath)
        {
        }

        public ConfigData GetConfigData()
        {
            var document = LoadConfigDoc();
            var elements = document.Elements("appSettings").Elements("add").ToList();

            var registeredEmail = elements.FindKeyElementByAttributeName("REGISTERED_EMAIL").Attribute("value").GetAs<string>();
            var licenseKey = elements.FindKeyElementByAttributeName("LICENSE_KEY").Attribute("value").GetAs<string>();
            var activationKey = elements.FindKeyElementByAttributeName("ACTIVATION_KEY").Attribute("value").GetAs<string>();
            var installationType = elements.FindKeyElementByAttributeName("INSTALLATION_TYPE_CHOSEN").Attribute("value").GetAs<string>();
            var installDate = elements.FindKeyElementByAttributeName("InstallDate").Attribute("value").GetAs<DateTime>();
            var julianDateString = elements.FindKeyElementByAttributeName("InstallDateJulian").Attribute("value").GetAs<string>();
            var hardwareUId = elements.FindKeyElementByAttributeName("HARDWARE_UID").Attribute("value").GetAs<string>();

            var messageDesignerEnabled = elements.FindKeyElementByAttributeName("MESSAGE_DESIGNER_FEATURE_CHECKED").Attribute("value").GetAs<string>();
            var printerManagmentEnabled = elements.FindKeyElementByAttributeName("PRINTER_MANAGEMENT_FEATURE_CHECKED").Attribute("value").GetAs<string>();
            var printJobManagementEnabled = elements.FindKeyElementByAttributeName("PRINTJOB_MANAGEMENT_FEATURE_CHECKED").Attribute("value").GetAs<string>();

            var configData = new ConfigData();
            configData.RegisteredEmail = registeredEmail;
            configData.LicenseKey = licenseKey;
            configData.ActivationKey = activationKey;
            configData.InstallationType = installationType;
            configData.InstallDate = Convert.ToDateTime(installDate);
            configData.HardwareUId = hardwareUId;
            configData.MessageDesignerEnabled = GetFeatureBooleanValue(messageDesignerEnabled);
            configData.PrinterManagmentEnabled = GetFeatureBooleanValue(printerManagmentEnabled);
            configData.PrintJobManagementEnabled = GetFeatureBooleanValue(printJobManagementEnabled);
            configData.FromJulianDate = LicenseDateTimeConverter.JulianDateStringToDateTime(julianDateString);

            return configData;
        }



        private XElement LoadConfigDoc()
        {
            XElement doc = XElement.Load(FilePath);
            return doc;
        }

        private bool GetFeatureBooleanValue(string featureValue)
        {
            switch (featureValue)
            {
                case "1":
                    return true;

                default:
                    return false;
            }
        }
    }
}
