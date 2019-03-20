using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private bool isReady = false;

    [SerializeField]
    private float coolDownTime = 2.5f;
    [SerializeField]
    protected Transform instantiationPointDown;
    [SerializeField]
    protected Transform instantiationPointUp;

    // Start is called before the first frame update
    void Start()
    {
        if (instantiationPointDown == null)
            instantiationPointDown = this.transform;
        if (instantiationPointUp == null)
            instantiationPointUp = this.transform;

        StartCoroutine(CoolDownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToInstantiate != null && isReady)
        {
            //instantiate the object
            isReady = false;
            Instantiate(objectToInstantiate, GetPositionForFireBall(), Quaternion.identity);
            StartCoroutine(CoolDownRoutine());
        }
    }

    public virtual Vector3 GetPositionForFireBall()
    {
        Vector3 position;
        if (this.transform.localScale.y > 0)
            position = instantiationPointDown.position;
        else
            position = instantiationPointUp.position;
        return position;
    }

    IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(coolDownTime);
        isReady = true;
    }
}
