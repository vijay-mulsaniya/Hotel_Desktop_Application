
CREATE TABLE States (
    StateID INT IDENTITY(1,1) PRIMARY KEY,
    StateCode NVARCHAR(10) NOT NULL UNIQUE,
    StateName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Cities (
    CityID INT IDENTITY(1,1) PRIMARY KEY,
    CityName NVARCHAR(100) NOT NULL,
    StateID INT NOT NULL,
    CONSTRAINT FK_Cities_States
        FOREIGN KEY (StateID) REFERENCES States(StateID),
    CONSTRAINT UQ_City_State UNIQUE (CityName, StateID)
);

INSERT INTO States (StateCode, StateName) VALUES
('AP', 'Andhra Pradesh'),
('AR', 'Arunachal Pradesh'),
('AS', 'Assam'),
('BR', 'Bihar'),
('CG', 'Chhattisgarh'),
('GA', 'Goa'),
('GJ', 'Gujarat'),
('HR', 'Haryana'),
('HP', 'Himachal Pradesh'),
('JH', 'Jharkhand'),
('KA', 'Karnataka'),
('KL', 'Kerala'),
('MP', 'Madhya Pradesh'),
('MH', 'Maharashtra'),
('MN', 'Manipur'),
('ML', 'Meghalaya'),
('MZ', 'Mizoram'),
('NL', 'Nagaland'),
('OD', 'Odisha'),
('PB', 'Punjab'),
('RJ', 'Rajasthan'),
('SK', 'Sikkim'),
('TN', 'Tamil Nadu'),
('TS', 'Telangana'),
('TR', 'Tripura'),
('UP', 'Uttar Pradesh'),
('UK', 'Uttarakhand'),
('WB', 'West Bengal'),
('DL', 'Delhi'),
('JK', 'Jammu and Kashmir'),
('LA', 'Ladakh'),
('CH', 'Chandigarh'),
('PY', 'Puducherry'),
('AN', 'Andaman and Nicobar Islands'),
('LD', 'Lakshadweep'),
('DN', 'Dadra and Nagar Haveli and Daman and Diu');

INSERT INTO Cities (CityName, StateID)
SELECT 'Visakhapatnam', StateID FROM States WHERE StateCode = 'AP'
UNION ALL SELECT 'Vijayawada', StateID FROM States WHERE StateCode = 'AP'
UNION ALL SELECT 'Guntur', StateID FROM States WHERE StateCode = 'AP'
UNION ALL SELECT 'Nellore', StateID FROM States WHERE StateCode = 'AP'
UNION ALL SELECT 'Kurnool', StateID FROM States WHERE StateCode = 'AP';

INSERT INTO Cities (CityName, StateID)
SELECT 'Hyderabad', StateID FROM States WHERE StateCode = 'TS'
UNION ALL SELECT 'Warangal', StateID FROM States WHERE StateCode = 'TS'
UNION ALL SELECT 'Nizamabad', StateID FROM States WHERE StateCode = 'TS'
UNION ALL SELECT 'Karimnagar', StateID FROM States WHERE StateCode = 'TS';

INSERT INTO Cities (CityName, StateID)
SELECT 'Mumbai', StateID FROM States WHERE StateCode = 'MH'
UNION ALL SELECT 'Pune', StateID FROM States WHERE StateCode = 'MH'
UNION ALL SELECT 'Nagpur', StateID FROM States WHERE StateCode = 'MH'
UNION ALL SELECT 'Nashik', StateID FROM States WHERE StateCode = 'MH'
UNION ALL SELECT 'Aurangabad', StateID FROM States WHERE StateCode = 'MH';

INSERT INTO Cities (CityName, StateID)
SELECT CityName, StateID
FROM (VALUES
('Ahmedabad'), ('Surat'), ('Vadodara'), ('Rajkot'), ('Bhavnagar'),
('Jamnagar'), ('Junagadh'), ('Gandhinagar'), ('Anand'), ('Morbi'),
('Mehsana'), ('Nadiad'), ('Bharuch'), ('Vapi'), ('Porbandar')
) v(CityName)
CROSS JOIN (SELECT StateID FROM States WHERE StateCode = 'GJ') s;

INSERT INTO Cities (CityName, StateID)
SELECT CityName, StateID
FROM (VALUES
('Jaipur'), ('Jodhpur'), ('Udaipur'), ('Kota'), ('Ajmer'),
('Bikaner'), ('Alwar'), ('Bharatpur'), ('Sikar'), ('Pali'),
('Chittorgarh'), ('Bhilwara'), ('Barmer'), ('Jaisalmer'), ('Nagaur')
) v(CityName)
CROSS JOIN (SELECT StateID FROM States WHERE StateCode = 'RJ') s;

INSERT INTO Cities (CityName, StateID)
SELECT CityName, StateID
FROM (VALUES
('Thiruvananthapuram'), ('Kochi'), ('Kozhikode'), ('Thrissur'),
('Kollam'), ('Alappuzha'), ('Palakkad'), ('Malappuram'),
('Kannur'), ('Kasaragod'), ('Kottayam'), ('Pathanamthitta'),
('Idukki'), ('Wayanad')
) v(CityName)
CROSS JOIN (SELECT StateID FROM States WHERE StateCode = 'KL') s;

INSERT INTO Cities (CityName, StateID)
SELECT CityName, StateID
FROM (VALUES
('Lucknow'), ('Kanpur'), ('Noida'), ('Greater Noida'), ('Ghaziabad'),
('Agra'), ('Mathura'), ('Meerut'), ('Aligarh'), ('Bareilly'),
('Moradabad'), ('Saharanpur'), ('Prayagraj'), ('Varanasi'),
('Gorakhpur'), ('Jhansi'), ('Ayodhya')
) v(CityName)
CROSS JOIN (SELECT StateID FROM States WHERE StateCode = 'UP') s;

INSERT INTO Cities (CityName, StateID)
SELECT CityName, StateID
FROM (VALUES
('Bhopal'), ('Indore'), ('Gwalior'), ('Jabalpur'), ('Ujjain'),
('Sagar'), ('Rewa'), ('Satna'), ('Dewas'), ('Ratlam'),
('Katni'), ('Chhindwara'), ('Morena'), ('Bhind'), ('Vidisha')
) v(CityName)
CROSS JOIN (SELECT StateID FROM States WHERE StateCode = 'MP') s;

select * from States
select * from Cities order by CityID