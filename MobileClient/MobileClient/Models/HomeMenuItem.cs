namespace MobileClient.Models
{
    public enum MenuItemType
    {
        FillSurveys,
        MySurveys,
        MyResponses,
        AllResponses,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}