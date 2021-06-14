using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private const int MAX_VALUE = 100;

    private float powerDropRate = 1f;
    
    private bool isGameOver = false;
    public GameObject gameOverScreen;
    public GameObject nextLevelScreen;

    public int coffeeHP = 100;
    public int coffePower = 50;

    public Slider HPBar;
    public Slider PowerBar;
    public GameObject heroChar;

    [SerializeField]
    private int damageTaken = 20;

    [SerializeField]
    private int powerIncrease = 10;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        SetBars(MAX_VALUE);
        UpdateBars();
        LevelManager.levelManager.SpawnTeaCups();
    }

    // Update is called once per frame
    void Update()
    {
        if ((isGameOver) && (Input.GetButtonDown("Fire1")))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void SetBars(int value)
    {
        HPBar.maxValue = value;
        PowerBar.maxValue = value;
    }

    public void DecreaseHP()
    {
        coffeeHP -= damageTaken;

        if (coffeeHP <= 0)
        {
            GameOver();
        }

        UpdateBars();

    }

    private void UpdateBars()
    {
        HPBar.value = coffeeHP;
        PowerBar.value = coffePower;
    }

    private void GameOver()
    {
        isGameOver = true;
        heroChar.SetActive(false);
        gameOverScreen.SetActive(true);
        LevelManager.levelManager.ResetLevelManager();


    }

    public void IncreasePower()
    {
        coffePower += powerIncrease;

        if (coffePower >= MAX_VALUE)
        {
            GameWin();
        }

        UpdateBars();

    }


    private void GameWin()
    {
        isGameOver = true;
        heroChar.SetActive(false);
        nextLevelScreen.SetActive(true);
        LevelManager.levelManager.numberOfTeaCups += 2;
    }

}
