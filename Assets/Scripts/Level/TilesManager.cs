using TDShooter.enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TDShooter.Level
{
    public class TilesManager : MonoBehaviour
    {
        [SerializeField]
        public Tile_Marker[,] tiles = new Tile_Marker[3, 3];
        private Tile_Marker[] tempArray = new Tile_Marker[3];
        private void Start()
        {
            List<Tile_Marker> list = new();
            list = FindObjectsOfType<Tile_Marker>().ToList();
            list.Sort((x, y) => x.number.CompareTo(y.number));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = list[i * 3 + j];
                    tiles[i, j].Callback += MoveRow;
                }
            }
        }
        private void MoveRow(Tile_Marker number)
        {
            if (number == tiles[0, 1])
            {
                Debug.Log("up");
                ReBuild(Direction.Up);
            }
            if (number == tiles[1, 0])
            {
                Debug.Log("left");
                ReBuild(Direction.Left);
            }
            if (number == tiles[1, 2])
            {
                Debug.Log("right");
                ReBuild(Direction.Right);
            }
            if (number == tiles[2, 1])
            {
                Debug.Log("down");
                ReBuild(Direction.Down);
            }
        }
        private void ReBuild(Direction direction)
        {

            switch (direction)
            {
                case Direction.Up:
                    for (int i = 0; i < 3; i++)
                    {
                        Vector3 newPos = tiles[2, i].transform.position;
                        newPos.z += 30;
                        tiles[2, i].transform.position = newPos;

                        tempArray[i] = tiles[2, i];

                    }
                    RebindArray(Direction.Up);
                    break;
                case Direction.Down:
                    for (int i = 0; i < 3; i++)
                    {
                        Vector3 newPos = tiles[0, i].transform.position;
                        newPos.z -= 30;
                        tiles[0, i].transform.position = newPos;

                        tempArray[i] = tiles[0, i];
                    }
                    RebindArray(Direction.Down);
                    break;
                case Direction.Left:
                    for (int i = 0; i < 3; i++)
                    {
                        Vector3 newPos = tiles[i, 2].transform.position;
                        newPos.x -= 30;
                        tiles[i, 2].transform.position = newPos;

                        tempArray[i] = tiles[i, 2];
                    }
                    RebindArray(Direction.Left);
                    break;
                case Direction.Right:
                    for (int i = 0; i < 3; i++)
                    {
                        Vector3 newPos = tiles[i, 0].transform.position;
                        newPos.x += 30;
                        tiles[i, 0].transform.position = newPos;

                        tempArray[i] = tiles[i, 0];
                    }
                    RebindArray(Direction.Right);
                    break;
                default:
                    break;
            }
        }

        private void RebindArray(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int i = 2; i > 0; i--)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            tiles[i, j] = tiles[i - 1, j];
                        }
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        tiles[0, j] = tempArray[j];
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            tiles[i, j] = tiles[i + 1, j];
                        }
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        tiles[2, j] = tempArray[j];
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 2; j > 0; j--)
                        {
                            tiles[i, j] = tiles[i, j - 1];
                        }
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        tiles[j, 0] = tempArray[j];
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)

                        {
                            tiles[i, j] = tiles[i, j + 1];
                        }
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        tiles[j, 2] = tempArray[j];
                    }
                    break;
                default:
                    break;
            }

        }
    }
}