using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank: MonoBehaviour
{
    public GameObject objectToInstantiate;

    private bool isReady = false;

    private float coolDownTime;
    [SerializeField]
    protected Transform instantiationPoint;

    // Start is called before the first frame update
    void Start()
    {
        coolDownTime = Random.Range(1.75f, 3.0f);
        StartCoroutine(CoolDownRoutine(0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToInstantiate != null && isReady)
        {
            //instantiate the object
            isReady = false;
            Instantiate(objectToInstantiate, GetPositionForFireBall(), Quaternion.identity);
            StartCoroutine(CoolDownRoutine(coolDownTime));
        }
    }

    public virtual Vector3 GetPositionForFireBall()
    {
            return new Vector2(this.transform.position.x - 0.6f, instantiationPoint.position.y);
    }

    IEnumerator CoolDownRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        isReady = true;
    }
}
