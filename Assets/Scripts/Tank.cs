using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank: MonoBehaviour
{
    public GameObject objectToInstantiate;

    private bool isReady = false;

    private float coolDownTime;
    [SerializeField]
    protected Transform instantiationPointDown;
    [SerializeField]
    protected Transform instantiationPointUp;

    // Start is called before the first frame update
    void Start()
    {
        coolDownTime = Random.Range(1.75f, 3.25f);
        StartCoroutine(CoolDownRoutine(0.5f));
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
        Vector3 position;
        if (this.transform.localScale.y > 0)
            position = new Vector2(this.transform.position.x - 0.6f, instantiationPointDown.position.y);
        else
            position = new Vector2(this.transform.position.x - 0.6f, instantiationPointUp.position.y);
        return position;
    }

    IEnumerator CoolDownRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        isReady = true;
    }
}
