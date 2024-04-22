using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] private Transform examineTarget;
    private Vector3 originalPosition;
    private Examinable currentExaminedObject;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private Transform originalParent;
    private bool isExamining = false;
    private bool ExamineMode = false;
    [SerializeField] private float rotateSpeed = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        print("ExaminableManager Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (isExamining == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    currentExaminedObject.transform.Rotate(touch.deltaPosition.x * rotateSpeed, touch.deltaPosition.y * rotateSpeed, 0);
                }
            }
        }
    }
    
    public void EnableExmamineMode()
    {
        ExamineMode = true;
    }
    
    public void DisableExamineMode()
    {
        ExamineMode = false;
    }

    public void PerformExamine(Examinable examinable)
    {
        if (ExamineMode == true && isExamining == false)
        {
            originalParent = examinable.transform.parent;
            
            examinable.DisableTranslation();
            
            //set current examined object
            currentExaminedObject = examinable;
            
            //debug logs
            Debug.Log("Object to be examined: " + currentExaminedObject.name);
            Debug.Log("Parent Position: " + currentExaminedObject.transform.parent.position);
            Debug.Log("Original World Position: " + currentExaminedObject.transform.position);
            Debug.Log("Original Local Position: " + currentExaminedObject.transform.localPosition);
            
            // Calculate the absolute world position by considering both local and parent's position
            Vector3 worldPosition = currentExaminedObject.transform.parent.position + currentExaminedObject.transform.localPosition;
            originalPosition = worldPosition; // Now this holds the true world position
            Debug.Log("Saved World Position: " + originalPosition);
            
            //save orignal rotation
            Quaternion worldRotation = currentExaminedObject.transform.parent.rotation * currentExaminedObject.transform.localRotation;
            originalRotation = worldRotation;

            //save original scale
            Vector3 worldScale = new Vector3(
                currentExaminedObject.transform.parent.lossyScale.x * currentExaminedObject.transform.localScale.x,
                currentExaminedObject.transform.parent.lossyScale.y * currentExaminedObject.transform.localScale.y,
                currentExaminedObject.transform.parent.lossyScale.z * currentExaminedObject.transform.localScale.z
            );
            originalScale = worldScale;


            //move to examine target
            currentExaminedObject.transform.position = examineTarget.position;
            currentExaminedObject.transform.parent = examineTarget;

            //set scale offset
            Vector3 offsetScale = originalScale * examinable.examineScaleOffset;
            currentExaminedObject.transform.localScale = offsetScale;

            //set examining to true
            isExamining = true;
            
            // Log after changes
            Debug.Log("New World Position: " + currentExaminedObject.transform.position);
            Debug.Log("New Local Position: " + currentExaminedObject.transform.localPosition);
        }
    }
    
    public void PerformUnexamine()
    {
        if (isExamining == true)
        {
            
            //move back to original position and rotation and scale
            currentExaminedObject.transform.SetParent(originalParent);
            currentExaminedObject.transform.position = originalPosition;
            currentExaminedObject.transform.rotation = originalRotation;
            currentExaminedObject.transform.localScale = originalScale;
            currentExaminedObject.EnableTranslation();
            currentExaminedObject = null;
            

            //set examining to false
            isExamining = false;
        }
    }
}
