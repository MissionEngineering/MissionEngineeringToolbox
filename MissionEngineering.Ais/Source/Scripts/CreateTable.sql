USE AIS;
GO

DROP TABLE IF EXISTS AisData;
GO

CREATE TABLE AisData(
    Id                         INT IDENTITY(1,1) PRIMARY KEY,
    Timestamp                  VARCHAR(250) NULL,
    TypeOfMobile               VARCHAR(250) NULL,
    MMSI                       VARCHAR(250) NULL,
    Latitude                   VARCHAR(250) NULL,
    Longitude                  VARCHAR(250) NULL,
    NavigationalStatus         VARCHAR(250) NULL,
    ROT                        VARCHAR(250) NULL,
    SOG                        VARCHAR(250) NULL,
    COG                        VARCHAR(250) NULL,
    Heading                    VARCHAR(250) NULL,
    IMO                        VARCHAR(250) NULL,
    Callsign                   VARCHAR(250) NULL,
    Name                       VARCHAR(250) NULL,
    ShipType                   VARCHAR(250) NULL,
    CargoType                  VARCHAR(250) NULL,
    Width                      VARCHAR(250) NULL,
    Length                     VARCHAR(250) NULL,
    TypeOfPositionFixingDevice VARCHAR(250) NULL,
    Draught                    VARCHAR(250) NULL,
    Destination                VARCHAR(250) NULL,
    ETA                        VARCHAR(250) NULL,
    DataSourceType             VARCHAR(250) NULL,
    A                          VARCHAR(250) NULL,
    B                          VARCHAR(250) NULL,
    C                          VARCHAR(250) NULL,
    D                          VARCHAR(250) NULL,
)


DROP VIEW IF EXISTS AisData_VW;
GO

CREATE VIEW AisData_VW AS
SELECT 
    Timestamp,
    TypeOfMobile,
    MMSI,
    Latitude,
    Longitude,
    NavigationalStatus,
    ROT,
    SOG,
    COG,
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
    A,
    B,
    C,
    D
FROM AisData;