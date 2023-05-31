using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGhosts : MonoBehaviour
{
    [SerializeField] GameObject[] gos;
    [SerializeField] Vector3 v3AFK;

    public void SetGhosts()
    {
        for (int i = 0; i < gos.Length; i++)
        {
            gos[i].transform.position = v3AFK;
        }
    }
}
