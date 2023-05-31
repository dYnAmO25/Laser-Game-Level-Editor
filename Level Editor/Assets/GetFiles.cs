using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GetFiles : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_InputField input;
    [SerializeField] GameObject goQuitScreen;
    
    public string[] sFiles;
    void Start()
    {
        SaveSystem.TestFolder();

        SetExplorer();

        if (sFiles.Length != 0)
        {
            dropdown.value = 1;

            ChangePath();
        }
    }

    // Update is called once per frame
    void Update()
    {   

    }

    public void SetExplorer()
    {
        sFiles = Directory.GetFiles(Application.persistentDataPath + "/CustomLevels");

        dropdown.ClearOptions();

        List<string> sList = new List<string>(sFiles);

        dropdown.AddOptions(sList);
    }

    public void ChangePath()
    {
        GameObject goLevelSystem = GameObject.FindGameObjectWithTag("LevelSystem");

        goLevelSystem.GetComponent<LevelSystem>().sPath = sFiles[dropdown.value];
    }

    public void CreateNewFile()
    {
        GameObject goLevelSystem = GameObject.FindGameObjectWithTag("LevelSystem");

        string sCreatePath = Application.persistentDataPath + "/CustomLevels/" + input.text + ".gg";

        goLevelSystem.GetComponent<LevelSystem>().sPath = sCreatePath;

        goLevelSystem.GetComponent<LevelSystem>().SaveLevel();
    }

    public void SetExplorerToObject()
    {
        string sTestPath = Application.persistentDataPath + "/CustomLevels\\" + input.text + ".gg";


        for (int i = 0; i < sFiles.Length; i++)
        {
            if (sFiles[i] == sTestPath)
            {    
                dropdown.value = i;
            }
        }
    }

    public void DeleteFile()
    {
        if (sFiles.Length != 0)
        {
            File.Delete(sFiles[dropdown.value]);
        }

        SetExplorer();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void AskQuitApp()
    {
        goQuitScreen.SetActive(true);
    }

    public void CancelQuitApp()
    {
        goQuitScreen.SetActive(false);
    }
}
