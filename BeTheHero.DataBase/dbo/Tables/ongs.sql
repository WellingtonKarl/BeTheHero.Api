CREATE TABLE [dbo].[ongs] (
    [Id]       VARCHAR (36)  NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Whatsapp] VARCHAR (15)  NOT NULL,
    [City]     NVARCHAR (50) NOT NULL,
    [UF]       VARCHAR (2)   NOT NULL,
    CONSTRAINT [PK_ongs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

