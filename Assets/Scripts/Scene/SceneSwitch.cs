using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The name of the scene to switch to.")]
    private string name;
    #endregion

    #region Scene Methods
    public void Switch() {
        SceneManager.LoadScene(name);
    }
    #endregion
}
