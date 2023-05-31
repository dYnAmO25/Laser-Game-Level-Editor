using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Vector3 v3Reset;
    [SerializeField] float fSpeed;

    public bool bMove = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bMove)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 v3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        v3 = v3 * Time.deltaTime * fSpeed;

        transform.position += v3;

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = v3Reset;
        }
    }
}
