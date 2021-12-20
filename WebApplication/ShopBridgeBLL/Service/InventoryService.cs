using Newtonsoft.Json;
using ShopBridgeBLL.Entity;
using ShopBridgeBLL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeBLL.Service
{
    public class InventoryService
    {
        InventoryRepository inventoryRepository = new InventoryRepository();
        public int CreateInventory(InventoryModel inventory, List<ImageModel> images, string userId)
        {
            return inventoryRepository.AddProduct(CreateInventoryXML(inventory), CreateImageXML(images), userId);
        }
        public int UpdateInventory(int inventoryId, InventoryModel inventory, List<ImageModel> images, string userId)
        {
            return inventoryRepository.UpdateProduct(inventoryId, CreateInventoryXML(inventory), CreateImageXML(images), userId);
        }
        public int DeleteInventory(int inventoryId, string userId)
        {
            return inventoryRepository.DeleteProduct(inventoryId, userId);
        }

        public InventoryModel GetInventoryById(int inventoryId)
        {
            DataTable dt = inventoryRepository.GetProductById(inventoryId);
            return ProcessInventories(dt).First();
        }
        public List<InventoryModel> GetInventoryByCategory(int categoryId)
        {
            DataTable dt = inventoryRepository.GetProductByCategory(categoryId);
            return ProcessInventories(dt);
        }
        public List<InventoryModel>  GetAllInventories()
        {
            DataTable dt = inventoryRepository.GetAllItems();
            return ProcessInventories(dt);
        }
        private List<InventoryModel> ProcessInventories(DataTable dt)
        {
            List<InventoryModel> inventories = new List<InventoryModel>();
            inventories.AddRange(from dr in System.Data.DataTableExtensions.AsEnumerable(dt)
                                 select new InventoryModel()
                                 {
                                     Id = Convert.ToInt32(dr["id"]) is DBNull ? 0 : Convert.ToInt32(dr["id"]),
                                     ProductName = Convert.ToString(dr["item"]) is DBNull ? "" : Convert.ToString(dr["item"]),
                                     Category = Convert.ToString(dr["category"]) is DBNull ? "" : Convert.ToString(dr["category"]),
                                     Description = Convert.ToString(dr["Description"]) is DBNull ? "" : Convert.ToString(dr["Description"]),
                                     DiscountAvailable = Convert.ToInt32(dr["DiscountAvailable"]) is DBNull ? 0 : Convert.ToInt32(dr["DiscountAvailable"]),
                                     IsActive = Convert.ToInt32(dr["is_active"]) is DBNull ? 0 : Convert.ToInt32(dr["is_active"]),
                                     IsStockAvailable = Convert.ToInt32(dr["Is_Stock_Available"]) is DBNull ? 0 : Convert.ToInt32(dr["Is_Stock_Available"]),
                                     Price = Convert.ToDouble(dr["price"]) is DBNull ? 0 : Convert.ToDouble(dr["price"]),
                                     Images = Convert.ToString(dr["images"]) is DBNull ? "" : Convert.ToString(dr["images"])
                                 });
            return inventories;
        }
        private string CreateInventoryXML(InventoryModel inventories)
        {
            var serializeData = JsonConvert.SerializeObject(inventories);
            return JsonConvert.DeserializeXmlNode("{\"doc\":" + serializeData + "}", "root").InnerXml;
        }
        private string CreateImageXML(IEnumerable<ImageModel> images)
        {
            var serializeData = JsonConvert.SerializeObject(images);
            return JsonConvert.DeserializeXmlNode("{\"doc\":" + serializeData + "}", "root").InnerXml;
        }
    }
}
