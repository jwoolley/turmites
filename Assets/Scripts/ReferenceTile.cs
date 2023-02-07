using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceTile : Tile
{
    // Start is called before the first frame update
    private Vector2 dimensions;
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  public Vector2 getPosition() {
    return transform.position;
  }

  public Vector2 getDimensions() {
    // NOTE: for some reason, precalculating this 
    //       returns (0,0). So calculate every time until
    //       I can figure out why
      SpriteRenderer sr = GetComponent<SpriteRenderer>();
      dimensions = new Vector2(sr.bounds.size.x, sr.bounds.size.y);

    return dimensions;
  }

  public float getWidth() {
    return getDimensions().x;
  }
  public float getHeight() {
    return getDimensions().y;
  }

  public Tile createTile() {
    Tile tile = GameObject.Instantiate(this);
    Destroy(tile.GetComponent<ReferenceTile>());
    tile.onCreate();
    return tile;
  }
}
