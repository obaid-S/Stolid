using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;



public class txt : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Movement movement;

    private string[] lines;
    public Image imgBox;
    private Sprite[] chars;
    public float txtSpeed;
    public GameObject box;


    private int index;

    private UnityEvent afterTxt;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")){
            if (textComponent.text==(lines[index]+"\n\n(Press ENTER To Continue)")){
                NextLine();
            }else{
                StopAllCoroutines();
                textComponent.text=lines[index]+"\n\n(Press ENTER To Continue)";
            }
        }

    }

    public void startTxt(string[]givenLines, Sprite[]givenChars, UnityEvent givenAfterTxt){
        movement.allowMove=false;
        lines=givenLines;
        chars=givenChars;
        afterTxt=givenAfterTxt;

        box.SetActive(true);
        index=0; 
        imgBox.sprite=chars[index];
        textComponent.text=string.Empty;
        StartCoroutine(Typeline());
    }//rests txt starts

    IEnumerator Typeline(){//types one char at time
        foreach(char c in (lines[index]+"\n\n(Press ENTER To Continue)").ToCharArray()){ 
             textComponent.text+=c;
             yield return new WaitForSeconds(txtSpeed); 
        }
    }
    
    void NextLine(){//checks if all lines r shown, dispaers if yes
        if(index < lines.Length -1){
            index++;
            textComponent.text=string.Empty;
            imgBox.sprite=chars[index];
            StartCoroutine(Typeline());
        }else{
            box.SetActive(false);
            movement.allowMove=true;
            afterTxt.Invoke();
            
        }
    }

}
