using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentSurveySystem.ApiClient.Model;

namespace MobileClient.Views.MySurveys
{
    public class QuestioDtoModel : QuestionDto, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public QuestioDtoModel()
        {
        }

        public QuestioDtoModel(QuestionDto question)
        {
            this.Id = question.Id;
            this.Index = question.Index;
            this.QuestionText = question.QuestionText;
            this.QuestionType = question.QuestionType;
            this.ValidationConfig = question.ValidationConfig;
            this.Values = question.Values;
        }

        public new int? Index { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}