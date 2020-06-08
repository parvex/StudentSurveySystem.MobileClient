using System.ComponentModel;
using System.Runtime.CompilerServices;
using IO.Swagger.Model;
using Mapster;

namespace MobileClient.Views.MySurveys
{
    public class QuestionVm : QuestionDto, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public QuestionVm()
        {
        }

        public QuestionVm(QuestionDto question)
        {
            this.Id = question.Id;
            this.Index = question.Index;
            this.QuestionText = question.QuestionText;
            this.QuestionType = question.QuestionType;
            this.ValidationConfig = question.ValidationConfig;
            this.Values = question.Values;
        }

        public new int? Index { get; set; }

        public QuestionDto ToDto()
        {
            var dto = this.Adapt<QuestionDto>();
            return dto;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}