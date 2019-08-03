using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTo3dTarget : MonoBehaviour
{
    
    private Camera mainCam;

    private RectTransform rectT;
    private RectTransform canvas;

    public Vector3 offset;

    private Transform target;
    
    // Use this for initialization
    void Start ()
    {
        rectT = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        
    }

    private void Update()
    {
        if(target)
            Follow(target.position);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void Follow(Vector3 position)
    {
        float screenToCanvasKoef = canvas.rect.width / Screen.width;

        Vector3 pos2d = mainCam.WorldToScreenPoint(position);
        if(pos2d.z > 0)
        {
            Vector3 pos = pos2d;
            pos *= screenToCanvasKoef;
            pos += offset;
            
            rectT.anchoredPosition = pos;


            Vector3 p = rectT.position;
            p.z = pos2d.z;
            rectT.position = p;
        }
    }

    public void SetOffset(Vector3 offset)
    {
        this.offset = offset;
    }

}
