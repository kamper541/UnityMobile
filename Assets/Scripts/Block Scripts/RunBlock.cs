using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections.Generic;

public class RunBlock : MonoBehaviour
{
    private static bool running = false;
    private static bool rotating = false;
    private static bool Activated = false;

    private static InputField stepsI;

    private static int steps;

    private static InputField revsI;

    private static int revs;

    public static InputField getStepsI(){
        return stepsI;
    }

    public static InputField getRevsI(){
        return revsI;
    }

    public static int getSteps(){
        return steps;
    }

    public static int getRevs(){
        return revs;
    }

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

    public void click(){ 
        StartCoroutine(takeAction());
    }

    public IEnumerator takeAction(){
        Debug.Log("clicked");
        if(!Activated){
        Activated = true;
        GameObject[] panel = GameObject.FindGameObjectsWithTag("BlockCode");
        //LinkedList<Button> buttons = new LinkedList<Button>(panel);
        for(int i = 0 ; i < panel.Length ; i++){
            //Debug.Log(i);
        if(panel[i].name == "Run(Clone)"){
            stepsI = panel[i].GetComponentInChildren<InputField>();
            steps = int.Parse(stepsI.text);
            running = true;
            yield return new WaitWhile(() => running == true);
            stepsI = null;
            Debug.Log(running);
            
        }else if(panel[i].name == "Rotate(Clone)"){
            revsI = panel[i].GetComponentInChildren<InputField>();
            revs = int.Parse(revsI.text);
            rotating = true;
            yield return new WaitWhile(() => rotating == true);
            revsI = null;
            Debug.Log(rotating);
        }else if(panel[i].name == "Wait(Clone)"){
            yield return new WaitForSeconds(5f);
        }
        }
        panel = null;
        Activated = false;
        }else{

        }
    }
}
