using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadSystem 
    {
        public static string Load()
        {
            if (PlayerPrefs.HasKey("SavedData"))
            {
                return PlayerPrefs.GetString("SavedData");
            }
            return null;
        }
        public static void Save(string data)
        {
            PlayerPrefs.SetString("SavedData", data);
        }
    }



}

