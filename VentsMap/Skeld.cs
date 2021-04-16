using System;
using System.Collections.Generic;
using System.Text;
using VentusMod.Classes;
using UnityEngine;

namespace VentusMod.VentsMap
{
    public class Skeld
    {
        public static bool FindSkeldVents()
        {
            Vent[] skeldVents = Utilities.ListVents();

            bool flag1 = LEngineVent == null;
            if (flag1)
            {
                LEngineVent = Utilities.CheckVent(skeldVents, "LEngineVent");
            }

            bool flag2 = REngineVent == null;
            if (flag2)
            {
                REngineVent = Utilities.CheckVent(skeldVents, "REngineVent");
            }

            bool flag3 = UpperReactorVent == null;
            if (flag3)
            {
                UpperReactorVent = Utilities.CheckVent(skeldVents, "UpperReactorVent");
            }

            bool flag4 = ReactorVent == null;
            if (flag4)
            {
                ReactorVent = Utilities.CheckVent(skeldVents, "ReactorVent");
            }

            bool flag5 = ShieldsVent == null;
            if (flag5)
            {
                ShieldsVent = Utilities.CheckVent(skeldVents, "ShieldsVent");
            }

            bool flag6 = WeaponsVent == null;
            if (flag6)
            {
                WeaponsVent = Utilities.CheckVent(skeldVents, "WeaponsVent");
            }

            bool flag7 = NavVentNorth == null;
            if (flag7)
            {
                NavVentNorth = Utilities.CheckVent(skeldVents, "NavVentNorth");
            }

            bool flag8 = NavVentSouth == null;
            if (flag8)
            {
                NavVentSouth = Utilities.CheckVent(skeldVents, "NavVentSouth");
            }
            
            bool flag9 = SkeldStorageVent == null;
            if (flag9)
            {
                SkeldStorageVent = Utilities.CheckVent(skeldVents, "SkeldStorageVent");
            }

            bool flag10 = MedVent == null;
            if (flag10)
            {
                MedVent = Utilities.CheckVent(skeldVents, "MedVent");
            }

            bool flag11 = LifeSuppVent == null;
            if (flag11)
            {
                LifeSuppVent = Utilities.CheckVent(skeldVents, "LifeSuppVent");
            }

            bool flag12 = ElecVent == null;
            if (flag12)
            {
                ElecVent = Utilities.CheckVent(skeldVents, "ElecVent");
            }

            bool flag13 = AdminVent == null;
            if (flag13)
            {
                AdminVent = Utilities.CheckVent(skeldVents, "AdminVent");
            }

            bool flag14 = BigYVent == null;
            if (flag14)
            {
                BigYVent = Utilities.CheckVent(skeldVents, "BigYVent");
            }

            bool flag15 = CafeVent == null;
            if (flag15)
            {
                CafeVent = Utilities.CheckVent(skeldVents, "CafeVent");
            }

            SkeldVentsFound = (LEngineVent != null && REngineVent != null && UpperReactorVent != null
                && ReactorVent != null && ShieldsVent != null && WeaponsVent != null && NavVentNorth != null
                && NavVentSouth != null && MedVent != null && LifeSuppVent != null
                && ElecVent != null && AdminVent != null && BigYVent != null && CafeVent != null && SkeldStorageVent != null);

            return SkeldVentsFound;
        }
        public static void ChangeSkeldVents()
        {
            WeaponsVent.Left = LEngineVent;
            WeaponsVent.Right = NavVentSouth;

            LEngineVent.Right = WeaponsVent;
            LEngineVent.Left = ReactorVent;

            ReactorVent.Right = REngineVent;
            ReactorVent.Left = LEngineVent;

            REngineVent.Right = SkeldStorageVent;
            REngineVent.Left = ReactorVent;

            ShieldsVent.Left = SkeldStorageVent;
            ShieldsVent.Right = NavVentSouth;

            NavVentSouth.Right = WeaponsVent;
            NavVentSouth.Left = ShieldsVent;

            SkeldStorageVent.Left = REngineVent;
            SkeldStorageVent.Right = ShieldsVent;

            AdminVent.Left = ElecVent;
            AdminVent.Right = BigYVent;
            AdminVent.Center = CafeVent;

            ElecVent.Left = LifeSuppVent;
            ElecVent.Right = AdminVent;
            ElecVent.Center = MedVent;

            CafeVent.Left = MedVent;
            CafeVent.Right = BigYVent;
            CafeVent.Center = AdminVent;

            MedVent.Left = LifeSuppVent;
            MedVent.Right = CafeVent;
            MedVent.Center = ElecVent;

            ElecVent.gameObject.transform.position = new Vector3(-9.7f, -8.8f, 6.8f);
            WeaponsVent.gameObject.transform.position = new Vector3(7.5f, 1.25f, 6.92f);
            NavVentNorth.gameObject.SetActive(false);
            UpperReactorVent.gameObject.SetActive(false);
        }

        public static Vent LEngineVent;
        public static Vent REngineVent;
        public static Vent UpperReactorVent;
        public static Vent ReactorVent;
        public static Vent ShieldsVent;
        public static Vent WeaponsVent;
        public static Vent NavVentNorth;
        public static Vent NavVentSouth;

        public static Vent MedVent;
        public static Vent LifeSuppVent;
        public static Vent ElecVent;
        public static Vent AdminVent;
        public static Vent BigYVent;
        public static Vent CafeVent;

        public static Vent SkeldStorageVent; // Custom Vent

        public static bool SkeldVentsFound;
    }
}
