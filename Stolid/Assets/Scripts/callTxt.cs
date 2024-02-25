using UnityEngine;
using UnityEngine.Events;

public class callTxt : MonoBehaviour
{
    public txt text;
    public string[] givenLines; 
    public Sprite[] givenChars;
    public UnityEvent givenAfterTxt;

    public void callStart(){
        
        text.startTxt(givenLines,givenChars,givenAfterTxt);
    }
}
