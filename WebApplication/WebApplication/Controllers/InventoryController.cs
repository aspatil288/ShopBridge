using ShopBridgeBLL.Entity;
using ShopBridgeBLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : Controller
    {
        [HttpPost]
        [Route("CreateInventory")]
        public int CreateInventory(InventoryModel inventory, List<ImageModel> images, string userId)
        {
            InventoryService inventoryService = new InventoryService();
            int result;
            try
            {
                result = inventoryService.CreateInventory(inventory, images, userId);
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateInventory")]
        public int UpdateInventory(int inventoryId, InventoryModel inventory, List<ImageModel> images, string userId)
        {
            InventoryService inventoryService = new InventoryService();
            int result;
            try
            {
                result = inventoryService.UpdateInventory(inventoryId, inventory, images, userId);
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        [HttpGet]
        [Route("DeleteInventory")]
        public int DeleteInventory(int inventoryId, string userId)
        {
            InventoryService inventoryService = new InventoryService();
            int result;
            try
            {
                result = inventoryService.DeleteInventory(inventoryId, userId);
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        [HttpGet]
        [Route("GetInventoryById")]
        public InventoryModel GetInventoryById(int inventoryId)
        {
            InventoryService inventoryService = new InventoryService();
            InventoryModel inventory = null;
            try
            {
                inventory = inventoryService.GetInventoryById(inventoryId);
            }
            catch (Exception ex)
            {
                inventory = new InventoryModel();
            }
            return inventory;
        }
        [HttpGet]
        [Route("GetInventoryByCategory")]
        public List<InventoryModel> GetInventoryByCategory(int categoryId)
        {
            InventoryService inventoryService = new InventoryService();
            List<InventoryModel> inventory = null;
            try
            {
                inventory = inventoryService.GetInventoryByCategory(categoryId);
            }
            catch (Exception ex)
            {
                inventory = new List<InventoryModel>();
            }
            return inventory;
        }
        [HttpGet]
        [Route("GetAllInventories")]
        public List<InventoryModel> GetAllInventories()
        {
            InventoryService inventoryService = new InventoryService();
            List<InventoryModel> inventory = null;
            try
            {
                inventory = inventoryService.GetAllInventories();
            }
            catch (Exception ex)
            {
                inventory = new List<InventoryModel>();
            }
            return inventory;
        }

    }
}
