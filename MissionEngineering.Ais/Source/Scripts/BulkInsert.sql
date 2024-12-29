USE AIS;
GO

BULK INSERT AisData_VW
FROM 'C:\Users\missi\Downloads\ais\aisdk-2024-12-01_Part.csv'
WITH (
    DATAFILETYPE = 'char',
    FIRSTROW = 2,
    FIELDTERMINATOR = ',', 
    ROWTERMINATOR = '\n'
);