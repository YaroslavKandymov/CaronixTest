using System;

namespace CaronixTest.Save
{
    [Serializable]
    public class PlayerSaveData : SaveData
    {
        public string Name;
        public int Money;
    }
}