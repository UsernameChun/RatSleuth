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
        int[] signals; //signals
        public int[] Signals {
            get {
                return signals;
            }
        }
        Scene next_Scene; //next scene
        public Scene nextScene {
            get {
                return next_Scene;
            }
        }
    }
    void createMapping() {
        string[] files = Directory.GetFiles(Application.dataPath + Path.PathSeparator + "SceneTransitions");
        foreach (string file in files) {

        }
    }
    public string parse(int signal, string curScene, int Scene = -1) {
        JsonToScene deserial = JsonUtility.FromJson<JsonToScene>(Application.dataPath + Path.PathSeparator + "SceneGroupTransitions" + Path.PathSeparator + curScene + ".json");
        for (int index = 0; index < deserial.Signals.Length; index += 1 ) {
            if (deserial.Signals[index] == signal) {
                return deserial.nextScene.scene;
            }
        }
        return null;
    }
}
