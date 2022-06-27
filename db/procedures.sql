IF OBJECT_ID('CountBy1') IS NOT NULL
    DROP SEQUENCE Count.CountBy1;

IF OBJECT_ID('Count') IS NOT NULL
    DROP SCHEMA Count;
GO

Create SCHEMA Count;
GO

CREATE SEQUENCE Count.CountBy1
    Start WITH 10
    INCREMENT BY 1;
GO
--------------------------------------------------------
----------------------ADD_ORDER-------------------------
--------------------------------------------------------
IF OBJECT_ID('ADD_ORDER') IS NOT NULL
    DROP PROCEDURE ADD_ORDER
GO


CREATE PROCEDURE ADD_ORDER
    @pOrderID INT OUTPUT,
    @pCustID NVARCHAR(20),
    @pProdID NVARCHAR(30),
    @pOrderDate NVARCHAR(20),
    @pQuantity INT,
    @pShipDate NVARCHAR(20),
    @pShipMode NVARCHAR(50)
AS
BEGIN
    DECLARE @ID BIGINT;
    SET @ID = NEXT VALUE FOR Count.CountBy1;
    SET @pOrderID = @ID
    BEGIN TRY
        INSERT INTO [Order]
        (OrderID, CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode)
    VALUES
        (@pOrderID, @pCustID, @pProdID, @pOrderDate, @pQuantity, @pShipDate, @pShipMode)
    END TRY
    BEGIN CATCH
    END CATCH

    RETURN @pOrderID
END
GO

------------------------------------------------------------
------------------------DELETE ORDER------------------------
------------------------------------------------------------

IF OBJECT_ID('DELETE_ORDER') IS NOT NULL
    DROP PROCEDURE DELETE_ORDER
GO
CREATE PROCEDURE DELETE_ORDER
    @pOrderID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM [Order]
        WHERE OrderID = @pOrderID;
        IF @@ROWCOUNT = 0
            THROW 50060, 'Team not found', 1
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() = 50060
            THROW
    END CATCH
END
GO

------------------------------------------------------------
------------------------UPDATE ORDER------------------------
------------------------------------------------------------

IF OBJECT_ID('UPDATE_ORDER') IS NOT NULL
    DROP PROCEDURE UPDATE_ORDER
GO
CREATE PROCEDURE UPDATE_ORDER
    @pOrderID INT,
    @pCustID NVARCHAR(20),
    @pProdID NVARCHAR(30),
    @pOrderDate NVARCHAR(20),
    @pQuantity INT,
    @pShipDate NVARCHAR(20),
    @pShipMode NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        UPDATE [Order]
        SET CustID = @pCustID, ProdID = @pProdID, OrderDate = @pOrderDate, Quantity = @pQuantity, ShipDate = @pShipDate, ShipMode = @pShipMode
        WHERE OrderID = @pOrderID
        IF @@ROWCOUNT = 0
            THROW 50070, 'Could not update Order ;C', 1
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() = 50070
            THROW
    END CATCH
END
GO
SELECT * FROM [Order]