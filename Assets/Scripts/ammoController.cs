using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour
{

    private int ammoCount;
    private int normalAmmoCount;
    private int shockAmmoCount;
    private int wallAmmoCount;
    private BulletType currentAmmoType;

    public UIController interfaceController;

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
        shockAmmoCount = 10;
        wallAmmoCount = 10;
        normalAmmoCount = 10;
        currentAmmoType = ammoController.BulletType.Normal;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void decreaseAmmo()
    {
        ammoCount--;
        updateAmmoCounterUI();
    }

    public void decreaseAmmoType()
    {
        BulletType newAmmoType = currentAmmoType;
        newAmmoType--;
        newAmmoType = clampBullet(newAmmoType, 0, 2);
        switchAmmoCount(newAmmoType);
        currentAmmoType = newAmmoType;
        //print(newAmmoType);
        //print(currentAmmoType);
        updateAmmoTypeUI();
    }

    public void increaseAmmoType()
    {
        BulletType newAmmoType = currentAmmoType;
        newAmmoType++;
        newAmmoType = clampBullet(newAmmoType, 0, 2);
        switchAmmoCount(newAmmoType);
        currentAmmoType = newAmmoType;
        //print(newAmmoType);
        //print(currentAmmoType);
        updateAmmoTypeUI();
    }

    public void reload()
    {
        ammoCount = 10;
    }

    private void switchAmmoCount(BulletType newAmmoType)
    {
        switch (currentAmmoType)
        {
            default:
                {
                    print("Unknown ammo type provided");
                    //print("new " + currentAmmoType);
                    break;
                }
            case ammoController.BulletType.Normal:
                {
                    normalAmmoCount = ammoCount;
                    print("norm " + normalAmmoCount);
                    break;
                }
            case ammoController.BulletType.Shock:
                {
                    shockAmmoCount = ammoCount;
                    print("shock " + shockAmmoCount);
                    break;
                }
            case ammoController.BulletType.Wall:
                {
                    wallAmmoCount = ammoCount;
                    print("wall " + wallAmmoCount);
                    break;
                }
        }
        switch (newAmmoType)
        {
            default:
                {
                    print("Unknown ammo type provided");
                    //print("cur " + newAmmoType);
                    break;
                }
            case ammoController.BulletType.Normal:
                {
                    ammoCount = normalAmmoCount;
                    print("norm1 " + normalAmmoCount);
                    break;
                }
            case ammoController.BulletType.Shock:
                {
                    ammoCount = shockAmmoCount;
                    print("shock1 " + shockAmmoCount);
                    break;
                }
            case ammoController.BulletType.Wall:
                {
                    ammoCount = wallAmmoCount;
                    print("wall1 " + wallAmmoCount);
                    break;
                }
        }
        updateAmmoCounterUI();
    }

    private void updateAmmoCounterUI()
    {
        interfaceController.updateAmmoCount(ammoCount);
    }

    private void updateAmmoTypeUI()
    {
        interfaceController.updateAmmoType(currentAmmoType);
    }

    public static BulletType clampBullet(BulletType clamp, int minValue, int maxValue)
    {
        BulletType clamped = (BulletType)Mathf.Clamp((int)clamp, minValue, maxValue);

        return clamped;
    }

    public bool ammoCheck()
    {
        if(ammoCount < 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}