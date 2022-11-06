using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class CV : MonoBehaviour
{
    WebCamTexture webCamText;

    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        webCamText = new WebCamTexture(devices[0].name);
        webCamText.Play();
        //cascade = new CascadeClassifier(Application.dataPath + @"haarcascade_frontalface_default.xml");
        cascade = new CascadeClassifier(System.IO.Path.Combine(Application.dataPath, "haarcascade_frontalface_default.xml"));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = webCamText;

        Mat frame = OpenCvSharp.Unity.TextureToMat(webCamText);
        findNewFace(frame);

        
    }

    void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
        }
    }
}
