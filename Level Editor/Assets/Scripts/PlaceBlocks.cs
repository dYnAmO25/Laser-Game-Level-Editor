using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceBlocks : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    
    [SerializeField] GameObject[] goGhostBlocks;
    [SerializeField] GameObject[] goBlocks;
    [SerializeField] Vector3 v3AFK;
    
    float fY = 0.25f;
    float fConstant = 1000;

    private float fRoation;
    private float fSize = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (dropdown.value)
        {
            case 0:
                PlaceBlock();
                break;
            case 1:
                PlacePlayer();
                break;
            case 2:
                PlaceLaser();
                break;
            case 3:
                PlaceLaser();
                break;
            case 4:
                PlaceGoal();
                break;
        }
    }

    private void PlaceBlock()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                int iX = (int)(hit.point.x + fConstant);
                int iZ = (int)(hit.point.z + fConstant);

                Vector3 v3 = new Vector3();
                v3 = new Vector3(iX + 0.5f - fConstant, fY, iZ + 0.5f - fConstant);

                goGhostBlocks[dropdown.value].transform.position = v3;

                if (Input.GetKey(KeyCode.E))
                {
                    Instantiate(goBlocks[dropdown.value], v3, Quaternion.identity);
                }

            }
            else
            {
                goGhostBlocks[dropdown.value].transform.position = v3AFK;

                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (hit.collider.tag != "Ground")
                    {
                        Destroy(hit.collider.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            goGhostBlocks[dropdown.value].transform.position = v3AFK;
        }
    }

    private void PlacePlayer()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                float fX = Mathf.Round(hit.point.x / 0.25f) * 0.25f;
                float fZ = Mathf.Round(hit.point.z / 0.25f) * 0.25f;

                Vector3 v3 = new Vector3();
                v3 = new Vector3(fX, fY, fZ);

                goGhostBlocks[dropdown.value].transform.position = v3;

                if (Input.GetKey(KeyCode.E))
                {
                    Collider[] cols = Physics.OverlapSphere(v3, 0.1f);


                    if (cols.Length == 0)
                    {
                        GameObject goTestForPlayer = GameObject.FindGameObjectWithTag("Player");
                        
                        if (goTestForPlayer == null)
                        {
                            Instantiate(goBlocks[dropdown.value], v3, Quaternion.identity);
                        }
                        else
                        {
                            Destroy(goTestForPlayer);
                            Instantiate(goBlocks[dropdown.value], v3, Quaternion.identity);
                        }
                    }

                }

            }
            else
            {
                goGhostBlocks[dropdown.value].transform.position = v3AFK;

                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (hit.collider.tag != "Ground")
                    {
                        Destroy(hit.collider.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            goGhostBlocks[dropdown.value].transform.position = v3AFK;
        }
    }

    private void PlaceGoal()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                int iX = (int)(hit.point.x + fConstant);
                int iZ = (int)(hit.point.z + fConstant);

                Vector3 v3 = new Vector3();
                v3 = new Vector3(iX - fConstant, fY, iZ - fConstant);

                goGhostBlocks[dropdown.value].transform.position = v3;

                if (Input.GetKey(KeyCode.E))
                {
                    Instantiate(goBlocks[dropdown.value], v3, Quaternion.identity);
                }

            }
            else
            {
                goGhostBlocks[dropdown.value].transform.position = v3AFK;

                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (hit.collider.tag != "Ground")
                    {
                        Destroy(hit.collider.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            goGhostBlocks[dropdown.value].transform.position = v3AFK;
        }
    }

    private void PlaceLaser()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                float fX = Mathf.Round(hit.point.x / 0.25f) * 0.25f;
                float fZ = Mathf.Round(hit.point.z / 0.25f) * 0.25f;

                Vector3 v3 = new Vector3();
                v3 = new Vector3(fX, fY, fZ);

                fRoation = GetRotation(fRoation);
                fSize = GetSize(fSize);

                goGhostBlocks[dropdown.value].transform.position = v3;
                goGhostBlocks[dropdown.value].transform.rotation = Quaternion.Euler(new Vector3(0, fRoation, 0));
                goGhostBlocks[dropdown.value].transform.localScale = new Vector3(fSize, 0.5f, 0.5f);

                if (Input.GetKey(KeyCode.E))
                {
                    Collider[] cols = Physics.OverlapSphere(v3, 0.1f);


                    if (cols.Length == 0)
                    {
                        GameObject goLaser = Instantiate(goBlocks[dropdown.value], v3, Quaternion.Euler(new Vector3(0, fRoation, 0)));
                        goLaser.transform.localScale = new Vector3(fSize, 0.5f, 0.5f);
                    }

                }

            }
            else
            {
                goGhostBlocks[dropdown.value].transform.position = v3AFK;

                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (hit.collider.tag != "Ground")
                    {
                        Destroy(hit.collider.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            goGhostBlocks[dropdown.value].transform.position = v3AFK;
        }
    }

    private float GetRotation(float fCurrentRotation)
    {
        if (Input.mouseScrollDelta.y > 0f)
        {
            return (fCurrentRotation + 45);
        }
        else if (Input.mouseScrollDelta.y < 0f)
        {
            return (fCurrentRotation - 45);
        }
        else
        {
            return fCurrentRotation;
        }
    }

    private float GetSize(float fCurrentSize)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return 9;
        }
        else
        {
            return fCurrentSize;
        }
    }
}