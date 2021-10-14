using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Parser : MonoBehaviour
{
    [System.Serializable]
    private class SceneGroup {
        public int id;
        public string name;
        public string defaultScene;
        public string[] scenes;
    }
    [System.Serializable]
    private class JsonToSceneGroup {
        int[] signals; //signals
        public int[] Signals {
            get {
                return signals;
            }
        }
        SceneGroup[] next_SceneGroup; //next scene
        public SceneGroup[] nextSceneGroup {
            get {
                return next_SceneGroup;
            }
        }
    }
    void createMapping() {
        string[] files = Directory.GetFiles(Application.dataPath + Path.PathSeparator + "SceneTransitions");
        foreach (string file in files) {

        }
    }
    public string parse(int signal, string curScene, int Scene = -1) {
        JsonToSceneGroup deserial = JsonUtility.FromJson<JsonToSceneGroup>(Application.dataPath + Path.PathSeparator + "SceneGroupTransitions" + Path.PathSeparator + curScene + ".json");
        for (int index = 0; index < deserial.Signals.Length; index += 1 ) {
            if (deserial.Signals[index] == signal) {
                if (Scene == -1) {
                    return deserial.nextSceneGroup[index].defaultScene;
                } else {
                    return deserial.nextSceneGroup[index].scenes[Scene];
                }
            }
        }
        return null;
    }
}
