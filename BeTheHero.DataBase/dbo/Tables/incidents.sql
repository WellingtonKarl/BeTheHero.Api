CREATE TABLE [dbo].[incidents] (
    [IdIncident]  INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (3000) NOT NULL,
    [Value]       NVARCHAR (50)   NULL,
    [Ongs_Id]     VARCHAR (36)    NOT NULL,
    CONSTRAINT [PK_incidents] PRIMARY KEY CLUSTERED ([IdIncident] ASC),
    CONSTRAINT [fk_ongs_incidents] FOREIGN KEY ([Ongs_Id]) REFERENCES [dbo].[ongs] ([Id]) ON UPDATE CASCADE
);

