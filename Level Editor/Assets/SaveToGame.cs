using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveToGame : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    private string sGamePath = "C:/Users/nikla/AppData/LocalLow/Niklas Fucking Gerum/LaserGame/CustomLevels";

    public void SaveTGame()
    {
        sGamePath = Application.persistentDataPath;
        sGamePath = sGamePath.Replace("Level Editor", "");
        
        if (Directory.Exists(sGamePath))
        {
            string sPath = sGamePath + "LaserGame/CustomLevels\\" + input.text + ".gg";
            GameObject go = GameObject.FindGameObjectWithTag("LevelSystem");

            go.GetComponent<LevelSystem>().sPath = sPath;

            SendConsoleMassage("Level saved to Game");
        }
        else
        {
            SaveNormal();

            SendConsoleMassage("Level could not be saved to Game (File Path does not exist)");
        }
    }

    public void SaveNormal()
    {
        string sPath = Application.persistentDataPath + "/CustomLevels\\" + input.text + ".gg";
        GameObject go = GameObject.FindGameObjectWithTag("LevelSystem");

        go.GetComponent<LevelSystem>().sPath = sPath;
    }

    private void SendConsoleMassage(string s)
    {
        GameObject.FindGameObjectWithTag("Console").GetComponent<ConsoleManager>().SetConsole(s);
    }
}
