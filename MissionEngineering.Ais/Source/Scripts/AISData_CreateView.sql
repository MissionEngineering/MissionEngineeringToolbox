USE AIS
GO
DROP VIEW vwAISData;

USE AIS
GO
CREATE VIEW vwAISData AS
SELECT 
    TimeStamp,
    TypeOfMobile,
    MMSI,
    Latitude,
    Longitude,
    NavigationalStatus,
    RateOfTurn,
    SpeedOverGround,
    CourseOverGround,
    Heading,
    IMO,
    Callsign,
    Name,
    ShipType,
    CargoType,
    Width,
    Length,
    TypeOfPositionFixingDevice,
    Draught,
    Destination,
    ETA,
    DataSourceType,
    SizeA,
    SizeB,
    SizeC,
    SizeD
FROM AISData;