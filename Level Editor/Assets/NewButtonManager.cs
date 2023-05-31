using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewButtonManager : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject goMainCam;

    private TMP_InputField input;

    void Start()
    {
        input = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.text == "")
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }


        if (input.isFocused)
        {
            goMainCam.GetComponent<CameraMove>().bMove = false;
        }
        else
        {
            goMainCam.GetComponent<CameraMove>().bMove = true;
        }
    }
}
