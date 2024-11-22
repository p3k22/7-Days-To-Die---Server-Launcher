namespace _7D2D_ServerLauncher.Views
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow
   {
        public MainWindow()
        {
            InitializeComponent();

            ServerConfigPanel.Content = new Server();
            NetworkConfigPanel.Content = new Network();
            SlotConfigPanel.Content = new Slot();
            WebDashConfigPanel.Content = new WebDashboard();
            TelnetConfigPanel.Content = new Telnet();
            DirectoryConfigPanel.Content = new Directory();
            TechnicalConfigPanel.Content = new Technical();
            PerformanceConfigPanel.Content = new Performance();
            WorldConfigPanel.Content = new World();
            DifficultyConfigPanel.Content = new Difficulty();
            PlayerConfigPanel.Content = new Player();
            ZombieConfigPanel.Content = new Zombie();
            BloodMoonConfigPanel.Content = new BloodMoon();
            LootConfigPanel.Content = new Loot();
            LandClaimConfigPanel.Content = new LandClaim();
            TwitchConfigPanel.Content = new Twitch();
        }
    }
}