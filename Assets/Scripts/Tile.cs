using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
  {
  // Start is called before the first frame update
    [SerializeField]
    Color color = SceneController.DEFAULT_COLOR_1;
    public void setColor(Color color) {
      SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
      sr.color = color;
    }
  
    public void onCreate() {
    Debug.Log("Created new tile with color [" + color + "] at position ["
       + transform.position + "]");
    }

    public void makeVisible() {
      SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
      sr.enabled = true;
      gameObject.SetActive(true);
    }
}
