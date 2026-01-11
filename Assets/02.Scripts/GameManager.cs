using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ArrowGenerator;
    public GameObject RestartButton;
    public GameObject Player;
    public Text ui;
    public Image healthUI;
    private static int hpMax = 5;
    private int hp = hpMax;
    private float hpPrev = hpMax;
    public bool play = true;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
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
        ui.text = score + "";
        healthUI.fillAmount = hpPrev / hpMax;

        if (hp <= 0)
        {
            play = false;
            ArrowGenerator.GetComponent<GeneratorScript>().play = false;
            Player.GetComponent<PlayerControl>().play = false;
            RestartButton.SetActive(true);
        }
    }

    public void Hit() { hp--; }
    public void Scored() { if (play) { score++; } }

    public void Retry() { SceneManager.LoadScene("GameScene"); }
}
