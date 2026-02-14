
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

