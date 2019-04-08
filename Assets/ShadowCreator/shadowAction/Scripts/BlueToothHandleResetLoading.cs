using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToothHandleResetLoading : MonoBehaviour {

    private Vector3 loadingPosition = new Vector3(0, 0, 1);

    private MeshRenderer[] meshRenderer;
    // Update is called once per frame
    void LateUpdate () {
        transform.position = SvrManager.Instance.head.TransformPoint(loadingPosition);
        transform.LookAt(SvrManager.Instance.head);
	}

    void OnEnable() {
        if (meshRenderer == null) {
            meshRenderer = GetComponentsInChildren<MeshRenderer>(true);
        }
        foreach (var component in meshRenderer) {
            component.enabled = false;
        }
    }

    void Start() {
        meshRenderer = GetComponentsInChildren<MeshRenderer>(true);
        foreach (var component in meshRenderer) {
            component.enabled = false;
        }
    }
}
