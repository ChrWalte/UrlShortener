INSERT INTO Urls(
	Identifier,
	OriginalUrl,
	ShortUrlPath,
	NumberOfUses, 
	CreatedBy,
	Created,
	LastUsed
)
VALUES(
	@Identifier,
	@OriginalUrl,
	@ShortUrlPath,
	@NumberOfUses,
	@CreatedBy,
	@Created,
	@LastUsed
);