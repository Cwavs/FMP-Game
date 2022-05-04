using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class characterController : MonoBehaviour
{
    public ammoController ammController;
    private Camera cam;
    private GameObject Sway;
    private GameObject Aim;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponent<Camera>();
        Sway = GameObject.Find("Sway");
        Aim = GameObject.Find("Aim");
        Aim.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammController.reload();
        }

        if (Input.GetMouseButtonDown(0) && ammController.ammoCheck())
        {
            print("Shoot");
            ammController.decreaseAmmo();
            RaycastHit hit;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
            {
                print("Hit");
                Transform objectHit = hit.transform;

                objectHit.GetComponent<Ai>().OnHit();
            }
        }else if (!ammController.ammoCheck())
        {
            ammController.reload();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            ammController.increaseAmmoType();
        }else if(Input.GetKeyDown(KeyCode.X))
        {
            ammController.decreaseAmmoType();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sway.SetActive(false);
            Aim.SetActive(true);
            CinemachinePOV swayPOV = Sway.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
            CinemachinePOV aimPOV = Aim.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
            x = swayPOV.m_HorizontalAxis.Value;
            y = swayPOV.m_VerticalAxis.Value;
            aimPOV.m_HorizontalAxis.Value = x;
            aimPOV.m_VerticalAxis.Value = y;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Sway.SetActive(true);
            Aim.SetActive(false);
            CinemachinePOV swayPOV = Sway.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
            CinemachinePOV aimPOV = Aim.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
            x = aimPOV.m_HorizontalAxis.Value;
            y = aimPOV.m_VerticalAxis.Value;
            swayPOV.m_HorizontalAxis.Value = x;
            swayPOV.m_VerticalAxis.Value = y;
        }
    }
}
