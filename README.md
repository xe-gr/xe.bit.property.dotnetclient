# .Net core library for the xe.gr BIT API
This project is a .net core library that allows you to create packages for the xe.gr BIT property API. You can find more information about the API [here](https://developers.xe.gr/apis/bit/property/1.4.1/).

The library allows you to perform the following:
* Create classifieds through code.
* Create a BIT package through code and add classifieds to it.
* Encode classifieds and packages to XML.
* Save a package to a compressed file that includes all package information and associated image resources.
* Send a package to the BIT property API.

You can include this library in your project by getting the 'xe.bit.property.core' package from [nuget](https://www.nuget.org/packages/xe.bit.property.core/) or by downloading from the [Github releases](https://github.com/xe-gr/xe.bit.property.dotnetclient/releases) of this repository. Alternatively, you can build the sources from this repository.

# Validations
The library includes validations for classifieds and packages. The validations do not run automatically when you assign values to classified or package properties - instead you can run the Validate() method on the corresponding objects once you are done assigning values and examine any errors that occur without getting an exception. The validations *are* executed automatically when you serialize a package either to save it to disk or to send it to the BIT API and in this case an exception will be thrown if there are errors.

# Example usage
```c#
// Create a new classified.
var ad = new ResidenceAd
{
  RefId = "ref id",
  OwnerId = "owner id",
  MajorPhone = "major phone",
  ItemType = ResidenceItemType.APARTMENT,
  SubType = ResidenceItemSubtype.SINGLEROOM | ResidenceItemSubtype.LOFT,
  Area = 1000.32m,
  Level = ProfLevel.L0,
  Condition = Condition.USED,
  ConstructionYear = 1970,
  ConstructionType = ConstructionType.NEOKLASIKO,
  MasterBedrooms = 2,
  Geo = { AreaId = "59-41", Latitude = 1.1m, Longitude = 2.2m },
  HasParking = true,
  ParkingType = ParkingType.CLOSED,
  InternetText = "internet text",
  BodyText = "body text",
  AddOnText = "add on text"
};

// Add an image to the classified.
ad.AddAsset(new Asset
{
  Type = AssetType.IMAGE,
  Id = "1",
  FileType = AssetFileType.JPEG,
  IsPrimary = true,
  Order = 1,
  Status = AssetStatus.ACTIVE,
  LocalFileName = "d:\\test.jpeg"
});

// Validate the classified. At this point, no exception is thrown and a list of validation errors is returned.
var adValidationResult = ad.Validate();

// Create a package and add the classified to it.
var p = Package.CreatePackage("token", "id", PackagePolicy.RENEW_ALL_STOCK, true)
	.AddClassified(ad);

p.SkipAssets = false;

// Validate the package. At this point no exception is thrown and a list of validation errors is returned.
var packageValidationResult = p.Validate();

// Create a zip file for the created package. If there are validation errors, an exception will be thrown.
p.Pack(null, "d:\\packed.zip");

// Post the package to the BIT property API.
var client = new Client();
client.PostToBit("d:\\packed.zip", "batchImportTest@gmail.com", "999999", true);
```

# Caution: Work in progress
At the moment the library can only be used to create and send packages that include property classifieds. We are working to also include professional property, parking, land and vacation property ads.
