using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    private RotatingPlatform rotatingPlatform;

    private static bool can_rotate;

    public GameObject waterfall;

    public static bool getcan(){
        return can_rotate;
    }
    // Start is called before the first frame update
    private void Awake() {
       // rotatingPlatform = GetComponentInChildren<RotatingPlatform>();
       
    }
   private void OnTriggerEnter(Collider target) {
       if(target.CompareTag(Tags.PLAYER_TAG)){
           //rotatingPlatform.ActivateRotation();
           can_rotate = true;
           //SetEffect();
           waterfall.SetActive(true);
           Invoke("Deactivate" , 5f);
       }
   }

   private void Deactivate(){
       can_rotate = false;
   }

   private void SetEffect(){
       //waterfall.SetActive(true);
   }
}
