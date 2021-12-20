DELIMITER $$

DROP PROCEDURE IF EXISTS `usp_crud_inventory`$$

CREATE PROCEDURE `usp_crud_inventory`(ip_flag	VARCHAR(10),	ip_inventory_id	INT, ip_category_id INT,	ip_xml TEXT, ip_map_image_xml TEXT, ip_userid INT)
BEGIN

	DECLARE i INT DEFAULT 1;
	DECLARE j INT DEFAULT 1;
	
	IF ip_flag IN ('cr','up') THEN
		DROP TEMPORARY TABLE IF EXISTS temp_inventory;
		CREATE TEMPORARY TABLE temp_inventory
		(
			item VARCHAR(50),		price DOUBLE,		`description` TEXT,		DiscountAvailable INT,		Is_Stock_Available TINYINT,		
			Is_Active TINYINT,		category INT
		);
		
		whileloop: WHILE (TRUE) DO
			IF(EXTRACTVALUE(ip_xml,'//root/data[$i]/ProductName') <> '') THEN
				INSERT INTO temp_inventory
				(
					item,		price,		`description`,		discountAvailable,		is_stock_available,
					is_active,	category
				)
				SELECT
					EXTRACTVALUE(ip_xml,'//root/data[$i]/ProductName'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/Price'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/Description'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/DiscountAvailable'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/IsStockAvailable'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/IsActive'),
					EXTRACTVALUE(ip_xml,'//root/data[$i]/Category');
					
					SET i = i + 1;
			ELSE
				LEAVE whileloop;
			END IF;
		END WHILE;

		DROP TEMPORARY TABLE IF EXISTS temp_inventory_image;
		CREATE TEMPORARY TABLE temp_inventory_image
		(
			item VARCHAR(50),		Imagepath VARCHAR(200)
		);
		
		whileloop: WHILE (TRUE) DO
			IF(EXTRACTVALUE(ip_map_image_xml,'//root/data[$j]/ProductName') <> '') THEN
				INSERT INTO temp_inventory_image
				(
					item,		Imagepath
				)
				SELECT
					EXTRACTVALUE(ip_map_image_xml,'//root/data[$j]/ProductName'),
					EXTRACTVALUE(ip_map_image_xml,'//root/data[$j]/Imagepath');
					
					SET j = j + 1;
			ELSE
				LEAVE whileloop;
			END IF;
		END WHILE;

		IF ip_flag IN ("cr") THEN
			INSERT INTO inventory
			(
				item,			price,		`description`,		`DiscountAvailable`,		`Is_Stock_Available`,
				`Is_Active`,		`Created_By`,	`Created_Date`
			)
			SELECT	item,			price,		`Description`,		`DiscountAvailable`,		Is_Stock_Available,
				is_Active,		ip_userid,	NOW()
			FROM    temp_inventory;
			
			INSERT INTO	`map_inventory_category`
				(
					productid,		categoryid
				)
			SELECT		p.id,			pc.id
			FROM		inventory p
			INNER JOIN	temp_inventory tp 	ON tp.item = p.item
			INNER JOIN	`category` pc 	ON pc.id = tp.category;
			
			INSERT INTO	`imageData`
				(
					productId,		imagepath
				)
			SELECT		p.id,			tpi.imagepath
			FROM     	temp_inventory_image	tpi
			INNER JOIN	inventory p 		ON p.item = tpi.item;
		ELSE
			INSERT INTO 	`inventory_history`
				(
					item,			price,			`Description`,			DiscountAvailable,		Is_Stock_Available,		Is_Active,
					created_by,		created_date
				)
			SELECT		item,			price,			`Description`,			DiscountAvailable,		Is_Stock_Available,		Is_Active,
					ip_userid,		NOW()
			FROM 		inventory
			WHERE		id = ip_inventory_id;
			
			
			UPDATE 		inventory p
			INNER JOIN 	temp_inventory tp 	ON tp.item = p.item
			SET		p.price = tp.price,
					p.description = tp.description,
					p.discountAvailable = tp.discountAvailable,
					p.is_stock_available = tp.is_stock_available,
					p.is_active = tp.is_active,
					modified_by = ip_userid,
					modified_Date = NOW()
			WHERE		p.id = ip_inventory_id;
		END IF;
		
	ELSEIF ip_flag IN ('gibi') THEN -- get inventory by id
		SELECT 		id,			item,			price,			`Description`,			DiscountAvailable,		Is_Stock_Available,
				p.is_active,		pc.name AS category,	GROUP_CONCAT(IFNULL(pim.imagepath,''),"|") AS images
		FROM 		inventory p
		INNER JOIN	map_inventory_category	mpc ON mpc.productid = p.id
		INNER JOIN	category		pc ON pc.id = mpc.categoryid
		LEFT JOIN	`imageData`		pim ON pim.productId = p.id
		WHERE		p.id = ip_inventory_id;
		
	ELSEIF ip_flag IN ('gibc') THEN -- get inventory by category
		SELECT 		id,			item,			price,			`Description`,			DiscountAvailable,		Is_Stock_Available,
				p.is_active,		pc.name AS category,	GROUP_CONCAT(IFNULL(pim.imagepath,''),"|") AS images
		FROM 		inventory p
		INNER JOIN	map_inventory_category	mpc ON mpc.productid = p.id
		INNER JOIN	category		pc ON pc.id = mpc.categoryid
		LEFT JOIN	`imageData`		pim ON pim.productId = p.id
		WHERE		pc.id = ip_category_id
		GROUP BY	item;
		
	ELSEIF ip_flag IN ('gai') THEN
		SELECT 		id,			item,			price,			`Description`,			DiscountAvailable,		Is_Stock_Available,		
				p.is_active,		pc.name AS category ,	GROUP_CONCAT(IFNULL(pim.imagepath,''),"|") AS images
		FROM 		inventory p
		INNER JOIN	map_inventory_category	mpc ON mpc.productid = p.id
		INNER JOIN	category		pc ON pc.id = mpc.categoryid
		LEFT JOIN	`imageData`		pim ON pim.productId = p.id
		GROUP BY	item;
	
	ELSEIF ip_flag IN ('dl') THEN
		UPDATE 		inventory
		SET 		is_active = 0,
				modified_by = ip_userid,
				modified_Date = NOW()
		WHERE 		id = ip_inventory_id;
	
	END IF;
END$$

DELIMITER;
	