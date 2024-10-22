namespace IngameScript
{
    partial class Program
    {
        public class ResourceNames
        {
            public const string
                RPowder = "powder",
                RMagnesium = "Magnesium",
                RStone = "Stone",
                RIron = "Iron",
                RNickel = "Nickel",
                RSilicon = "Silicon",
                RCobalt = "Cobalt",
                RPlatinum = "Platinum",
                RUranium = "Uranium",
                RScrap = "Scrap",
                RCarbon = "Carbon",
                RPotassium = "Potassium",
                RPhosphorus = "Phosphorus",
                RNaquadah = "Naquadah",
                RTrinium = "Trinium",
                RNeutronium = "Neutronium",
                RCopper = "Copper",
                RLithium = "Lithium",
                RBauxite = "Bauxite",
                RTitanium = "Titanium",
                RTantalum = "Tantalum",
                RSulfur = "Sulfur",
                RNiter = "Niter",
                RCoal = "Coal",
                RDeuterium = "Deuterium";
            // public const string R = "";
        }

        public class Ingot : ResourceNames
        {
            const string prefix = "Ingot ";
            public const string
                Scrap = prefix + RScrap,
                Magnesium = prefix + RMagnesium,
                Magnesiumpowder = RMagnesium + RPowder,
                Gunpowder = "Gun" + RPowder,
                Stone = prefix + RStone,
                Iron = prefix + RIron,
                Nickel = prefix + RNickel,
                Silicon = prefix + RSilicon,
                Cobalt = prefix + RCobalt,
                Platinum = prefix + RPlatinum,
                Uranium = prefix + RUranium,
                WaterFood = prefix + "WaterFood",
                Nutrients = prefix + "Nutrients",
                SubFresh = prefix + "SubFresh",
                GreyWater = prefix + "GreyWater",
                CleanWater = prefix + "CleanWater",
                SpentFuel = prefix + "SpentFuel",
                Niter = prefix + RNiter,
                DeuteriumContainer = prefix + RDeuterium + "Container",
                Carbon = prefix + RCarbon,
                Potassium = prefix + RPotassium,
                Phosphorus = prefix + RPhosphorus,
                Naquadah = prefix + RNaquadah,
                Trinium = prefix + RTrinium,
                Neutronium = prefix + RNeutronium,
                Copper = prefix + RCopper,
                Lithium = prefix + RLithium,
                Titanium = prefix + RTitanium,
                Tantalum = prefix + RTantalum,
                Sulfur = prefix + RSulfur,
                Aluminium = prefix + "Aluminium";
            // public const string  = prefix + "";
        }

        public class Ore : ResourceNames
        {
            const string prefix = "Ore ";
            public const string
                Scrap = prefix + RScrap,
                Magnesium = prefix + RMagnesium,
                Stone = prefix + RStone,
                Iron = prefix + RIron,
                Nickel = prefix + RNickel,
                Silicon = prefix + RSilicon,
                Cobalt = prefix + RCobalt,
                Platinum = prefix + RPlatinum,
                Uranium = prefix + RUranium,
                Organic = prefix + "Organic",
                Ice = prefix + "Ice",
                Deuterium = prefix + RDeuterium,
                Carbon = prefix + RCarbon,
                Potassium = prefix + RPotassium,
                Phosphorus = prefix + RPhosphorus,
                Naquadah = prefix + RNaquadah,
                Trinium = prefix + RTrinium,
                Neutronium = prefix + RNeutronium,
                Niter = prefix + RNiter,
                Copper = prefix + RCopper,
                Lithium = prefix + RLithium,
                Bauxite = prefix + RBauxite,
                Titanium = prefix + RTitanium,
                Tantalum = prefix + RTantalum,
                Sulfur = prefix + RSulfur,
                Coal = prefix + RCoal;
            // public const string  = prefix + "";
        }
    }
}
