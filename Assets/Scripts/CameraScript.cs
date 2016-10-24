using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Camera camera;

	// Use this for initialization
	void Start () {
	    camera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if ( isInputUnZoom() && this.camera.orthographicSize < 10)
        {
            unZoom();
        }
        else if (isInputZoom() && this.camera.orthographicSize > 1) 
        {
            zoom();
        }
	}

    public bool isInputZoom()
    {
        bool result = false;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            result = true;
        }
        return result;
    }

    public bool isInputUnZoom()
    {
        bool result = false;
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            result = true;
        }
        return result;
    } 

    public void zoom()
    {
        this.camera.orthographicSize--;
    }

    public void unZoom()
    {
        this.camera.orthographicSize++;
    }
}
