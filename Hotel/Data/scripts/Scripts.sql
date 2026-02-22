
-- Seed Rooms
Insert into Rooms(HotelID, RoomNumber, RoomTitle, RoomType, Capacity, Charges, IsClean, IsAvailable) values
  (1, 'G2', 'Dormitory',0,1,500,1,1),
  (1, 'G3', 'Dormitory',0,1,500,1,1),
  (1, 'G4', 'Dormitory',0,1,500,1,1),
  (1, 'G5', 'Dormitory',0,1,500,1,1),
  (1, 'G6', 'Dormitory',0,1,500,1,1),
  (1, 'G7', 'Dormitory',0,1,500,1,1),
  (1, 'G8', 'Dormitory',0,1,500,1,1),
  (1, 'G9', 'Dormitory',0,1,500,1,1),
  (1, 'G10', 'Dormitory',0,1,500,1,1),
  (1, 'G11', 'Dormitory',0,1,500,1,1),
  (1, 'G12', 'Dormitory',0,1,500,1,1),
  (1, 'G13', 'Dormitory',0,1,500,1,1),

  (1, 'F1', 'Dormitory',0,1,500,1,1),
  (1, 'F2', 'Dormitory',0,1,500,1,1),
  (1, 'F3', 'Dormitory',0,1,500,1,1),
  (1, 'F4', 'Dormitory',0,1,500,1,1),
  (1, 'F5', 'Dormitory',0,1,500,1,1),
  (1, 'F6', 'Dormitory',0,1,500,1,1),
  (1, 'F7', 'Dormitory',0,1,500,1,1),
  (1, 'F8', 'Dormitory',0,1,500,1,1),
  (1, 'F9', 'Dormitory',0,1,500,1,1),
  (1, 'F10', 'Dormitory',0,1,500,1,1),
  
  (1, 'S1', 'Dormitory',0,1,500,1,1),
  (1, 'S2', 'Dormitory',0,1,500,1,1),
  (1, 'S3', 'Dormitory',0,1,500,1,1),
  (1, 'S4', 'Dormitory',0,1,500,1,1),
  (1, 'S5', 'Dormitory',0,1,500,1,1),
  (1, 'S6', 'Dormitory',0,1,500,1,1),
  (1, 'S7', 'Dormitory',0,1,500,1,1),
  (1, 'S8', 'Dormitory',0,1,500,1,1),
  (1, 'S9', 'Dormitory',0,1,500,1,1),
  (1, 'S10', 'Dormitory',0,1,500,1,1),
  
  (1, 'T1', 'Dormitory',0,1,500,1,1),
  (1, 'T2', 'Dormitory',0,1,500,1,1),
  (1, 'T3', 'Dormitory',0,1,500,1,1),
  (1, 'T4', 'Dormitory',0,1,500,1,1),
  (1, 'T5', 'Dormitory',0,1,500,1,1),
  (1, 'T6', 'Dormitory',0,1,500,1,1),
  (1, 'T7', 'Dormitory',0,1,500,1,1),
  (1, 'T8', 'Dormitory',0,1,500,1,1),
  (1, 'T9', 'Dormitory',0,1,500,1,1),
  (1, 'T10', 'Dormitory',0,1,500,1,1)

  -- INdexes for faster searches
CREATE INDEX IX_TblRoomBooking_RoomID_Date
ON RoomBookings (RoomID, Date);


--
CREATE TABLE [dbo].[RoomBookingsHistory](
    [HistoryID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Action] [nvarchar](10), -- 'UPDATE' or 'DELETE'
    [HistoryTimestamp] [datetime2](7) DEFAULT GETDATE(),
    [ID] [int],
    [HotelID] [int],
    [BookingMasterID] [int],
    [RoomID] [int],
    [GuestID] [int],
    [Status] [int],
    [Date] [datetime2](7),
    [NightStay] [bit],
    [AdultCount] [int],
    [ChildCount] [int],
    [Amount] [decimal](12, 2),
    [CreatedOn] [datetime2](7),
    [CreatedbyId] [int],
    [UpdatedOn] [datetime2](7),
    [UpdatedbyId] [int],
    [IsActive] [bit],
    [IsDeleted] [bit]
);

Go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vijay Mulsaniya>
-- Create date: 22-02-2026
-- Description:	To Record A History
-- =============================================
CREATE TRIGGER dbo.Tr_Update_Delete_Bookings 
   ON  dbo.RoomBookings 
   AFTER DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @Action nvarchar(10);
    IF EXISTS(SELECT * FROM inserted)
        SET @Action = 'UPDATE';
    ELSE
        SET @Action = 'DELETE';

    -- Insert the "Before" state (from the DELETED table)
    INSERT INTO [dbo].[RoomBookingsHistory] (
        [Action], [ID], [HotelID], [BookingMasterID], [RoomID], [GuestID], 
        [Status], [Date], [NightStay], [AdultCount], [ChildCount], [Amount], 
        [CreatedOn], [CreatedbyId], [UpdatedOn], [UpdatedbyId], [IsActive], [IsDeleted]
    )
    SELECT 
        @Action, [ID], [HotelID], [BookingMasterID], [RoomID], [GuestID], 
        [Status], [Date], [NightStay], [AdultCount], [ChildCount], [Amount], 
        [CreatedOn], [CreatedbyId], [UpdatedOn], [UpdatedbyId], [IsActive], [IsDeleted]
    FROM DELETED;

END
GO


CREATE TABLE [dbo].[PaymentsHistory](
    -- 1. Tracking Columns
    [HistoryID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Action] [nvarchar](10) NULL,
    [HistoryTimestamp] [datetime2](7) NULL,
    
    -- 2. Original Columns
    [ID] [int] NOT NULL, -- IDENTITY removed to store the original ID
    [HotelID] [int] NOT NULL,
    [BookingMasterID] [int] NOT NULL,
    [AmountPaid] [decimal](12, 2) NOT NULL,
    [PaymentDate] [datetime2](7) NOT NULL,
    [Method] [int] NULL,
    [OnlineTransacionRefNumber] [nvarchar](50) NULL,
    [CreatedOn] [datetime2](7) NULL,
    [CreatedbyId] [int] NULL,
    [UpdatedOn] [datetime2](7) NULL,
    [UpdatedbyId] [int] NULL,
    [IsActive] [bit] NULL,
    [IsDeleted] [bit] NULL,
    [RoomID] [int] NULL
)
GO
CREATE TRIGGER [dbo].[trg_Payments_Audit]
ON [dbo].[Payments]
AFTER UPDATE, DELETE
AS
BEGIN
    -- SET NOCOUNT ON prevents extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;

    DECLARE @Action NVARCHAR(10);

    -- Determine the action type. 
    -- If there are rows in the 'inserted' table, it's an UPDATE. Otherwise, it's a DELETE.
    IF EXISTS (SELECT * FROM inserted)
        SET @Action = 'UPDATE';
    ELSE
        SET @Action = 'DELETE';

    -- Insert the old values from the 'deleted' pseudo-table into the history table
    INSERT INTO [dbo].[PaymentsHistory] (
        [Action],
        [HistoryTimestamp],
        [ID],
        [HotelID],
        [BookingMasterID],
        [AmountPaid],
        [PaymentDate],
        [Method],
        [OnlineTransacionRefNumber],
        [CreatedOn],
        [CreatedbyId],
        [UpdatedOn],
        [UpdatedbyId],
        [IsActive],
        [IsDeleted],
        [RoomID]
    )
    SELECT 
        @Action,
        SYSDATETIME(), -- Captures the precise timestamp of the action
        d.[ID],
        d.[HotelID],
        d.[BookingMasterID],
        d.[AmountPaid],
        d.[PaymentDate],
        d.[Method],
        d.[OnlineTransacionRefNumber],
        d.[CreatedOn],
        d.[CreatedbyId],
        d.[UpdatedOn],
        d.[UpdatedbyId],
        d.[IsActive],
        d.[IsDeleted],
        d.[RoomID]
    FROM deleted d;

END
GO

CREATE TABLE [dbo].[BookingMastersHistory](
    -- Tracking Columns
    [HistoryID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Action] [nvarchar](10) NULL,
    [HistoryTimestamp] [datetime2](7) NULL,

    -- Original Columns
    [ID] [int] NOT NULL, -- IDENTITY removed
    [HotelID] [int] NOT NULL,
    [GuestID] [int] NOT NULL,
    [CheckInDate] [datetime2](7) NOT NULL,
    [CheckOutDate] [datetime2](7) NOT NULL,
    [Discount] [decimal](12, 2) NOT NULL,
    [InputTaxCredit] [bit] NOT NULL,
    [HotelStateCode] [nvarchar](20) NOT NULL,
    [GuestStateCode] [nvarchar](20) NOT NULL,
    [IsGSTApplicable] [bit] NOT NULL,
    [IsTaxInclusive] [bit] NOT NULL,
    [CreatedOn] [datetime2](7) NULL,
    [CreatedbyId] [int] NULL,
    [UpdatedOn] [datetime2](7) NULL,
    [UpdatedbyId] [int] NULL,
    [IsActive] [bit] NULL,
    [IsDeleted] [bit] NULL,
    [InvoiceDate] [datetime2](7) NOT NULL,
    [InvoiceNumber] [nvarchar](50) NULL
)
GO

CREATE TRIGGER [dbo].[trg_BookingMasters_Audit]
ON [dbo].[BookingMasters]
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Action NVARCHAR(10);

    -- Determine if the action is an UPDATE or DELETE
    IF EXISTS (SELECT * FROM inserted)
        SET @Action = 'UPDATE';
    ELSE
        SET @Action = 'DELETE';

    -- Insert the old values into the history table
    INSERT INTO [dbo].[BookingMastersHistory] (
        [Action],
        [HistoryTimestamp],
        [ID],
        [HotelID],
        [GuestID],
        [CheckInDate],
        [CheckOutDate],
        [Discount],
        [InputTaxCredit],
        [HotelStateCode],
        [GuestStateCode],
        [IsGSTApplicable],
        [IsTaxInclusive],
        [CreatedOn],
        [CreatedbyId],
        [UpdatedOn],
        [UpdatedbyId],
        [IsActive],
        [IsDeleted],
        [InvoiceDate],
        [InvoiceNumber]
    )
    SELECT 
        @Action,
        SYSDATETIME(),
        d.[ID],
        d.[HotelID],
        d.[GuestID],
        d.[CheckInDate],
        d.[CheckOutDate],
        d.[Discount],
        d.[InputTaxCredit],
        d.[HotelStateCode],
        d.[GuestStateCode],
        d.[IsGSTApplicable],
        d.[IsTaxInclusive],
        d.[CreatedOn],
        d.[CreatedbyId],
        d.[UpdatedOn],
        d.[UpdatedbyId],
        d.[IsActive],
        d.[IsDeleted],
        d.[InvoiceDate],
        d.[InvoiceNumber]
    FROM deleted d;

END
GO