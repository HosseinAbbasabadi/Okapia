/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[Ammount]
      ,[PanTrunc]
      ,[RRN]
      ,[LocalDateTime]
      ,[TrAmmount]
  FROM [okapia_db].[dbo].[JobTransactions]

  declare @i int = 1;
  while(@i <= 200)
	begin
	begin tran
	INSERT INTO [dbo].[JobTransactions]
           ([Ammount]
           ,[PanTrunc]
           ,[RRN]
           ,[LocalDateTime]
           ,[TrAmmount])
     VALUES
           (720000
           ,'692673481213****'
           ,65398
           ,'2019-06-12 13:00:00.000'
           ,650000)
	commit tran
	set @i = @i + 1;
	end

	
  declare @i int = 1;
  while(@i <= 200)
	begin
	begin tran
	INSERT INTO [dbo].[JobTransactions]
           ([Ammount]
           ,[PanTrunc]
           ,[RRN]
           ,[LocalDateTime]
           ,[TrAmmount])
     VALUES
           (900000
           ,'123456789161****'
           ,21332
           ,'2019-06-13 16:00:00.000'
           ,850000)
	commit tran
	set @i = @i + 1;
	end

	
  declare @i int = 1;
  while(@i <= 200)
	begin
	begin tran
	INSERT INTO [dbo].[JobTransactions]
           ([Ammount]
           ,[PanTrunc]
           ,[RRN]
           ,[LocalDateTime]
           ,[TrAmmount])
     VALUES
           (500000
           ,'987654321123****'
           ,98764
           ,'2019-06-14 09:00:00.000'
           ,380000)
	commit tran
	set @i = @i + 1;
	end

declare @i int = 1;
  while(@i <= 200)
	begin
	begin tran
	INSERT INTO [dbo].[JobTransactions]
           ([Ammount]
           ,[PanTrunc]
           ,[RRN]
           ,[LocalDateTime]
           ,[TrAmmount])
     VALUES
           (2000000
           ,'603782561943****'
           ,54360
           ,'2019-08-01 15:00:00.000'
           ,1900000)
	commit tran
	set @i = @i + 1;
	end