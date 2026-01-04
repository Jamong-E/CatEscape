using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ui;
    public Image healthUI;
    private static int hpMax = 5;
    private static int hp = hpMax;
    private float hpPrev = hp;
    private float prevChange = 0;
    private int frames = 0;
    private int spinTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (hpPrev > hp)
        {
            hpPrev = hpPrev - (hpPrev - hp) * 0.1f;
            if (hpPrev - hp < 0.02f) { hpPrev = hp; }
        }
        if (hpPrev < hp) { hpPrev = hp; }
        //
        ui.text = hp + "";
        healthUI.fillAmount = hpPrev / hpMax;
    }

    public void Hit() { hp--; }
}
