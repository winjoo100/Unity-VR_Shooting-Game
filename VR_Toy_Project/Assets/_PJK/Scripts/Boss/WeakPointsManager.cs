using UnityEngine;

public class WeakPointsManager : MonoBehaviour
{
    public GameObject[] weakpoints;
    private float weakpointhp = 100;

    void Start()
    {
        for (int i = 0; i < weakpoints.Length; i++)
        {

            weakpoints[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (weakpointhp <= 0)
        {
            for(int i = 0; i < 3; i++)
            {
                
                weakpoints[i].SetActive(false);
                weakpoints[i].transform.localScale = new Vector3(1, 1, 1);

            }
        }
    }


    void Onweakpoint()
    {
        for (int i = 0; i < 3; i++)
        {
            int onweak = Random.Range(0, 3);

            weakpoints[onweak].SetActive(true);
        
            if ( i == 0 )
            {
                weakpoints[i].transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }

}
