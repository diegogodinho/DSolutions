using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Web.Comum.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RangeFieldRangeValidator : ValidationAttribute
    {
        public int minValue { get; set; }
        public int maxValue { get; set; }
        
        private const string _defaultErrorMessage =" o valor deve estar entre {0} e {1}.";

        public RangeFieldRangeValidator()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                 minValue, maxValue);
        }
        
        public override bool IsValid(object value)
        {
            int valueAsString = (Int32)value;
            return (valueAsString >= minValue && valueAsString <= maxValue);
        }

    }
}