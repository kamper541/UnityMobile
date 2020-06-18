using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public float moveSmoothing = 10f;
    public float rotationSmoothing = 15f;

    private Vector2 touchPosition;
    private float swipeResistance = 200.0f;

    private Transform target ;
    private Vector3 targetForward;

    private Vector3 offset;

    void Awake() {
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start(){
        targetForward = transform.forward;
        targetForward.y = 0f;
        //Snap();
    }

    // Update is called once per frame
    void Update(){
        if(RunBlock.getAct()){
        FollowPlayer();
        }else{
        //FreeHand();
        }

    }

    public void FreeHandR(){
        // if(Input.GetMouseButtonDown(0)){
        //     touchPosition = Input.mousePosition;
        // }
        // if(Input.GetMouseButtonUp(0)){
        //     float swipeForce = touchPosition.x - Input.mousePosition.x;
        //     if(Mathf.Abs(swipeForce) > swipeResistance){
        //         if(swipeForce < 0){
        //             SlideCamera(true);
        //         }else{
        //             SlideCamera(false);
        //         }
        //     }
        // }
        transform.Translate(targetForward * Time.deltaTime);
        
    }

    

    void Snap(){
        if(target != null){
            transform.position = target.position;

        }
        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    void FollowPlayer(){
        if(target != null){
            transform.position = 
                Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSmoothing);
        }

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = Vector3.Slerp(forward, forward, Time.deltaTime * rotationSmoothing);
        forward.y = transform.forward.y;
        transform.forward = forward;

    }
}
