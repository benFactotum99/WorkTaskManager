namespace WorkTaskManagerBackend.Config.Settings
{
    public partial class AppSettings
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; }
    }

    public class ConnectionStringsConfig
    {
        public string cnn { get; set; }
    }
}
