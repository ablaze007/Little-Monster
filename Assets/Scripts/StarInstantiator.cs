using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInstantiator : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private bool isReady = false;
    private bool levelUp = true;

    [SerializeField]
    private float coolDownTime = 8.0f;
    [SerializeField]
    private float startTime = 0.0f;

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
            Instantiate(objectToInstantiate, this.transform.position, Quaternion.identity);
            StartCoroutine(CoolDownRoutine());
        }

        if (HighScore.GetScore() > 100 && HighScore.GetScore() < 300 && levelUp)
        {
            levelUp = false;
            coolDownTime = 9.5f;
        }

        if (HighScore.GetScore() > 300 && !levelUp)
        {
            levelUp = true;
            coolDownTime = 8.0f;
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
