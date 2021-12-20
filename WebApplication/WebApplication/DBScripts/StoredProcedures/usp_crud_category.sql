DELIMITER $$

DROP PROCEDURE IF EXISTS `usp_crud_category`$$

CREATE PROCEDURE `usp_crud_category`(ip_flag VARCHAR(5),ip_xml TEXT, ip_userid INT, ip_category_id INT)
BEGIN

	DECLARE i INT DEFAULT 1;
	
	DROP TEMPORARY TABLE IF EXISTS temp_category;
	CREATE TEMPORARY TABLE temp_category
	(
		`name` VARCHAR(50),		is_active TINYINT
	);
	
	whileloop: WHILE (TRUE) DO
		IF(EXTRACTVALUE(ip_xml,'//root/data[$i]/CategoryName') <> '') THEN
			INSERT INTO temp_category
			(
				`name`,			is_active
			)
			SELECT
				EXTRACTVALUE(ip_xml,'//root/data[$i]/CategoryName'),
				EXTRACTVALUE(ip_xml,'//root/data[$i]/isActive');
				
				SET i = i + 1;
		ELSE
			LEAVE whileloop;
		END IF;
	END WHILE;

	IF ip_flag IN ("cr") THEN
		
		INSERT INTO category
		(
			`name`,			is_active,		created_by,	created_date
		)
		SELECT	`name`,			is_active		ip_userid,	NOW()
		FROM    temp_category;
		
	ELSEIF ip_flag IN ('dl') THEN
		
		UPDATE 		category c
		INNER JOIN 	temp_category tc 	ON tc.name = c.name			
		SET		c.is_active = 0
		WHERE		c.id = ip_category_id;
	
	ELSEIF ip_flag IN ('ga') THEN
		
		SELECT 		`id`,			`name`,			is_active
		FROM 		category;
	END IF;
		
	
END$$

DELIMITER;
	