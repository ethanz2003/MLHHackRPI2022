using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    int playerHealth = 3;
    public turret_sutff thing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth == 0) {
            // GameObject = getTurret();
            thing.stopFiring();
            
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        playerHealth--;
        Debug.Log("Player health is: " + playerHealth);
    }
}
