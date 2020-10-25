using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColor : MonoBehaviour
{
    public Color lerpedColor;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(Color.magenta, Color.clear, Mathf.PingPong(Time.time, 2));
        rend.material.color = lerpedColor;
    }
}
