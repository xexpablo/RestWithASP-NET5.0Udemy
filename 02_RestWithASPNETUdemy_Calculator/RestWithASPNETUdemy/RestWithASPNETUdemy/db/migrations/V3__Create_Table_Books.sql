CREATE TABLE `books` (
	`id` INT(10) NOT NULL AUTO_INCREMENT,
	`price` DECIMAL(62,2) NOT NULL DEFAULT '0.00',
	`author` LONGTEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`launch_date` DATETIME(6) NOT NULL,
	`title` LONGTEXT NOT NULL COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;