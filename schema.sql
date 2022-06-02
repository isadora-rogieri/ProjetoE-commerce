CREATE TABLE [dbo].[Cliente] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Bairro]      NVARCHAR (MAX) NOT NULL,
    [CEP]         NVARCHAR (MAX) NOT NULL,
    [Complemento] NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [Endereco]    NVARCHAR (MAX) NOT NULL,
    [Municipio]   NVARCHAR (MAX) NOT NULL,
    [Nome]        NVARCHAR (MAX) NOT NULL,
    [Telefone]    NVARCHAR (MAX) NOT NULL,
    [UF]          NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[ItemPedido] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [PedidoId]      INT             NOT NULL,
    [PrecoUnitario] DECIMAL (18, 2) NOT NULL,
    [ProdutoId]     INT             NOT NULL,
    [Quantidade]    INT             NOT NULL,
    CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemPedido_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemPedido_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemPedido_PedidoId]
    ON [dbo].[ItemPedido]([PedidoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemPedido_ProdutoId]
    ON [dbo].[ItemPedido]([ProdutoId] ASC);

CREATE TABLE [dbo].[Pedido] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ClienteId] INT NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pedido_ClienteId]
    ON [dbo].[Pedido]([ClienteId] ASC);

CREATE TABLE [dbo].[Produto] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Codigo]    NVARCHAR (MAX)  NOT NULL,
    [Nome]      NVARCHAR (MAX)  NOT NULL,
    [Descricao] NVARCHAR (MAX)  NOT NULL,
    [Preco]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

