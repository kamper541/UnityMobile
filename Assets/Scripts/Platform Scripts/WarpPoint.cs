using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform TheEnd;
  
    private void OnTriggerEnter(Collider target) {
       if(target.CompareTag(Tags.PLAYER_TAG)){
           target.gameObject.transform.position = TheEnd.position;
       }
   }
}
