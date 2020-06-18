using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 rotatingAngles;

    private Quaternion initialRotation;

    [SerializeField]
    private float smoothRotate = 1f;

    [SerializeField]
    private bool can_Rotate;

    private bool back_To_initial_Rotation;

    [SerializeField]
    private float deactivateTimer = 5f;

    void Awake() {
        initialRotation = transform.rotation;

    }


    // Update is called once per frame
    void Update()
    {
        RotatePlatform();
    }

    void RotatePlatform(){
        if(can_Rotate){
            transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(rotatingAngles.x , rotatingAngles.y, rotatingAngles.z),
            smoothRotate * Time.deltaTime);

        }
    }

    public void ActivateRotation(){
        if(!can_Rotate){
            can_Rotate = true;

            Invoke("DeactivateRotation", deactivateTimer);
        }
    }

    void DeactivateRotation(){
        can_Rotate = false;
    }
}
