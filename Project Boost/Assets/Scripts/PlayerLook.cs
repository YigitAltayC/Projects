using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoSingleton<PlayerLook>
{

    private Transform[] _surfaces = new Transform[2];
    private Color[] _colors = new Color[2];
    
    private Transform _outerSurfaces;
    private Transform _innerSurfaces;

    private Color _outerColor = new Color();
    private Color _innerColor = new Color();
    
    private const string _outerColorHex = "#008FA1";
    private const string _innerColorHex = "#00FFE0";

    private int colorIndex = 0;
    
    
    private 
    // Start is called before the first frame update
    void Start()
    {
        _surfaces[0] = transform.GetChild(0);
        _surfaces[1] = transform.GetChild(1);
        
        ColorUtility.TryParseHtmlString(_outerColorHex, out _colors[0]);
        ColorUtility.TryParseHtmlString(_innerColorHex, out _colors[1]);

    }
    

    public void BrightenSurfaceColor()
    {
        foreach (Transform surface in _surfaces[colorIndex])
        {
            surface.GetComponent<MeshRenderer>().material.color = _colors[colorIndex];
        }

        colorIndex++;
        
        if (colorIndex >= _surfaces.Length)
            colorIndex = _surfaces.Length - 1;


    }

    public void DarkenSurfaceColor()
    {
        foreach (Transform surface in _surfaces[colorIndex])
        {
            surface.GetComponent<MeshRenderer>().material.color = Color.black;
        }

        colorIndex--;
        
        
        if (colorIndex <= 0)
            colorIndex = 0;
    }
}
