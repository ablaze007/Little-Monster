using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiator: MonoBehaviour
{
    private float timer;

    private float blockTimer1 = 0.75f;
    private float blockTimer2 = 0.25f;
    private float blockTimer3 = 0.05f;

    public GameObject blockGreen;
    public GameObject blockRed;
    public GameObject tank;
    public GameObject tank2;

    public Transform blockGreen1Transform;
    public Transform blockGreen2Transform;
    public Transform blockGreen3Transform;
    public Transform blockRed1Transform;
    public Transform blockRed2Transform;
    public Transform blockRed3Transform;

    private float minimumCoolDownTime = 0.575f;
    private float tankSpawnWaitTime = 7.5f;
    private int tankTime = 20;

    private bool pauseGreen = false;
    private bool pauseRed = false;
    private bool levelUp = true;
    private bool spawningTank = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartCoroutine(InstantiatorRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Timer - " + (int)timer);

        if(((int)timer)!= 0 && ((int)timer)%tankTime == 0 && !spawningTank)
        {
            spawningTank = true;
            StartCoroutine(TankInstantiateRoutine());
        }

        if(HighScore.GetScore() > 200 && HighScore.GetScore() < 750 && levelUp)
        {
            levelUp = false;
            blockTimer1 = 0.85f;
            blockTimer2 = 0.48f;
            blockTimer2 = 0.12f;
        }

        if(HighScore.GetScore() > 750 && !levelUp)
        {
            levelUp = true;
            blockTimer1 = 0.90f;
            blockTimer2 = 0.55f;
            blockTimer3 = 0.25f;
        }
    }

    private void instantiateBlocks(int option) //option: 1-green, 2-red
    {
        float R = Random.Range(0.0f, 1.0f);
        if (option == 1)
        {
            if (R < blockTimer1)
                Instantiate(blockGreen, blockGreen1Transform.position, Quaternion.identity);
            if (R < blockTimer2)
                Instantiate(blockGreen, blockGreen2Transform.position, Quaternion.identity);
            if (R < blockTimer3)
                Instantiate(blockGreen, blockGreen3Transform.position, Quaternion.identity);
        }
        else if(option == 2)
        {
            if (R < blockTimer1)
                Instantiate(blockRed, blockRed1Transform.position, Quaternion.identity);
            if (R < blockTimer2)
                Instantiate(blockRed, blockRed2Transform.position, Quaternion.identity);
            if (R < blockTimer3)
                Instantiate(blockRed, blockRed3Transform.position, Quaternion.identity);
        }
    }

    IEnumerator InstantiatorRoutine()
    {
        yield return new WaitForSeconds(minimumCoolDownTime);

        if(!pauseGreen)
            instantiateBlocks(1);
        if(!pauseRed)
            instantiateBlocks(2);

        StartCoroutine(InstantiatorRoutine());
    }

    IEnumerator TankInstantiateRoutine()
    {
        float R = Random.Range(0.0f, 1.0f);
        if (R < 0.5)
            pauseGreen = true;
        if (R >= 0.5)
            pauseRed = true;
        
        yield return new WaitForSeconds(tankSpawnWaitTime);
        if (R < 0.5)
        {
            Instantiate(tank2);
        }
        if (R >= 0.50)
        {
            Instantiate(tank);
        }

        yield return new WaitForSeconds(3.5f);
        spawningTank = false;
        pauseGreen = false;
        pauseRed = false;
    }
}
