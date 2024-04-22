using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightSwitcher : MonoBehaviour
{
    public Material targetMaterial;
    
    private Color originalEmissionColor;
    
    // Start is called before the first frame update
    void Start()
    {
        //store the gems original emission color
        originalEmissionColor = targetMaterial.GetColor("_EmissionColor");
        
        //set the gems emission to black
        targetMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting == true)
        {
            //emit
            targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
        }
        else
        {
            //stop emitting
            targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }
}