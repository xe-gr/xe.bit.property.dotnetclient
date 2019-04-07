namespace xe.bit.property.core.Ads
{
	public class Geo
	{
		public virtual string AreaId { get; set; }
		public virtual string SubAreaDescription { get; set; }
		public virtual string StreetName { get; set; }
		public virtual string StreetNumber { get; set; }
		public virtual decimal? Longitude { get; set; }
		public virtual decimal? Latitude { get; set; }
		public virtual string PostCode { get; set; }
	}
}