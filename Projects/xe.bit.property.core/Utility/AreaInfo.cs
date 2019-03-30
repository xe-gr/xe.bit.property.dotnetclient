using System;
using System.Collections.Generic;
using xe.bit.property.core.Properties;

namespace xe.bit.property.core.Utility
{
	public class AreaInfo
	{
		private static Dictionary<string, AreaProperty> AreaMap { get; }
		private static List<string> Exceptions { get; }

		static AreaInfo()
		{
			AreaMap = new Dictionary<string, AreaProperty>();
			Exceptions = new List<string>();

			var fileInfo = Resources.AreaInfo;
			var lines = fileInfo.Split("\r\n");
			foreach (var line in lines)
			{
				if (line.StartsWith("Map_Id") || string.IsNullOrEmpty(line)) continue;
				var fields = line.Split(new[] {'\t'});
				var property = new AreaProperty {MapId = fields[0], MapLabel = string.IsNullOrEmpty(fields[3]) ? fields[1] : $"{fields[1]}, {fields[3]}"};
				AreaMap.Add(property.MapId, property);
			}

			fileInfo = Resources.AreaExceptions;
			lines = fileInfo.Split("\r\n");
			foreach (var line in lines)
			{
				if (string.IsNullOrEmpty(line)) continue;
				Exceptions.Add(line);
			}

			Exceptions.Sort();
		}

		public static int NumberOfExceptions => Exceptions.Count;

		public static bool IsAreaIdException(string areaId) => Exceptions.BinarySearch(areaId) >= 0;

		public static bool IsAreaIdValid(string areaId) => !string.IsNullOrEmpty(areaId) && AreaMap.ContainsKey(areaId);

		public static string GetMapLabelOfAreaId(string areaId)
		{
			if (!AreaMap.TryGetValue(areaId, out var property))
			{
				throw new InvalidOperationException($"AreaId {areaId} is not valid");
			}

			return property.MapLabel;
		}

		internal class AreaProperty
		{
			public string MapId { get; set; }
			public string MapLabel { get; set; }
		}
	}
}