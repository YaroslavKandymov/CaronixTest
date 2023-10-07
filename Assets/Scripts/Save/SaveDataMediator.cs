using Zenject;

namespace CaronixTest.Save
{
    public class SaveDataMediator
    {
        [Inject] private PlayerSaveData _playerSaveData;
        
        public string PlayerName => _playerSaveData.Name;
        public int Money => _playerSaveData.Money;

        public void SaveName(string username)
        {
            _playerSaveData.Name = username;
            
            SaveSystem.SaveData(_playerSaveData);
        }

        public void AddMoney(int value)
        {
            _playerSaveData.Money += value;
            
            SaveSystem.SaveData(_playerSaveData);
        }
    }
}