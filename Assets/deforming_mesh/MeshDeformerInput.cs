using UnityEngine;

public class MeshDeformerInput : MonoBehaviour {
	
	public float force = 10f;
	public float forceOffset = 0.1f;
	Camera cam;
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput(0);
		}
		if (Input.GetMouseButton(1)) {
			HandleInput(1);
		}
	}

	void Start()
    {
        cam = GetComponent<Camera>();
    }


	void HandleInput (int mousebutton) {
		Ray inputRay = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(inputRay, out hit)) {
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
			if (deformer) {
				Vector3 point = hit.point;
				if (mousebutton == 0) {
					point += hit.normal * forceOffset;
				} else {
					point += hit.normal * forceOffset *-1;
				}
				deformer.AddDeformingForce(point, force);
			}
		}
	}
}