namespace Equipment.Domain.Entities.OldEnums
{
    public enum Diameter
    {
        noAssign = -1,
        DN015 = 15,
        DN020 = 20,
        DN025 = 25,
        DN032 = 32,
        DN040 = 40,
        DN050 = 50,
        DN065 = 65,
        DN080 = 80,
        DN100 = 100,
        DN125 = 125,
        DN150 = 150,
        DN200 = 200,
        DN250 = 250,
        DN300 = 300,
        DN350 = 350,
        DN400 = 400,
        DN500 = 500
    }

    public record PVCTube
    {
        public int DiameterOuter_mm { get; }
        public float Thickness_mm { get; }
        public string VendorCode { get; }

        public PVCTube(int diameterOuter_mm, float thickness_mm, string vendorCode)
        {
            DiameterOuter_mm = diameterOuter_mm;
            VendorCode = vendorCode;
            Thickness_mm = thickness_mm;
        }
    }


    public static class DiameterCorrector
    {
        public static Diameter ClosestOuterTubeDiameterToDN(this double outerDiameter_in_cm)
        {
            return outerDiameter_in_cm switch
            {
                < 2.3 => Diameter.DN015,
                < 3.0 => Diameter.DN020,
                < 3.8 => Diameter.DN025,
                < 4.6 => Diameter.DN032,
                < 5.3 => Diameter.DN040,
                < 6.9 => Diameter.DN050,
                < 8.0 => Diameter.DN065,
                < 9.2 => Diameter.DN080,
                < 12.0 => Diameter.DN100,
                < 14.5 => Diameter.DN125,
                < 19.8 => Diameter.DN150,
                < 24.9 => Diameter.DN200,
                < 29.9 => Diameter.DN250,
                < 34.9 => Diameter.DN300,
                < 39.9 => Diameter.DN350,
                < 49.9 => Diameter.DN400,
                < 59.9 => Diameter.DN500,
                _ => Diameter.noAssign
            };
        }
        public static Diameter MmToClosestDiameter(this int diameterInMM)
        {
            return diameterInMM switch
            {
                < 23 => Diameter.DN015,
                < 30 => Diameter.DN020,
                < 38 => Diameter.DN025,
                < 46 => Diameter.DN032,
                < 53 => Diameter.DN040,
                < 69 => Diameter.DN050,
                < 80 => Diameter.DN065,
                < 92 => Diameter.DN080,
                < 120 => Diameter.DN100,
                < 145 => Diameter.DN125,
                < 198 => Diameter.DN150,
                < 249 => Diameter.DN200,
                < 299 => Diameter.DN250,
                < 349 => Diameter.DN300,
                < 399 => Diameter.DN350,
                < 499 => Diameter.DN400,
                < 599 => Diameter.DN500,
                _ => Diameter.DN500
            };
        }
        public static PVCTube DiameterToPVCTubeData(this Diameter diameter)
        {
            return diameter switch
            {
                Diameter.noAssign => throw new InvalidDataException("Диаметр не назначен"),
                Diameter.DN015 => new PVCTube(20, 2, "PIPERP020"),
                Diameter.DN020 => new PVCTube(25, 2, "PIPERP025"),
                Diameter.DN025 => new PVCTube(32, 2.4f, "PIPERP032"),
                Diameter.DN032 => new PVCTube(40, 2, "PIPERP040"),
                Diameter.DN040 => new PVCTube(50, 2.4f, "PIPERP050"),
                Diameter.DN050 => new PVCTube(63, 3, "PIPERP063"),
                Diameter.DN065 => new PVCTube(75, 3.6f, "PIPERP075"),
                Diameter.DN080 => new PVCTube(90, 4.3f, "PIPERP090"),
                Diameter.DN100 => new PVCTube(110, 4.8f, "PIPERP110"),
                Diameter.DN125 => new PVCTube(125, 4.8f, "PIPERP125"),
                Diameter.DN150 => new PVCTube(160, 7.6f, "PIPERP160"),
                Diameter.DN200 => new PVCTube(225, 8.6f, "PIPERP225"),
                Diameter.DN250 => new PVCTube(250, 9.6f, "PIPERP250"),
                Diameter.DN300 => new PVCTube(315, 12.1f, "PIPERP315"),
                _ => throw new NotImplementedException($"Для {diameter} не существует ПВХ трубы")
            };
        }

        public static Diameter PVCOuterDiameterToDiameter(this string outerD)
        {
            if (!int.TryParse(outerD, out int d))
                throw new ArgumentException($"Не удалось преобразовать {outerD} в диаметр");
            return d.PVCOuterDiameterToDiameter();
        }

        public static Diameter PVCOuterDiameterToDiameter(this int outerD)
        {
            return outerD switch
            {
                20 => Diameter.DN015,
                25 => Diameter.DN020,
                32 => Diameter.DN025,
                40 => Diameter.DN032,
                50 => Diameter.DN040,
                63 => Diameter.DN050,
                75 => Diameter.DN065,
                90 => Diameter.DN080,
                110 => Diameter.DN100,
                125 => Diameter.DN125,
                160 => Diameter.DN150,
                225 => Diameter.DN200,
                280 => Diameter.DN250,
                315 => Diameter.DN300,
                355 => Diameter.DN350,
                400 => Diameter.DN400,
                _ => Diameter.noAssign
            };
        }

        public static Diameter PVCOuterDiameterToDiameter(this short outerD)
        {
            return outerD switch
            {
                20 => Diameter.DN015,
                25 => Diameter.DN020,
                32 => Diameter.DN025,
                40 => Diameter.DN032,
                50 => Diameter.DN040,
                63 => Diameter.DN050,
                75 => Diameter.DN065,
                90 => Diameter.DN080,
                110 => Diameter.DN100,
                125 => Diameter.DN125,
                160 => Diameter.DN150,
                225 => Diameter.DN200,
                280 => Diameter.DN250,
                315 => Diameter.DN300,
                355 => Diameter.DN350,
                400 => Diameter.DN400,
                _ => Diameter.noAssign
            };
        }

        public static string DiameterToPVCOuterDiameter(this Diameter diameter)
        {
            return diameter switch
            {
                Diameter.noAssign => throw new NotImplementedException(),
                Diameter.DN015 => "020",
                Diameter.DN020 => "025",
                Diameter.DN025 => "032",
                Diameter.DN032 => "040",
                Diameter.DN040 => "050",
                Diameter.DN050 => "063",
                Diameter.DN065 => "075",
                Diameter.DN080 => "090",
                Diameter.DN100 => "110",
                Diameter.DN125 => "125",
                Diameter.DN150 => "160",
                Diameter.DN200 => "225",
                Diameter.DN250 => "250",
                Diameter.DN300 => "315",
                Diameter.DN350 => "355",
                Diameter.DN400 => "400",
                _ => throw new NotImplementedException("Преобрахование для диаметров более 400 не предусмотрено")
            };
        }


    }



}
