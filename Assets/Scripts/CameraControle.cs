using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour {

    public Transform alvo;      //Quem a camera segue
    public float velocidade;    //Com qual velocidade a camera segue

    public float minX = -9999;
    public float maxX = 9999;
    public float minY = -9999;
    public float maxY = 9999;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (alvo != null)
        {
            var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
        }

        //Limite
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            var alcanceHorizontal = camera.orthographicSize * Screen.width / Screen.height;

            var realMinX = minX + alcanceHorizontal;
            var realMaxX = maxX - alcanceHorizontal;

            x = Mathf.Clamp(x, realMinX, realMaxX);
            y = Mathf.Clamp(y, minY, maxY);

            transform.position = new Vector3(x, y, z);
        }
    }
}
