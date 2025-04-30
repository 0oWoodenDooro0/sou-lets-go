using System;

namespace Code.Scripts
{
    public class ItemStack
    {
        private readonly string _guid = Guid.NewGuid().ToString();
        private readonly Item _item;
        private int _amount;
        private readonly bool _canRotate;
        private ItemOrientation _orientation = ItemOrientation.Deafult;

        public ItemStack(Item item)
        {
            _item = item;
            _canRotate = item.width != item.height;
            _amount = 1;
        }

        public ItemStack(Item item, int amount)
        {
            _item = item;
            _canRotate = item.width != item.height;
            _amount = amount;
        }

        public string GetGuid()
        {
            return _guid;
        }

        public int GetWidth()
        {
            return _orientation == ItemOrientation.Deafult ? _item.width : _item.height;
        }

        public int GetHeight()
        {
            return _orientation == ItemOrientation.Deafult ? _item.height : _item.width;
        }

        public ItemOrientation GetOrientation()
        {
            return _orientation;
        }

        public void ChangeOrientation()
        {
            if (!_canRotate) return;

            if (_orientation == ItemOrientation.Deafult)
            {
                _orientation = ItemOrientation.Right;
                return;
            }

            _orientation = ItemOrientation.Deafult;
        }
    }

    public enum ItemOrientation
    {
        Deafult,
        Right,
    }
}