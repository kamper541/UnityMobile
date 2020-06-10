using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    Vector3 oldEulerAngles;

    float zPost;

    float angle;

    int framePerU;


    public static bool getFinish(){
        return finish;
    }

    private void Start() {
        this.transform.position = new Vector3(0 , 5 ,0);
        this.transform.rotation = new Quaternion(0 , 0 , 0 ,0);
        oldEulerAngles = this.transform.rotation.eulerAngles;
        zPost = this.transform.localPosition.z;
        angle = this.transform.rotation.y;
        framePerU = 0;
    }

    void Awake(){
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;

        mainCam = Camera.main;
    }


    //Update is called once per frame
        void Update()
        {
    //     //UpdateForward();
    //     //GetInput();
    //     if(RunBlock.getRunning() == true){
    //     StartCoroutine(MovePlayer());
    //     }
    //     else if(RunBlock.getRotating() == true){
    //     StartCoroutine(RotatePlayer());
    //     }\
        if(MenuScript.closing){
            RunBlock.setRunning();
            RunBlock.setRotating();
            RunBlock.setActivate();
        }
        if(this.transform.position.y < -5f){
            RunBlock.setRunning();
            RunBlock.setRotating();
            RunBlock.setActivate();
            SceneManager.LoadScene("GameOver");
        }
        }

    void FixedUpdate() {
        
        // if(oldEulerAngles == this.transform.rotation.eulerAngles){
        //     RunBlock.setRotating();
        // }
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        if(RunBlock.getRotating() == true){
        RotatePlayer(90.0f);
        }
        else if(RunBlock.getRunning() == true){
        MovePlayer(13.0f);
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
    public void MovePlayer(float ans){
            //dPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X), 0f, Input.GetAxisRaw(Axis.MOUSE_Y));
            // dPos.Normalize();

            // dPos *= moveSpeed * Time.fixedDeltaTime;
            // dPos = Quaternion.Euler(0f, mainCam.transform.eulerAngles.y, 0f) * dPos;
            // rb.MovePosition(rb.position + dPos);

            // if(dPos != Vector3.zero){
            //     targetForward = Vector3.ProjectOnPlane(-dPos, Vector3.up);
            // }
            //float elapsedTime = 0.0f;
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
            
            //if(RunBlock.getRunning() == true){
            if(framePerU == 132){
                RunBlock.setRunning();
                zPost = this.transform.localPosition.z;
                framePerU = 0;
            }else{
             transform.Translate(Vector3.back * Time.deltaTime * 5.0f);
             framePerU++;
             //transform.Translate(new Vector3(0 , 0 , -13.5f),Space.Self);
            // rb.position += Vector3.forward * Time.deltaTime * 5.0f;
            // Debug.Log("this is x" + this.transform.position.x);
            // Debug.Log("this is y" + this.transform.position.y);
            // Debug.Log("this is z" + this.transform.position.z);
            }

            //}
        // finish = false;
        // transform.position += transform.forward * -unit;
        // finish = true;
        // RunBlock.setRunning();
        
    }


    public void RotatePlayer(float ans){

        //Debug.Log("Rotating");
        
        if(this.transform.rotation.eulerAngles.y >= angle + ans){
            RunBlock.setRotating();
            angle = this.transform.rotation.eulerAngles.y;
        }else{
        // float tar = this.transform.rotation.y + ans;
        // Quaternion target = Quaternion.Euler(0.0f, tar, 0.0f);
        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target,  Time.deltaTime * 5.0f);
        // yield return new WaitForSeconds(2f);
        transform.Rotate(0 , 90 , 0);
        }
        Debug.Log(angle);
    }

}
