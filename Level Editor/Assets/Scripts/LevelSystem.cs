using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] GameObject goFloor;
    [SerializeField] GameObject goBlock;
    [SerializeField] GameObject goPlayerPrefab;
    [SerializeField] GameObject goGoal;
    [SerializeField] GameObject goBlueLaser;
    [SerializeField] GameObject goRedLaser;

    public string sPath;

    private float fY = 0.25f;
    
    public void SaveLevel()
    {
        SaveSystem.SaveLevel(sPath);
    }

    public void LoadLevel()
    {
        //Gets Data
        Level data = SaveSystem.LoadLevel(sPath);

        DeleteLevel();

        //Builds new Level
        //Builds Ground
        Vector3 v3 = new Vector3();
        
        v3.x = 0;
        v3.y = -0.05f;
        v3.z = 0;
        GameObject goCurrentBlock = Instantiate(goFloor, v3, Quaternion.identity);

        v3.x = data.iX;
        v3.y = 0.1f;
        v3.z = data.iZ;
        goCurrentBlock.transform.localScale = v3;

        //Builds Player
        v3.x = data.fXP;
        v3.y = 0.5f;
        v3.z = data.fZP;
        Instantiate(goPlayerPrefab, v3, Quaternion.identity);

        //Builds Blocks
        v3.y = fY;

        for (int i = 0; i < data.position.Length; i += 2)
        {
            v3.x = data.position[i];
            v3.z = data.position[i + 1];

            Instantiate(goBlock, v3, Quaternion.identity);
        }

        //Builds Goals
        for (int i = 0; i < data.goalsPosition.Length; i += 2)
        {
            v3.x = data.goalsPosition[i];
            v3.z = data.goalsPosition[i + 1];

            Instantiate(goGoal, v3, Quaternion.identity);
        }

        //Lasers
        Vector3 v3R = new Vector3();
        Vector3 v3S = new Vector3(2, 0.5f, 0.5f);
        GameObject goCurrentLaser;

        //Builds Blue Laser
        for (int i = 0; i < data.blueLaser.Length; i += 4)
        {
            v3.x = data.blueLaser[i];
            v3.z = data.blueLaser[i + 1];
            v3R.y = data.blueLaser[i + 2];
            v3S.x = data.blueLaser[i + 3];

            goCurrentLaser = Instantiate(goBlueLaser, v3, Quaternion.Euler(v3R));
            goCurrentLaser.transform.localScale = v3S;
        }

        //Builds Red Laser
        for (int i = 0; i < data.redLaser.Length; i += 4)
        {
            v3.x = data.redLaser[i];
            v3.z = data.redLaser[i + 1];
            v3R.y = data.redLaser[i + 2];
            v3S.x = data.redLaser[i + 3];

            goCurrentLaser = Instantiate(goRedLaser, v3, Quaternion.Euler(v3R));
            goCurrentLaser.transform.localScale = v3S;
        }
    }

    public void DeleteLevel()
    {
        //Removes old Level
        GameObject goGround = GameObject.FindGameObjectWithTag("Ground");
        GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject[] goBlocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject[] goGoals = GameObject.FindGameObjectsWithTag("Goal");
        GameObject[] goRedLasers = GameObject.FindGameObjectsWithTag("RedLaser");
        GameObject[] goBlueLasers = GameObject.FindGameObjectsWithTag("BlueLaser");

        Destroy(goGround);
        Destroy(goPlayer);

        for (int i = 0; i < goBlocks.Length; i++)
        {
            Destroy(goBlocks[i]);
        }

        for (int i = 0; i < goGoals.Length; i++)
        {
            Destroy(goGoals[i]);
        }

        for (int i = 0; i < goRedLasers.Length; i++)
        {
            Destroy(goRedLasers[i]);
        }

        for (int i = 0; i < goBlueLasers.Length; i++)
        {
            Destroy(goBlueLasers[i]);
        }
    }

    public void NewDeleteLevel()
    {
        //Removes old Level
        GameObject goGround = GameObject.FindGameObjectWithTag("Ground");
        GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject[] goBlocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject[] goGoals = GameObject.FindGameObjectsWithTag("Goal");
        GameObject[] goRedLasers = GameObject.FindGameObjectsWithTag("RedLaser");
        GameObject[] goBlueLasers = GameObject.FindGameObjectsWithTag("BlueLaser");

        goGround.transform.localScale = new Vector3(10, -0.05f, 10);
        Destroy(goPlayer);

        for (int i = 0; i < goBlocks.Length; i++)
        {
            Destroy(goBlocks[i]);
        }

        for (int i = 0; i < goGoals.Length; i++)
        {
            Destroy(goGoals[i]);
        }

        for (int i = 0; i < goRedLasers.Length; i++)
        {
            Destroy(goRedLasers[i]);
        }

        for (int i = 0; i < goBlueLasers.Length; i++)
        {
            Destroy(goBlueLasers[i]);
        }
    }

    public void SendConsoleMassage()
    {
        GameObject.FindGameObjectWithTag("Console").GetComponent<ConsoleManager>().SetConsole("Level Saved");
    }
}
