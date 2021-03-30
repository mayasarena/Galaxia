using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildMenu : MonoBehaviour
{
    public CanvasGroup buildMenu;
    public float startSize;
    public float endSize;
    public float zoomSpeed;
    public bool timeToLerpUp;
    public bool timeToLerpDown;
    public float t;

    void Start()
    {
        buildMenu.blocksRaycasts = false;
        buildMenu.alpha = 0;
        t = 0f;
    }

    void Update()
    {
        // Upon opening menu, zoom out camera
        if (timeToLerpUp)
        {
            if (t < 1)
            {
                t += Time.deltaTime * zoomSpeed;
                Camera.main.orthographicSize = Mathf.Lerp(startSize, endSize, t);
            }
            else
            {
                t = 0f;
                timeToLerpUp = false;
            }
        }

        // Upon closing menu, zoom back in
        if (timeToLerpDown)
        {
            if (t < 1)
            {
                t += Time.deltaTime * zoomSpeed;
                Camera.main.orthographicSize = Mathf.Lerp(endSize, startSize, t);
            }
            else
            {
                t = 0f;
                timeToLerpDown = false;
            }
        }
    }

    // Open build menu
    public void Build()
    {
        buildMenu.blocksRaycasts = true;
        buildMenu.alpha = 1;
        timeToLerpUp = true;
    }

    // Close build menu
    public void Close() {
        buildMenu.blocksRaycasts = false;
        buildMenu.alpha = 0;
        timeToLerpDown = true;
    }

}
