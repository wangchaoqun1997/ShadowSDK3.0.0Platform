using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AScene {
    public Scene scene;
    public string path;
    public string title;
    public string info;
    public int buildIndex;


    public AScene(string _path, string _title = "", string _info = "") {
        buildIndex = SceneUtility.GetBuildIndexByScenePath(_path);
        if (buildIndex == -1) {
            Debug.LogError("buildInde == -1 ; Scene not exist or not build");
            return;
        }
        scene = SceneManager.GetSceneByBuildIndex(buildIndex);
        if (scene == null) {
            title = "Can not Find";
            info = "Can not Find Scene:"+_path;
            Debug.LogError("Can not find Scene:" + _path);
            return;
        }
        
        path = _path;
        if (_title != "") {
            title = _title;
        } else {
            title = scene.name;
        }
        if (_info != "") {
            info = _info;
        } else {
            info = "Please Add Information";
        }

    }

    public void LoadSceneAsync() {
        SceneManager.LoadSceneAsync(buildIndex);
    }
}