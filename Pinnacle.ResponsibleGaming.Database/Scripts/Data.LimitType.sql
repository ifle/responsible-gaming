if not exists (SELECT * FROM [dbo].[LimitType])
begin
INSERT [dbo].[LimitType] ([LimitTypeId], [Name]) VALUES (1, N'Deposit limit') 
end
