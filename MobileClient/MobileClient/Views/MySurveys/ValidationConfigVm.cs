using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using IO.Swagger.Model;
using Mapster;
using MobileClient.Annotations;
using MobileClient.Models;

namespace MobileClient.Views.MySurveys
{
    public class ValidationConfigVm : ValidationConfig, INotifyPropertyChanged
    {
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

        public new string MinNumericValue { get; set; }

        public new string MaxNumericValue { get; set; }

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
            dto.MaxNumericValue = double.TryParse(MaxNumericValue, out var tempValMax) ? tempValMax : (double?)null;
            dto.MinNumericValue = double.TryParse(MinNumericValue, out var tempValMin) ? tempValMin : (double?)null;
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