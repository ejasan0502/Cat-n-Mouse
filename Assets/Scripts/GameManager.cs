using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject resetBtn;

    private static Object _lock = new Object();
    private static GameManager _instance;
    public static GameManager instance {
        get {
            lock(_lock){
                if ( _instance == null ) _instance = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            }
            return _instance;
        }
    }

    public void Reset(){
        Application.LoadLevel(0);
        if ( resetBtn != null ) resetBtn.SetActive(false);
    }

    public void DisplayReset(){
        if ( resetBtn != null ) {
            resetBtn.SetActive(true);
            resetBtn.transform.GetChild(0).GetComponent<Text>().text = "Play again?";
        }
    }

    public void Victory(){
        if ( resetBtn != null ) {
            resetBtn.SetActive(true);
            resetBtn.transform.GetChild(0).GetComponent<Text>().text = "Victory! Play again?";
        }
    }
}
