using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveManager
{
    public void Save(List<PlanetController> planetList, int playerPlanetId)
    {
        SingleModeSave singleModeSave = new SingleModeSave(planetList, playerPlanetId);

        string saveJson = JsonUtility.ToJson(singleModeSave);

        PlayerPrefs.SetString(Data.saveName, saveJson);
        PlayerPrefs.Save();
    }

    public SingleModeSave Load()
    {
        SingleModeSave singleModeSave = JsonUtility.FromJson<SingleModeSave>(PlayerPrefs.GetString(Data.saveName));
        return singleModeSave;
    }

    public bool IsSaveAvaliable
    {
        get
        {
            return PlayerPrefs.HasKey(Data.saveName);
        }
    }
}


