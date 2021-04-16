using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;

namespace VentusMod.Classes
{
    public class Utilities
    {
        public static bool CheckCommsTask(PlayerControl p)
        {
            List<PlayerTask> tasks = p.myTasks.ToArray().ToList();
            bool isComms = tasks.Exists(t => t.TaskType == TaskTypes.FixComms);

            return isComms;
        }

        public static Vent[] ListVents()
        {

            return ShipStatus.Instance.AllVents;

        }

        public static Vent CreateNewVent(string name, Vector3 position)
        {

            Vent originalVent = ListVents()[ListVents().Length - 1];
            Vent newVent = UnityEngine.Object.Instantiate(originalVent, originalVent.transform.parent);
            newVent.gameObject.name = name;
            newVent.Id = ListVents().Length;
            newVent.gameObject.transform.position = position;

            return newVent;
        }

        public static void AddNewVent(Vent vent)
        {
            Vent[] originalList = ListVents();
            int originalLength = originalList.Length;   

            Vent[] newList = new Vent[originalLength + 1];

            for (int i = 0; i < originalLength; i++)
            {
                newList[i] = originalList[i];
            }

            newList.SetValue(vent, (newList.Length - 1));

            ShipStatus.Instance.AllVents = newList;
        }

        public static Vent CheckVent(Vent[] vlist, string name)
        {
            Vent vent = Array.Find(vlist, vent => vent.gameObject.name == name);
            return vent;
        }        
    }
}
