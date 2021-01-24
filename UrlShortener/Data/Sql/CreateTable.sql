CREATE TABLE Urls(
	Identifier uniqueidentifier NOT NULL PRIMARY KEY,
	OriginalUrl text NULL,
	ShortUrlPath text NULL,
	NumberOfUses int NOT NULL,
	CreatedBy text NULL,
	Created text NOT NULL,
	LastUsed text NULL
);