-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: proyectolabo4
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comments` (
  `PostId` int NOT NULL,
  `UserId` int NOT NULL,
  `MainContent` varchar(600) NOT NULL,
  `Media` varchar(300) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `DeletedAt` datetime DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  `CommentId` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`CommentId`),
  KEY `PostId` (`PostId`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `comments_ibfk_1` FOREIGN KEY (`PostId`) REFERENCES `posts` (`PostId`),
  CONSTRAINT `comments_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
INSERT INTO `comments` VALUES (1,2,'¡Gran publicación del post 1!',NULL,'2023-11-01 21:08:09',NULL,NULL,1),(1,2,'¡Gran publicación del post 1!',NULL,'2023-11-01 21:08:10',NULL,NULL,2),(2,1,'Esto es interesante.',NULL,'2023-11-01 21:08:12',NULL,NULL,3),(1,3,'creato','creato','2023-11-07 19:19:43',NULL,NULL,4);
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `communities`
--

DROP TABLE IF EXISTS `communities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `communities` (
  `CommunityId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `State` tinyint(1) NOT NULL,
  PRIMARY KEY (`CommunityId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `communities`
--

LOCK TABLES `communities` WRITE;
/*!40000 ALTER TABLE `communities` DISABLE KEYS */;
INSERT INTO `communities` VALUES (1,'Comunidad 1',1),(2,'Comunidad 2',0),(3,'Comunidad 3',1),(4,'Deporte',1);
/*!40000 ALTER TABLE `communities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `likes` (
  `PostId` int NOT NULL,
  `UserId` int NOT NULL,
  PRIMARY KEY (`UserId`,`PostId`),
  KEY `PostId` (`PostId`),
  CONSTRAINT `likes_ibfk_1` FOREIGN KEY (`PostId`) REFERENCES `posts` (`PostId`),
  CONSTRAINT `likes_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likes`
--

LOCK TABLES `likes` WRITE;
/*!40000 ALTER TABLE `likes` DISABLE KEYS */;
INSERT INTO `likes` VALUES (1,1),(1,2);
/*!40000 ALTER TABLE `likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `posts`
--

DROP TABLE IF EXISTS `posts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `posts` (
  `PostId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `DateTime` datetime NOT NULL,
  `Title` varchar(255) NOT NULL,
  `MainContent` varchar(600) NOT NULL,
  `Media` varchar(255) DEFAULT NULL,
  `CommunityId` int NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `DeletedAt` datetime DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  PRIMARY KEY (`PostId`),
  KEY `UserId` (`UserId`),
  KEY `CommunityId` (`CommunityId`),
  CONSTRAINT `posts_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `posts_ibfk_2` FOREIGN KEY (`CommunityId`) REFERENCES `communities` (`CommunityId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posts`
--

LOCK TABLES `posts` WRITE;
/*!40000 ALTER TABLE `posts` DISABLE KEYS */;
INSERT INTO `posts` VALUES (1,1,'2023-11-01 12:00:00','Mi primera publicación','Este es el contenido de mi publicación.','imagen.jpg',1,'2023-11-01 21:06:50',NULL,NULL),(2,2,'2023-11-01 14:30:00','Otra publicación interesante','Aquí va el contenido de otra publicación.',NULL,2,'2023-11-01 21:07:12',NULL,NULL),(3,1,'0001-01-01 00:00:00','Public creada aca','Public creada aca','Public creada aca',1,'2023-11-03 21:31:58',NULL,NULL),(4,1,'0001-01-01 00:00:00',' segunda Public creada aca',' segunda  Public creada aca','segunda  Public creada aca',1,'2023-11-03 21:32:33',NULL,NULL),(5,3,'0001-01-01 00:00:00','Natali el mas capito','NAtali callate la boca','dale BBOCA.PNG',2,'2023-11-04 13:41:38',NULL,NULL),(7,3,'0001-01-01 00:00:00','Hoilka','vsfsfsdfsf','dfsdfs',1,'2023-11-07 00:33:58',NULL,NULL);
/*!40000 ALTER TABLE `posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Moderator'),(3,'User');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saved`
--

DROP TABLE IF EXISTS `saved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saved` (
  `UserId` int NOT NULL,
  `PostId` int NOT NULL,
  PRIMARY KEY (`UserId`,`PostId`),
  KEY `PostId` (`PostId`),
  CONSTRAINT `saved_ibfk_1` FOREIGN KEY (`PostId`) REFERENCES `posts` (`PostId`),
  CONSTRAINT `saved_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saved`
--

LOCK TABLES `saved` WRITE;
/*!40000 ALTER TABLE `saved` DISABLE KEYS */;
INSERT INTO `saved` VALUES (2,1),(1,2);
/*!40000 ALTER TABLE `saved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `userId` int NOT NULL,
  `roleId` int NOT NULL,
  PRIMARY KEY (`userId`,`roleId`),
  KEY `roleId` (`roleId`),
  CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `userroles_ibfk_2` FOREIGN KEY (`roleId`) REFERENCES `roles` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (3,1),(4,1),(5,1),(6,1);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `UserName` varchar(30) NOT NULL,
  `Password` varchar(60) NOT NULL,
  `Email` varchar(250) NOT NULL,
  `RegistrationDate` date NOT NULL,
  `Pfp` varchar(255) NOT NULL,
  `BirthDate` date NOT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `DeletedAt` datetime DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserName` (`UserName`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Jane','Smith','janesmith','123456','jane.smith@example.com','2023-11-01','profile_pic.jpg','1985-03-15','987-654-3210','2023-11-01 22:13:04',NULL,NULL),(2,'John','Doe','johndoe','123456','john.doe@example.com','2023-11-01','profile_pic.jpg','1990-01-01','123-456-7890','2023-11-01 22:13:04',NULL,NULL),(3,'Mateo','Nerli','Mateo','$2a$13$rLFgXICmj/9GXuoy8V.0zuJ.xuS/TCToAgIxdl4QoLlip.4WFAdbS','mateo@gmail.com','0001-01-01','imagen.png','2003-03-06','3364512460','2023-11-02 22:05:04',NULL,NULL),(4,'useractualizado','useractualizado','useractualizado','$2a$13$jD8l29auc8/lVfzeAB3q..16XDTxtOIXqKqmQ9DkLbSWaLMYKTDBK','useractualizado@useractualizado.com','0001-01-01','useractualizado','2023-11-04','useractualizado','2023-11-03 21:23:19',NULL,NULL),(5,'usercreate','usercreate','usercreate','$2a$13$cjRXFe3HzPkPc1Xw1ZdiqeN8bRUpgwNSrHkS4DG0k8ZXk33Y1Cf7K','usercreate@gmail.com','0001-01-01','usercreate','2023-11-04','123456','2023-11-03 21:38:11',NULL,NULL),(6,'Mateo','Nerli','MNErli','$2a$13$moqaOnqgoTnK0hPwzZBqfOPYuw5MQQs4QQ4pG5RMcf0mzAz.vU/BC','mateone@gmail.com','0001-01-01','foto.png','2023-11-07','3366545545','2023-11-07 20:55:38',NULL,NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-08 14:46:44
