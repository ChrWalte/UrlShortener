UPDATE Urls
SET OriginalUrl = @OriginalUrl,
	ShortUrlPath = @ShortUrlPath,
	NumberOfUses = @NumberOfUses,
	LastUsed = @LastUsed
WHERE Identifier = @Identifier;