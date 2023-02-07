using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TermiteBehavior;

public class TermiteBehavior : MonoBehaviour
{
  // Start is called before the first frame update
    Direction currentDirection = Direction.Up;
    void Start() {
      currentDirection = Direction.Up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Direction getFacingDirection() {
      return currentDirection;
    }

    public void rotate(Rotation rotation) {
    float degrees = 90.0f * (rotation == Rotation.Clockwise ? -1 : 1);
      transform.Rotate(0.0f, 0.0f, (90.0f * (rotation == Rotation.Clockwise ? -1 : 1)));
      Direction newDirection = determineDirection(currentDirection, rotation);
      Debug.Log($"Rotation complete. rotation: {rotation}, degrees: {degrees}, oldDir: {currentDirection}, newDir: {newDirection}");
            currentDirection = newDirection;

      }

  public void move(Direction direction, float distance) {
    Debug.Log("Moving (" + distance + ")" + " in direction " + direction);
    
    Vector3 movement;
    switch (currentDirection) {
      case Direction.Up:
        movement = new Vector3(
          transform.position.x,
          transform.position.y + distance);
        break;
      case Direction.Right:
        movement = new Vector3(
          transform.position.x + distance,
          transform.position.y);
        break;
      case Direction.Down:
        movement = new Vector3(
          transform.position.x,
          transform.position.y - distance);
        break;
        case Direction.Left:
          movement = new Vector3(
            transform.position.x - distance,
            transform.position.y);
        break;
        default:
          movement = new Vector3();
          break;
      }
      transform.position = movement;
    }

    // assumes 90 degree rotation
    static Direction determineDirection(Direction currentDirection, 
      Rotation rotation) {
      switch (currentDirection) {
        case Direction.Up:
          return rotation == Rotation.Clockwise
            ? Direction.Right : Direction.Left;
        case Direction.Right:
          return rotation == Rotation.Clockwise
            ? Direction.Down : Direction.Up;
        case Direction.Down:
          return rotation == Rotation.Clockwise
            ? Direction.Left : Direction.Right;
        case Direction.Left:
          return rotation == Rotation.Clockwise
            ? Direction.Up : Direction.Down;
        default:
          return currentDirection;
    }
    }

    public void move(Rotation rotation) {
      transform.Rotate(0.0f, 0.0f,
        90.0f * ((rotation == Rotation.Counterclockwise) ? -1 : 1));
    }

  public enum Rotation {
      Counterclockwise,
      Clockwise,
  }

  public enum Direction {
    Up,
    Right,
    Left,
    Down
  }
}
