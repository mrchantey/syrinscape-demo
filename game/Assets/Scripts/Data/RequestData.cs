using System;


namespace SyrinscapeDemo
{
    [Serializable]
    public struct RequestData
    {
        public string weaponType;
        public string enemyType;
        public override string ToString() => $"weapon type: {weaponType}\tenemy type: {enemyType}";
    }

}

