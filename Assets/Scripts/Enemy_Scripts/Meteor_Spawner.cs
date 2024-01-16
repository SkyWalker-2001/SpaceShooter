
using System.Collections;
using UnityEngine;

public class Meteor_Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] meteor_Prefabs;
    [SerializeField] private float spawnTime;
    private float timer = 0f;
    private int i;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer > spawnTime){
            i = Random.Range(0, meteor_Prefabs.Length);
            GameObject obj = Instantiate(meteor_Prefabs[i],  new Vector3( Random.Range(maxLeft, maxRight),yPos,-5), Quaternion.Euler(0,0,Random.Range(0,360)));
            float size = Random.Range(0.9f, 1.1f);
            obj.transform.localScale = new Vector3(size,size,1);
            timer = 0;
        }
        
    }

    private IEnumerator SetBoundaries(){
        yield return new WaitForSeconds(0.2f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f,0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f,0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0,1.1f)).y;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
