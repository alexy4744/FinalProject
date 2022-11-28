START TRANSACTION;

CREATE DATABASE final_project;

USE final_project;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
    ) CHARACTER SET=utf8mb4;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Recipes` (
                           `Id` int NOT NULL AUTO_INCREMENT,
                           `CreatedOnUtc` datetime(6) NOT NULL,
                           `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
                           `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
                           `Steps` longtext CHARACTER SET utf8mb4 NOT NULL,
                           CONSTRAINT `PK_Recipes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Ingredient` (
                              `RecipeId` int NOT NULL,
                              `Id` int NOT NULL AUTO_INCREMENT,
                              `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
                              `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
                              `Quantity` int unsigned NOT NULL,
                              CONSTRAINT `PK_Ingredient` PRIMARY KEY (`Id`, `RecipeId`),
                              CONSTRAINT `FK_Ingredient_Recipes_RecipeId` FOREIGN KEY (`RecipeId`) REFERENCES `Recipes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE UNIQUE INDEX `IX_Recipes_Name` ON `Recipes` (`Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221127220703_InitalCreate', '6.0.11');

COMMIT;

