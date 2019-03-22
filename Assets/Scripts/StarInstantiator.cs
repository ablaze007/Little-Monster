using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInstantiator : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private bool isReady = false;

    [SerializeField]
    private float coolDownTime = 11.0f;
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
