using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IO.Swagger.Model;
using Mapster;
using MobileClient.Annotations;
using MobileClient.Models;

namespace MobileClient.Views.MySurveys
{
    public class ValidationConfigVm : ValidationConfig, INotifyPropertyChanged
    {
        private double? _maxNumericValue;
        private double? _minNumericValue;
        private DateTime? _minDateValue;
        private string _regex;
        private DateTime? _maxDateValue;

        public event PropertyChangedEventHandler PropertyChanged;
        public AutoObsDictionary<string, string> ErrorDictionary { get; set; } = new AutoObsDictionary<string, string>();


        public new string Regex
        {
            get => _regex;
            set
            {
                ErrorDictionary["Regex"] = IsValidRegex(value) ? null : "Regex is invalid";
                _regex = value;
            }
        }

        public new string MinNumericValue
        {
            get => _minNumericValue.ToString();
            set
            {
                _minNumericValue = double.TryParse(value, out var tempVal) ? tempVal : (double?)null;
                ErrorDictionary["NumericRange"] = _minNumericValue > _maxNumericValue ? "Min value must be lesser than max" : null;
            }
        }

        public new string MaxNumericValue
        {
            get => _maxNumericValue.ToString();
            set
            {
                _maxNumericValue = double.TryParse(value, out var tempVal) ? tempVal : (double?)null;
                ErrorDictionary["NumericRange"] = _minNumericValue > _maxNumericValue ? "Min value must be lesser than max" : null;
            }
        }

        public new DateTime? MinDateValue
        {
            get => _minDateValue;
            set
            {
                ErrorDictionary["DateRange"] = value > MaxDateValue ? "Min date must be before max" : null;
                _minDateValue = value;
            }
        }

        public new DateTime? MaxDateValue
        {
            get => _maxDateValue;
            set
            {
                ErrorDictionary["DateRange"] = MinDateValue > value ? "Min date must be before max" : null;
                _maxDateValue = value;
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ValidationConfig ToDto()
        {
            var config = new TypeAdapterConfig();
            config.ForType<ValidationConfigVm, ValidationConfig>().ConstructUsing(src => new ValidationConfig(default, default, default, default, default, default))
                .Ignore(x => x.MaxNumericValue)
                .Ignore(x => x.MinNumericValue);
            var dto = this.Adapt<ValidationConfig>(config);
            dto.MaxNumericValue = _maxNumericValue;
            dto.MinNumericValue = _minNumericValue;
            return dto;
        }

        private bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return false;

            try
            {
                System.Text.RegularExpressions.Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}