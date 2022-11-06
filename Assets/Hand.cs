using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public GameObject lightSaber;

    Vector2 direction; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lightSaber.transform.up = Vector2.Lerp(lightSaber.transform.up, -direction, Time.deltaTime * 10); ;

    }

    public void onInputString(string s)
    {
        if (s.Length > 5)
        {
            string str = s.Substring(1, s.Length - 1);
            string[] splitArray = str.Split(char.Parse(","));

            float x1, y1, x2, y2;

            float.TryParse(splitArray[0], out x1);
            float.TryParse(splitArray[1], out y1);
            float.TryParse(splitArray[3], out x2);
            float.TryParse(splitArray[4], out y2);

            rotate(new Vector2(x2-x1, y1-y2));

        }




    }

    void rotate(Vector2 pt1)
    {
        direction = pt1.normalized;
    }
}
