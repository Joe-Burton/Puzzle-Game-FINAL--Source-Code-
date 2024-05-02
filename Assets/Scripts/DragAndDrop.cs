using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 originalPostion;
    // Start is called before the first frame update
    void Start()
    {
        originalPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drag()
    {
        print("Dragging");
        //GameObject.Find("image").transform.position = Input.mousePosition;
        gameObject.transform.position = Input.mousePosition;

        //Original:
        //GameObject.Find("image").transform.position = Input.mousePosition;
        //print("Dragging" + gameObject.name);
    }

    public void Drop()
    {
        checkMatch();
        //GameObject ph1 = GameObject.Find("PH1");
        //GameObject img = GameObject.Find("image");
        //float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        //if (distance <= 50)
        //{
        //    img.transform.position = ph1.transform.position;
        //}
    }

    public void checkMatch()
    {
        //GameObject ph1 = GameObject.Find("PH1");
        //GameObject img = GameObject.Find("image");
        GameObject img = gameObject;
        string tag = gameObject.tag;
        GameObject ph1 = GameObject.Find("PH" +tag);
        float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        print("Distance" + distance);
        if (distance <= 50) snap(img, ph1);
        else moveBack();
    }

    public void moveBack()
    {
        transform.position = originalPostion;
    }

    public void snap(GameObject img, GameObject ph)
    {
        img.transform.position = ph.transform.position;
    }

    public void initCardPosition() 
    {
        originalPostion = transform.position; 
    }
}