using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;


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
        DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(JsonToScene));
        FileStream f = new FileStream(Application.dataPath  + "/SceneGroupTransitions" + "/" + curScene + ".json", FileMode.OpenOrCreate);
        JsonToScene deserial = null;
        if (f.Length > 0) {
            deserial = (JsonToScene) jsonSer.ReadObject(f);
            for (int index = 0; index < deserial.signals.Length; index += 1 ) {
                if (deserial.signals[index] == signal) {
                    return deserial.next_Scene.scene;
                }
            }
            return null;
        }
        return null;
    }
}
