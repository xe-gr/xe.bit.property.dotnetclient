using System.Collections.Generic;
using System.IO;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Ads
{
	public class Asset
	{
		public virtual AssetType Type { get; set; }
		public virtual string Id { get; set; }
		public virtual AssetFileType FileType { get; set; }
		public virtual AssetStatus Status { get; set; }
		public virtual bool IsPrimary { get; set; }
		public virtual string Caption { get; set; }
		public virtual int Order { get; set; }
		public virtual string Uri { get; set; }
		public virtual Dictionary<string, string> Properties { get; protected set; } = new Dictionary<string, string>();
		public virtual string LocalFileName
		{
			get => _localFileName;
			set
			{
				_localFileName = value;
				var fi = new FileInfo(_localFileName);
				Uri = fi.Name;
			}

		}

		private string _localFileName;

		public void AddProperty(string key, string value)
		{
			Properties.Add(key, value);
		}

		public void ClearProperties()
		{
			Properties.Clear();
		}
	}
}