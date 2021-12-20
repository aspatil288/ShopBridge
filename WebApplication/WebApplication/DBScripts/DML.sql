delete from category where id <8;
insert  into `category`(`id`,`Name`,`Is_Active`,`Created_By`,`Created_Date`) values 
(1,'Home Appliances',1,1,'2021-12-19 14:37:38'),
(2,'Clothing',1,1,'2021-12-19 14:37:43'),
(3,'Day Care',1,1,'2021-12-19 14:37:52'),
(4,'Cosmetics',1,1,'2021-12-19 14:37:57'),
(5,'Shoes',1,1,'2021-12-19 14:38:04'),
(6,'Electronics',1,1,'2021-12-19 14:38:09'),
(7,'Groceries',1,1,'2021-12-19 14:38:42');

delete from imagedata where productId = 1;
insert  into `imagedata`(`ProductId`,`Imagepath`) values 
(1,'~/Images/Santoor1.jpg'),
(1,'~/Images/Santoor2.jpg'),
(1,'~/Images/Santoor3.jpg');

delete from inventory where id < 2;
insert  into `inventory`(`Id`,`Item`,`Price`,`Description`,`DiscountAvailable`,`Is_Stock_Available`,`Is_Active`,`Created_By`,`Created_Date`,`Modified_By`,`Modified_Date`) values 
(1,'Santoor Soap',10,'Santoor Soap\r\nmfdt 01/12/21\r\n',2,1,1,1,'2021-12-19 00:00:02',NULL,'2021-12-19 08:35:27'),
(2,'Colgate',20,'Colgate\r\nmfdt - 01/02/21',0,1,1,NULL,'2021-12-19 14:35:08',NULL,'2021-12-19 14:35:08');

delete from map_inventory_category where ProductId < 3;
insert  into `map_inventory_category`(`ProductId`,`CategoryId`) values 
(1,3),
(2,3);

delete from map_user_roles where roleid in (1,2);
insert  into `map_user_roles`(`userId`,`roleId`) values 
(1,1),
(2,2),
(3,2);

delete from userroles where roleid <5;
insert  into `userroles`(`RoleId`,`Role`,`Is_Active`,`Created_by`,`Created_Date`) values 
(1,'Admin',1,1,'2021-12-19 14:41:22'),
(2,'User',1,1,'2021-12-19 14:41:28'),
(3,'Supervisor',1,1,'2021-12-19 14:41:39'),
(4,'Agent',1,1,'2021-12-19 14:41:47');

delete from users where userid <4;
insert  into `users`(`UserId`,`UserName`,`Email`,`Password`,`Confirm_Password`,`Created_By`,`Created_date`) values 
(1,'Admin','Admin123@gmail.com','admin@123','admin@123',1,'2021-12-19 14:40:02'),
(2,'WillSmith','WillSmith@gmail.com','will@123','will@123',1,'2021-12-19 14:40:35'),
(3,'John','John11@gmail.com','john@123','john@123',1,'2021-12-19 14:40:56');