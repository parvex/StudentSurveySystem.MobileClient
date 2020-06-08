namespace MobileClient.Models
{
    public enum MenuItemType
    {
        FillSurveys,
        MySurveys,
        MySurveyTemplates,
        MyResponses,
        AllResponses,
        About,
        Logout,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}