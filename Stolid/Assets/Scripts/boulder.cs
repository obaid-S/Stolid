
using System.Collections;
using UnityEngine;

public class boulder : MonoBehaviour
{
    public shooter shooter;
    public Movement movement;
    private bool shootNow=true;
    public bool drop=false;
    private bool dropped=false;

    public GameObject fallingBoulder;
    public GameObject fallingBoulderTwo;
    public GameObject dustPrefab;

    



    

    

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(rockLoop());

    }

    void Update(){
        if(Input.GetKeyUp("i") & !dropped){
            shootNow=false;
            StopAllCoroutines();
            StartCoroutine(test());
        }
        
        
    }
    IEnumerator rockLoop(){
        while(shootNow){
            shooter.fire();
            yield return new WaitForSeconds(.3f/movement.speedMulti);
        }         
    }
    
    IEnumerator test(){
        yield return new WaitForSeconds(.3f);
        shootNow=true;
        StartCoroutine(rockLoop());
    }

    public void dropRocks(){
        StopAllCoroutines();
        dropped=true;
        StartCoroutine(dropBoulder());

        
    }
    IEnumerator dropBoulder(){
        var temp=0;

        while(temp<130){
            fallingBoulder.transform.position=Vector2.MoveTowards(fallingBoulder.transform.position,new Vector2(5,4.4f),Time.deltaTime*Mathf.Pow(2,temp/15));
            if (temp%3==0 || temp>120){
                var dust=Instantiate(dustPrefab,new Vector3(fallingBoulder.transform.position.x+Random.Range(-2,2),fallingBoulder.transform.position.y-Random.Range(0,3),0),fallingBoulder.GetComponent<Transform>().rotation);
                dust.SetActive(true);
            }
            temp++;
            yield return null;

        }
        while(temp<260){
            fallingBoulderTwo.transform.position=Vector2.MoveTowards(fallingBoulderTwo.transform.position,new Vector2(5,4f),Time.deltaTime*Mathf.Pow(2,(temp-90)/15));
            if (temp%3==0 || (temp-130)>120){
                var dust=Instantiate(dustPrefab,new Vector3(fallingBoulderTwo.transform.position.x+Random.Range(-2,3),fallingBoulderTwo.transform.position.y-Random.Range(0,3),0),fallingBoulderTwo.GetComponent<Transform>().rotation);
                dust.SetActive(true);
            }
            temp++;
            yield return null;
        }
        dropped=true;
            
    }
  
}
