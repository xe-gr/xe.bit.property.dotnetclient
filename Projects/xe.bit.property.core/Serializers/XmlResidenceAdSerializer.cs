using System.Collections.Generic;
using System.IO;
using System.Xml;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlResidenceAdSerializer : XmlBaseSerializer
	{
		public override string Serialize(BaseAd ad)
		{
			using (var ms = new MemoryStream())
			using (var writer = XmlWriter.Create(ms, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment, OmitXmlDeclaration = true }))
			{
				var r = (ResidenceAd)ad;

				writer
					.ElementWithAttributes("Item",
						new Dictionary<string, string> {{"type", ad.AdType.ToString()}, {"refId", ad.RefId}})
					.Element("Item.ownerId", ad.OwnerId)
					.Element("Item.majorPhone", ad.MajorPhone)
					.Element("Item.departmentOnCategory", ad.DepartmentOnCategory)
					.Element("Item.otherPhones", ad.OtherPhones, "Item.phone")
					.CData("Item.internetText", ad.InternetText)
					.CData("Item.addOnText", ad.AddOnText)
					.CData("Item.bodyText", ad.BodyText)
					.Field("Item.type", r.ItemType)
					.Field("Item.subtype", r.SubType)
					.Field("Item.area", r.Area)
					.Field("Item.level", r.Level?.ToString())
					.Field("Item.constructionType", r.ConstructionType)
					.Field("Item.condition", r.Condition)
					.Field("Item.conditionDetails", r.ConditionDetails)
					.Field("Item.constructionYear", r.ConstructionYear)
					.Field("Item.floors", r.Floors)
					.Field("Item.floorsArea", r.FloorsArea)
					.Field("Item.refurbishmentYear", r.RefurbishmentYear)
					.Field("Item.orientation", r.Orientation)
					.Field("Item.bedrooms", r.Bedrooms)
					.Field("Item.masterBedrooms", r.MasterBedrooms)
					.Field("Item.bathrooms", r.Bathrooms)
					.Field("Item.wc", r.Wc)
					.Field("Item.hasParking", r.HasParking, true)
					.Field("Item.parkingType", r.ParkingType)
					.Field("Item.hasStorage", r.HasStorage, true)
					.Field("Item.storageArea", r.StorageArea)
					.Field("Item.hasAutonomousHeating", r.HasAutonomousHeating, true)
					.Field("Item.hasCentralHeating", r.HasCentralHeating, true)
					.Field("Item.hasAirConditioning", r.HasAirConditioning, true)
					.Field("Item.hasSecureDoor", r.HasSecureDoor, true)
					.Field("Item.viewType", r.ViewType)
					.Field("Item.hasFirePlace", r.HasFirePlace, true)
					.Field("Item.hasSolarBoiler", r.HasSolarBoiler, true)
					.Field("Item.withoutElevator", r.WithoutElevator, true)
					.Field("Item.hasNaturalGas", r.HasNaturalGas, true)
					.Field("Item.hasGarden", r.HasGarden, true)
					.Field("Item.gardenArea", r.GardenArea)
					.Field("Item.location", r.Location)
					.Field("Item.land", r.Land)
					.Field("Item.availabilityType", r.AvailabilityType)
					.Field("Item.hasPrivateTerrace", r.HasTerraceArea, true)
					.Field("Item.terraceArea", r.TerraceArea)
					.Field("Item.hasPool", r.HasPool, true)
					.Field("Item.hasTents", r.HasTents, true)
					.Field("Item.isWithoutCommunalCharge", r.IsWithoutCommunalCharge, true)
					.Field("Item.isSuitableForProfessionalUse", r.IsSuitableForProfessionalUse, true)
					.Field("Item.isFurnished", r.IsFurnished, true)
					.Field("Item.availableFrom", r.AvailableFrom)
					.Field("Item.spacesPlan", r.SpacesPlan)
					.Field("Item.isSuitableForStudents", r.IsSuitableForProfessionalUse, true)
					.Field("Item.isAgentAccepted", r.IsAgentAccepted, true)
					.Field("Item.hasSemiOpenSpaces", r.HasSemiOpenSpaces, true)
					.Field("Item.semiOpenSpacesArea", r.SemiOpenSpacesArea)
					.Field("Item.energy_class", r.EnergyClass);

				SerializeGeo(writer, ad);
				SerializeFinancial(writer, ad);

				writer.CloseElement();

				writer.Flush();
				writer.Close();
				return System.Text.Encoding.Default.GetString(ms.ToArray());
			}
		}
	}
}