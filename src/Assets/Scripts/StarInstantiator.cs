using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInstantiator : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public Transform positionUp;
    public Transform positionDown;

    private bool isReady = false;
    private bool levelUp = true;

    [SerializeField]
    private float coolDownTime = 7.5f;
    [SerializeField]
    private float startTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToInstantiate != null && isReady)
        {
            //instantiate the object
            isReady = false;
            float R = Random.Range(0.0f, 1.0f);
            if (R < 0.5)
                Instantiate(objectToInstantiate, positionUp.position, Quaternion.identity);
            else
                Instantiate(objectToInstantiate, positionDown.position, Quaternion.identity);

            StartCoroutine(CoolDownRoutine());
        }

        if (HighScore.GetScore() > 200 && HighScore.GetScore() < 750 && levelUp)
        {
            levelUp = false;
            coolDownTime = 6.0f;
        }

        if (HighScore.GetScore() > 750 && !levelUp)
        {
            levelUp = true;
            coolDownTime = 5.0f;
        }
    }

    IEnumerator CoolDownRoutine()
    {
        float r = Random.Range(0.0f, 3.0f);
        yield return new WaitForSeconds(coolDownTime+r);
        isReady = true;
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(startTime);
        isReady = true;
    }
}
