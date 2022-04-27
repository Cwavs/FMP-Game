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

    public enum BulletType
    {
        Normal,
        Shock,
        Wall
    }

    // Start is called before the first frame update
    void Start()
    {
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
