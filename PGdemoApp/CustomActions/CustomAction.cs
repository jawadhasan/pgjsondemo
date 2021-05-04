using Microsoft.Deployment.WindowsInstaller;
using System;

namespace CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CalculateJulianDate(Session session)
        {
            session.Log("Begin CustomAction CalculateJulianDate");
            try
            {
                var currentDate = DateTime.Now;
                var uId = LicenseDateTimeConverter.DateTimeToJulianDate(currentDate);
                session["INSTALL_DATE_JULIAN"] = uId.ToString();
                session.Log("JulianDate uint value: " + uId);
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log("ERROR in custom action CalculateJulianDate {0}", ex.ToString());
                return ActionResult.Failure;
            }
        }
    }
}
