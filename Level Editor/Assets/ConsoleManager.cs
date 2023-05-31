using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    [SerializeField] float fResetTime;

    private TMP_Text text;

    private float fCurrenTime;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fCurrenTime > 0)
        {
            fCurrenTime -= Time.deltaTime;
        }
        else
        {
            text.text = "";
        }
    }

    public void SetConsole(string s)
    {
        fCurrenTime = fResetTime;

        text.text = s;
    }
}
