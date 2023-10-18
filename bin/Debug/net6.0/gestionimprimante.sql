-- MySqlBackup.NET 2.3.7.0
-- Dump Time: 2023-04-19 23:41:34
-- --------------------------------------
-- Server version 5.7.36 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of emplacement
-- 

DROP TABLE IF EXISTS `emplacement`;
CREATE TABLE IF NOT EXISTS `emplacement` (
  `idEmplacement` int(11) NOT NULL AUTO_INCREMENT,
  `etagere` varchar(20) NOT NULL,
  `numero` int(11) NOT NULL,
  PRIMARY KEY (`idEmplacement`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table emplacement
-- 

/*!40000 ALTER TABLE `emplacement` DISABLE KEYS */;
INSERT INTO `emplacement`(`idEmplacement`,`etagere`,`numero`) VALUES(2,'A',1),(3,'A',2),(4,'A',3),(5,'B',1);
/*!40000 ALTER TABLE `emplacement` ENABLE KEYS */;

-- 
-- Definition of cartouche
-- 

DROP TABLE IF EXISTS `cartouche`;
CREATE TABLE IF NOT EXISTS `cartouche` (
  `idCart` int(11) NOT NULL AUTO_INCREMENT,
  `nomCart` varchar(30) NOT NULL,
  `couleur` varchar(10) NOT NULL,
  `quantite` int(11) NOT NULL,
  `idEmplace` int(11) DEFAULT NULL,
  PRIMARY KEY (`idCart`),
  KEY `idEmplace` (`idEmplace`),
  CONSTRAINT `cartouche_ibfk_1` FOREIGN KEY (`idEmplace`) REFERENCES `emplacement` (`idEmplacement`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table cartouche
-- 

/*!40000 ALTER TABLE `cartouche` DISABLE KEYS */;
INSERT INTO `cartouche`(`idCart`,`nomCart`,`couleur`,`quantite`,`idEmplace`) VALUES(1,'Noir','Noir',1,2),(2,'Jaune','Jaune',5,3),(3,'Magenta','Magenta',7,4),(4,'Cyan','Cyan',20,5),(10,'TEST','Magenta',1,NULL),(11,'RICOH TYPE 6210D','Noir',0,NULL),(12,'RICOH TYPE 4500','Noir',0,NULL),(13,'BROTHER TN-241BK','Noir',0,NULL),(14,'BROTHER TN-241C','Cyan',0,NULL),(15,'BROTHER TN-241M','Magenta',0,NULL),(16,'BROTHER TN-241Y','Jaune',0,NULL),(17,'BROTHER TN-411BK','Noir',0,NULL),(18,'BROTHER TN-421BK','Noir',0,NULL),(19,'BROTHER TN-421C','Cyan',0,NULL),(20,'BROTHER TN-421M','Magenta',0,NULL),(21,'BROTHER TN-421Y','Jaune',0,NULL),(22,'BROTHER TN-321BK','Noir',0,NULL),(23,'BROTHER TN-321C','Cyan',0,NULL),(24,'BROTHER TN-321M','Magenta',0,NULL),(25,'BROTHER TN-321Y','Jaune',0,NULL),(26,'BROTHER TN-2210','Noir',0,NULL);
/*!40000 ALTER TABLE `cartouche` ENABLE KEYS */;

-- 
-- Definition of contient
-- 

DROP TABLE IF EXISTS `contient`;
CREATE TABLE IF NOT EXISTS `contient` (
  `idImprimante` int(11) NOT NULL,
  `idCartouche` int(11) NOT NULL,
  `dateChangement` date NOT NULL,
  PRIMARY KEY (`idImprimante`,`idCartouche`,`dateChangement`),
  KEY `idCartouche` (`idCartouche`),
  CONSTRAINT `contient_ibfk_1` FOREIGN KEY (`idImprimante`) REFERENCES `imprimante` (`idPrint`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `contient_ibfk_2` FOREIGN KEY (`idCartouche`) REFERENCES `cartouche` (`idCart`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table contient
-- 

/*!40000 ALTER TABLE `contient` DISABLE KEYS */;
INSERT INTO `contient`(`idImprimante`,`idCartouche`,`dateChangement`) VALUES(1,1,'2023-02-06 00:00:00'),(2,1,'2023-02-06 00:00:00'),(7,10,'2023-02-06 00:00:00'),(11,11,'2023-02-23 00:00:00'),(11,12,'2023-01-17 00:00:00'),(12,13,'2023-02-06 00:00:00'),(21,13,'2023-02-27 00:00:00'),(12,14,'2023-02-01 00:00:00'),(12,15,'2023-01-11 00:00:00'),(12,16,'2023-02-04 00:00:00'),(13,18,'2023-01-18 00:00:00'),(14,18,'2023-01-13 00:00:00'),(15,18,'2023-02-01 00:00:00'),(16,18,'2023-01-18 00:00:00'),(17,18,'2023-01-26 00:00:00'),(13,19,'2023-02-02 00:00:00'),(14,19,'2023-01-20 00:00:00'),(15,19,'2023-02-02 00:00:00'),(16,19,'2023-01-13 00:00:00'),(17,19,'2023-01-24 00:00:00'),(13,20,'2023-02-03 00:00:00'),(14,20,'2023-02-02 00:00:00'),(15,20,'2023-02-01 00:00:00'),(16,20,'2023-01-20 00:00:00'),(17,20,'2023-01-31 00:00:00'),(13,21,'2023-02-04 00:00:00'),(14,21,'2023-02-04 00:00:00'),(15,21,'2023-02-01 00:00:00'),(16,21,'2023-01-28 00:00:00'),(17,21,'2023-01-31 00:00:00'),(18,22,'2023-01-05 00:00:00'),(19,22,'2023-01-04 00:00:00'),(18,23,'2023-02-01 00:00:00'),(19,23,'2023-01-12 00:00:00'),(18,24,'2023-02-02 00:00:00'),(19,24,'2023-02-01 00:00:00'),(18,25,'2023-02-05 00:00:00'),(19,25,'2023-02-02 00:00:00'),(20,26,'2023-02-02 00:00:00');
/*!40000 ALTER TABLE `contient` ENABLE KEYS */;

-- 
-- Definition of empreint
-- 

DROP TABLE IF EXISTS `empreint`;
CREATE TABLE IF NOT EXISTS `empreint` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomObject` varchar(40) NOT NULL,
  `quantite` int(11) NOT NULL,
  `dateEmpreint` date NOT NULL,
  `dateRetour` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table empreint
-- 

/*!40000 ALTER TABLE `empreint` DISABLE KEYS */;
INSERT INTO `empreint`(`id`,`nomObject`,`quantite`,`dateEmpreint`,`dateRetour`) VALUES(3,'ttt',0,'2023-08-02 00:00:00','2023-08-02 00:00:00'),(4,'ok',0,'2023-08-02 00:00:00','2023-08-02 00:00:00'),(6,'test',0,'2023-09-02 00:00:00','2023-09-02 00:00:00'),(7,'tett',0,'2023-09-02 00:00:00','2023-09-02 00:00:00');
/*!40000 ALTER TABLE `empreint` ENABLE KEYS */;

-- 
-- Definition of imprimante
-- 

DROP TABLE IF EXISTS `imprimante`;
CREATE TABLE IF NOT EXISTS `imprimante` (
  `idPrint` int(11) NOT NULL AUTO_INCREMENT,
  `nomPrint` varchar(40) NOT NULL,
  PRIMARY KEY (`idPrint`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table imprimante
-- 

/*!40000 ALTER TABLE `imprimante` DISABLE KEYS */;
INSERT INTO `imprimante`(`idPrint`,`nomPrint`) VALUES(1,'BROTHER DCP 700L'),(2,'BROTHER DCP L2500D'),(7,'TEST'),(8,'TEST2'),(9,'RICOH 7503'),(11,'RICOH 4002'),(12,'BROTHER DCP 9020CDW'),(13,'BROTHER DCP L8410CDW'),(14,'BROTHER DCP L8410CDW'),(15,'BROTHER DCP L8410CDW'),(16,'BROTHER DCP L8410CDW'),(17,'BROTHER DCP L8410CDW'),(18,'BROTHER DCP L8400CDN'),(19,'BROTHER DCP L8250CDN'),(20,'BROTHER HL 2240'),(21,'MARION');
/*!40000 ALTER TABLE `imprimante` ENABLE KEYS */;

-- 
-- Definition of appartient
-- 

DROP TABLE IF EXISTS `appartient`;
CREATE TABLE IF NOT EXISTS `appartient` (
  `idClasse` int(11) NOT NULL,
  `idImprimante` int(11) NOT NULL,
  PRIMARY KEY (`idClasse`,`idImprimante`),
  KEY `idImprimante` (`idImprimante`),
  CONSTRAINT `appartient_ibfk_1` FOREIGN KEY (`idClasse`) REFERENCES `salle` (`idSalle`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `appartient_ibfk_2` FOREIGN KEY (`idImprimante`) REFERENCES `imprimante` (`idPrint`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table appartient
-- 

/*!40000 ALTER TABLE `appartient` DISABLE KEYS */;
INSERT INTO `appartient`(`idClasse`,`idImprimante`) VALUES(2,1),(1,2),(2,2),(4,7),(5,8),(7,9),(7,11),(8,12),(9,13),(10,14),(11,15),(12,16),(17,17),(14,18),(15,19),(16,20),(18,21);
/*!40000 ALTER TABLE `appartient` ENABLE KEYS */;

-- 
-- Definition of durabilite
-- 

DROP TABLE IF EXISTS `durabilite`;
CREATE TABLE IF NOT EXISTS `durabilite` (
  `idImprimante` int(11) NOT NULL,
  `idCartouche` int(11) NOT NULL,
  `statEnMois` int(11) NOT NULL,
  PRIMARY KEY (`idImprimante`,`idCartouche`,`statEnMois`),
  KEY `idCartouche` (`idCartouche`),
  CONSTRAINT `durabilite_ibfk_1` FOREIGN KEY (`idCartouche`) REFERENCES `cartouche` (`idCart`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `durabilite_ibfk_2` FOREIGN KEY (`idImprimante`) REFERENCES `imprimante` (`idPrint`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table durabilite
-- 

/*!40000 ALTER TABLE `durabilite` DISABLE KEYS */;
INSERT INTO `durabilite`(`idImprimante`,`idCartouche`,`statEnMois`) VALUES(1,1,0),(2,1,0),(7,10,0),(11,11,0),(11,12,0),(12,13,0),(21,13,0),(12,14,0),(12,15,0),(12,16,0),(13,18,0),(14,18,0),(15,18,0),(16,18,0),(17,18,0),(13,19,0),(14,19,0),(15,19,0),(16,19,0),(17,19,0),(13,20,0),(14,20,0),(15,20,0),(16,20,0),(17,20,0),(13,21,0),(14,21,0),(15,21,0),(16,21,0),(17,21,0),(18,22,0),(19,22,0),(18,23,0),(19,23,0),(18,24,0),(19,24,0),(18,25,0),(19,25,0),(20,26,0);
/*!40000 ALTER TABLE `durabilite` ENABLE KEYS */;

-- 
-- Definition of livraisoncartouche
-- 

DROP TABLE IF EXISTS `livraisoncartouche`;
CREATE TABLE IF NOT EXISTS `livraisoncartouche` (
  `idLivr` int(11) NOT NULL AUTO_INCREMENT,
  `quantiteCommande` int(11) NOT NULL,
  `dateCommande` date NOT NULL,
  `dateLivraison` date NOT NULL,
  PRIMARY KEY (`idLivr`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table livraisoncartouche
-- 

/*!40000 ALTER TABLE `livraisoncartouche` DISABLE KEYS */;
INSERT INTO `livraisoncartouche`(`idLivr`,`quantiteCommande`,`dateCommande`,`dateLivraison`) VALUES(1,7,'2023-01-12 00:00:00','2023-01-11 00:00:00'),(2,5,'2023-01-10 00:00:00','2023-01-17 00:00:00'),(3,2,'2023-01-11 00:00:00','2023-01-31 00:00:00'),(6,4,'2023-01-11 00:00:00','2023-01-25 00:00:00'),(7,2,'2023-01-11 00:00:00','2023-01-11 00:00:00'),(8,2,'2023-01-11 00:00:00','2023-01-11 00:00:00'),(9,10,'2023-01-11 00:00:00','2023-01-11 00:00:00'),(15,4,'2023-01-12 00:00:00','2023-01-12 00:00:00');
/*!40000 ALTER TABLE `livraisoncartouche` ENABLE KEYS */;

-- 
-- Definition of reference
-- 

DROP TABLE IF EXISTS `reference`;
CREATE TABLE IF NOT EXISTS `reference` (
  `idCartouche` int(11) NOT NULL,
  `idLivraison` int(11) NOT NULL,
  PRIMARY KEY (`idCartouche`,`idLivraison`),
  KEY `idLivraison` (`idLivraison`),
  CONSTRAINT `reference_ibfk_1` FOREIGN KEY (`idCartouche`) REFERENCES `cartouche` (`idCart`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reference_ibfk_2` FOREIGN KEY (`idLivraison`) REFERENCES `livraisoncartouche` (`idLivr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table reference
-- 

/*!40000 ALTER TABLE `reference` DISABLE KEYS */;
INSERT INTO `reference`(`idCartouche`,`idLivraison`) VALUES(13,1),(14,2),(15,3),(16,6),(22,7),(23,8),(24,9),(25,15);
/*!40000 ALTER TABLE `reference` ENABLE KEYS */;

-- 
-- Definition of salle
-- 

DROP TABLE IF EXISTS `salle`;
CREATE TABLE IF NOT EXISTS `salle` (
  `idSalle` int(11) NOT NULL AUTO_INCREMENT,
  `nomSalle` varchar(20) NOT NULL,
  PRIMARY KEY (`idSalle`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table salle
-- 

/*!40000 ALTER TABLE `salle` DISABLE KEYS */;
INSERT INTO `salle`(`idSalle`,`nomSalle`) VALUES(1,'J301'),(2,'C307'),(4,'TEST'),(5,'TEST2'),(6,'C003'),(7,'SALLE PROF C'),(8,'C003'),(9,'C009'),(10,'C213'),(11,'C214'),(12,'C215'),(14,'C226'),(15,'C305'),(16,'C012'),(17,'C306'),(18,'STMG');
/*!40000 ALTER TABLE `salle` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2023-04-19 23:41:34
-- Total time: 0:0:0:0:118 (d:h:m:s:ms)
