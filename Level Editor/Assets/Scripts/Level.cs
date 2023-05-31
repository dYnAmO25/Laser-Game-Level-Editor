using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    //Ground
    public int iX;
    public int iZ;

    //Player
    public float fXP;
    public float fZP;

    //Blocks
    public float[] position;

    //Goals
    public float[] goalsPosition;

    //Blue Laser
    public float[] blueLaser;

    //Red Laser
    public float[] redLaser;

    public Level()
    {
        //Ground
        iX = (int)GameObject.FindGameObjectWithTag("Ground").transform.localScale.x;
        iZ = (int)GameObject.FindGameObjectWithTag("Ground").transform.localScale.z;

        //Player
        GameObject goNowPlayer = GameObject.FindGameObjectWithTag("Player");

        if (goNowPlayer != null)
        {
            fXP = goNowPlayer.transform.position.x;
            fZP = goNowPlayer.transform.position.z;
        }
        else
        {
            NoPlayerFound();
        }


        //Blocks
        GameObject[] goBlocks = GameObject.FindGameObjectsWithTag("Block");

        position = new float[goBlocks.Length * 2];

        for (int i = 0; i < goBlocks.Length * 2; i += 2)
        {
            position[i] = goBlocks[i / 2].transform.position.x;
            position[i + 1] = goBlocks[i / 2].transform.position.z;
        }

        //Goals
        GameObject[] goGoals = GameObject.FindGameObjectsWithTag("Goal");

        goalsPosition = new float[goGoals.Length * 2];

        for (int i = 0; i < goGoals.Length * 2; i += 2)
        {
            goalsPosition[i] = goGoals[i / 2].transform.position.x;
            goalsPosition[i + 1] = goGoals[i / 2].transform.position.z;
        }

        //Blue Laser
        GameObject[] goBlueLaser = GameObject.FindGameObjectsWithTag("BlueLaser");

        blueLaser = new float[goBlueLaser.Length * 4];

        for (int i = 0; i < goBlueLaser.Length * 4; i += 4)
        {
            blueLaser[i] = goBlueLaser[i / 4].transform.position.x;
            blueLaser[i + 1] = goBlueLaser[i / 4].transform.position.z;
            blueLaser[i + 2] = goBlueLaser[i / 4].transform.rotation.eulerAngles.y;
            blueLaser[i + 3] = goBlueLaser[i / 4].transform.localScale.x;
        }

        //Red Laser
        GameObject[] goRedLaser = GameObject.FindGameObjectsWithTag("RedLaser");

        redLaser = new float[goRedLaser.Length * 4];

        for (int i = 0; i < goRedLaser.Length * 4; i += 4)
        {
            redLaser[i] = goRedLaser[i / 4].transform.position.x;
            redLaser[i + 1] = goRedLaser[i / 4].transform.position.z;
            redLaser[i + 2] = goRedLaser[i / 4].transform.rotation.eulerAngles.y;
            redLaser[i + 3] = goRedLaser[i / 4].transform.localScale.x;
        }
    }

    private void NoPlayerFound()
    {
        Debug.Log("Kein Spieler gesetzt");
    }
}
