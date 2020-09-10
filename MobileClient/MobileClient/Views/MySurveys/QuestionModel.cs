using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IO.Swagger.Model;
using Mapster;

namespace MobileClient.Views.MySurveys
{
    public class QuestionModel :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int? Id { get; set; }
        public int? Index  {get; set;}
        public string QuestionText  {get; set;}
        public QuestionType QuestionType  {get; set;}
        public bool? Required  {get; set;}
        public ValidationConfig ValidationConfig  {get; set;}
        public List<StringDoubleNullableValueTuple> Values {get; set;}

        public QuestionModel()
        {
        }

        public QuestionModel(QuestionDto question)
        {
            Id = question.Id;
            Index = question.Index;
            QuestionText = question.QuestionText;
            QuestionType = question.QuestionType;
            Required = question.Required;
            ValidationConfig = question.ValidationConfig;
            Values = question.Values;
        }

        public QuestionDto ToDto()
        {
            return new QuestionDto(Id, Index, QuestionText, QuestionType, Required, ValidationConfig, Values);
        }

        public QuestionModel Clone()
        {
            var model = new QuestionModel();
            model.Id = Id;
            model.Index = Index;
            model.QuestionText = QuestionText;
            model.QuestionType = QuestionType;
            model.Required = Required;
            model.ValidationConfig = ValidationConfig;
            model.Values = Values;
            return model;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}