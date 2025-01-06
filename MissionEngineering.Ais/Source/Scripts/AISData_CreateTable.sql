USE AIS
GO
DROP TABLE AISData;

CREATE TABLE AISData (
    Id                         INT PRIMARY KEY IDENTITY (1,1),
    TimeStamp                  DATETIME2   NOT NULL,
    TypeOfMobile               VARCHAR(50) NOT NULL,
    MMSI                       INT         NOT NULL,
    Latitude                   FLOAT       NOT NULL,
    Longitude                  FLOAT       NOT NULL,
    NavigationalStatus         VARCHAR(50) NOT NULL,
    RateOfTurn                 FLOAT           NULL,
    SpeedOverGround            FLOAT           NULL,
    CourseOverGround           FLOAT           NULL,
    Heading                    FLOAT           NULL,
    IMO                        VARCHAR(50) NOT NULL,
    Callsign                   VARCHAR(50) NOT NULL,
    Name                       VARCHAR(50) NOT NULL,
    ShipType                   VARCHAR(50) NOT NULL,
    CargoType                  VARCHAR(50) NOT NULL,
    Width                      VARCHAR(50) NOT NULL,
    Length                     VARCHAR(50) NOT NULL,
    TypeOfPositionFixingDevice VARCHAR(50) NOT NULL,
    Draught                    VARCHAR(50) NOT NULL,
    Destination                VARCHAR(50) NOT NULL,
    ETA                        VARCHAR(50)     NULL,
    DataSourceType             VARCHAR(50) NOT NULL,
    SizeA                      VARCHAR(50)     NULL,
    SizeB                      VARCHAR(50)     NULL,
    SizeC                      VARCHAR(50)     NULL,
    SizeD                      VARCHAR(50)     NULL
)