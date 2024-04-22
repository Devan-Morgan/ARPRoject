using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTransparencySwitcher : MonoBehaviour
{
    public Material targetMaterial;
    
    private float originalAlpha;
    
    // Start is called before the first frame update
    void Start()
    {
        // Store the original alpha value of the material
        originalAlpha = targetMaterial.color.a;
    }

    public void ChangeTransparency(bool isVisible)
    {
        if (isVisible == true)
        {
            // Set alpha back to original, making material visible
            Color color = targetMaterial.color;
            color.a = originalAlpha;
            targetMaterial.color = color;
        }
        else
        {
            // Set alpha to 0 to make material fully transparent
            Color color = targetMaterial.color;
            color.a = 0;
            targetMaterial.color = color;
        }
    }
}