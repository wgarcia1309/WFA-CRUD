DROP TABLE [dbo].[inventario];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[inventario] (
    [ID] int,
    [PRODUCT] varchar,
    [QUANTITY] int,
    [MODIFIED_DATE] date,
    PRIMARY KEY ([ID])
);


INSERT INTO [dbo].[inventario] ([ID],[PRODUCT],[QUANTITY],[MODIFIED_DATE]) VALUES (1,'Product 1',1000,'2015-10-22');
INSERT INTO [dbo].[inventario] ([ID],[PRODUCT],[QUANTITY],[MODIFIED_DATE]) VALUES (2,'Product 2',550,'2014-10-10');
INSERT INTO [dbo].[inventario] ([ID],[PRODUCT],[QUANTITY],[MODIFIED_DATE]) VALUES (3,'Product 3',223,'2015-05-12');