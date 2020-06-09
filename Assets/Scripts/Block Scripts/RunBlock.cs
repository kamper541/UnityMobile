using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RunBlock : MonoBehaviour
{
    private static bool running = false;
    private static bool rotating = false;

    private static bool Activated = false;
    public static bool getRunning(){
        return running;
    }

    public static bool getRotating(){
        return rotating;
    }

    public static bool getAct(){
        return Activated;
    }

    public static void setRunning(){
        running = false;
    }
    public static void setRotating(){
        rotating = false;
    }

    public static void setActivate(){
        Activated = false;
    }

    void click(){ 
        StartCoroutine(takeAction());
    }

    public IEnumerator takeAction(){
        Button[] panel = GameObject.FindWithTag("Drop").GetComponentsInChildren<Button>();
        LinkedList<Button> buttons = new LinkedList<Button>(panel);
        for(int i = 0 ; i < panel.Length ; i++){
            Debug.Log(i);
        if(panel[i].name == "Run(Clone)"){
            running = true;
            Activated = true;
            yield return new WaitWhile(() => running == true);
            Debug.Log(running);
            
        }else if(panel[i].name == "Rotate(Clone)"){
            rotating = true;
            Activated = true;
            yield return new WaitWhile(() => rotating == true);
            Debug.Log(rotating);
        }else{
            //yield return new WaitForSecondsRealtime(2);
            
        }
        }
    }
}
