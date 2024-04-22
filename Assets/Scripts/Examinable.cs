using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Examinable : MonoBehaviour
{
    [SerializeField] private ExaminableManager examinablemanager;
    [SerializeField] public float examineScaleOffset = 1f;
    [SerializeField] public ARTranslationInteractable arTranslationInteractable;
    
    // Start is called before the first frame update
    void Start()
    {
        examinablemanager = FindObjectOfType<ExaminableManager>();
        //examinablemanager.AddExaminable(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableTranslation()
    {
        arTranslationInteractable.enabled = false;
    }

    public void EnableTranslation()
    {
        arTranslationInteractable.enabled = true;
    }
    
    public void RequestExamine()
    {
        examinablemanager.PerformExamine(this);
    }
    
    public void RequestUnexamine()
    {
        examinablemanager.PerformUnexamine();
    }
}
