

--INSERT INTO Reading(BuildingId, ObjectId, DataFieldId, Value, TimeStamp)
WITH RandomNumbers (RowNumber, RandomNumber) AS (
    -- Anchor member definition
    SELECT  1                         AS RowNumber, 
            RAND( CHECKSUM( NEWID())) AS RandomNumber
    UNION ALL
    -- Recursive member definition
    SELECT  rn.RowNumber + 1          AS RowNumber, 
            RAND( CHECKSUM( NEWID())) AS RandomNumber
    FROM RandomNumbers rn
    WHERE rn.RowNumber < 42048000
)
-- Statement that executes the CTE
--DELETE FROM READING
INSERT INTO Reading(BuildingId, ObjectId, DataFieldId, Value, TimeStamp)

SELECT m.bid,m.OID,lid,rn.RandomNumber*40,Datetwo
FROM RandomNumbers rn
INNER JOIN (
SELECT  ROW_NUMBER() OVER (ORDER BY B.ID) AS SrNo, b.Id bid,1 AS OID,l.Id lid,Datetwo
FROM
(SELECT Datetwo,d.Id FROM datetimetemp
CROSS JOIN DataField d) L
 CROSS JOIN( SELECT  * FROM Building ORDER BY Id OFFSET 24 ROWS 
FETCH NEXT 12 ROWS ONLY ) B
)M ON RN.RowNumber = M.SrNo
option (maxrecursion 0)
GO


