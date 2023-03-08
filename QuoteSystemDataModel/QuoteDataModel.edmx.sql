
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2023 10:58:30
-- Generated from EDMX file: D:\InternshipProject\QuoteSystem\QuoteSystemDataModel\QuoteDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CGLQuoteDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Quotes'
CREATE TABLE [dbo].[Quotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuoteNumber] nvarchar(max)  NOT NULL,
    [RiskState] nvarchar(max)  NOT NULL,
    [Premium] float  NOT NULL,
    [AgentId] nvarchar(max)  NOT NULL,
    [PolicyTerm_Id] int  NOT NULL,
    [Prospect_Id] int  NOT NULL
);
GO

-- Creating table 'PolicyTerms'
CREATE TABLE [dbo].[PolicyTerms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PolicyEffectiveDate] datetime  NOT NULL,
    [PolicyExpiryDate] datetime  NOT NULL
);
GO

-- Creating table 'Prospects'
CREATE TABLE [dbo].[Prospects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrganisationName] nvarchar(max)  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [NumberOfBusinessUnits] int  NOT NULL
);
GO

-- Creating table 'Businesses'
CREATE TABLE [dbo].[Businesses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IndustryType] nvarchar(max)  NOT NULL,
    [Territory] nvarchar(max)  NOT NULL,
    [Exposure] int  NOT NULL,
    [ProspectId] int  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- Creating table 'Coverages'
CREATE TABLE [dbo].[Coverages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CoverageName] nvarchar(max)  NOT NULL,
    [Deductible] int  NOT NULL,
    [OccuranceLimit] int  NOT NULL,
    [AggregateLimit] int  NOT NULL,
    [CoveragePremium] float  NOT NULL,
    [BusinessId] int  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstLine] nvarchar(max)  NOT NULL,
    [SecondLine] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Agents'
CREATE TABLE [dbo].[Agents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AgentId] nvarchar(max)  NOT NULL,
    [AgentName] nvarchar(max)  NOT NULL,
    [AgencyName] nvarchar(max)  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CodeValueLists'
CREATE TABLE [dbo].[CodeValueLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ListName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CodeValues'
CREATE TABLE [dbo].[CodeValues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [CodeValueListId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [PK_Quotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PolicyTerms'
ALTER TABLE [dbo].[PolicyTerms]
ADD CONSTRAINT [PK_PolicyTerms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prospects'
ALTER TABLE [dbo].[Prospects]
ADD CONSTRAINT [PK_Prospects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [PK_Businesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Coverages'
ALTER TABLE [dbo].[Coverages]
ADD CONSTRAINT [PK_Coverages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [PK_Agents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CodeValueLists'
ALTER TABLE [dbo].[CodeValueLists]
ADD CONSTRAINT [PK_CodeValueLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CodeValues'
ALTER TABLE [dbo].[CodeValues]
ADD CONSTRAINT [PK_CodeValues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PolicyTerm_Id] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [FK_QuotePolicyTerm]
    FOREIGN KEY ([PolicyTerm_Id])
    REFERENCES [dbo].[PolicyTerms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuotePolicyTerm'
CREATE INDEX [IX_FK_QuotePolicyTerm]
ON [dbo].[Quotes]
    ([PolicyTerm_Id]);
GO

-- Creating foreign key on [Prospect_Id] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [FK_QuoteProspect]
    FOREIGN KEY ([Prospect_Id])
    REFERENCES [dbo].[Prospects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuoteProspect'
CREATE INDEX [IX_FK_QuoteProspect]
ON [dbo].[Quotes]
    ([Prospect_Id]);
GO

-- Creating foreign key on [ProspectId] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_ProspectBusiness]
    FOREIGN KEY ([ProspectId])
    REFERENCES [dbo].[Prospects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProspectBusiness'
CREATE INDEX [IX_FK_ProspectBusiness]
ON [dbo].[Businesses]
    ([ProspectId]);
GO

-- Creating foreign key on [BusinessId] in table 'Coverages'
ALTER TABLE [dbo].[Coverages]
ADD CONSTRAINT [FK_BusinessCoverage]
    FOREIGN KEY ([BusinessId])
    REFERENCES [dbo].[Businesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessCoverage'
CREATE INDEX [IX_FK_BusinessCoverage]
ON [dbo].[Coverages]
    ([BusinessId]);
GO

-- Creating foreign key on [Address_Id] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_BusinessAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessAddress'
CREATE INDEX [IX_FK_BusinessAddress]
ON [dbo].[Businesses]
    ([Address_Id]);
GO

-- Creating foreign key on [CodeValueListId] in table 'CodeValues'
ALTER TABLE [dbo].[CodeValues]
ADD CONSTRAINT [FK_CodeValueListCodeValue]
    FOREIGN KEY ([CodeValueListId])
    REFERENCES [dbo].[CodeValueLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CodeValueListCodeValue'
CREATE INDEX [IX_FK_CodeValueListCodeValue]
ON [dbo].[CodeValues]
    ([CodeValueListId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------