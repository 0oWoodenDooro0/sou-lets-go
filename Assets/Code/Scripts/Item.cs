using UnityEngine;

namespace Code.Scripts
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        public int id;
        public new string name;
        public int width;
        public int height;
        public int price;
    }
}