using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BigSchool.ViewModel
{
    public class FutureDate :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isvalid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/MM/yyyy",
                CultureInfo.CurrentCulture,
               DateTimeStyles.None, 
               out datetime);
            return ( isvalid && datetime > DateTime.Now);
        }
    }
}