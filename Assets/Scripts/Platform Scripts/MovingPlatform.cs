using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
        [SerializeField]
        private Transform movePoint;

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
    }

    void MovePlatform(){
        Debug.Log("2");
        if(can_Move){
            transform.position = Vector3.MoveTowards(transform.position,
            movePoint.position, smoothMovement);

            if(Vector3.Distance(transform.position, movePoint.position) <= halfDistance){
                if(!smoothMovementHalfed){

                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
            }

            if(Vector3.Distance(transform.position, movePoint.position) == 0f){
                can_Move = false;

                if(smoothMovementHalfed){
                    smoothMovement = initailMovement;
                    smoothMovementHalfed = false;
                }

                soundFX.PlayAudio(false);
            }
        }
    }

    public void ActivateMovement(){
        can_Move = true;

        //soundFX.PlayAudio(true);
    }

    private void OnTriggerEnter(Collider target) {
       if(target.CompareTag(Tags.PLAYER_TAG)){
           Invoke("ActivateMovement",timer);
           target.gameObject.transform.parent = transform;
       }
   }
}
