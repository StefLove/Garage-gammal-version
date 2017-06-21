namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Garage2._0.Enum.TypeOfVehicle;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2._0.DataAccess.GarageContext context)
        {
            context.ParkedVehicles.AddOrUpdate(

                pv => pv.RegNumber,
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "QSW098", Brand = "BMW", Model = "520d", Color = "Svart", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "EDC321", Brand = "FIAT", Model = "500L", Color = "Gul", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "AQR564", Brand = "VW", Model = "Passat", Color = "Silver", NoOfWheels = 4, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Bus, RegNumber = "DSL675", Brand = "Scania", Model = "DC13", Color = "Vit", NoOfWheels = 6, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Boat, RegNumber = "ADKN456", Brand = "Flipper", Model = "F800R", Color = "Bl�", NoOfWheels = 0, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Airplane, RegNumber = "NAB900", Brand = "Cessna", Model = "402", Color = "Vit", NoOfWheels = 4, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Motorcycle, RegNumber = "GHJ789", Brand = "BMW", Model = "F800R", Color = "Svart", NoOfWheels = 2, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Motorcycle, RegNumber = "AHJ090", Brand = "Harley-Davidson", Model = "500L", Color = "Gul", NoOfWheels = 2, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Airplane, RegNumber = "JBB007", Brand = "Concorde", Model = "C33", Color = "Vit", NoOfWheels = 16, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Bus, RegNumber = "TUR333", Brand = "Scania", Model = "S2000", Color = "Vit", NoOfWheels = 8, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Boat, RegNumber = "SNE897", Brand = "Flipper", Model = "F800R", Color = "Bl�", NoOfWheels = 0, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Airplane, RegNumber = "DIN999", Brand = "Cessna", Model = "402", Color = "Vit", NoOfWheels = 2, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "FRU752", Brand = "Ferrari", Model = "F12", Color = "R�d", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "MAN222", Brand = "Aston Martin", Model = "500L", Color = "Gul", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "WWW333", Brand = "VW", Model = "Golf", Color = "Gr�n", NoOfWheels = 4, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Bus, RegNumber = "HIP444", Brand = "Scania", Model = "DC13", Color = "Brun", NoOfWheels = 8, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Boat, RegNumber = "HOP555", Brand = "Uttern", Model = "U127", Color = "Gr�", NoOfWheels = 0, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Airplane, RegNumber = "SAS123", Brand = "Fokker", Model = "F-28", Color = "Vit", NoOfWheels = 16, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "FIN753", Brand = "BMW", Model = "F800R", Color = "Svart", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "LOS987", Brand = "FIAT", Model = "500L", Color = "Gul", NoOfWheels = 4, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Car, RegNumber = "BIL144", Brand = "Volvo", Model = "144", Color = "Vit", NoOfWheels = 4, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Motorcycle, RegNumber = "DUC565", Brand = "Ducati", Model = "D1200R", Color = "Svart", NoOfWheels = 2, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Motorcycle, RegNumber = "HUS987", Brand = "Husqvarna", Model = "500cc", Color = "Gul", NoOfWheels = 2, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Motorcycle, RegNumber = "HON787", Brand = "Honda", Model = "750", Color = "Gr�n", NoOfWheels = 2, CheckInTime = DateTime.Now },

                new Models.ParkedVehicle { TypeOfVehicle = Boat, RegNumber = "B�T003", Brand = "Buster", Model = "DC13", Color = "Vit", NoOfWheels = 0, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Boat, RegNumber = "ZXY321", Brand = "Princess", Model = "P44", Color = "Bl�", NoOfWheels = 0, CheckInTime = DateTime.Now },
                new Models.ParkedVehicle { TypeOfVehicle = Airplane, RegNumber = "QTY555", Brand = "Boeing", Model = "747", Color = "Vit", NoOfWheels = 20, CheckInTime = DateTime.Now }
                );
        }

    }
}
