using System.Collections.Generic;

namespace Code.Scripts
{
    public class Container
    {
        private readonly Dictionary<string, ItemStack> _itemStacks;
        private readonly string[,] _grid;
        private readonly int _width;
        private readonly int _height;

        public Container(int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new string[width, height];
            _itemStacks = new Dictionary<string, ItemStack>();
        }

        public ItemStack GetItemStack(int targetX, int targetY)
        {
            if (targetX < 0 || targetX >= _width) return null;
            if (targetY < 0 || targetY >= _height) return null;

            return _grid[targetX, targetY] == null ? null : _itemStacks.GetValueOrDefault(_grid[targetX, targetY]);
        }

        public ItemStack AddItemStack(ItemStack itemStack, int targetX, int targetY)
        {
            if (!CanAddItemStack(itemStack, targetX, targetY)) return null;
            _itemStacks[itemStack.GetGuid()] = itemStack;

            for (var i = 0; i < itemStack.GetWidth(); i++)
            {
                for (var j = 0; j < itemStack.GetHeight(); j++)
                {
                    _grid[targetX + i, targetY + j] = itemStack.GetGuid();
                }
            }

            return itemStack;
        }

        public ItemStack AddItemStack(ItemStack itemStack)
        {
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    if (AddItemStack(itemStack, i, j) != null) return itemStack;
                }
            }

            return null;
        }

        public bool CanAddItemStack(ItemStack itemStack, int targetX, int targetY)
        {
            if (targetX < 0 || targetX >= _width) return false;
            if (targetY < 0 || targetY >= _height) return false;

            for (var i = 0; i < itemStack.GetWidth(); i++)
            {
                for (var j = 0; j < itemStack.GetHeight(); j++)
                {
                    var checkX = targetX + i;
                    var checkY = targetY + j;

                    if (checkX < 0 || checkX >= _width || checkY < 0 || checkY >= _height) return false;
                    if (_grid.GetValue(checkX, checkY) != null) return false;
                }
            }

            return true;
        }
    }
}