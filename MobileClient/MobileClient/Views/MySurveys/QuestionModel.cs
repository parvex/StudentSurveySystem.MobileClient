using System.ComponentModel;
using System.Runtime.CompilerServices;
using IO.Swagger.Model;
using Mapster;

namespace MobileClient.Views.MySurveys
{
    public class QuestionModel : QuestionDto, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public QuestionModel()
        {
        }

        public QuestionModel(QuestionDto question) : base(question.Id, question.Index, question.QuestionText, question.QuestionType, question.ValidationConfig, question.Values)
        {
        }

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