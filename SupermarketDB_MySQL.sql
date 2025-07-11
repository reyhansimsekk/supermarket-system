-- Süpermarket Otomasyon Sistemi - MySQL Veritabanı
-- MySQL 8.0+ için tasarlanmıştır

-- Veritabanını oluştur
CREATE DATABASE IF NOT EXISTS supermarket_db 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE supermarket_db;

-- Mevcut tabloları sil (eğer varsa)
DROP TABLE IF EXISTS ReturnDetails;
DROP TABLE IF EXISTS Returns;
DROP TABLE IF EXISTS StockMovements;
DROP TABLE IF EXISTS ZReports;
DROP TABLE IF EXISTS SalesDetails;
DROP TABLE IF EXISTS Sales;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Brands;
DROP TABLE IF EXISTS Categories;
DROP TABLE IF EXISTS Users;

-- Kullanıcılar Tablosu
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    UserType ENUM('Admin', 'Kasiyer') NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Ürün Kategorileri Tablosu
CREATE TABLE Categories (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE
);

-- Markalar Tablosu
CREATE TABLE Brands (
    BrandID INT AUTO_INCREMENT PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE
);

-- Ürünler Tablosu
CREATE TABLE Products (
    ProductCode VARCHAR(50) PRIMARY KEY,
    ProductName VARCHAR(200) NOT NULL,
    CategoryID INT,
    BrandID INT,
    CostPrice DECIMAL(18,2) NOT NULL DEFAULT 0,
    UnitPrice DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    MinStockLevel INT DEFAULT 10,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
);

-- Satışlar Ana Tablosu
CREATE TABLE Sales (
    SaleID INT AUTO_INCREMENT PRIMARY KEY,
    SaleDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UserID INT,
    TotalAmount DECIMAL(18,2) NOT NULL,
    PaymentType ENUM('Nakit', 'Kart') NOT NULL,
    DiscountAmount DECIMAL(18,2) DEFAULT 0,
    NetAmount DECIMAL(18,2) NOT NULL,
    IsReturned BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Satış Detayları Tablosu
CREATE TABLE SalesDetails (
    SalesDetailID INT AUTO_INCREMENT PRIMARY KEY,
    SaleID INT,
    ProductCode VARCHAR(50),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    DiscountAmount DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (SaleID) REFERENCES Sales(SaleID),
    FOREIGN KEY (ProductCode) REFERENCES Products(ProductCode)
);

-- Z Raporları Tablosu
CREATE TABLE ZReports (
    ZReportID INT AUTO_INCREMENT PRIMARY KEY,
    ReportDate DATE NOT NULL,
    UserID INT,
    TotalSales INT NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    CashAmount DECIMAL(18,2) NOT NULL,
    CardAmount DECIMAL(18,2) NOT NULL,
    DiscountAmount DECIMAL(18,2) NOT NULL,
    NetAmount DECIMAL(18,2) NOT NULL,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- İade İşlemleri Tablosu
CREATE TABLE Returns (
    ReturnID INT AUTO_INCREMENT PRIMARY KEY,
    OriginalSaleID INT,
    ReturnDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UserID INT,
    ReturnAmount DECIMAL(18,2) NOT NULL,
    ReturnReason VARCHAR(500),
    IsProcessed BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (OriginalSaleID) REFERENCES Sales(SaleID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- İade Detayları Tablosu
CREATE TABLE ReturnDetails (
    ReturnDetailID INT AUTO_INCREMENT PRIMARY KEY,
    ReturnID INT,
    ProductCode VARCHAR(50),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ReturnID) REFERENCES Returns(ReturnID),
    FOREIGN KEY (ProductCode) REFERENCES Products(ProductCode)
);

-- Stok Hareketleri Tablosu
CREATE TABLE StockMovements (
    MovementID INT AUTO_INCREMENT PRIMARY KEY,
    ProductCode VARCHAR(50),
    MovementType ENUM('Giriş', 'Çıkış', 'İade') NOT NULL,
    Quantity INT NOT NULL,
    MovementDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UserID INT,
    Notes VARCHAR(500),
    ReferenceID INT,
    FOREIGN KEY (ProductCode) REFERENCES Products(ProductCode),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- İndeksler
CREATE INDEX idx_products_category ON Products(CategoryID);
CREATE INDEX idx_products_brand ON Products(BrandID);
CREATE INDEX idx_sales_date ON Sales(SaleDate);
CREATE INDEX idx_salesdetails_sale ON SalesDetails(SaleID);
CREATE INDEX idx_salesdetails_product ON SalesDetails(ProductCode);
CREATE INDEX idx_stockmovements_product ON StockMovements(ProductCode);
CREATE INDEX idx_stockmovements_date ON StockMovements(MovementDate);

-- Başlangıç Verileri

-- Varsayılan Admin Kullanıcı (Şifre: admin123)
INSERT INTO Users (Username, Password, FullName, UserType) 
VALUES ('admin', 'admin123', 'Sistem Yöneticisi', 'Admin');

-- Varsayılan Kasiyer (Şifre: kasiyer123)
INSERT INTO Users (Username, Password, FullName, UserType) 
VALUES ('kasiyer', 'kasiyer123', 'Varsayılan Kasiyer', 'Kasiyer');

-- Örnek Kategoriler
INSERT INTO Categories (CategoryName) VALUES 
('Gıda'),
('İçecek'),
('Temizlik'),
('Kişisel Bakım'),
('Elektronik'),
('Kırtasiye');

-- Örnek Markalar
INSERT INTO Brands (BrandName) VALUES 
('Ülker'),
('Coca Cola'),
('P&G'),
('Unilever'),
('Samsung'),
('Faber-Castell');

-- Örnek Ürünler
INSERT INTO Products (ProductCode, ProductName, CategoryID, BrandID, UnitPrice, StockQuantity) VALUES 
('8690504020011', 'Ülker Çikolata 80g', 1, 1, 5.50, 100),
('5449000000996', 'Coca Cola 330ml', 2, 2, 3.00, 200),
('8690637318799', 'Fairy Bulaşık Deterjanı 650ml', 3, 3, 12.50, 50),
('8690644130199', 'Dove Şampuan 400ml', 4, 4, 18.75, 75),
('8806085123456', 'Samsung USB Kablo', 5, 5, 25.00, 30),
('4005401234567', 'Faber-Castell Kalem Seti', 6, 6, 15.25, 60);

-- Stored Procedures

DELIMITER //

-- Stok Kontrolü için Prosedür
CREATE PROCEDURE sp_CheckLowStock()
BEGIN
    SELECT 
        p.ProductCode,
        p.ProductName,
        p.StockQuantity,
        p.MinStockLevel,
        c.CategoryName,
        b.BrandName
    FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
    INNER JOIN Brands b ON p.BrandID = b.BrandID
    WHERE p.StockQuantity <= p.MinStockLevel AND p.IsActive = TRUE
    ORDER BY p.StockQuantity ASC;
END //

-- Günlük Satış Raporu Prosedürü
CREATE PROCEDURE sp_DailySalesReport(IN report_date DATE)
BEGIN
    SELECT 
        s.SaleID,
        s.SaleDate,
        u.FullName as Kasiyer,
        s.TotalAmount,
        s.PaymentType,
        s.DiscountAmount,
        s.NetAmount
    FROM Sales s
    INNER JOIN Users u ON s.UserID = u.UserID
    WHERE DATE(s.SaleDate) = report_date
    ORDER BY s.SaleDate DESC;
END //

-- Z Raporu Oluşturma Prosedürü
CREATE PROCEDURE sp_CreateZReport(IN report_date DATE, IN user_id INT)
BEGIN
    DECLARE total_sales INT DEFAULT 0;
    DECLARE total_amount DECIMAL(18,2) DEFAULT 0;
    DECLARE cash_amount DECIMAL(18,2) DEFAULT 0;
    DECLARE card_amount DECIMAL(18,2) DEFAULT 0;
    DECLARE discount_amount DECIMAL(18,2) DEFAULT 0;
    DECLARE net_amount DECIMAL(18,2) DEFAULT 0;
    
    SELECT 
        COUNT(*),
        IFNULL(SUM(TotalAmount), 0),
        IFNULL(SUM(CASE WHEN PaymentType = 'Nakit' THEN NetAmount ELSE 0 END), 0),
        IFNULL(SUM(CASE WHEN PaymentType = 'Kart' THEN NetAmount ELSE 0 END), 0),
        IFNULL(SUM(DiscountAmount), 0),
        IFNULL(SUM(NetAmount), 0)
    INTO total_sales, total_amount, cash_amount, card_amount, discount_amount, net_amount
    FROM Sales
    WHERE DATE(SaleDate) = report_date AND IsReturned = FALSE;
    
    INSERT INTO ZReports (ReportDate, UserID, TotalSales, TotalAmount, CashAmount, CardAmount, DiscountAmount, NetAmount)
    VALUES (report_date, user_id, total_sales, total_amount, cash_amount, card_amount, discount_amount, net_amount);
END //

DELIMITER ;

-- Triggers

-- Satış sonrası stok güncelleme trigger'ı
DELIMITER //
CREATE TRIGGER tr_UpdateStockAfterSale
AFTER INSERT ON SalesDetails
FOR EACH ROW
BEGIN
    UPDATE Products 
    SET StockQuantity = StockQuantity - NEW.Quantity,
        ModifiedDate = CURRENT_TIMESTAMP
    WHERE ProductCode = NEW.ProductCode;
    
    -- Stok hareketi kaydet
    INSERT INTO StockMovements (ProductCode, MovementType, Quantity, UserID, Notes, ReferenceID)
    SELECT 
        NEW.ProductCode, 
        'Çıkış', 
        NEW.Quantity, 
        (SELECT UserID FROM Sales WHERE SaleID = NEW.SaleID),
        'Satış işlemi',
        NEW.SaleID;
END //
DELIMITER ;

-- İade sonrası stok güncelleme trigger'ı
DELIMITER //
CREATE TRIGGER tr_UpdateStockAfterReturn
AFTER INSERT ON ReturnDetails
FOR EACH ROW
BEGIN
    UPDATE Products 
    SET StockQuantity = StockQuantity + NEW.Quantity,
        ModifiedDate = CURRENT_TIMESTAMP
    WHERE ProductCode = NEW.ProductCode;
    
    -- Stok hareketi kaydet
    INSERT INTO StockMovements (ProductCode, MovementType, Quantity, UserID, Notes, ReferenceID)
    SELECT 
        NEW.ProductCode, 
        'İade', 
        NEW.Quantity, 
        (SELECT UserID FROM Returns r WHERE r.ReturnID = NEW.ReturnID),
        'İade işlemi',
        NEW.ReturnID;
END //
DELIMITER ;

SELECT 'MySQL Süpermarket Veritabanı başarıyla oluşturuldu!' as Message;