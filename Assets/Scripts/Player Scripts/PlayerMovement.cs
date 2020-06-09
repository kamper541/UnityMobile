using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;
    private float smoothMovement = 15f;

    private Vector3 targetForward;
    private bool canMove;
    private Vector3 dPos;
    private Camera mainCam;

    private static bool finish = true;

    private float unit = 3f;
    //private float walk = 1f

    public static bool getFinish(){
        return finish;
    }
    void Awake(){
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;

        mainCam = Camera.main;
    }

    //Update is called once per frame
    // void Update()
    // {
    //     //UpdateForward();
    //     //GetInput();
    //     if(RunBlock.getRunning() == true){
    //     StartCoroutine(MovePlayer());
    //     }
    //     else if(RunBlock.getRotating() == true){
    //     StartCoroutine(RotatePlayer());
    //     }
    // }

    void FixedUpdate() {
        // if(RunBlock.getRunning()){
        // Debug.Log("inside Move");
        // MovePlayer();
        // }
        //MovePlayer();
        if(RunBlock.getRunning() == true){
        StartCoroutine(MovePlayer());
        }
        else if(RunBlock.getRotating() == true){
        StartCoroutine(RotatePlayer());
        }
        
    }
    void GetInput(){
        if(Input.GetMouseButtonDown(0)){
            canMove = true;
            finish = false;
        }else if (Input.GetMouseButtonUp(0)){
            canMove = false;
            finish = true;
        }
    }

    void UpdateForward(){
        transform.forward = Vector3.Slerp(
            transform.forward, targetForward, Time.deltaTime * smoothMovement
        );
    }
    public IEnumerator MovePlayer(){
        //Debug.Log("Moving");
            //dPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X), 0f, Input.GetAxisRaw(Axis.MOUSE_Y));
            // dPos.Normalize();

            // dPos *= moveSpeed * Time.fixedDeltaTime;
            // dPos = Quaternion.Euler(0f, mainCam.transform.eulerAngles.y, 0f) * dPos;
            // rb.MovePosition(rb.position + dPos);

            // if(dPos != Vector3.zero){
            //     targetForward = Vector3.ProjectOnPlane(-dPos, Vector3.up);
            // }
             float elapsedTime = 0.0f;
            // Vector3 startingPos = this.transform.position;
            // Vector3 endPos = startingPos;
            // endPos.z = this.transform.position.z - 5.0f;
            // while(elapsedTime < 3.0){
                
            //     this.transform.position = Vector3.Lerp(startingPos , endPos , (elapsedTime/3.0f));
            //     elapsedTime += Time.deltaTime;
            //     yield return new WaitForEndOfFrame();
            // } 
            // this.transform.position = endPos;
            
            
            //transform.Translate( 0.0f ,0.0f,-13.0f);
            if(RunBlock.getRunning() == true){
            transform.Translate(Vector3.back * Time.deltaTime * 4.3f);
            yield return new WaitForSeconds(3f);
            }
            
            finish = true;
            RunBlock.setRunning();
        
        
        // finish = false;
        // transform.position += transform.forward * -unit;
        // finish = true;
        // RunBlock.setRunning();
        
    }


    public IEnumerator RotatePlayer(){
        //Debug.Log("Rotating");
        if(RunBlock.getRotating() == true){
        float tar = this.transform.rotation.y + 90.0f;
        Quaternion target = Quaternion.Euler(0.0f, tar, 0.0f);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target,  Time.deltaTime * 5.0f);
        yield return new WaitForFixedUpdate();
        }

        RunBlock.setRotating();
    }

}
