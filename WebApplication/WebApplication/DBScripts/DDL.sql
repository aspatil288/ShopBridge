DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Is_Active` tinyint DEFAULT '1',
  `Created_By` int DEFAULT '1',
  `Created_Date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `imagedata`;

CREATE TABLE `imagedata` (
  `ProductId` int DEFAULT NULL,
  `Imagepath` varchar(200) DEFAULT NULL
);

DROP TABLE IF EXISTS `inventory`;

CREATE TABLE `inventory` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Item` varchar(50) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DiscountAvailable` int DEFAULT NULL,
  `Is_Stock_Available` tinyint DEFAULT '1',
  `Is_Active` tinyint DEFAULT '1',
  `Created_By` int DEFAULT '1',
  `Created_Date` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified_By` int DEFAULT NULL,
  `Modified_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `inventory_history`;

CREATE TABLE `inventory_history` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Item` varchar(50) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DiscountAvailable` int DEFAULT NULL,
  `Is_Stock_Available` tinyint DEFAULT NULL,
  `Is_Active` tinyint DEFAULT NULL,
  `Created_By` int DEFAULT NULL,
  `Created_Date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `map_inventory_category`;

CREATE TABLE `map_inventory_category` (
  `ProductId` bigint DEFAULT NULL,
  `CategoryId` int DEFAULT NULL
);

DROP TABLE IF EXISTS `map_user_roles`;

CREATE TABLE `map_user_roles` (
  `userId` int DEFAULT NULL,
  `roleId` int DEFAULT NULL
);

DROP TABLE IF EXISTS `userroles`;

CREATE TABLE `userroles` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `Role` varchar(20) DEFAULT NULL,
  `Is_Active` tinyint DEFAULT NULL,
  `Created_by` int DEFAULT NULL,
  `Created_Date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`RoleId`)
);

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Password` varchar(200) DEFAULT NULL,
  `Confirm_Password` varchar(200) DEFAULT NULL,
  `Created_By` int DEFAULT '1',
  `Created_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`)
);

