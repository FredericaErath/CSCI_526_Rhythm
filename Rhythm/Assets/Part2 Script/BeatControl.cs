using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatControl : MonoBehaviour
{
    public GameObject circle;
    private float perfect = 0.5f;
    private float good = 1.0f;
    private float pass = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float GetAbs(float tar) 
    {
        if (tar <= 0) return -tar;
        else return tar;
    }

    int GetStatus(float distance)
    {
        if (distance <= perfect) return 0;
        else if (distance <= good) return 1;
        else if (distance <= pass) return 2;
        else return 3;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 10;
        if (gameObject.CompareTag("Single") && Input.GetButtonDown("Jump")){
            distance = GetAbs(transform.position.x - circle.transform.position.x);
            int status = GetStatus(distance);
            Debug.Log("Jump: " + status);
            if (status < 3) gameObject.SetActive(false);
        } else if (gameObject.CompareTag("Long") && Input.GetButtonDown("Fire1")){
            distance = GetAbs(transform.position.x - transform.localScale.x - circle.transform.position.x);
            Debug.Log("Begin shrink: " + GetStatus(distance));
        } else if (gameObject.CompareTag("Long") && Input.GetButtonUp("Fire1")) {
            distance = GetAbs(transform.position.x + transform.localScale.x - circle.transform.position.x);
            int status = GetStatus(distance);
            Debug.Log("After shrink: " + GetStatus(distance));
            if (status < 3) gameObject.SetActive(false);
        }

        
        
    }
}
