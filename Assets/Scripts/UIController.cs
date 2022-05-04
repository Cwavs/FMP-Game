using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text ammoTxt;
    public Image ammoType;

    // Start is called before the first frame update
    void Start()
    {
        ammoTxt = GameObject.FindGameObjectWithTag("Ammo Count").GetComponent<Text>();
        ammoType = GameObject.FindGameObjectWithTag("Ammo Type").GetComponent<Image>();
        ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAmmoType(ammoController.BulletType currentAmmoType)
    {
        switch (currentAmmoType)
        {
            default:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case ammoController.BulletType.Normal:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case ammoController.BulletType.Shock:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet Shock");
                    break;
                }
            case ammoController.BulletType.Wall:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet Wall");
                    break;
                }
        }
    }

    public void updateAmmoCount(int newAmmoCount)
    {
        ammoTxt.text = "Ammo: " + newAmmoCount;
    }
}
