using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    //GetComponent blaster_bolt;
    float delay = 4.0f;

    void Start()
    {

        // GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        WaitAndDestroy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy (gameObject);
    }
}
