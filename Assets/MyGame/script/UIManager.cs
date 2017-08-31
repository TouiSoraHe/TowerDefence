using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    //仅作为初始化时的数据保留
    private const int SCORE = 0;
    private const int MONEY = 600;
    private const int HEALTH = 10;
    public const int WAVE_COUNT = 20;

    public static UIManager instance;

    private int _score;
    private int _money;
    private int _health;
    private int _waveCount;

    public int Score {
        get { return _score; }
        set {
            _score = value;
            transform.Find("playing/score").GetComponent<Text>().text = "分数:" + _score;
        }
    }
    public int Money
    {
        get { return _money; }
        set
        {
            if (value >= 0)
            {
                _money = value;
                transform.Find("playing/money").GetComponent<Text>().text = "$" + _money;
            }
        }
    }
    public int Health {
        get { return _health; }
        set {
            if (value >= 0)
            {
                _health = value;
                transform.Find("playing/health").GetComponent<Text>().text = "生命:" + _health;
                if (value == 0)
                {
                    gameOver();
                }
            }
        }
    }
    public int WaveCount {
        get { return _waveCount; }
        set {
            if (value >= 0)
            {
                _waveCount = value;
                transform.Find("playing/waveCount").GetComponent<Text>().text = "还剩下:" + _waveCount + "波怪物";
            }
        }
    }

    static UIManager()
    {
        GameObject go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Canvas"));
        DontDestroyOnLoad(go);
        instance = go.AddComponent<UIManager>();
    }

    private void init()
    {
        Score = SCORE;
        Money = MONEY;
        Health = HEALTH;
        WaveCount = WAVE_COUNT;
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);

        transform.Find("startPanel").gameObject.SetActive(true);
        transform.Find("select").gameObject.SetActive(false);
        transform.Find("playing").gameObject.SetActive(false);
        transform.Find("gameOver").gameObject.SetActive(false);

        transform.Find("startPanel/startBtn").GetComponent<Button>().onClick.AddListener(startGame);
        transform.Find("startPanel/gameOverBtn").GetComponent<Button>().onClick.AddListener(endGame);

        transform.Find("select/backBtn").GetComponent<Button>().onClick.AddListener(back);
        transform.Find("select/map1Btn").GetComponent<Button>().onClick.AddListener(map1Btn);

        transform.Find("playing/weapon/Tow_Acid1").GetComponent<Button>().onClick.AddListener(selectTow_Acid1);
        transform.Find("playing/weapon/Tow_Cannon1").GetComponent<Button>().onClick.AddListener(selectTow_Cannon1);
        transform.Find("playing/weapon/Tow_Crossbow1").GetComponent<Button>().onClick.AddListener(selectTow_Crossbow1);
        transform.Find("playing/weapon/Tow_Fire1").GetComponent<Button>().onClick.AddListener(selectTow_Fire1);
        transform.Find("playing/weapon/Tow_Gatling1").GetComponent<Button>().onClick.AddListener(selectTow_Gatling1);

        transform.Find("gameOver/Panel/again").GetComponent<Button>().onClick.AddListener(againGame);
        transform.Find("gameOver/Panel/back").GetComponent<Button>().onClick.AddListener(backMainScene);


    }

    private void backMainScene()
    {
        SceneManager.LoadScene(0);
        transform.Find("gameOver").gameObject.SetActive(false);
        transform.Find("startPanel").gameObject.SetActive(true);
    }

    private void againGame()
    {
        init();
        transform.Find("gameOver").gameObject.SetActive(false);
        transform.Find("playing").gameObject.SetActive(true);
        SceneManager.LoadScene(1);
    }

    private void selectTow_Gatling1()
    {
        BuildWeapon.instance.weaponIndex = 4;
    }

    private void selectTow_Fire1()
    {
        BuildWeapon.instance.weaponIndex = 3;
    }

    private void selectTow_Crossbow1()
    {
        BuildWeapon.instance.weaponIndex = 2;
    }

    private void selectTow_Cannon1()
    {
        BuildWeapon.instance.weaponIndex = 1;
    }

    private void selectTow_Acid1()
    {
        BuildWeapon.instance.weaponIndex = 0;
    }

    private void map1Btn()
    {
        init();
        transform.Find("select").gameObject.SetActive(false);
        transform.Find("playing").gameObject.SetActive(true);
        SceneManager.LoadScene(1);
    }

    private void back()
    {
        transform.Find("startPanel").gameObject.SetActive(true);
        transform.Find("select").gameObject.SetActive(false);
    }

    private void endGame()
    {
        Application.Quit();
    }

    private void startGame()
    {
        transform.Find("select").gameObject.SetActive(true);
        transform.Find("startPanel").gameObject.SetActive(false);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        transform.Find("gameOver").gameObject.SetActive(true);
        transform.Find("gameOver/Panel/score").GetComponent<Text>().text = Score.ToString();
        if (_health != 0)
        {
            transform.Find("gameOver/Panel/title").GetComponent<Text>().text = "恭喜通关";
        }
        transform.Find("playing").gameObject.SetActive(false);
    }
}
