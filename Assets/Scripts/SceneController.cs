using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
    public static readonly Color DEFAULT_COLOR_1 = Color.black;
    public static readonly Color DEFAULT_COLOR_2 = Color.white;
    public static readonly Color DEBUG_COLOR_1 = Color.magenta;
    public static readonly float DEFAULT_UPDATE_INTERVAL = 1.0f;
    [SerializeField]
    TermiteBehavior termite;
    [SerializeField]
    ReferenceTile  referenceTile;
    [SerializeField]
    Color color1 = DEFAULT_COLOR_1;
    [SerializeField]
    Color color2 = DEFAULT_COLOR_2;
    [SerializeField]
    float updateInterval = DEFAULT_UPDATE_INTERVAL;

    float timeCounter;
    void Start() {
    timeCounter = 0.0f;
    // generate tiles?
    // set all tiles to color1
    Vector2 position = referenceTile.getPosition();
    spawnTile(color2, position);
  }

    void Update() {
      timeCounter += Time.deltaTime;
      if (timeCounter > updateInterval) {
        timeCounter -= updateInterval;
        doUpdate();
      }
    }

    private void doUpdate() {
      if (_isTurning) {
        termite.rotate(TermiteBehavior.Rotation.Clockwise);
      } else {
        termite.move(termite.getFacingDirection(),
          referenceTile.getWidth());
        spawnTile(color2, termite.getGridPosition());
    }
      _isTurning = !_isTurning;
    }

  bool _isTurning = false;

  private void spawnTile(Color color,(int x, int y) gridPosition) {
    if (referenceTile != null) {
      Vector2 position =
        new Vector2(
          referenceTile.getPosition().x + gridPosition.x * referenceTile.getWidth(),
          referenceTile.getPosition().y + gridPosition.y * referenceTile.getHeight()
        );
      spawnTile(color, position);
    }
  }

  private void spawnTile(Color color, Vector2 position) {
      if (referenceTile != null) {
        Tile newTile = referenceTile.createTile();
        newTile.transform.position = position;
        newTile.setColor(DEBUG_COLOR_1);
        newTile.makeVisible();
      }
  }
}
