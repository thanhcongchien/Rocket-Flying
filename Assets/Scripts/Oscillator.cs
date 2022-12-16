using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    const float tau = Mathf.PI * 2;
    [SerializeField] Vector3 movementPlatform = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 5f;
    Vector3 startingPos;
    Vector3 offset;
    [Range(0,1)] [SerializeField] float movementFactor;
	// Use this for initialization
	void Start ()
    {
        startingPos = transform.position;
         
	}
	
	// Update is called once per frame
	void Update ()
    {
        Oscillate();
    }

    private void Oscillate()
    {
        if(period <= Mathf.Epsilon)
        {
            print("NaN error");
            return;
        }
        float cycles = Time.time / period;
        float sineWave = Mathf.Sin(cycles * tau);
        movementFactor = sineWave / 2f + 0.5f;
        offset = movementFactor * movementPlatform;
        transform.position = startingPos + offset;
    }
}
