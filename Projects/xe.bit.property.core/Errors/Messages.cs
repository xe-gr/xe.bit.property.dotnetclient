namespace xe.bit.property.core.Errors
{
	public static class Messages
	{
		public const string AreaIdCannotBeNullOrEmpty = "AreaID cannot be null or empty";
		public const string AreaIdIsInvalid = "AreaID {0} is not valid";
		public const string AreaIdIsException = "AreaID {0} is not allowed";
		public const string AssetIdCannotBeNullOrEmpty = "AssetID cannot be null or empty";
		public const string AssetUriCannotBeNullOrEmpty = "Asset URI cannot be null or empty";
		public const string TooManyImages = "Too many image assets - maximum of 10 allowed";
		public const string TooManyVideos = "Too many video assets - maximum of 1 allowed";
		public const string MoreThanOnePrimaryAssets = "Only one asset can be set to primary";
		public const string AddTypeMustBeResidence = "AdType must be re_residence for residence ads";
		public const string AddTypeMustBeResidenceHoliday = "AdType must be re_residence_hol for holiday residence ads";
		public const string AreaMustHaveValue = "Area must have a value";
		public const string AreaMustHavePositiveValue = "Area must have a positive value";
		public const string LevelMustHaveValue = "Level must have a value";
		public const string ConditionMustHaveValue = "Condition must have a value";
		public const string ConstructionYearOutOfBounds = "ConstructionYear must be greater than 1900 and less or equal to current year";
		public const string RefurbishmentYearOutOfBounds = "RefurbishmentYear must be greater than 1900 and less or equal to current year";
		public const string BedroomsOutOfBound = "Bedrooms must be greater than 0";
		public const string HasStorageConstraint = "If HasStorage is true, StorageArea must have a value";
		public const string HasSemiOpenSpacesConstraint = "If HasSemiOpenSpaces is true, SemiOpenSpacesArea must have a value";
		public const string HasGardenConstraint = "If HasGarden is true, GardenArea must have a value";
		public const string HasTerraceConstraint = "If HasTerrace is true, TerraceArea must have a value";
		public const string FloorsConstraint = "If floors is greater than zero, FloorsArea must have a value";
		public const string HasParkingConstraint = "If HasParking is true, ParkingType must have a value";
		public const string ResidenceSubTypeMustHaveValue = "If residence is APARTMENT, SubType must have a value";
		public const string ResidenceSubTypeMustBeNull = "If residence is not APARTMENT, SubType must not be specified";
		public const string RefIdCannotBeNullOrEmpty = "RefId cannot be null or empty";
		public const string OwnerIdCannotBeNullOrEmpty = "OwnerId cannot be null or empty";
		public const string MajorPhoneCannotBeNullOrEmpty = "Major phone cannot be null or empty";
        public const string AuthTokenCannotBeNullOrEmpty = "XE auth token cannot be null or empty";
		public const string SchemaVersionCannotBeNullOrEmpty = "Schema version cannot be null or empty";
		public const string PackageIdCannotBeNullOrEmpty = "Package ID cannot be null or empty";
		public const string ItemTypeMustBeParking = "Item type must be set to re_parking";
		public const string ParkingAreaMustHaveValue = "Parking area must have a value";
		public const string ParkingLevelMustHaveValue = "Parking level must have a value";
        public const string PriceCannotBeNullOrEmpty = "Price cannot be null or empty";
    }
}