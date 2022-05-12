using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class characterController : MonoBehaviour
{
    public gameController ammController;
    private Camera cam;
    private GameObject Sway;
    private GameObject Aim;
    private float x;
    private float y;
    private Material heatVisMterialVis;
    private Material heatVisMterialInvis;
    private float holdBreath;
    private bool holdingBreath;
    private bool noShoot;

    private float scroll;

    private bool oldHoldingBreath;

    public float holdBreathLength;

    // Start is called before the first frame update
    void Start()
    {
        holdBreath = holdBreathLength;
        holdingBreath = true;

        scroll = 40;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponent<Camera>();
        Sway = GameObject.Find("Sway");
        Aim = GameObject.Find("Aim");
        Aim.SetActive(false);

        heatVisMterialInvis = Resources.Load<Material>("Materials/Heat Vision Invis");
        heatVisMterialVis = Resources.Load<Material>("Materials/Heat Vision Vis");
    }

    private void Update()
    {
        scroll = (Input.mouseScrollDelta.y * -1) + scroll;

        cam.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Clamp(scroll, 20, 90);

        holdBreath = Mathf.Clamp(holdBreath, 0, holdBreathLength);

        if(Input.GetKeyDown(KeyCode.R))
        {
            ammController.reload();
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject.FindGameObjectsWithTag("Enemy");
        }

        if (Input.GetMouseButtonDown(0) && ammController.ammoCheck() && !noShoot)
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
            holdingBreath = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            holdingBreath = false;
        }

        print(holdingBreath);

        if(holdBreath <= 0)
        {
            holdingBreath = false;
        }

        if (holdingBreath != oldHoldingBreath)
        {
            if (holdingBreath)
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
            else
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
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            heatVisMterialInvis.SetFloat("Boolean_4838d837782b40e4b8a46df9670667b7", 1.0f);
            heatVisMterialVis.SetFloat("Boolean_4838d837782b40e4b8a46df9670667b7", 1.0f);
            noShoot = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            heatVisMterialInvis.SetFloat("Boolean_4838d837782b40e4b8a46df9670667b7", 0.0f);
            heatVisMterialVis.SetFloat("Boolean_4838d837782b40e4b8a46df9670667b7", 0.0f);
            noShoot = false;
        }

        oldHoldingBreath = holdingBreath;

        print(holdBreath);

        
    }

    void FixedUpdate()
    {
        if (holdingBreath)
        {
            holdBreath--;
        }
        else
        {
            holdBreath++;
        }
    }
}

public static class FloatExtensions
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}