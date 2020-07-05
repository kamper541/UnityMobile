using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PMsave : MonoBehaviour
{
    [SerializeField]
    private float startX;
    [SerializeField]
    private float startY;
    [SerializeField]
    private float startZ;
    [SerializeField]
    private float startR;
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

    float oldY;

    public float jumpForce = 20.0f;
    public static bool getFinish(){
        return finish;
    }

    private void Start() {
        this.transform.position = new Vector3(startX , startY ,startZ);
        this.transform.rotation = new Quaternion(0 , 0 , 0 ,0);
        transform.Rotate(0 , startR ,0);
        Debug.Log(this.transform.rotation.eulerAngles.y);
        oldEulerAngles = this.transform.rotation.eulerAngles;
        zPost = this.transform.localPosition.z;
        angle = this.transform.rotation.y;
        framePerU = 0;
        oldY = startY;
    }

    void Awake(){
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;

        mainCam = Camera.main;
    }


    //Update is called once per frame
        void Update()
        {
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
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        if(RunBlock.getRotating() == true){
        RotatePlayer(RunBlock.getRevs());
        }
        else if(RunBlock.getRunning() == true){
            MovePlayer(RunBlock.getSteps());
        }
        else if(RunBlock.getJumping() == true){
        Jump(1);
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

    public void MovePlayer(float ans){
            if(framePerU == ans * 2.0f * 10.0f){
                RunBlock.setRunning();
                zPost = this.transform.localPosition.z;
                framePerU = 0;
            }else{
             transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
             framePerU++;
            }
    }


    public void RotatePlayer(float ans){
        Debug.Log("Rotating");
        transform.Rotate(0 , ans , 0);
        RunBlock.setRotating();
        Debug.Log(angle);
    }

    public void Jump(float ans){
        // rb.AddForce( Vector3.up * jumpForce , ForceMode.Impulse);
        if(framePerU == ans * 2.0f * 10.0f){
            RunBlock.setJumping();
            framePerU = 0;
        }else{
            transform.Translate(Vector3.up * Time.deltaTime * 9.8f);
            framePerU ++;
        }
    }

}
