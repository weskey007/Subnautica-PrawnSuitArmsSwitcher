using System.Collections.Generic;

namespace PrawnSuitArmSwitcher.ExosuitArms
{
    public class ExosuitArmsStorage : IExosuitArmsStorage
    {
        public static ExosuitArmsStorage CreateInstance(IItemsContainer container) => new ExosuitArmsStorage(container);

        protected ExosuitArmsStorage(IItemsContainer container)
        {
            _armsContainer = container;
        }

        protected IItemsContainer _armsContainer;

        public IEnumerable<InventoryItem> GetAvailableArms()
        {
            foreach (var possibleArm in _armsContainer)
                if (CraftData.GetEquipmentType(possibleArm.item.GetTechType()) == EquipmentType.ExosuitArm)
                    yield return possibleArm;
        }

        public bool AddItem(InventoryItem inventoryItem) => _armsContainer.AddItem(inventoryItem);

        public bool RemoveItem(InventoryItem inventoryItem) => _armsContainer.RemoveItem(inventoryItem, true, false);

        public bool HasRoomFor(InventoryItem inventoryItem) => _armsContainer.HasRoomFor(inventoryItem.item, null);
    }
}
