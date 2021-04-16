using TMPro;
using UnityEngine;

namespace VentusMod.Classes
{
    public class Credits
    {
        public static void Initialize()
        {
            CreditsObject = UnityEngine.Object.Instantiate(HudManager.Instance.TaskText.gameObject);
            CreditsObject.gameObject.name = "VentusModCredits";
            CreditsObject.transform.SetParent(HudManager.Instance.gameObject.transform);
            CreditsObject.transform.localPosition = new Vector2(0.65f, 1.67f);
            
            CreditsObject.GetComponent<TextMeshPro>().text = ModName + ModVer + "\n" + Pandox;            
        }
        
        
        public const string ModName = "<color=#55E44CFF>VentusMod";
        public const string ModVer = " v1.2.3";
        public const string Pandox = "<color=white>by <color=#308CF6FF>Pandoxyd";
        public static GameObject CreditsObject;
    }
}
