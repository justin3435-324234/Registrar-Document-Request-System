-- Registrar Document Request System
-- SINGLE IMPORT FILE for XAMPP MySQL: localhost / root / no password
-- Import this file only: Database/database.sql
-- Updated: 2026-10-09 (merged upgrade_revisions.sql - no second import needed)
-- Creates: document_request (primary) + registrar_db (mirror for PDF compliance)

CREATE DATABASE IF NOT EXISTS `document_request` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
CREATE DATABASE IF NOT EXISTS `registrar_db` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

-- =============================================
-- PRIMARY: document_request
-- =============================================
USE `document_request`;
SET FOREIGN_KEY_CHECKS=0;
DROP TABLE IF EXISTS `tblaudittrail`;
DROP TABLE IF EXISTS `tblrequestdetails`;
DROP TABLE IF EXISTS `tblrequest`;
DROP TABLE IF EXISTS `tbldocuments`;
DROP TABLE IF EXISTS `tblstudents`;
DROP TABLE IF EXISTS `tblusers`;
SET FOREIGN_KEY_CHECKS=1;

-- tblusers : Login + Role
CREATE TABLE `tblusers` (
  `UserID` INT AUTO_INCREMENT PRIMARY KEY,
  `Username` VARCHAR(50) NOT NULL UNIQUE,
  `Password` VARCHAR(255) NOT NULL,
  `FullName` VARCHAR(100) NOT NULL,
  `Role` ENUM('Administrator','Registrar Staff') NOT NULL,
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tblusers` (`Username`, `Password`, `FullName`, `Role`, `Status`) VALUES
('admin', 'admin123', 'System Administrator', 'Administrator', 'Active'),
('registrar', 'registrar123', 'Maria Santos', 'Registrar Staff', 'Active'),
('staff1', 'staff123', 'Juan Dela Cruz', 'Registrar Staff', 'Active');

-- tblstudents (15 sample records)
CREATE TABLE `tblstudents` (
  `StudentID` VARCHAR(20) PRIMARY KEY,
  `LRN` VARCHAR(20) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  `FirstName` VARCHAR(50) NOT NULL,
  `MiddleName` VARCHAR(50),
  `Course` VARCHAR(50) NOT NULL,
  `YearLevel` VARCHAR(20) NOT NULL,
  `Section` VARCHAR(20) NOT NULL,
  `ContactNo` VARCHAR(20),
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tblstudents` (`StudentID`, `LRN`, `LastName`, `FirstName`, `MiddleName`, `Course`, `YearLevel`, `Section`, `ContactNo`, `Status`) VALUES
('20260001','123456789012','Dela Cruz','Juan','Santos','BSIT','3rd Year','BSIT-3A','09123456701','Active'),
('20260002','123456789013','Santos','Maria','Reyes','BSIT','2nd Year','BSIT-2B','09123456702','Active'),
('20260003','123456789014','Reyes','Carlos','Garcia','BSCS','4th Year','BSCS-4A','09123456703','Active'),
('20260004','123456789015','Garcia','Ana','Lopez','BSBA','1st Year','BSBA-1A','09123456704','Active'),
('20260005','123456789016','Mendoza','Jose','Cruz','BSIT','3rd Year','BSIT-3B','09123456705','Active'),
('20260006','123456789017','Torres','Elena','Diaz','BSCS','2nd Year','BSCS-2A','09123456706','Active'),
('20260007','123456789018','Rivera','Mark','Fernandez','BSBA','4th Year','BSBA-4A','09123456707','Active'),
('20260008','123456789019','Castro','Sofia','Navarro','BSIT','1st Year','BSIT-1A','09123456708','Active'),
('20260009','123456789020','Flores','David','Ramos','BSCS','3rd Year','BSCS-3A','09123456709','Active'),
('20260010','123456789021','Morales','Grace','Villanueva','BSBA','2nd Year','BSBA-2B','09123456710','Active'),
('20260011','123456789022','Ortiz','Paolo','Gutierrez','BSIT','4th Year','BSIT-4A','09123456711','Active'),
('20260012','123456789023','Gonzales','Isabella','Martinez','BSCS','1st Year','BSCS-1B','09123456712','Active'),
('20260013','123456789024','Bautista','Liam','Santiago','BSBA','3rd Year','BSBA-3A','09123456713','Active'),
('20260014','123456789025','Ramos','Chloe','Aquino','BSIT','2nd Year','BSIT-2A','09123456714','Active'),
('20260015','123456789026','Villanueva','Ethan','Hernandez','BSCS','4th Year','BSCS-4B','09123456715','Active');

-- tbldocuments (5 sample documents)
CREATE TABLE `tbldocuments` (
  `DocumentID` INT AUTO_INCREMENT PRIMARY KEY,
  `DocumentName` VARCHAR(100) NOT NULL UNIQUE,
  `Description` VARCHAR(255),
  `Fee` DECIMAL(10,2) NOT NULL,
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tbldocuments` (`DocumentName`, `Description`, `Fee`, `Status`) VALUES
('Transcript of Records', 'Official academic record', 150.00, 'Active'),
('Certificate of Enrollment', 'Proof of enrollment', 50.00, 'Active'),
('Certificate of Good Moral', 'Character certification', 100.00, 'Active'),
('Certification', 'General certification', 50.00, 'Active'),
('Honorable Dismissal', 'Transfer credential', 100.00, 'Active');

-- tblrequest (includes merged revision columns: LastAction, ReleasedBy, CancelledBy, etc.)
CREATE TABLE `tblrequest` (
  `RequestID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestNo` VARCHAR(20) NOT NULL UNIQUE,
  `StudentID` VARCHAR(20) NOT NULL,
  `RequestDate` DATE NOT NULL,
  `TotalAmount` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `PaymentStatus` VARCHAR(20) NOT NULL DEFAULT 'Unpaid',
  `ORNo` VARCHAR(6) NULL,
  `ORDate` DATE NULL,
  `Status` VARCHAR(30) NOT NULL DEFAULT 'Pending',
  `PrevStatus` VARCHAR(30) NULL DEFAULT NULL,
  `CreatedBy` INT NULL,
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `LastAction` VARCHAR(50) NULL,
  `LastActionBy` INT NULL,
  `LastActionDate` DATETIME NULL,
  `UpdatedBy` INT NULL,
  `ReleasedBy` INT NULL,
  `ReleasedDate` DATETIME NULL,
  `CancelledBy` INT NULL,
  `CancelledDate` DATETIME NULL,
  FOREIGN KEY (`StudentID`) REFERENCES `tblstudents`(`StudentID`),
  FOREIGN KEY (`CreatedBy`) REFERENCES `tblusers`(`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `tblrequestdetails` (
  `RequestDetailID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestID` INT NOT NULL,
  `DocumentID` INT NOT NULL,
  `Quantity` INT NOT NULL DEFAULT 1,
  `Amount` DECIMAL(10,2) NOT NULL,
  `SubTotal` DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (`RequestID`) REFERENCES `tblrequest`(`RequestID`) ON DELETE CASCADE,
  FOREIGN KEY (`DocumentID`) REFERENCES `tbldocuments`(`DocumentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- tblaudittrail (merged from upgrade_revisions.sql)
CREATE TABLE IF NOT EXISTS `tblaudittrail` (
  `AuditID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestNo` VARCHAR(20) NOT NULL,
  `ActionDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `PerformedBy` VARCHAR(100) NOT NULL,
  `UserRole` VARCHAR(30) NOT NULL,
  `ActionTaken` VARCHAR(50) NOT NULL,
  `OldValue` VARCHAR(255) NULL,
  `NewValue` VARCHAR(255) NULL,
  `Remarks` VARCHAR(255) NULL,
  INDEX `idx_req` (`RequestNo`),
  INDEX `idx_date` (`ActionDate`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- tblrequest + tblrequestdetails 15 samples (3 per status)
INSERT INTO `tblrequest` (`RequestNo`, `StudentID`, `RequestDate`, `TotalAmount`, `PaymentStatus`, `ORNo`, `ORDate`, `Status`, `CreatedBy`) VALUES
('REQ-2026-00001','20260001','2026-08-18',150.00,'Unpaid',NULL,NULL,'Pending',1),
('REQ-2026-00002','20260002','2026-08-18',100.00,'Unpaid',NULL,NULL,'Pending',2),
('REQ-2026-00003','20260003','2026-08-19',200.00,'Unpaid',NULL,NULL,'Pending',1),
('REQ-2026-00004','20260004','2026-08-19',150.00,'Unpaid',NULL,NULL,'Processing',2),
('REQ-2026-00005','20260005','2026-08-20',100.00,'Paid','OR-101','2026-08-20','Processing',1),
('REQ-2026-00006','20260006','2026-08-20',50.00,'Paid','OR-102','2026-08-20','Processing',2),
('REQ-2026-00007','20260007','2026-08-21',100.00,'Paid','OR-103','2026-08-21','Ready for Release',1),
('REQ-2026-00008','20260008','2026-08-21',150.00,'Paid','OR-104','2026-08-21','Ready for Release',2),
('REQ-2026-00009','20260009','2026-08-22',250.00,'Paid','OR-105','2026-08-22','Ready for Release',1),
('REQ-2026-00010','20260010','2026-08-22',50.00,'Paid','OR-106','2026-08-22','Released',2),
('REQ-2026-00011','20260011','2026-08-23',100.00,'Paid','OR-107','2026-08-23','Released',1),
('REQ-2026-00012','20260012','2026-08-23',150.00,'Paid','OR-108','2026-08-23','Released',2),
('REQ-2026-00013','20260013','2026-08-24',50.00,'Unpaid',NULL,NULL,'Cancelled',1),
('REQ-2026-00014','20260014','2026-08-24',100.00,'Unpaid',NULL,NULL,'Cancelled',2),
('REQ-2026-00015','20260015','2026-08-25',200.00,'Unpaid',NULL,NULL,'Cancelled',1);

INSERT INTO `tblrequestdetails` (`RequestID`, `DocumentID`, `Quantity`, `Amount`, `SubTotal`) VALUES
(1,1,1,150.00,150.00),
(2,3,1,100.00,100.00),
(3,1,1,150.00,150.00),(3,4,1,50.00,50.00),
(4,2,1,50.00,50.00),(4,5,1,100.00,100.00),
(5,3,1,100.00,100.00),
(6,4,1,50.00,50.00),
(7,5,1,100.00,100.00),
(8,1,1,150.00,150.00),
(9,1,1,150.00,150.00),(9,3,1,100.00,100.00),
(10,2,1,50.00,50.00),
(11,3,1,100.00,100.00),
(12,1,1,150.00,150.00),
(13,4,1,50.00,50.00),
(14,5,1,100.00,100.00),
(15,2,2,50.00,100.00),(15,3,1,100.00,100.00);

-- =============================================
-- MIRROR: registrar_db (same full schema for grading compliance)
-- App writes to both DBs via ExecuteOnBoth / LogAudit
-- =============================================
USE `registrar_db`;
SET FOREIGN_KEY_CHECKS=0;
DROP TABLE IF EXISTS `tblaudittrail`;
DROP TABLE IF EXISTS `tblrequestdetails`;
DROP TABLE IF EXISTS `tblrequest`;
DROP TABLE IF EXISTS `tbldocuments`;
DROP TABLE IF EXISTS `tblstudents`;
DROP TABLE IF EXISTS `tblusers`;
SET FOREIGN_KEY_CHECKS=1;

CREATE TABLE `tblusers` (
  `UserID` INT AUTO_INCREMENT PRIMARY KEY,
  `Username` VARCHAR(50) NOT NULL UNIQUE,
  `Password` VARCHAR(255) NOT NULL,
  `FullName` VARCHAR(100) NOT NULL,
  `Role` ENUM('Administrator','Registrar Staff') NOT NULL,
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tblusers` (`Username`, `Password`, `FullName`, `Role`, `Status`) VALUES
('admin', 'admin123', 'System Administrator', 'Administrator', 'Active'),
('registrar', 'registrar123', 'Maria Santos', 'Registrar Staff', 'Active'),
('staff1', 'staff123', 'Juan Dela Cruz', 'Registrar Staff', 'Active');

CREATE TABLE `tblstudents` (
  `StudentID` VARCHAR(20) PRIMARY KEY,
  `LRN` VARCHAR(20) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  `FirstName` VARCHAR(50) NOT NULL,
  `MiddleName` VARCHAR(50),
  `Course` VARCHAR(50) NOT NULL,
  `YearLevel` VARCHAR(20) NOT NULL,
  `Section` VARCHAR(20) NOT NULL,
  `ContactNo` VARCHAR(20),
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tblstudents` (`StudentID`, `LRN`, `LastName`, `FirstName`, `MiddleName`, `Course`, `YearLevel`, `Section`, `ContactNo`, `Status`) VALUES
('20260001','123456789012','Dela Cruz','Juan','Santos','BSIT','3rd Year','BSIT-3A','09123456701','Active'),
('20260002','123456789013','Santos','Maria','Reyes','BSIT','2nd Year','BSIT-2B','09123456702','Active'),
('20260003','123456789014','Reyes','Carlos','Garcia','BSCS','4th Year','BSCS-4A','09123456703','Active'),
('20260004','123456789015','Garcia','Ana','Lopez','BSBA','1st Year','BSBA-1A','09123456704','Active'),
('20260005','123456789016','Mendoza','Jose','Cruz','BSIT','3rd Year','BSIT-3B','09123456705','Active'),
('20260006','123456789017','Torres','Elena','Diaz','BSCS','2nd Year','BSCS-2A','09123456706','Active'),
('20260007','123456789018','Rivera','Mark','Fernandez','BSBA','4th Year','BSBA-4A','09123456707','Active'),
('20260008','123456789019','Castro','Sofia','Navarro','BSIT','1st Year','BSIT-1A','09123456708','Active'),
('20260009','123456789020','Flores','David','Ramos','BSCS','3rd Year','BSCS-3A','09123456709','Active'),
('20260010','123456789021','Morales','Grace','Villanueva','BSBA','2nd Year','BSBA-2B','09123456710','Active'),
('20260011','123456789022','Ortiz','Paolo','Gutierrez','BSIT','4th Year','BSIT-4A','09123456711','Active'),
('20260012','123456789023','Gonzales','Isabella','Martinez','BSCS','1st Year','BSCS-1B','09123456712','Active'),
('20260013','123456789024','Bautista','Liam','Santiago','BSBA','3rd Year','BSBA-3A','09123456713','Active'),
('20260014','123456789025','Ramos','Chloe','Aquino','BSIT','2nd Year','BSIT-2A','09123456714','Active'),
('20260015','123456789026','Villanueva','Ethan','Hernandez','BSCS','4th Year','BSCS-4B','09123456715','Active');

CREATE TABLE `tbldocuments` (
  `DocumentID` INT AUTO_INCREMENT PRIMARY KEY,
  `DocumentName` VARCHAR(100) NOT NULL UNIQUE,
  `Description` VARCHAR(255),
  `Fee` DECIMAL(10,2) NOT NULL,
  `Status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tbldocuments` (`DocumentName`, `Description`, `Fee`, `Status`) VALUES
('Transcript of Records', 'Official academic record', 150.00, 'Active'),
('Certificate of Enrollment', 'Proof of enrollment', 50.00, 'Active'),
('Certificate of Good Moral', 'Character certification', 100.00, 'Active'),
('Certification', 'General certification', 50.00, 'Active'),
('Honorable Dismissal', 'Transfer credential', 100.00, 'Active');

CREATE TABLE `tblrequest` (
  `RequestID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestNo` VARCHAR(20) NOT NULL UNIQUE,
  `StudentID` VARCHAR(20) NOT NULL,
  `RequestDate` DATE NOT NULL,
  `TotalAmount` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `PaymentStatus` VARCHAR(20) NOT NULL DEFAULT 'Unpaid',
  `ORNo` VARCHAR(6) NULL,
  `ORDate` DATE NULL,
  `Status` VARCHAR(30) NOT NULL DEFAULT 'Pending',
  `PrevStatus` VARCHAR(30) NULL DEFAULT NULL,
  `CreatedBy` INT NULL,
  `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `LastAction` VARCHAR(50) NULL,
  `LastActionBy` INT NULL,
  `LastActionDate` DATETIME NULL,
  `UpdatedBy` INT NULL,
  `ReleasedBy` INT NULL,
  `ReleasedDate` DATETIME NULL,
  `CancelledBy` INT NULL,
  `CancelledDate` DATETIME NULL,
  FOREIGN KEY (`StudentID`) REFERENCES `tblstudents`(`StudentID`),
  FOREIGN KEY (`CreatedBy`) REFERENCES `tblusers`(`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `tblrequestdetails` (
  `RequestDetailID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestID` INT NOT NULL,
  `DocumentID` INT NOT NULL,
  `Quantity` INT NOT NULL DEFAULT 1,
  `Amount` DECIMAL(10,2) NOT NULL,
  `SubTotal` DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (`RequestID`) REFERENCES `tblrequest`(`RequestID`) ON DELETE CASCADE,
  FOREIGN KEY (`DocumentID`) REFERENCES `tbldocuments`(`DocumentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `tblaudittrail` (
  `AuditID` INT AUTO_INCREMENT PRIMARY KEY,
  `RequestNo` VARCHAR(20) NOT NULL,
  `ActionDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `PerformedBy` VARCHAR(100) NOT NULL,
  `UserRole` VARCHAR(30) NOT NULL,
  `ActionTaken` VARCHAR(50) NOT NULL,
  `OldValue` VARCHAR(255) NULL,
  `NewValue` VARCHAR(255) NULL,
  `Remarks` VARCHAR(255) NULL,
  INDEX `idx_req` (`RequestNo`),
  INDEX `idx_date` (`ActionDate`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `tblrequest` (`RequestNo`, `StudentID`, `RequestDate`, `TotalAmount`, `PaymentStatus`, `ORNo`, `ORDate`, `Status`, `CreatedBy`) VALUES
('REQ-2026-00001','20260001','2026-08-18',150.00,'Unpaid',NULL,NULL,'Pending',1),
('REQ-2026-00002','20260002','2026-08-18',100.00,'Unpaid',NULL,NULL,'Pending',2),
('REQ-2026-00003','20260003','2026-08-19',200.00,'Unpaid',NULL,NULL,'Pending',1),
('REQ-2026-00004','20260004','2026-08-19',150.00,'Unpaid',NULL,NULL,'Processing',2),
('REQ-2026-00005','20260005','2026-08-20',100.00,'Paid','OR-101','2026-08-20','Processing',1),
('REQ-2026-00006','20260006','2026-08-20',50.00,'Paid','OR-102','2026-08-20','Processing',2),
('REQ-2026-00007','20260007','2026-08-21',100.00,'Paid','OR-103','2026-08-21','Ready for Release',1),
('REQ-2026-00008','20260008','2026-08-21',150.00,'Paid','OR-104','2026-08-21','Ready for Release',2),
('REQ-2026-00009','20260009','2026-08-22',250.00,'Paid','OR-105','2026-08-22','Ready for Release',1),
('REQ-2026-00010','20260010','2026-08-22',50.00,'Paid','OR-106','2026-08-22','Released',2),
('REQ-2026-00011','20260011','2026-08-23',100.00,'Paid','OR-107','2026-08-23','Released',1),
('REQ-2026-00012','20260012','2026-08-23',150.00,'Paid','OR-108','2026-08-23','Released',2),
('REQ-2026-00013','20260013','2026-08-24',50.00,'Unpaid',NULL,NULL,'Cancelled',1),
('REQ-2026-00014','20260014','2026-08-24',100.00,'Unpaid',NULL,NULL,'Cancelled',2),
('REQ-2026-00015','20260015','2026-08-25',200.00,'Unpaid',NULL,NULL,'Cancelled',1);

INSERT INTO `tblrequestdetails` (`RequestID`, `DocumentID`, `Quantity`, `Amount`, `SubTotal`) VALUES
(1,1,1,150.00,150.00),
(2,3,1,100.00,100.00),
(3,1,1,150.00,150.00),(3,4,1,50.00,50.00),
(4,2,1,50.00,50.00),(4,5,1,100.00,100.00),
(5,3,1,100.00,100.00),
(6,4,1,50.00,50.00),
(7,5,1,100.00,100.00),
(8,1,1,150.00,150.00),
(9,1,1,150.00,150.00),(9,3,1,100.00,100.00),
(10,2,1,50.00,50.00),
(11,3,1,100.00,100.00),
(12,1,1,150.00,150.00),
(13,4,1,50.00,50.00),
(14,5,1,100.00,100.00),
(15,2,2,50.00,100.00),(15,3,1,100.00,100.00);
