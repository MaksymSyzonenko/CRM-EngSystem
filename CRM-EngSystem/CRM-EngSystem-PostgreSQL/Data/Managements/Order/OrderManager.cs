using AutoMapper;
using CRM_EngSystem_PostgreSQL.Data.Entities.Catalog;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.WareHouse;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;

namespace CRM_EngSystem_PostgreSQL.Data.Managements.Order
{
    public sealed class OrderManager : IOrderManager
    {
        private const int DefaultDiscount = 35;
        private const int DefaultMarkUp = 55;
        private const double DefaultWeightCoefficient = 1.75;
        private const double DefaultVolumeCoefficient = 2.4;
        private const decimal DefaultShippingCost = 100;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public static decimal CalculatePurchaseCost(int discount, decimal price)
            => (1 - discount) * price;

        public static decimal CalculateSellPrice(int discount, int markUp,  decimal price)
            => (1 + markUp) * CalculatePurchaseCost(discount, price);

        public static decimal CalculateShippingCost(double weight, double weightCoefficient, double volume, double volumeCoefficient)
            => DefaultShippingCost + (decimal)((weight * weightCoefficient) + (volume * volumeCoefficient));

        public async Task<bool> AddEquipmentToOrderAsync(EquipmentCatalogPositionEntity equipmentCatalogPosition, OrderEntity order)
        {
            if(order.EquipmentOrderPositions!.Any(equipment => equipment.EquipmentCatalogPositionId == equipmentCatalogPosition.EquipmentCatalogPositionId)) 
                return false;

            int quantityInStock = (await ((IWareHouseRepository)_unitOfWork.Repository<WareHouseEntity>())
                .GetEquipmentWareHousePositionAsync(equipmentCatalogPosition.EquipmentCatalogPositionId)).Quantity;

            EquipmentOrderPositionEntity equipmentOrderPosition = new()
            {
                EquipmentCatalogPosition = equipmentCatalogPosition,
                Order = order,
                Price = equipmentCatalogPosition.Price,
                Discount = DefaultDiscount,
                MarkUp = DefaultMarkUp,
                Quantity = 1,
                PurchaseCost = CalculatePurchaseCost(DefaultDiscount, equipmentCatalogPosition.Price),
                SellPrice = CalculateSellPrice(DefaultDiscount, DefaultMarkUp, equipmentCatalogPosition.Price),
                QuantityInStock = quantityInStock,
                QuantityToTake = 0,
                ShippingCost = CalculateShippingCost(equipmentCatalogPosition.Weight, DefaultWeightCoefficient, equipmentCatalogPosition.Volume, DefaultVolumeCoefficient)
            };

            await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).AddEquipmentOrderPositionAsync(equipmentOrderPosition);

            return true;
        }

        public async Task ChangeEquipmentCalculationsForOrderAsync(EquipmentOrderPositionEntity equipmentOrderPosition, int discount, int markUp)
        {
            var updatedEquipment = _mapper.Map<EquipmentOrderPositionEntity, EquipmentOrderPositionEntity>(equipmentOrderPosition);

            updatedEquipment.Discount = discount;
            updatedEquipment.MarkUp = markUp;
            updatedEquipment.PurchaseCost = CalculatePurchaseCost(discount, equipmentOrderPosition.Price);
            updatedEquipment.SellPrice = CalculateSellPrice(discount, markUp, equipmentOrderPosition.Price);

            await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).UpdateEquipmentOrderPositionAsync(equipmentOrderPosition.EquipmentCatalogPositionId, updatedEquipment);
        }

        public async Task ChangeEquipmentQuantityForOrderAsync(EquipmentOrderPositionEntity equipmentOrderPosition, int quantity)
        {
            var updatedEquipment = _mapper.Map<EquipmentOrderPositionEntity, EquipmentOrderPositionEntity>(equipmentOrderPosition);

            updatedEquipment.Quantity = quantity;

            await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).UpdateEquipmentOrderPositionAsync(equipmentOrderPosition.EquipmentCatalogPositionId, updatedEquipment);
        }
    }
}
