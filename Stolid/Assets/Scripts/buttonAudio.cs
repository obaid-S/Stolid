
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonAudio : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource src;
    public AudioClip select,hover;
    public audioCaller audioCaller;

    //for mute
    public GameObject trigger;

    void Start(){
        try{
            trigger.GetComponent<Toggle>().isOn=SceneManagerScript.muted;
        }catch{}//if it is the mute button do that
    }

    
    public void OnClick()
    {
        audioCaller.playClip(src, select);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioCaller.playClip(src, hover);
    }

    
}
