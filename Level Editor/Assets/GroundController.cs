using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputX;
    [SerializeField] TMP_InputField inputZ;
    
    private GameObject goGround;

    public void SetGround()
    {
        int iX, iZ;
        int.TryParse(inputX.text, out iX);
        int.TryParse(inputZ.text, out iZ);

        if (iX > 0 && iZ > 0 && iX < 256 && iZ < 256)
        {
            goGround = GameObject.FindGameObjectWithTag("Ground");

            Vector3 v3 = new Vector3(iX, 0.1f, iZ);
            goGround.transform.localScale = v3;
        }
    }
}
