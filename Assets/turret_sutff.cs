using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_sutff : MonoBehaviour
{
    public bool firing = true;
    public GameObject anakin;       // bullets
    public GameObject turret_shoot; // turret itself
    int shotsFired = 0;
    Vector3 currentPosition;
    public Vector3 test = new Vector3(20.0f, 0.0f, 0.0f);
    public Vector3 start_bullet = new Vector3(0, 1, 0);

    public GameObject target;

    public GameObject saber;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.CreatePrimitive(PrimitiveType.Cube);
        // Instantiate(anakin);
  
            StartCoroutine(recurse());
            // StartCoroutine(turn_slowly());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getTurret()
    {
        return turret_shoot;
    }


    public void stopFiring()
    {
        firing = false;
    }

    IEnumerator recurse()
    {
        while(firing)
        {
            yield return new WaitForSeconds(3);
            shotsFired++;
            float offsetX = Random.Range(-10, 10);
            float offsetY = Random.Range(-10, 10);
            float offsetZ = Random.Range(80, 100);

            float randX = Random.Range(-2f, 2f);
            float randY = Random.Range(0.2f, 1f);
            float randZ = Random.Range(-1f, 1f);

            Debug.Log(randX * saber.transform.position.x);
            Debug.Log(saber.transform.position.x);

            

            target.transform.position = new Vector3(saber.transform.position.x + 0.5f * randX, saber.transform.position.y + 3f* randY, saber.transform.position.z + 0.5f* randZ);

            float forceY = offsetY / 2;
            float forcez = offsetZ / 9;

            Vector3 shoot = new Vector3(offsetX, offsetY, offsetZ);

            Vector3 position = new Vector3(
                turret_shoot.transform.position.x, 
                turret_shoot.transform.position.y, 
                turret_shoot.transform.position.z);
            
            // current position is the direction that it's pointing
            currentPosition = new Vector3(offsetX, offsetY, offsetZ);

            turret_shoot.transform.LookAt(target.transform);

            Vector3 vec = new Vector3(turret_shoot.transform.forward.x * randX, turret_shoot.transform.forward.y * randY, turret_shoot.transform.forward.z * randZ);


            
            //turret_shoot.transform.eulerAngles = currentPosition;
            //anakin.GetComponent<Rigidbody>().AddForce(currentPosition, ForceMode.Impulse);
            GameObject bull = Instantiate(anakin, turret_shoot.transform.position + turret_shoot.transform.forward * 3, Quaternion.identity);
            //bull.transform.eulerAngles = shoot;
            //bull.GetComponent<Rigidbody>().AddForce(bull.transform.forward * 50);

            bull.GetComponent<Rigidbody>().AddForce(turret_shoot.transform.forward * 50);
            
        }

    }
/*
    IEnumerator turn_slowly()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            float offsetX = Random.Range(-10, 10);
            float offsetY = Random.Range(-10, 10);
            float offsetZ = Random.Range(80, 100);
            // turret_shoot.transform.Rotate(23, 0, 0, Space.Self);
            currentPosition = new Vector3(offsetX, offsetY, offsetZ);
            turret_shoot.transform.eulerAngles = currentPosition;
            anakin.transform.eulerAngles = currentPosition;

            Bullet


        }

    }
    */

}
