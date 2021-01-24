SELECT
	Identifier,
	OriginalUrl,
	ShortUrlPath,
	NumberOfUses,
	CreatedBy,
	Created,
	LastUsed
FROM Urls
WHERE Identifier = @Identifier;