using UnityEngine;

public class Camera_Scroll : MonoBehaviour {

    public GameObject mario;
    public float leftbound;
    public float rightbound;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - mario.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = mario.transform.position + offset;
        Mathf.Clamp(transform.position.x, leftbound, rightbound);
	}
}
