namespace FlashCardBlazorApp.Shared
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
