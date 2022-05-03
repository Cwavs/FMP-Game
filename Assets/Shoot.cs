using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public Text ammoTxt;
    public Image ammoType;
    private int ammoCount;
    private BulletType currentAmmoType;
    private GameObject hit;

    public enum BulletType
    {
        Normal,
        Shock,
        Wall
    }

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ammoCount = 10;
        ammoTxt = GameObject.FindGameObjectWithTag("Ammo Count").GetComponent<Text>();
        ammoType = GameObject.FindGameObjectWithTag("Ammo Type").GetComponent<Image>();
        currentAmmoType = BulletType.Normal;
        ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
    }


    // Update is called once per frame
    void Update()
    {
        currentAmmoType = clampBullet(currentAmmoType, 0, 2);
        ammoTxt.text = "Ammo: " + ammoCount;
        if (ammoCount == -1)
        {
            ammoCount = 10;
        }
        if (Input.GetMouseButtonDown(0) && ammoCount > -1)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            Debug.DrawRay(ray.origin, ray.direction);
            if(hitInfo.transform != null)
            {
                hit = hitInfo.transform.gameObject;
            }
            
            if(hit.tag == "Enemy")
            {
                Destroy(hit);
            }
            ammoCount--;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 10;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            currentAmmoType--;
            print(currentAmmoType);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            currentAmmoType++;
            print(currentAmmoType);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        switch (currentAmmoType)
        {
            default:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case BulletType.Normal:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case BulletType.Shock:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet Shock");
                    break;
                }
            case BulletType.Wall:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet Wall");
                    break;
                }
        }
    }

    public BulletType clampBullet(BulletType clamp, int maxValue, int minValue)
    {

        BulletType clamped = (BulletType)Mathf.Clamp(((int)clamp), maxValue, minValue);

        return clamped;
    }
}
