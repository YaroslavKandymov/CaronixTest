using UnityEngine;

namespace CaronixTest.EnemyComponents
{
    public struct EnemyData
    {
        public string Name;
        public Texture2D Avatar;

        public EnemyData(string name, Texture2D avatar)
        {
            Name = name;
            Avatar = avatar;
        }
    }
}