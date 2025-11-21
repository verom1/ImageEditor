namespace ImageEditorApp.Patterns.Singleton
{
    // Простий Singleton для налаштувань (наприклад, остання папка)
    public sealed class AppSettings
    {
        private static readonly AppSettings _instance = new AppSettings();
        public static AppSettings Instance => _instance;

        private AppSettings() { }

        public string LastOpenFolder { get; set; } = "";
    }
}
