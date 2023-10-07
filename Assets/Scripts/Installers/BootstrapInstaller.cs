using CaronixTest.Save;
using CaronixTest.StringFields;
using Zenject;

namespace CaronixTest.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            FillFileNames();
            BindPlayerData();
        }

        private void FillFileNames()
        {
            FileNamesContainer.Add(typeof(PlayerSaveData), FileNames.PlayerData);
        }

        private void BindPlayerData()
        {
            var data = SaveSystem.LoadData<PlayerSaveData>();

            if (data == null)
            {
                data = new PlayerSaveData();
                
                SaveSystem.SaveData(data);
            }

            Container.BindInstance(data);
        }
    }
}