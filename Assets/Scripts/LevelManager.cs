using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public float beanCooldown;
    private float beanCooldownTimer = 0;

    public int numberOfTeaCups = 5;
    public float cupmoveSpeed = 1.8f;

    private int iniNumberOfTeaCups;

    public GameObject teaCup;
    public GameObject coffeeBean;

    // Start is called before the first frame update
    void Start()
    {
        if (levelManager == null)
        {
            levelManager = this;
            iniNumberOfTeaCups = numberOfTeaCups;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoffeeBean();

        
    }

    public void SpawnTeaCups()
    {
        for (int i = 0; i < numberOfTeaCups; i++)
        {
            Instantiate(teaCup);
        }
    }

    private void SpawnCoffeeBean()
    {
        if (beanCooldownTimer >= beanCooldown)
        {
            Instantiate(coffeeBean);
            beanCooldownTimer = 0;

        }
        else
        {
            beanCooldownTimer += Time.deltaTime;
        }
    }
    
    public void ResetLevelManager()
    {
        numberOfTeaCups = iniNumberOfTeaCups;
    }
}
