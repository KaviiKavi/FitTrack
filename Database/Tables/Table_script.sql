/* =========================================================
   DATABASE: FitnessSaaS
   ========================================================= */

-- Optional: Create DB
-- CREATE DATABASE FitnessSaaS;
-- GO
-- USE FitnessSaaS;
-- GO

/* =========================================================
   1. AdminUsers 
   ========================================================= */
CREATE TABLE AdminUsers (
    AdminUserId INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(500) NOT NULL,
    FullName NVARCHAR(150) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

/* =========================================================
   1. OWNERS (TENANTS)
   ========================================================= */
CREATE TABLE Owners (
    OwnerId INT IDENTITY(1,1) PRIMARY KEY,
    BusinessName NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

/* =========================================================
   2. ROLES
   ========================================================= */
   CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL);

/* =========================================================
   3. USERS (AUTH)
   ========================================================= */
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    PasswordHash NVARCHAR(500) NOT NULL,
    RoleId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME

    CONSTRAINT FK_Users_Owners
        FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId),

	CONSTRAINT FK_Users_Roles
        FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

/* =========================================================
   3. CLIENTS
   ========================================================= */
CREATE TABLE Clients (
    ClientId INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NOT NULL,
    ClientName NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20),
    WhatsAppNumber NVARCHAR(20),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL,
	UpdateOn DATETIME 

    CONSTRAINT FK_Clients_Owners
        FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId)
);

/* =========================================================
   4. PACKAGES (OWNER SPECIFIC)
   ========================================================= */
CREATE TABLE Packages (
    PackageId INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NOT NULL,
    PackageName NVARCHAR(100) NOT NULL,
    DurationInDays INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL,
	UpdateOn DATETIME

    CONSTRAINT FK_Packages_Owners
        FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId)
);

/* =========================================================
   5. CLIENT PACKAGES (SUBSCRIPTION HISTORY)
   ========================================================= */
CREATE TABLE ClientPackages (
    ClientPackageId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT NOT NULL,
    PackageId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    AssignedOn DATETIME NOT NULL,

    CONSTRAINT FK_ClientPackages_Clients
        FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),

    CONSTRAINT FK_ClientPackages_Packages
        FOREIGN KEY (PackageId) REFERENCES Packages(PackageId)
);

/* =========================================================
   6. PAYMENTS (IMMUTABLE)
   ========================================================= */
CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT NOT NULL,
    ClientPackageId INT NOT NULL,
    PaidAmount DECIMAL(10,2) NOT NULL,
    PaymentDate DATE NOT NULL,
    NextPaymentDate DATE NULL,
    CreatedOn DATETIME NOT NULL

    CONSTRAINT FK_Payments_Clients
        FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),

    CONSTRAINT FK_Payments_ClientPackages
        FOREIGN KEY (ClientPackageId) REFERENCES ClientPackages(ClientPackageId)
);

/* =========================================================
   7. PAYMENT HISTORY (AUDIT)
   ========================================================= */
CREATE TABLE PaymentHistory (
    HistoryId INT IDENTITY(1,1) PRIMARY KEY,
    PaymentId INT NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    ActionDate DATETIME NOT NULL,

    CONSTRAINT FK_PaymentHistory_Payments
        FOREIGN KEY (PaymentId) REFERENCES Payments(PaymentId)
);

/* =========================================================
   8. AUDIT LOGS (SYSTEM LEVEL)
   ========================================================= */
CREATE TABLE AuditLogs (
    AuditId INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NULL,
    EntityName NVARCHAR(100) NOT NULL,
    EntityId INT NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    CreatedOn DATETIME NOT NULL
);
