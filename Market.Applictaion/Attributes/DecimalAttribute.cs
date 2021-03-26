using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Market.Applictaion.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DecimalAttribute : ValidationAttribute
    {
        public DecimalAttribute(int precision, int scale)
        {
            Precision = precision;
            Scale = scale;
        }

        public int Precision { get; private  set; }
        public int Scale { get; private set; }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is decimal)
            {
                if (Precision <= Scale)
                {
                    return new ValidationResult("Precision must be greater then scale.");
                }

                var integerPart = Precision - Scale;
                var regex = new Regex(@"^\-?\d{0," + integerPart + @"}(.\d{0," + Scale + "})?$");
                if (!regex.IsMatch(((decimal)value).ToString(CultureInfo.InvariantCulture)))
                {
                    return new ValidationResult($"Given {value} does not match decimal {(Precision, Scale)} pattern.");
                }
                else
                {
                    return null;
                }
            }
            return new ValidationResult("Type provided must be an Decimal.");

        }
    }
}
