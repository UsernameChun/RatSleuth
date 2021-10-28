using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Parser : MonoBehaviour
{
    [System.Serializable]
    private class Scene {
        public int id;
        public string name;

        public string scene;
    }
    [System.Serializable]
    private class JsonToScene {
        public int[] signals; //signals
        public Scene next_Scene; //next scene
    }
    void createMapping() {
        string[] files = Directory.GetFiles(Application.dataPath + Path.PathSeparator + "SceneTransitions");
        foreach (string file in files) {
            
        }
    }
    public string parse(int signal, string curScene, int Scene = -1) {
        JsonToScene deserial = JsonUtility.FromJson<JsonToScene>(Application.dataPath + Path.PathSeparator + "SceneGroupTransitions" + Path.PathSeparator + curScene + ".json");
        for (int index = 0; index < deserial.signals.Length; index += 1 ) {
            if (deserial.signals[index] == signal) {
                return deserial.next_Scene.scene;
            }
        }
        return null;
    }
}
