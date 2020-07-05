using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combining : MonoBehaviour
{
    [SerializeField]
        private Transform movePoint1;

        [SerializeField]
        private Transform movePoint2;

        private Vector3 startPosition;

        [SerializeField]
        private float smoothMovement = 0.3f;
        private float initailMovement;

        private bool smoothMovementHalfed;

        private bool can_Move;
        private bool move_to_Initial;

        [SerializeField]
        private float halfDistance = 15f;

        [SerializeField]
        private bool activateMovementInStart;
        
        [SerializeField]
        private float timer = 1f;

        [SerializeField]
        private string WhichOne;


        private SoundFX soundFX;
    // Start is called before the first frame update
    void Awake() {
        startPosition = transform.position;
        initailMovement = smoothMovement;

        soundFX = GetComponent<SoundFX>();
    }
    void Start(){
        if(activateMovementInStart){
            Invoke("ActivateMovement",timer);
        }
    }

    // Update is called once per frame
    void Update(){
        MovePlatform();
        Move();
    }

    void MovePlatform(){
        if(SeperateButton.now == WhichOne){
            Debug.Log("1");
            transform.position = Vector3.MoveTowards(transform.position,
            movePoint1.position, smoothMovement);

            if(Vector3.Distance(transform.position, movePoint1.position) <= halfDistance){
                if(!smoothMovementHalfed){

                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
            }

            if(Vector3.Distance(transform.position, movePoint1.position) == 0f){
                can_Move = false;

                if(smoothMovementHalfed){
                    smoothMovement = initailMovement;
                    smoothMovementHalfed = false;
                }

                //soundFX.PlayAudio(false);
            }
        }
    }

    private void OnTriggerEnter(Collider target) {
        if(target.CompareTag(Tags.PLAYER_TAG)){
            Debug.Log(can_Move);
            WhichOne = "999";
           can_Move = true;
           target.gameObject.transform.parent = transform;
           Invoke("Deact" , 3f);
       }
   }

    private void  Deact(){
        can_Move = false;
    }
   

   private void Move(){
       if(can_Move){
            transform.position = Vector3.MoveTowards(transform.position,
            movePoint2.position, smoothMovement);

            if(Vector3.Distance(transform.position, movePoint2.position) <= halfDistance){
                if(!smoothMovementHalfed){

                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
            }

            if(Vector3.Distance(transform.position, movePoint2.position) == 0f){
                can_Move = false;

                if(smoothMovementHalfed){
                    smoothMovement = initailMovement;
                    smoothMovementHalfed = false;
                }

                soundFX.PlayAudio(false);
            }
        }
   }

//    public void Deact(){
//        Destroy(gameObject.GetComponent<Seperate>());
//    }]
}
