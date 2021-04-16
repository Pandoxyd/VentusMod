using System;
using System.Collections.Generic;
using System.Text;
using VentusMod.Classes;
using UnityEngine;

namespace VentusMod.VentsMap
{
    public class Airship
    {
        public static bool FindAirshipVents()
        {
            Vent[] airshipVents = Utilities.ListVents();

            bool flag1 = StorageVent == null;
            if (flag1)
            {
                StorageVent = Utilities.CheckVent(airshipVents, "StorageVent");
            }

            bool flag2 = RecrodsVent == null;
            if (flag2)
            {
                RecrodsVent = Utilities.CheckVent(airshipVents, "RecrodsVent");
            }

            bool flag3 = ShowersVent == null;
            if (flag3)
            {
                ShowersVent = Utilities.CheckVent(airshipVents, "ShowersVent");
            }

            bool flag4 = HallwayVent2 == null;
            if (flag4)
            {
                HallwayVent2 = Utilities.CheckVent(airshipVents, "HallwayVent2");
            }

            bool flag5 = HallwayVent1 == null;
            if (flag5)
            {
                HallwayVent1 = Utilities.CheckVent(airshipVents, "HallwayVent1");
            }

            bool flag6 = GaproomVent2 == null;
            if (flag6)
            {
                GaproomVent2 = Utilities.CheckVent(airshipVents, "GaproomVent2");
            }

            bool flag7 = GaproomVent1 == null;
            if (flag7)
            {
                GaproomVent1 = Utilities.CheckVent(airshipVents, "GaproomVent1");
            }

            bool flag8 = EjectionVent == null;
            if (flag8)
            {
                EjectionVent = Utilities.CheckVent(airshipVents, "EjectionVent");
            }

            bool flag9 = SecurityVent == null;
            if (flag9)
            {
                SecurityVent = Utilities.CheckVent(airshipVents, "KitchenVent");
            }

            bool flag10 = VaultVent == null;
            if (flag10)
            {
                VaultVent = Utilities.CheckVent(airshipVents, "VaultVent");
            }

            bool flag11 = EngineVent == null;
            if (flag11)
            {
                EngineVent = Utilities.CheckVent(airshipVents, "EngineVent");
            }

            bool flag12 = CockpitVent == null;
            if (flag12)
            {
                CockpitVent = Utilities.CheckVent(airshipVents, "CockpitVent");
            }

            bool isVentsFound = (StorageVent != null && RecrodsVent != null && ShowersVent != null
                && HallwayVent2 != null && HallwayVent1 != null && GaproomVent2 != null && GaproomVent1 != null
                && EjectionVent != null && SecurityVent != null && VaultVent != null && EngineVent != null
                && CockpitVent != null);

            return isVentsFound;
        }

        public static void ChangeAirshipVents()
        {
            StorageVent.Left = SecurityVent;
            StorageVent.Right = RecrodsVent;

            SecurityVent.Left = EjectionVent;
            SecurityVent.Right = StorageVent;

            EjectionVent.Left = CockpitVent;
            EjectionVent.Right = SecurityVent;

            CockpitVent.Left = EjectionVent;
            CockpitVent.Right = VaultVent;

            VaultVent.Left = CockpitVent;
            VaultVent.Right = GaproomVent1;

            GaproomVent1.Left = VaultVent;
            GaproomVent1.Right = GaproomVent2;

            GaproomVent2.Left = GaproomVent1;
            GaproomVent2.Right = RecrodsVent;

            RecrodsVent.Left = GaproomVent2;
            RecrodsVent.Right = StorageVent;

            HallwayVent2.Left = EngineVent;
            HallwayVent2.Right = ShowersVent;

            ShowersVent.Left = HallwayVent2;
            ShowersVent.Right = HallwayVent1;

            HallwayVent1.Left = EngineVent;
            HallwayVent1.Right = ShowersVent;

            EngineVent.Left = HallwayVent1;
            EngineVent.Right = HallwayVent2;

            EjectionVent.gameObject.transform.position = new Vector3(-15.6f, -13f, 0f);
            SecurityVent.gameObject.transform.position = new Vector3(5f, -10.3f, 0f);
        }

        public static Vent StorageVent;//Cargo Bay Vent
        public static Vent RecrodsVent;
        public static Vent ShowersVent;
        public static Vent HallwayVent2;//Upper Vent
        public static Vent HallwayVent1;//Lower Vent
        public static Vent GaproomVent2;//Right Vent
        public static Vent GaproomVent1;//Left Vent
        public static Vent EjectionVent;//Viewing Deck Vent
        public static Vent SecurityVent;//KitchenVent moved to Security
        public static Vent VaultVent;
        public static Vent EngineVent;
        public static Vent CockpitVent;

        public static bool AirshipVentsFound;
    }
}
