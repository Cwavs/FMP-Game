using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private TMP_Text scoreText;
    private Text ammoTxt;
    private Image ammoType;

    // Start is called before the first frame update
    void Start()
    {
        ammoTxt = GameObject.FindGameObjectWithTag("Ammo Count").GetComponent<Text>();
        ammoType = GameObject.FindGameObjectWithTag("Ammo Type").GetComponent<Image>();
        scoreText = GameObject.FindGameObjectWithTag("Score Text").GetComponent<TMP_Text>();
        ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAmmoType(gameController.BulletType currentAmmoType)
    {
        switch (currentAmmoType)
        {
            default:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case gameController.BulletType.Normal:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet");
                    break;
                }
            case gameController.BulletType.Shock:
                {
                    ammoType.sprite = Resources.Load<Sprite>("Bullet Types/Bullet Shock");
                    break;
                }
            case gameController.BulletType.Wall:
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

    public void updateScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
