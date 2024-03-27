using UnityEngine;

public class audioCaller : MonoBehaviour
{
    public AudioSource src;
    public float audioLvl;
    
    void Start(){
        src.Play();
    }

    void Update(){
        if(SceneManagerScript.muted){
            src.volume=0;
        }else if(!SceneManagerScript.muted){
            src.volume=audioLvl;

        }
    }

    public void playClip(AudioSource thisSource, AudioClip clip){
        if(!SceneManagerScript.muted){
            thisSource.PlayOneShot(clip);
        }
    }
    
}
