using Ex05_01.GameFramework;

namespace Ex05_01.GameUI
{
    internal class GameInit
    {
        
        internal static void StartGame()
        {
            FormGameSettingsD formGameSettings = new FormGameSettingsD();
            formGameSettings.ShowDialog();
        }
    }
}
