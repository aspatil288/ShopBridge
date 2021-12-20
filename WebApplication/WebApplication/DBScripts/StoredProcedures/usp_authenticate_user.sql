DELIMITER $$

DROP PROCEDURE IF EXISTS `usp_authenticate_user`$$

CREATE PROCEDURE `usp_authenticate_user`(ip_username VARCHAR(200), ip_password VARCHAR(200))
BEGIN

	SELECT 	UserId
	FROM 	users
	WHERE 	username = ip_username AND `password` = ip_password;
	
END$$

DELIMITER;
	