using System;
using System.Collections.Generic;
using System.Text;
using VentusMod.Classes;
using UnityEngine;

namespace VentusMod.VentsMap
{
    public class Polus
    {
        public static bool FindPolusVents()
        {
            Vent[] polusVents = Utilities.ListVents();

            bool flag1 = SouthVent == null;
            if (flag1)
            {
                SouthVent = Utilities.CheckVent(polusVents, "SouthVent");
            }

            bool flag2 = ElectricBuildingVent == null;
            if (flag2)
            {
                ElectricBuildingVent = Utilities.CheckVent(polusVents, "ElectricBuildingVent");
            }

            bool flag3 = ScienceBuildingVent == null;
            if (flag3)
            {
                ScienceBuildingVent = Utilities.CheckVent(polusVents, "ScienceBuildingVent");
            }

            bool flag4 = StorageVent == null;
            if (flag4)
            {
                StorageVent = Utilities.CheckVent(polusVents, "StorageVent");
            }

            bool flag5 = BathroomVent == null;
            if (flag5)
            {
                BathroomVent = Utilities.CheckVent(polusVents, "BathroomVent");
            }

            bool flag6 = AdminVent == null;
            if (flag6)
            {
                AdminVent = Utilities.CheckVent(polusVents, "AdminVent");
            }

            bool flag7 = OfficeVent == null;
            if (flag7)
            {
                OfficeVent = Utilities.CheckVent(polusVents, "OfficeVent");
            }

            bool flag8 = CommsVent == null;
            if (flag8)
            {
                CommsVent = Utilities.CheckVent(polusVents, "CommsVent");
            }

            bool flag9 = LifeSuppVent == null;
            if (flag9)
            {
                LifeSuppVent = Utilities.CheckVent(polusVents, "LifeSuppVent");
            }

            bool flag10 = ElecFenceVent == null;
            if (flag10)
            {
                ElecFenceVent = Utilities.CheckVent(polusVents, "ElecFenceVent");
            }

            bool flag11 = ElectricalVent == null;
            if (flag11)
            {
                ElectricalVent = Utilities.CheckVent(polusVents, "ElectricalVent");
            }

            bool flag12 = SubBathroomVent == null;
            if (flag12)
            {
                SubBathroomVent = Utilities.CheckVent(polusVents, "SubBathroomVent");
            }

            bool flag13 = PolusSpecimenVent == null;
            if (flag13)
            {
                PolusSpecimenVent = Utilities.CheckVent(polusVents, "PolusSpecimenVent");
            }

            bool isVentsFound = (SouthVent != null && ElectricBuildingVent != null && ScienceBuildingVent != null
                && StorageVent != null && BathroomVent != null && AdminVent != null && OfficeVent != null
                && CommsVent != null && LifeSuppVent != null && ElecFenceVent != null && ElectricalVent != null
                && SubBathroomVent != null && PolusSpecimenVent != null);

            return isVentsFound;
        }

        public static void ChangePolusVents()
        {
            ElectricBuildingVent.Left = ElectricalVent;
            ElectricBuildingVent.Right = ScienceBuildingVent;
            ScienceBuildingVent.Left = ElectricBuildingVent;
            ScienceBuildingVent.Right = BathroomVent;
            BathroomVent.Left = ScienceBuildingVent;
            BathroomVent.Center = SubBathroomVent;
            BathroomVent.Right = PolusSpecimenVent;
            SouthVent.Left = LifeSuppVent;
            SouthVent.Right = AdminVent;
            LifeSuppVent.Left = ElectricalVent;
            LifeSuppVent.Right = SouthVent;
            LifeSuppVent.Center = ElecFenceVent;
            ElectricalVent.Left = LifeSuppVent;
            ElectricalVent.Right = ElectricBuildingVent;
            ElectricalVent.Center = ElecFenceVent;

            AdminVent.Left = SouthVent;
            AdminVent.Right = PolusSpecimenVent;

            SubBathroomVent.Left = StorageVent;
            SubBathroomVent.Right = OfficeVent;
            SubBathroomVent.Center = BathroomVent;
            OfficeVent.Left = CommsVent;
            OfficeVent.Right = SubBathroomVent;
            CommsVent.Left = ElecFenceVent;
            CommsVent.Right = OfficeVent;
            ElecFenceVent.Right = CommsVent;
            ElecFenceVent.Left = StorageVent;
            ElecFenceVent.Center = ElectricalVent;
            StorageVent.Left = ElecFenceVent;
            StorageVent.Right = SubBathroomVent;

            PolusSpecimenVent.Left = null;
            PolusSpecimenVent.Right = null;
            PolusSpecimenVent.Center = null;

            BathroomVent.gameObject.transform.position = new Vector3(35f, -9.6f, 2f);
        }

        public static Vent SouthVent;
        public static Vent ElectricBuildingVent;
        public static Vent ScienceBuildingVent;
        public static Vent StorageVent;
        public static Vent BathroomVent;
        public static Vent AdminVent;
        public static Vent OfficeVent;
        public static Vent CommsVent;
        public static Vent LifeSuppVent;
        public static Vent ElecFenceVent;
        public static Vent ElectricalVent;
        public static Vent SubBathroomVent;

        public static Vent PolusSpecimenVent; // Custom Vent

        public static bool PolusVentsFound;
    }
}
