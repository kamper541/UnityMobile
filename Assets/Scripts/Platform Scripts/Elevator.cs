using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform moving;

    [SerializeField]
    private string whatToDo;

    [SerializeField]
    private float height;

    private bool can_move;
    void Start()
    {
        //setMove();
    }

    // Update is called once per frame
    void Update()
    {
        LetMove();
    }

    void LetMove(){
        if(can_move) {
            moving.Translate(Vector3.up * Time.deltaTime * 1.0f);
        }
    }

    void setMove(){
        can_move = true;

        Invoke("StopMoving" , height);
    }

    void StopMoving(){
        can_move = false;
    }

    private void OnTriggerEnter(Collider target) {
       if(target.CompareTag(Tags.PLAYER_TAG)){
           setMove();
           
       }
   }
}
