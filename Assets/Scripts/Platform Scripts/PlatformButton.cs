using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    private RotatingPlatform rotatingPlatform;
    // Start is called before the first frame update
    private void Awake() {
        rotatingPlatform = GetComponentInParent<RotatingPlatform>();
    }
   private void OnTriggerEnter(Collider target) {
       if(target.CompareTag(Tags.PLAYER_TAG)){
           rotatingPlatform.ActivateRotation();
       }
   }
}
